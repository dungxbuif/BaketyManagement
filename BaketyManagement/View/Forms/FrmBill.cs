
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
        Int32 rowDgvBill;
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
            var data = from bi in db.Bills
                       join nv in db.staff on bi.IdStaff equals nv.IdStaff
                       join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                       join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                       group new { bi, ctb, ca } by new { bi.IdBill, bi.ExportDate, bi.Discount, nv.NameStaff} into bill
                        select bill;
            var query = data
                .Select(bill => new
                {
                    idBill = bill.Key.IdBill,
                    exportDate = bill.Key.ExportDate,
                    nameStaff = bill.Key.NameStaff,
                    discount = bill.Key.Discount,
                    TongTien = bill.Sum(b => b.ctb.AmountOrder * b.ca.Price * ((100 - bill.Key.Discount) / 100))
                });
            //dgvBill.DataSource = query.ToList();
            foreach(var bill in query)
            {
                dgvBill.Rows.Add();
                dgvBill.Rows[rowDgvBill].Cells[0].Value = bill.idBill;
                dgvBill.Rows[rowDgvBill].Cells[1].Value = bill.exportDate.ToString("dd/MM/yyyy");
                dgvBill.Rows[rowDgvBill].Cells[2].Value = bill.nameStaff;
                dgvBill.Rows[rowDgvBill].Cells[3].Value = bill.discount;
                dgvBill.Rows[rowDgvBill].Cells[4].Value = bill.TongTien;
                rowDgvBill++;
            }
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rowDgvBill = e.RowIndex;
            if (rowDgvBill >= 0 && rowDgvBill <= dgvBill.Rows.Count - 1)
            {
                Int32 idBill = Convert.ToInt32(dgvBill.Rows[rowDgvBill].Cells[0].Value);
                var query = from ctb in db.BilDetails
                            join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                            join re in db.Recipes on ca.IdRecipe equals re.IdRecipe
                            where ctb.IdBill == idBill
                            select new
                            {
                                nameCake = re.NameCake,
                                price = ca.Price,
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
                var data = from bi in db.Bills
                           join nv in db.staff on bi.IdStaff equals nv.IdStaff
                           join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                           join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                           where bi.IdStaff == (from nv in db.staff
                                                where nv.NameStaff == searchKey
                                                select nv.IdStaff).FirstOrDefault()
                           group new { bi, ctb, ca } by new { bi.IdBill, bi.ExportDate, bi.Discount, nv.NameStaff } into bill
                           select bill;
                var query = data
                    .Select(bill => new
                    {
                        idBill = bill.Key.IdBill,
                        exportDate = bill.Key.ExportDate,
                        nameStaff = bill.Key.NameStaff,
                        discount = bill.Key.Discount,
                        TongTien = bill.Sum(b => b.ctb.AmountOrder * b.ca.Price * ((100 - bill.Key.Discount) / 100))
                    });
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
