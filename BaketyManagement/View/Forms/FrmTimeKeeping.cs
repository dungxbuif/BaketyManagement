
using BaketyManagement.DataModels;
using BaketyManagement.DTO;
using BaketyManagement.View.FormInfor;
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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp13212.Models;
using Document = iTextSharp.text.Document;

namespace BaketyManagement.View.Forms
{
    public partial class FrmTimeKeeping : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        Int32 row = -1;
        public FrmTimeKeeping()
        {
            InitializeComponent();
        }

        private void tlpTimeKeeping_Paint(object sender, PaintEventArgs e)
        {
            FrmMain.ShadowPanel(sender, e);
        }

        private void FrmTimeKeeping_Load(object sender, EventArgs e)
        {
            LoadSalary();
        }

        private void LoadSalary()
        {
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            row = 0;
            var query = from slr in db.Salaries
                        select new
                        {
                            slr.IdStaff,
                            nameStaff = (from stf in db.staff
                                         where stf.IdStaff == slr.IdStaff
                                         select stf.NameStaff).FirstOrDefault(),
                            slr.TimeKeeped,
                            slr.WorkingTime,
                            slr.HoursOverTime,
                        };
            dgvTimeKeeping.Rows.Clear();
            foreach (var slr in query)
            {
                DateTime timekeep = (DateTime)slr.TimeKeeped;
                dgvTimeKeeping.Rows.Add();
                dgvTimeKeeping.Rows[row].Cells[0].Value = slr.IdStaff.ToString();
                dgvTimeKeeping.Rows[row].Cells[1].Value = slr.nameStaff.ToString();
                dgvTimeKeeping.Rows[row].Cells[2].Value = timekeep.ToString("dd/MM/yyyy");
                dgvTimeKeeping.Rows[row].Cells[3].Value = slr.WorkingTime.ToString();
                dgvTimeKeeping.Rows[row].Cells[4].Value = slr.HoursOverTime.ToString();
                row++;
            }
        }

        private void btnAddSalary_Click(object sender, EventArgs e)
        {

        }

