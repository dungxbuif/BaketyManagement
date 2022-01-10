
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using WinFormsApp13212.Models;

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
                if (dgvStatistical.Columns.Count > 2)
                {
                    dgvStatistical.Columns.Remove("TenSanPham");
                    dgvStatistical.Columns.Remove("SoLuongThuc");
                    dgvStatistical.Columns.Remove("DoanhThu");
                    dgvStatistical.Columns.Remove("GiamGia");
                    dgvStatistical.Columns.Remove("DoanhThuThuc");
                    dgvStatistical.Columns.Remove("TongDoanhThu");
                    dgvStatistical.Columns.Add("NhanVien", "Nhân viên");
                    dgvStatistical.Columns.Add("TongTien", "Tổng tiền");
                }
                DateTime now = DateTime.Now;
                DateTime sevenDaysAgo = DateTime.Today.AddDays(-7);
                dgvStatistical.Columns[0].HeaderText = "Nhân viên";
                dgvStatistical.Columns[1].HeaderText = "Tổng tiền";
                gbStatisticalList.Text = "Danh sách doanh thu của từng nhân viên 7 ngày gần đây nhất (từ ngày " + sevenDaysAgo.ToString("dd/MM/yyyy") + " đến ngày " + now.ToString("dd/MM/yyyy") + ")";
                var data = from staff in db.staff
                           join bi in db.Bills on staff.IdStaff equals bi.IdStaff
                           join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                           join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                           where bi.ExportDate <= now && bi.ExportDate >= sevenDaysAgo
                           group new { staff, ctb, ca, bi } by new { staff.NameStaff } into st
                           select st;
                var query = data
                    .Select(st => new
                    {
                        nameStaff = st.Key.NameStaff,
                        value = st.Sum(s => s.ctb.AmountOrder * s.ca.Price * ((100 - s.bi.Discount) / 100))
                    })
                    .OrderByDescending(st => st.value); ;
                Int32 row = 0;
                dgvStatistical.Rows.Clear();
                foreach (var st in query)
                {
                    dgvStatistical.Rows.Add();
                    dgvStatistical.Rows[row].Cells[0].Value = st.nameStaff;
                    dgvStatistical.Rows[row].Cells[1].Value = st.value;
                    row++;
                }
            }
            else if (radRevenue3MonthsList.Checked)
            {
                if (dgvStatistical.Columns.Count > 2)
                {
                    dgvStatistical.Columns.Remove("TenSanPham");
                    dgvStatistical.Columns.Remove("SoLuongThuc");
                    dgvStatistical.Columns.Remove("DoanhThu");
                    dgvStatistical.Columns.Remove("GiamGia");
                    dgvStatistical.Columns.Remove("DoanhThuThuc");
                    dgvStatistical.Columns.Remove("TongDoanhThu");
                    dgvStatistical.Columns.Add("NhanVien", "Nhân viên");
                    dgvStatistical.Columns.Add("TongTien", "Tổng tiền");
                }
                DateTime now = DateTime.Now;
                DateTime thirtyDaysAgo = DateTime.Today.AddDays(-30);
                dgvStatistical.Columns[0].HeaderText = "Nhân viên";
                dgvStatistical.Columns[1].HeaderText = "Tổng tiền";
                gbStatisticalList.Text = "Danh sách doanh thu của từng nhân viên 30 ngày gần đây nhất (từ ngày " + thirtyDaysAgo.ToString("dd/MM/yyyy") + " đến ngày " + now.ToString("dd/MM/yyyy") + ")";
                var data = from staff in db.staff
                           join bi in db.Bills on staff.IdStaff equals bi.IdStaff
                           join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                           join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                           where bi.ExportDate <= now && bi.ExportDate >= thirtyDaysAgo
                           group new { staff, ctb, ca, bi } by new { staff.NameStaff } into st
                           select st;
                var query = data
                    .Select(st => new
                    {
                        nameStaff = st.Key.NameStaff,
                        value = st.Sum(s => s.ctb.AmountOrder * s.ca.Price * ((100 - s.bi.Discount) / 100))
                    })
                    .OrderByDescending(st => st.value); ;
                Int32 row = 0;
                dgvStatistical.Rows.Clear();
                foreach (var st in query)
                {
                    dgvStatistical.Rows.Add();
                    dgvStatistical.Rows[row].Cells[0].Value = st.nameStaff;
                    dgvStatistical.Rows[row].Cells[1].Value = st.value;
                    row++;
                }
            }
            else if (radBestSellerList.Checked)
            {
                if (dgvStatistical.Columns.Count > 2)
                {
                    dgvStatistical.Columns.Remove("TenSanPham");
                    dgvStatistical.Columns.Remove("SoLuongThuc");
                    dgvStatistical.Columns.Remove("DoanhThu");
                    dgvStatistical.Columns.Remove("GiamGia");
                    dgvStatistical.Columns.Remove("DoanhThuThuc");
                    dgvStatistical.Columns.Remove("TongDoanhThu");
                    dgvStatistical.Columns.Add("NhanVien", "Nhân viên");
                    dgvStatistical.Columns.Add("TongTien", "Tổng tiền");
                }
                DateTime now = DateTime.Now;
                DateTime thirtyDaysAgo = DateTime.Today.AddDays(-30);
                dgvStatistical.Columns[0].HeaderText = "Tên bánh";
                dgvStatistical.Columns[1].HeaderText = "Số lượng";
                gbStatisticalList.Text = "Danh sách 10 loại bánh bán chạy nhất trong 30 ngày gần đây (từ ngày " + thirtyDaysAgo.ToString("dd/MM/yyyy") + " đến ngày " + now.ToString("dd/MM/yyyy") + ")";
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
                    .OrderByDescending(cake => cake.amount)
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
            else if (radSlowestSellerList.Checked)
            {
                double TongTien = 0;
                DateTime now = DateTime.Now;
                DateTime thirtyDaysAgo = DateTime.Today.AddDays(-30);
                dgvStatistical.Columns.Remove("NhanVien");
                dgvStatistical.Columns.Remove("TongTien");
                dgvStatistical.Columns.Add("TenSanPham", "Tên sản phẩm");
                dgvStatistical.Columns.Add("SoLuongThuc", "Số lượng thực");
                dgvStatistical.Columns.Add("DoanhThu", "Doanh thu");
                dgvStatistical.Columns.Add("GiamGia", "Giảm giá");
                dgvStatistical.Columns.Add("DoanhThuThuc", "Doanh thu thực");
                dgvStatistical.Columns.Add("TongDoanhThu", "Tổng doanh thu");
                gbStatisticalList.Text = "Thống kê doanh thu sản phẩm trong 30 ngày gần đây (từ ngày " + thirtyDaysAgo.ToString("dd/MM/yyyy") + " đến ngày " + now.ToString("dd/MM/yyyy") + ")";
                var data = from ca in db.Cakes
                           join res in db.Recipes on ca.IdRecipe equals res.IdRecipe
                           join ctb in db.BilDetails on ca.IdCake equals ctb.IdCake
                           join bi in db.Bills on ctb.IdBill equals bi.IdBill
                           where bi.ExportDate <= now && bi.ExportDate >= thirtyDaysAgo
                           group new { ca, ctb, bi } by new { ca.IdCake, res.NameCake } into cake
                           select cake;
                var query = data
                .Select(st => new
                {
                    nameCake = st.Key.NameCake,
                    amount = st.Sum(s => s.ctb.AmountOrder),
                    value = st.Sum(s => s.ctb.AmountOrder * s.ca.Price),
                    discount = st.Sum(s => s.ctb.AmountOrder * s.ca.Price * (s.bi.Discount / 100)),
                    actValue = st.Sum(s => s.ctb.AmountOrder * s.ca.Price * ((100 - s.bi.Discount) / 100)),
                    sumValue = st.Sum(s => s.ctb.AmountOrder * s.ca.Price * ((100 - s.bi.Discount) / 100))
                });
                var dataTongTien = from bi in db.Bills
                           join nv in db.staff on bi.IdStaff equals nv.IdStaff
                           join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                           join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                           where bi.ExportDate <= now && bi.ExportDate >= thirtyDaysAgo
                                   group new { bi, ctb, ca } by new { bi.IdBill, bi.ExportDate, bi.Discount, nv.NameStaff } into bill
                           select bill;
                var queryTongTien = dataTongTien
                    .Select(bill => new
                    {
                        tien = bill.Sum(b => b.ctb.AmountOrder * b.ca.Price * ((100 - bill.Key.Discount) / 100))
                    });
                foreach (var tinhTien in queryTongTien)
                {
                    TongTien += (double)tinhTien.tien;
                }
                Int32 row = 0;
                dgvStatistical.Rows.Clear();
                foreach (var st in query)
                {
                    dgvStatistical.Rows.Add();
                    dgvStatistical.Rows[row].Cells[0].Value = st.nameCake;
                    dgvStatistical.Rows[row].Cells[1].Value = st.amount;
                    dgvStatistical.Rows[row].Cells[2].Value = st.value;
                    dgvStatistical.Rows[row].Cells[3].Value = st.discount;
                    dgvStatistical.Rows[row].Cells[4].Value = st.actValue;
                    dgvStatistical.Rows[row].Cells[5].Value = st.sumValue;
                    row++;
                }
                dgvStatistical.Rows.Add();
                dgvStatistical.Rows[row+1].Cells[0].Value = "Tổng tiền";
                dgvStatistical.Rows[row+1].Cells[5].Value = TongTien.ToString();
            }
        }
        private void LoadStatisticalList()
        {
            DateTime now = DateTime.Now;
            DateTime sevenDaysAgo = DateTime.Today.AddDays(-7);
            dgvStatistical.Columns.Add("NhanVien", "Nhân viên");
            dgvStatistical.Columns.Add("TongTien", "Tổng tiền");
            gbStatisticalList.Text = "Danh sách doanh thu của từng nhân viên 7 ngày gần đây nhất (từ ngày "+ sevenDaysAgo.ToString("dd/MM/yyyy")+" đến ngày "+now.ToString("dd/MM/yyyy")+")";
            var data = from staff in db.staff
                       join bi in db.Bills on staff.IdStaff equals bi.IdStaff
                       join ctb in db.BilDetails on bi.IdBill equals ctb.IdBill
                       join ca in db.Cakes on ctb.IdCake equals ca.IdCake
                       where bi.ExportDate <= now && bi.ExportDate >= sevenDaysAgo
                       group new { staff, ctb, ca, bi } by new { staff.NameStaff } into st
                       select st;
            var query = data
                .Select(st => new
                {
                    nameStaff = st.Key.NameStaff,
                    value = st.Sum(s => s.ctb.AmountOrder * s.ca.Price * ((100 - s.bi.Discount) / 100))
                })
                .OrderByDescending(st => st.value);
            Int32 row = 0;
            dgvStatistical.Rows.Clear();
            foreach (var st in query)
            {
                dgvStatistical.Rows.Add();
                dgvStatistical.Rows[row].Cells[0].Value = st.nameStaff;
                dgvStatistical.Rows[row].Cells[1].Value = st.value;
                row++;
            }
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

        private void btn_exportPDF_Click(object sender, EventArgs e)
        {
            if (dgvStatistical.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                sfd.FileName = "StatisticalList.pdf";
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
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<h1>TIEM BANH CAU DIEN</h1>");
                            sb.Append("<div>455 Cau Dien,<br /> Bac Tu Liem, Ha Noi</div>");
                            sb.Append("<div>(+84) 698-888-888</div>");
                            sb.Append("<div>Ngay in: " + DateTime.Now.ToString("dd/MM/yyyy") + "</div>");
                            sb.Append("<div>Noi dung: " + gbStatisticalList.Text + "</div>");
                            sb.Append("<div><br></div>");
                            PdfPTable pdfTable = new PdfPTable(dgvStatistical.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgvStatistical.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }
                            if (dgvStatistical.Columns.Count > 2)
                            {
                                foreach (DataGridViewRow row in dgvStatistical.Rows)
                                {
                                    if (row.Index < dgvStatistical.Rows.Count - 2)
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
                                    else if(row.Index == dgvStatistical.Rows.Count - 2)
                                    {
                                        string cell1 = "";
                                        pdfTable.AddCell(cell1);
                                        string cell2 = "";
                                        pdfTable.AddCell(cell2);
                                        string cell3 = "";
                                        pdfTable.AddCell(cell3);
                                        string cell4 = "";
                                        pdfTable.AddCell(cell4);
                                        string cell5 = "";
                                        pdfTable.AddCell(cell5);
                                        string cell6 = "";
                                        pdfTable.AddCell(cell6);
                                    }
                                    else
                                    {
                                        string cell1 = row.Cells[0].Value.ToString();
                                        pdfTable.AddCell(cell1);
                                        string cell2 = "";
                                        pdfTable.AddCell(cell2);
                                        string cell3 = "";
                                        pdfTable.AddCell(cell3);
                                        string cell4 = "";
                                        pdfTable.AddCell(cell4);
                                        string cell5 = "";
                                        pdfTable.AddCell(cell5);
                                        string cell6 = row.Cells[5].Value.ToString();
                                        pdfTable.AddCell(cell6);
                                    }
                                }
                            }
                            else
                            {
                                foreach (DataGridViewRow row in dgvStatistical.Rows)
                                {
                                    if (dgvStatistical.Rows.Count == 1)
                                    {
                                        string cell1 = row.Cells[0].Value.ToString();
                                        pdfTable.AddCell(cell1);
                                        string cell2 = row.Cells[1].Value.ToString();
                                        pdfTable.AddCell(cell2);
                                    }
                                    else
                                    {
                                        if (row.Index < dgvStatistical.Rows.Count - 1)
                                        {
                                            string cell1 = row.Cells[0].Value.ToString();
                                            pdfTable.AddCell(cell1);
                                            string cell2 = row.Cells[1].Value.ToString();
                                            pdfTable.AddCell(cell2);
                                        }
                                        else
                                        {
                                            string cell1 = "";
                                            pdfTable.AddCell(cell1);
                                            string cell2 = "";
                                            pdfTable.AddCell(cell2);
                                        }
                                    }

                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                StringReader sr = new StringReader(sb.ToString());
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
                                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();
                                htmlparser.Parse(sr);
                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }

                            MessageBox.Show("Xuất dữ liệu thành công !!!", "Info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có bản ghi để xuất !!!", "Info");
            }
        }

        private void radRevenue7DaysList_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
