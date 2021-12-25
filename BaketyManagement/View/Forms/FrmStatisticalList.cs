
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
                dgvStatistical.Columns[0].HeaderText = "Ngay";
                dgvStatistical.Columns[1].HeaderText = "Tong tien";
                gbStatisticalList.Text = "Danh sach doanh thu 7 ngay gan day";
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
                dgvStatistical.Rows[0].Cells[0].Value = "Tu ngay " + sevenDaysAgo.ToString("dd/MM/yyyy") + " den " + now.ToString("dd/MM/yyyy");
                dgvStatistical.Rows[0].Cells[1].Value = TongTien.ToString();
            }
            else if (radRevenue3MonthsList.Checked)
            {
                double TongTien = 0;
                DateTime now = DateTime.Now;
                DateTime month = new DateTime(now.Year, now.Month, 1);
                DateTime threeMonthAgo = month.AddMonths(-2);
                dgvStatistical.Columns[0].HeaderText = "Thang";
                dgvStatistical.Columns[1].HeaderText = "Tong tien";
                gbStatisticalList.Text = "Danh sach doanh thu 3 thang gan day";
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
                dgvStatistical.Rows[0].Cells[0].Value = "Tu ngay " + threeMonthAgo.ToString("dd/MM/yyyy") + " den " + now.ToString("dd/MM/yyyy");
                dgvStatistical.Rows[0].Cells[1].Value = TongTien.ToString();
            }
            else if (radBestSellerList.Checked)
            {
                DateTime now = DateTime.Now;
                DateTime thirtyDaysAgo = DateTime.Today.AddDays(-29);
                dgvStatistical.Columns[0].HeaderText = "Ten banh";
                dgvStatistical.Columns[1].HeaderText = "So luong";
                gbStatisticalList.Text = "Danh sach 10 loai banh ban chay nhat trong 30 ngay gan day";
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
                dgvStatistical.Columns[0].HeaderText = "Ten banh";
                dgvStatistical.Columns[1].HeaderText = "So luong";
                gbStatisticalList.Text = "Danh sach 10 loai banh ban cham nhat trong 30 ngay gan day";
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
            dgvStatistical.Columns.Add("Ngay", "Ngay");
            dgvStatistical.Columns.Add("TongTien", "Tong tien");
            gbStatisticalList.Text = "Danh sach doanh thu 7 ngay gan day";
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

            dgvStatistical.Rows[0].Cells[0].Value = "Tu ngay "+sevenDaysAgo.ToString("dd/MM/yyyy") + " den ngay " + now.ToString("dd/MM/yyyy");
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

        private void btn_exportPDF_Click(object sender, EventArgs e)
        {
            if (dgvStatistical.Rows.Count > 0)
            {
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
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<h1>TIEM BANH CAU DIEN</h1>");
                            sb.Append("<div>455 Cau Dien,<br /> Bac Tu Liem, Ha Noi</div>");
                            sb.Append("<div>(+84) 698-888-888</div>");
                            sb.Append("<div>Ngay in: "+DateTime.Now.ToString("dd/MM/yyyy") + "</div>");
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

                            foreach (DataGridViewRow row in dgvStatistical.Rows)
                            {
                                if(dgvStatistical.Rows.Count == 1)
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
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record To Export !!!", "Info");
            }
        }
    }
}