        private void btnTimeKeeping_Click(object sender, EventArgs e)
        {
            try
            {
                row = 0;
                Int32 idStaff = (int)MainDto.accountDto.IdStaff;
                FrmInforSalary.idStaff = idStaff;
                FrmInforSalary.checkSender = 2;
                FrmInforSalary frmInforSalary = new FrmInforSalary();
                frmInforSalary.ShowDialog();
                LoadSalary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editSalary()
        {
            try
            {
                if (row < 0 || row >= dgvTimeKeeping.Rows.Count - 1)
                {
                    throw new Exception("Vui lòng chọn nhân viên cần cập nhật!");
                }
                Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
                FrmInforSalary.idStaff = idStaff;
                FrmInforSalary.checkSender = 1;
                FrmInforSalary frmInforSalary = new FrmInforSalary();
                frmInforSalary.ShowDialog();
                LoadSalary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTimeKeeping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnEditSalary_Click(object sender, EventArgs e)
        {
            editSalary();
        }

        private void btnCancelTimeKeeping_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa chấm công của nhân viên " + dgvTimeKeeping.Rows[row].Cells[1].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
                Salary slXoa = (from sl in db.Salaries
                                where sl.IdStaff == idStaff
                                select sl).FirstOrDefault();
                db.Salaries.Remove(slXoa);
                db.SaveChanges();
                row--;
                MessageBox.Show("Xóa chấm công thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadSalary();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSumSalaryInfor frmSumSalaryInfor = new FrmSumSalaryInfor();
                FrmSumSalaryInfor.timeKeepedMonth = dateTimePicker2.Value.Month;
                FrmSumSalaryInfor.timeKeepedYear = dateTimePicker2.Value.Year;
                frmSumSalaryInfor.ShowDialog();
                LoadSalary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa chấm công của nhân viên ngày hôm nay của " + dgvTimeKeeping.Rows[row].Cells[1].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
                    var query = from slr in db.Salaries
                                where slr.IdStaff == idStaff
                                select slr;
                    string nowDay = DateTime.Now.ToString("dd/MM/yyyy");
                    foreach (var day in query)
                    {
                        DateTime timeKeep = (DateTime)day.TimeKeeped;
                        string timeKeepDay = timeKeep.ToString("dd/MM/yyyy");
                        if (timeKeepDay != nowDay)
                        {
                            throw new Exception("Nhân viên này chưa được chấm công ngày hôm nay");
                        }
                    }
                    Salary slXoa = (from sl in db.Salaries
                                    where sl.IdStaff == idStaff
                                    select sl).FirstOrDefault();
                    slXoa.TimeKeeped = DateTime.Today.AddDays(-1);
                    //slXoa.WorkDay = slXoa.WorkDay - 1;
                    //db.SaveChanges();
                    //MessageBox.Show("Xóa chấm công ngày hôm nay thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //LoadSalary();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void btnTimeKeepingSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtTimeKeepingSearch.Text;
                string time = dateTimePicker1.Value.ToString("dd-MM-yyyy");
                if (userName == "")
                    throw new Exception("Nhập tên nhân viên cần tìm");
                else
                {
                    dgvTimeKeeping.Rows.Clear();
                    var accTim = from nv in db.staff
                                 select new
                                 {
                                     nv.IdStaff,
                                     nv.NameStaff,
                                     TimeKeeped = (from sl in db.Salaries
                                                   where sl.IdStaff == nv.IdStaff
                                                   select sl.TimeKeeped).FirstOrDefault(),
                                     WorkingTime = (from sl in db.Salaries
                                                where sl.IdStaff == nv.IdStaff
                                                select sl.WorkingTime).FirstOrDefault(),
                                     HoursOverTime = (from sl in db.Salaries
                                                      where sl.IdStaff == nv.IdStaff
                                                      select sl.HoursOverTime).FirstOrDefault(),
                                 };
                    row = 0;
                    foreach (var slr in accTim)
                    {
                        DateTime timeKeep = (DateTime)slr.TimeKeeped;
                        string timeKeepDay = timeKeep.ToString("dd-MM-yyyy");
                        if (slr.NameStaff.Contains(userName) && timeKeepDay == time)
                        {
                            DateTime timekeep = (DateTime)slr.TimeKeeped;
                            dgvTimeKeeping.Rows.Add();
                            dgvTimeKeeping.Rows[row].Cells[0].Value = slr.IdStaff.ToString();
                            dgvTimeKeeping.Rows[row].Cells[1].Value = slr.NameStaff.ToString();
                            dgvTimeKeeping.Rows[row].Cells[2].Value = timekeep.ToString("dd/MM/yyyy");
                            dgvTimeKeeping.Rows[row].Cells[3].Value = slr.WorkingTime.ToString();
                            dgvTimeKeeping.Rows[row].Cells[4].Value = slr.HoursOverTime.ToString();
                            row++;
                        }
                    }
                }
                if (dgvTimeKeeping.Rows.Count <= 0)
                {
                    throw new Exception("Không tồn tại nhân viên có tên " + userName + "!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisplaySalary_Click(object sender, EventArgs e)
        {
            LoadSalary();
        }

        private void btnPrintSalary_Click(object sender, EventArgs e)
        {
            if (dgvTimeKeeping.Rows.Count > 0)
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
                            sb.Append("<div>Ngay in: " + DateTime.Now.ToString("dd/MM/yyyy") + "</div>");
                            sb.Append("<div>Noi dung: " + dgvTimeKeeping.Text + "</div>");
                            sb.Append("<div><br></div>");
                            PdfPTable pdfTable = new PdfPTable(dgvTimeKeeping.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn column in dgvTimeKeeping.Columns)
                            {
                                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfTable.AddCell(cell);
                            }

                            foreach (DataGridViewRow row in dgvTimeKeeping.Rows)
                            {
                                if (row.Index < dgvTimeKeeping.Rows.Count - 1)
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        pdfTable.AddCell(cell.Value.ToString());
                                    }
                                }
                                else
                                {
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        pdfTable.AddCell("");
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

        private void dgvTimeKeeping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }
    }
}
