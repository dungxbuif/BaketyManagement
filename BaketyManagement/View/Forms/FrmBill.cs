
using BaketyManagement.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaketyManagement.View.Forms
{
    public partial class FrmBill : Form
    {
        BakeryManagementContext db = new BakeryManagementContext();
        Int32 rowDgvBill = 0;
        public FrmBill()
        {
            InitializeComponent();
        }

        private void FrmBill_Load(object sender, EventArgs e)
        {
            LoadTabBill();
        }
        private void LoadTabBill()
        {
            var query = from hd in db.Bills
                        select new
                        {
                            hd.IdBill,
                            hd.ExportDate,
                            nameStaff = (from nv in db.staff
                            where nv.IdStaff == hd.IdStaff
                            select nv.NameStaff).FirstOrDefault(),
                            hd.Discount,
                            TongTien = ((from ctb in db.BilDetails
                                        where ctb.IdBill == hd.IdBill
                                        select ctb.AmountOrder).FirstOrDefault() * 
                                        (from cake in db.Cakes
                                         where cake.IdCake == ((from ctb in db.BilDetails
                                                               where ctb.IdBill == hd.IdBill
                                                               select ctb.IdCake).FirstOrDefault())
                                            select cake.Price).FirstOrDefault())*((100-hd.Discount)/100)
                        };
            dgvBill.DataSource = query.ToList();
        }


        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowDgvBill = e.RowIndex;
            if (rowDgvBill >= 0 && rowDgvBill <= dgvBill.Rows.Count - 1)
            {
                Int32 idBill = Convert.ToInt32(dgvBill.Rows[rowDgvBill].Cells[0].Value);
                var query = from ctb in db.BilDetails
                            where ctb.IdBill == idBill
                            select new
                            {
                                nameCake = (from ct in db.Recipes
                                            where ct.IdRecipe == ((
                                                from b in db.Cakes
                                                where b.IdCake == ((
                                                    from ctb in db.BilDetails
                                                    where ctb.IdBill == idBill
                                                    select ctb.IdCake
                                                    ).FirstOrDefault())
                                                select b.IdRecipe
                                                ).FirstOrDefault())
                                            select ct.NameCake).FirstOrDefault(),
                                price = (from cake in db.Cakes
                                         where cake.IdCake == ((from ctb in db.BilDetails
                                                                where ctb.IdBill == idBill
                                                                select ctb.IdCake).FirstOrDefault())
                                         select cake.Price).FirstOrDefault(),
                                ctb.AmountOrder
                            };
                dgvBillDetail.DataSource = query.ToList();
            }
            else
            {
                dgvBillDetail.DataSource = null;
            }
        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadTabBill();
            txtSearchKeyBill.Clear();
        }

        private void btnSearchBill_Click(object sender, EventArgs e)
        {
            SearchBillByStaffName();
        }

        private void SearchBillByStaffName()
        {
            try
            {
                dgvBillDetail.DataSource = null;
                dgvBill.DataSource = null;
                String searchKey = txtSearchKeyBill.Text;
                if (searchKey == "")
                {
                    throw new Exception("Vui lòng nhập từ khóa tìm kiếm!");
                }
                var query = from hd in db.Bills
                            where hd.IdStaff == (from nv in db.staff
                                                 where nv.NameStaff == searchKey
                                                 select nv.IdStaff).FirstOrDefault()
                            select new
                            {
                                hd.IdBill,
                                hd.ExportDate,
                                nameStaff = (from nv in db.staff
                                             where nv.IdStaff == hd.IdStaff
                                             select nv.NameStaff).FirstOrDefault(),
                                hd.Discount,
                                TongTien = ((from ctb in db.BilDetails
                                             where ctb.IdBill == hd.IdBill
                                             select ctb.AmountOrder).FirstOrDefault() *
                                            (from cake in db.Cakes
                                             where cake.IdCake == ((from ctb in db.BilDetails
                                                                    where ctb.IdBill == hd.IdBill
                                                                    select ctb.IdCake).FirstOrDefault())
                                             select cake.Price).FirstOrDefault()) * ((100 - hd.Discount) / 100)
                            };
                dgvBill.DataSource = query.ToList();
                txtSearchKeyBill.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FilterBill()
        {
            try
            {
                dgvBillDetail.DataSource = null;
                dgvBill.DataSource = null;
                DateTime startDate = dtpStartDay.Value;
                DateTime endDate = dtpEndDate.Value;
                if (DateTime.Compare(startDate, endDate) > 0)
                {
                    throw new Exception("Vui lòng chọn ngày kết thúc trùng hoặc sau ngày bắt đầu!");
                }
                var query = from hd in db.Bills
                            where hd.ExportDate >= startDate && 
                                    hd.ExportDate <= endDate
                            select new
                            {
                                hd.IdBill,
                                hd.ExportDate,
                                nameStaff = (from nv in db.staff
                                             where nv.IdStaff == hd.IdStaff
                                             select nv.NameStaff).FirstOrDefault(),
                                hd.Discount,
                                TongTien = ((from ctb in db.BilDetails
                                             where ctb.IdBill == hd.IdBill
                                             select ctb.AmountOrder).FirstOrDefault() *
                                            (from cake in db.Cakes
                                             where cake.IdCake == ((from ctb in db.BilDetails
                                                                    where ctb.IdBill == hd.IdBill
                                                                    select ctb.IdCake).FirstOrDefault())
                                             select cake.Price).FirstOrDefault()) * ((100 - hd.Discount) / 100)
                            };
                dgvBill.DataSource = query.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnFilterBill_Click(object sender, EventArgs e)
        {
            FilterBill();
        }
    }
}
