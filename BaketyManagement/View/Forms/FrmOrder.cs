
using BaketyManagement.DataModels;
using BaketyManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaketyManagement.View
{
    public partial class FrmOrder : Form
    {   
        private BakeryManagementContext db = BakeryManagementContext.Instance;
        private Int32 rowDgvCake = 0;
        private Int32 idBill = 0;
        public FrmOrder()
        {
            InitializeComponent();
            //InitGraphic(); 
            //DisableButton();
        }

        private void FrmOrder_Load(object sender, EventArgs e)
        {
            LoadCake(); 
        }
       
        private void LoadCake()
        {
            var query = from cake in db.Cakes
                        where cake.Amount > 0
                        join recipe in db.Recipes
                        on cake.IdRecipe equals recipe.IdRecipe
                        select new 
                        {
                            IdCake = cake.IdCake,
                            name = recipe.NameCake,
                            price = cake.Price,
                            amount = cake.Amount,
                            size = cake.Size,
                            exp = (DateTime)cake.ExpCake
                        };
            dgvCake.DataSource = query.ToList();
            dgvCake.Columns[0].HeaderText = "Mã";
            dgvCake.Columns[1].HeaderText = "Tên bánh";
            dgvCake.Columns[2].HeaderText = "Giá";
            dgvCake.Columns[3].HeaderText = "Số lượng còn";
            dgvCake.Columns[4].HeaderText = "Kích cỡ";
            dgvCake.Columns[5].HeaderText = "Hạn dùng";
        }

        private void LoadBill()
        {
            var query = from bill in db.BilDetails
                        where bill.IdBill == idBill
                        join cake in db.Cakes
                        on bill.IdCake equals cake.IdCake
                        select new
                        {
                            IdCake = cake.IdCake,
                            name = (from recipe in db.Recipes
                                   where recipe.IdRecipe == cake.IdRecipe
                                   select recipe.NameCake).FirstOrDefault(),
                            price = cake.Price,
                            amount = bill.AmountOrder,
                            size = cake.Size,
                            exp = (DateTime)cake.ExpCake
                        };
            var totalMoney = 0;
            foreach(var item in query.ToList())
            {
                totalMoney += Convert.ToInt32(item.amount) * Convert.ToInt32(item.price);
            }
            txtTotalMoney.Text = totalMoney.ToString();
            dgvBill.DataSource = query.ToList();
            dgvBill.Columns[0].HeaderText = "Mã";
            dgvBill.Columns[1].HeaderText = "Tên bánh";
            dgvBill.Columns[2].HeaderText = "Giá";
            dgvBill.Columns[3].HeaderText = "Số lượng còn";
            dgvBill.Columns[4].HeaderText = "Kích cỡ";
            dgvBill.Columns[5].HeaderText = "Hạn dùng";
        }
        private void btnAll_Click(object sender, EventArgs e)
        {
            LoadCake();
        }

        private void dgvCake_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowDgvCake = e.RowIndex;
            if (rowDgvCake >= 0)
            {
                txtNameCake.Text = dgvCake.Rows[rowDgvCake].Cells[1].Value.ToString();
                numAmountOrder.Value = 0;
                txtNameCake.Tag = dgvCake.Rows[rowDgvCake].Cells[0].Value;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            tim(txtSearchCake.Text);
        }

      /*  private SearchCakeByCakeName()*/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCakeToBill();
        }

        private void AddCakeToBill()
        {
           
                validateAddCake();
                if(idBill == 0)
                    createBill();
                createBillDetailAndUpdateCake();
                LoadCake();
                LoadBill();
        }
        private void createBillDetailAndUpdateCake()
        {
            var cake = db.Cakes.Where(c => c.IdCake == Int32.Parse(txtNameCake.Tag.ToString())).FirstOrDefault();
            cake.Amount = cake.Amount - Convert.ToInt32(numAmountOrder.Value);
            
            var selectedCake = db.BilDetails.Where(b => b.IdCake == cake.IdCake && b.IdBill == idBill).FirstOrDefault();
            if(selectedCake != null)
            {
                selectedCake.AmountOrder += Convert.ToInt32((int)numAmountOrder.Value);
            }
            else
            {
                var billDetail = new BilDetail();
                billDetail.IdCake = cake.IdCake;
                billDetail.AmountOrder = Convert.ToInt32(numAmountOrder.Value);
                billDetail.IdBill = idBill;
                db.BilDetails.Add(billDetail);
            }
            
            db.SaveChanges();
        }
        private void createBill()
        {
            var query = db.Bills.Select(c => c);
            var count = query.Count() + 1;
            var bill = new Bill();
            bill.IdBill = count;
            bill.IdStaff = MainDto.accountDto.IdStaff;
            bill.ExportDate = DateTime.Now;
            db.Bills.Add(bill);
            db.SaveChanges();
            idBill = count;
        }

        private void validateAddCake()
        {
            if (txtNameCake.Text == "")
                throw new Exception("Vui lòng chọn bánh");
            Int32 amount = Convert.ToInt32(numAmountOrder.Value);
            if (amount <= 0)
            {
                throw new Exception("Số lượng mua hàng phải lớn 0!");
            }
            txtTotalMoney.Text = "0";
            txtCustomerMoney.Text = "0";
            txtReturnMoney.Text = "0";

            var query = db.Cakes.Where(c => c.IdCake == Int32.Parse(txtNameCake.Tag.ToString())).FirstOrDefault();
            var amountCake = Convert.ToInt32(query.Amount);
            if (amountCake < Int32.Parse(numAmountOrder.Value.ToString()))
                throw new Exception("Số lượng mua phải nhỏ hơn số lượng có");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(dgvBill.Rows.Count == 0) return;
            var billdetail = db.BilDetails.Where(b => b.IdBill == idBill);
                   
            foreach(var item in billdetail.ToList())
            {
                var cake = db.Cakes.Where(c=>c.IdCake == item.IdCake).FirstOrDefault();
                cake.Amount += item.AmountOrder;
                db.BilDetails.Remove(item);
            }

            db.SaveChanges();
            LoadCake();
            LoadBill();
        }
        private void tim(string ten)
        {
            if (ten == "") {
                MessageBox.Show("Hãy nhập tên bánh");
                return;
            }
            var query = from cake in db.Cakes
                        join recipe in db.Recipes
                        on cake.IdRecipe equals recipe.IdRecipe
                        where recipe.NameCake.ToLower().Contains(ten.ToLower())
                        select new
                        {
                            IdCake = cake.IdCake,
                            name = recipe.NameCake,
                            price = cake.Price,
                            amount = cake.Amount,
                            size = cake.Size,
                            exp = (DateTime)cake.ExpCake
                        };
            if(query.Count() <= 0)
            {
                MessageBox.Show("Không có tên bánh cần tìm");
                return;
            }
            dgvCake.DataSource = query.ToList();
            dgvCake.Columns[0].HeaderText = "Mã";
            dgvCake.Columns[1].HeaderText = "Tên bánh";
            dgvCake.Columns[2].HeaderText = "Giá";
            dgvCake.Columns[3].HeaderText = "Số lượng còn";
            dgvCake.Columns[4].HeaderText = "Kích cỡ";
            dgvCake.Columns[5].HeaderText = "Hạn dùng";
        }
        private void btnCookies_Click(object sender, EventArgs e)
        {
            tim("Bánh quy");
        }

        private void btnMoonCake_Click(object sender, EventArgs e)
        {
            tim("Bánh trung thu");
        }

        private void btnGato_Click(object sender, EventArgs e)
        {
            tim("Bánh gato");
        }

        private void btnBread_Click(object sender, EventArgs e)
        {
            tim("Bánh my");
        }

        private void btnQuickBread_Click(object sender, EventArgs e)
        {
            tim("Đồ ăn nhanh");
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            changeTotalAfterDiscount();
        }

        private void txtTotalMoney_TextChanged(object sender, EventArgs e)
        {
            changeTotalAfterDiscount();
        }

        private void changeTotalAfterDiscount()
        {
            try
            {
                Single total = Convert.ToSingle(txtTotalMoney.Text);
                Single discount = Convert.ToSingle(txtDiscount.Text);
                if (discount < 0)
                {
                    throw new Exception("Giảm giá phải lớn hơn hoặc bằng 0!");
                }
                if (discount != 0)
                {
                    txtTotalMoneyAfterDiscount.Text = (total - total * discount / 100).ToString();
                    txtDiscount.Text = discount.ToString();
                }
                else
                {
                    txtTotalMoneyAfterDiscount.Text = txtTotalMoney.Text;
                    txtDiscount.Text = discount.ToString();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            Single totalMoney = Convert.ToSingle(txtTotalMoney.Text);
            if (totalMoney > 0)
            {
                Pay();
                txtTotalMoney.Text = "0";
                txtDiscount.Text = "0";
                txtTotalMoneyAfterDiscount.Text = "0";
                txtCustomerMoney.Text = "0";
                txtReturnMoney.Text = "0";
            }
            else
            {
                MessageBox.Show("Không có hóa đơn nào cần thanh toán!", "Thông báo");
            }
        }

        private void Pay()
        {
            try
            {
                Single totalMoney = Convert.ToSingle(txtTotalMoney.Text);
                Single discount = Convert.ToSingle(txtDiscount.Text);
                Single customerMoney = Convert.ToSingle(txtCustomerMoney.Text);
                Single returnMoney = 0;
                Single totalAfterDiscount = 0;
                var bill = db.Bills.Where(b => b.IdBill == idBill).FirstOrDefault();
                if (customerMoney <= 0)
                {
                    throw new Exception("Số tiền khách hàng thanh toán ít hơn số tiền phải trả!");
                }
                if (discount > 0)
                {

                    if (customerMoney < totalMoney - totalMoney * discount / 100)
                    {
                        throw new Exception("Số tiền khách hàng thanh toán ít hơn số tiền phải trả!");
                    }
                    txtReturnMoney.Text = Convert.ToString(customerMoney - (totalMoney - totalMoney * discount / 100));
                    returnMoney = customerMoney - (totalMoney - totalMoney * discount / 100);
                    totalAfterDiscount = totalMoney - totalMoney * discount / 100;
                    bill.Discount = discount;
                }
                else
                {
                    if (customerMoney < totalMoney)
                    {
                        throw new Exception("Số tiền khách hàng thanh toán ít hơn số tiền phải trả!");
                    }
                    txtReturnMoney.Text = Convert.ToString(customerMoney - totalMoney);
                    returnMoney = customerMoney - totalMoney;
                    totalAfterDiscount = totalMoney;
                }
                dgvBill.DataSource = null;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
