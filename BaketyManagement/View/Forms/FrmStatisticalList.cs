
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
    public partial class FrmStatisticalList : Form
    {
        BakeryManagementContext db = new BakeryManagementContext();
        public FrmStatisticalList()
        {
            InitializeComponent();
        }

        private void FrmStatisticalList_Load(object sender, EventArgs e)
        {
            LoadStatisticalList();
        }
        private void StatisticalList()
        {
            if (radRevenue7DaysList.Checked)
            {
                double TongTien = 0;
                DateTime now = DateTime.Now;
                DateTime sevenDaysAgo = DateTime.Today.AddDays(-7);
                dgvStatistical.Columns[0].HeaderText = "Ngày";
                dgvStatistical.Columns[1].HeaderText = "Tổng tiền";
                gbStatisticalList.Text = "Danh sách doanh thu 7 ngày gần đây";
                var data = from bi in db.Bills
                           join nv in db.staff on bi.IdStaff equals nv.IdStaff
                           join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                           join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                           where bi.ExportDate <= now && bi.ExportDate >= sevenDaysAgo
                           group new { bi, ctb, ca } by new { bi.IdBill, bi.ExportDate, bi.Discount, nv.NameStaff } into bill
                           select bill;
                var query = data
                    .Select(bill => new
                    {
                        tien = bill.Sum(b => b.ctb.AmountOrder * b.ca.Price * ((100 - bill.Key.Discount) / 100))
                    });

                foreach (var tinhTien in query)
                {
                    TongTien += (double)tinhTien.tien;
                }
                dgvStatistical.Rows.Clear();
                dgvStatistical.Rows[0].Cells[0].Value = "Từ ngày " + sevenDaysAgo.ToString("dd/MM/yyyy") + " đến " + now.ToString("dd/MM/yyyy");
                dgvStatistical.Rows[0].Cells[1].Value = TongTien.ToString();
            }
            else if (radRevenue3MonthsList.Checked)
            {
                double TongTien = 0;
                DateTime now = DateTime.Now;
                DateTime month = new DateTime(now.Year, now.Month, 1);
                DateTime threeMonthAgo = month.AddMonths(-2);
                dgvStatistical.Columns[0].HeaderText = "Tháng";
                dgvStatistical.Columns[1].HeaderText = "Tổng tiền";
                gbStatisticalList.Text = "Danh sách doanh thu 3 tháng gần đây";
                var data = from bi in db.Bills
                           join nv in db.staff on bi.IdStaff equals nv.IdStaff
                           join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                           join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                           where bi.ExportDate <= now && bi.ExportDate >= threeMonthAgo
                           group new { bi, ctb, ca } by new { bi.IdBill, bi.ExportDate, bi.Discount, nv.NameStaff } into bill
                           select bill;
                var query = data
                    .Select(bill => new
                    {
                        tien = bill.Sum(b => b.ctb.AmountOrder * b.ca.Price * ((100 - bill.Key.Discount) / 100))
                    });

                foreach (var tinhTien in query)
                {
                    TongTien += (double)tinhTien.tien;
                }
                dgvStatistical.Rows.Clear();
                dgvStatistical.Rows[0].Cells[0].Value = "Từ ngày " + threeMonthAgo.ToString("dd/MM/yyyy") + " đến " + now.ToString("dd/MM/yyyy");
                dgvStatistical.Rows[0].Cells[1].Value = TongTien.ToString();
            }
            else if (radBestSellerList.Checked)
            {
                DateTime now = DateTime.Now;
                DateTime thirtyDaysAgo = DateTime.Today.AddDays(-29);
                dgvStatistical.Columns[0].HeaderText = "Tên bánh";
                dgvStatistical.Columns[1].HeaderText = "Số lượng";
                gbStatisticalList.Text = "Danh sách 10 loại bánh bán chạy nhất trong 30 ngày gần đây";
                var data = from ca in db.Cakes
                           join res in db.Recipes on ca.IdRecipe equals res.IdRecipe
                           join ctb in db.BilDetails on ca.IdCake equals ctb.IdCake
                           join bi in db.Bills on ctb.IdBill equals bi.IdBill
                           where bi.ExportDate <= now && bi.ExportDate >= thirtyDaysAgo
                           group new { ca, ctb  } by new { ca.IdCake, res.NameCake } into cake
                           select cake;
                var query = data
                    .Select(cake => new
                            {
                                nameCake = cake.Key.NameCake,
                                amount = cake.Sum(c => c.ctb.AmountOrder)
                            })
                    .OrderByDescending(cake => cake.amount)
                    .Take(10);

                Int32 row = 0;
                dgvStatistical.Rows.Clear();
                foreach(var cake in query)
                {
                    dgvStatistical.Rows.Add();
                    dgvStatistical.Rows[row].Cells[0].Value = cake.nameCake;
                    dgvStatistical.Rows[row].Cells[1].Value = cake.amount;
                    row++;
                }
            }
            else if (radSlowestSellerList.Checked)
            {
                DateTime now = DateTime.Now;
                DateTime thirtyDaysAgo = DateTime.Today.AddDays(-29);
                dgvStatistical.Columns[0].HeaderText = "Tên bánh";
                dgvStatistical.Columns[1].HeaderText = "Số lượng";
                gbStatisticalList.Text = "Danh sách 10 loại bánh bán chậm nhất trong 30 ngày gần đây";
                var data = from ca in db.Cakes
                           join res in db.Recipes on ca.IdRecipe equals res.IdRecipe
                           join ctb in db.BilDetails on ca.IdCake equals ctb.IdCake
                           join bi in db.Bills on ctb.IdBill equals bi.IdBill
                           where bi.ExportDate <= now && bi.ExportDate >= thirtyDaysAgo
                           group new { ca, ctb } by new { ca.IdCake, res.NameCake } into cake
                           select cake;
                var query = data
                    .Select(cake => new
                    {
                        nameCake = cake.Key.NameCake,
                        amount = cake.Sum(c => c.ctb.AmountOrder)
                    })
                    .OrderBy(cake => cake.amount)
                    .Take(10);

                Int32 row = 0;
                dgvStatistical.Rows.Clear();
                foreach (var cake in query)
                {
                    dgvStatistical.Rows.Add();
                    dgvStatistical.Rows[row].Cells[0].Value = cake.nameCake;
                    dgvStatistical.Rows[row].Cells[1].Value = cake.amount;
                    row++;
                }
            }
        }
        private void LoadStatisticalList()
        {
            double TongTien = 0;
            DateTime now = DateTime.Now;
            DateTime sevenDaysAgo = DateTime.Today.AddDays(-7);
            dgvStatistical.Columns.Add("Ngay", "Ngày");
            dgvStatistical.Columns.Add("TongTien", "Tổng tiền");
            gbStatisticalList.Text = "Danh sách doanh thu 7 ngày gần đây";
            var data = from bi in db.Bills
                       join nv in db.staff on bi.IdStaff equals nv.IdStaff
                       join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                       join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                       where bi.ExportDate <= now && bi.ExportDate >= sevenDaysAgo
                       group new { bi, ctb, ca } by new { bi.IdBill, bi.ExportDate, bi.Discount, nv.NameStaff } into bill
                       select bill;
            var query = data
                .Select(bill => new
                {
                    tien = bill.Sum(b => b.ctb.AmountOrder * b.ca.Price * ((100 - bill.Key.Discount) / 100))
                });

            foreach(var tinhTien in query)
            {
                TongTien += (double)tinhTien.tien;
            }

            dgvStatistical.Rows[0].Cells[0].Value = "Từ ngày "+sevenDaysAgo.ToString("dd/MM/yyyy") + " đến " + now.ToString("dd/MM/yyyy");
            dgvStatistical.Rows[0].Cells[1].Value = TongTien.ToString();
        }

        private void radRevenue7DaysList_Click(object sender, EventArgs e)
        {
            StatisticalList();
        }

        private void radRevenue3MonthsList_Click(object sender, EventArgs e)
        {
            StatisticalList();
        }

        private void radBestSellerList_Click(object sender, EventArgs e)
        {
            StatisticalList();
        }

        private void radSlowestSellerList_Click(object sender, EventArgs e)
        {
            StatisticalList();
        }
    }
}
