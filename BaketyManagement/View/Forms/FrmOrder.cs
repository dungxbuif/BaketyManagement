
using BaketyManagement.DataModels;
using BaketyManagement.DTO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp13212.Models;

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
                            exp = Convert.ToDateTime(cake.ExpCake).ToString("dd/MM/yyyy")
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
                            exp = Convert.ToDateTime(cake.ExpCake).ToString("dd/MM/yyyy")
                        };
            var totalMoney = 0;
            foreach(var item in query.ToList())
            {
                totalMoney += Convert.ToInt32(item.amount) * Convert.ToInt32(item.price);
            }
            txtTotalMoney.Text = totalMoney.ToString();
            dgvBill.DataSource = query.ToList();
            dgvBill.Columns[0].HeaderText = "Ma";
            dgvBill.Columns[1].HeaderText = "Ten banh";
            dgvBill.Columns[2].HeaderText = "Gia";
            dgvBill.Columns[3].HeaderText = "So Luong";
            dgvBill.Columns[4].HeaderText = "Kich co";
            dgvBill.Columns[5].HeaderText = "Han dung";
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
            timTheoTen(txtSearchCake.Text);
        }

      /*  private SearchCakeByCakeName()*/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCakeToBill();
        }

        private void AddCakeToBill()
        {
            try
            {
                validateAddCake();
                if (idBill == 0)
                    createBill();
                createBillDetailAndUpdateCake();
                LoadCake();
                LoadBill();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
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
        private void timTheoTen(string ten)
        {
            if (ten == "")
            {
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
                            exp = Convert.ToDateTime(cake.ExpCake).ToString("dd/MM/yyyy")
                        };
            if (query.Count() <= 0)
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
        private void tim(string ten)
        {
            if (ten == "") {
                MessageBox.Show("Hãy nhập tên bánh");
                return;
            }
            var query = from cake in db.Cakes
                        join recipe in db.Recipes
                        on cake.IdRecipe equals recipe.IdRecipe
                        join category in db.Categories
                        on recipe.IdCategory equals category.IdCategory
                        where category.NameCategory.ToLower().Contains(ten.ToLower())
                        select new
                        {
                            IdCake = cake.IdCake,
                            name = recipe.NameCake,
                            price = cake.Price,
                            amount = cake.Amount,
                            size = cake.Size,
                            exp = Convert.ToDateTime(cake.ExpCake).ToString("dd/MM/yyyy")
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
            }
            else
            {
                MessageBox.Show("Không có hóa đơn nào cần thanh toán!", "Thông báo");
            }
        }

        private void Pay()
        {
                Single totalMoney = Convert.ToSingle(txtTotalMoney.Text);
                Single discount = Convert.ToSingle(txtDiscount.Text);
                Single returnMoney = 0;
                Single totalAfterDiscount = 0;
                var bill = db.Bills.Where(b => b.IdBill == idBill).FirstOrDefault();
                if (discount > 0)
                {
                    totalAfterDiscount = totalMoney - totalMoney * discount / 100;
                    bill.Discount = discount;
                }
                else
                {
                    bill.Discount = 0;
                    totalAfterDiscount = totalMoney;
                }
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "Output.pdf";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;
                            MessageBox.Show("Không thể in dữ liệu." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<h1>TIEM BANH CAU DIEN</h1>");
                            sb.Append("<div>455 Cau Dien,<br /> Bac Tu Liem, Ha Noi</div>");
                            sb.Append("<div>(+84) 698-888-888</div>");
                            sb.Append("<div>Ngay in: " + DateTime.Now.ToString("dd/MM/yyyy") + "</div>");
                            sb.Append("<div>Noi dung: Hoa don ban hang</div>");
                            sb.Append("<div><br></div>");
                            PdfPTable pdfTable = new PdfPTable(dgvBill.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            StringBuilder sbTotalMoney = new StringBuilder();
                            sbTotalMoney.Append("<div style='text-align: right'><b>Tong tien: "+ totalMoney + "</b></div>");
                            foreach (DataGridViewColumn column in dgvBill.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvBill.Rows)
                            {
                                string cell1 = row.Cells[0].Value.ToString();
                                pdfTable.AddCell(cell1);
                                string cell2 = row.Cells[1].Value.ToString();
                                pdfTable.AddCell(cell2);
                                string cell3 = row.Cells[2].Value.ToString();
                                pdfTable.AddCell(cell3);
                                string cell4 = row.Cells[3].Value.ToString();
                                pdfTable.AddCell(cell4);
                                string cell5 = row.Cells[4].Value.ToString();
                                pdfTable.AddCell(cell5);
                                string cell6 = row.Cells[5].Value.ToString();
                                pdfTable.AddCell(cell6);
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                StringReader sr = new StringReader(sb.ToString());
                                StringReader srTotal = new StringReader(sbTotalMoney.ToString());
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                htmlparser.Parse(sr);
                                pdfDoc.Add(pdfTable);
                                htmlparser.Parse(srTotal);
                                pdfDoc.Close();
                                stream.Close();
                            }
                            MessageBox.Show("In hóa đơn thành công !!!", "Info");
                        }
                    }
                else
                {
                    MessageBox.Show("No Record To Export !!!", "Info");
                }

                dgvBill.DataSource = null;
                db.SaveChanges();
                idBill = 0;
                MessageBox.Show("Thanh toán thành công");
             
        }

    }
}
