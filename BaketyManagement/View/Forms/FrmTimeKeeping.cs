
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
            LoadSalary();
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
                            slr.IdSalary,
                            slr.IdStaff,
                            nameStaff = (from stf in db.staff
                                         where stf.IdStaff == slr.IdStaff
                                         select stf.NameStaff).FirstOrDefault(),
                            slr.TimeKeeped,
                            slr.WorkingTime,
                            slr.HoursOverTime,
                        };
            dgvTimeKeeping.Rows.Clear();
            var data = query
                .OrderBy(sl => sl.nameStaff).ThenBy(sl => sl.TimeKeeped);

            foreach (var slr in data)
            {
                DateTime timekeep = (DateTime)slr.TimeKeeped;
                dgvTimeKeeping.Rows.Add();
                dgvTimeKeeping.Rows[row].Cells[0].Value = slr.IdSalary.ToString();
                dgvTimeKeeping.Rows[row].Cells[1].Value = slr.IdStaff.ToString();
                dgvTimeKeeping.Rows[row].Cells[2].Value = slr.nameStaff.ToString();
                dgvTimeKeeping.Rows[row].Cells[3].Value = timekeep.ToString("dd/MM/yyyy");
                dgvTimeKeeping.Rows[row].Cells[4].Value = slr.WorkingTime.ToString();
                dgvTimeKeeping.Rows[row].Cells[5].Value = slr.HoursOverTime.ToString();
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
                FrmSumSalaryInfor.timeKeepedMonth = dateTimePicker2.Value.Month;
                FrmSumSalaryInfor.timeKeepedYear = dateTimePicker2.Value.Year;
                FrmSumSalaryInfor frmSumSalaryInfor = new FrmSumSalaryInfor();
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
                    var query = from slr in db.Salaries
                                select new
                                {
                                    slr.IdSalary,
                                    slr.IdStaff,
                                    nameStaff = (from stf in db.staff
                                                 where stf.IdStaff == slr.IdStaff
                                                 select stf.NameStaff).FirstOrDefault(),
                                    slr.TimeKeeped,
                                    slr.WorkingTime,
                                    slr.HoursOverTime,
                                };
                    var data = query
                        .OrderByDescending(sl => sl.nameStaff);
                    row = 0;
                    foreach (var slr in data)
                    {
                        DateTime timeKeep = (DateTime)slr.TimeKeeped;
                        string timeKeepDay = timeKeep.ToString("dd-MM-yyyy");
                        if (slr.nameStaff.Contains(userName) && timeKeepDay == time)
                        {
                            DateTime timekeep = (DateTime)slr.TimeKeeped;
                            dgvTimeKeeping.Rows.Add();
                            dgvTimeKeeping.Rows[row].Cells[1].Value = slr.IdStaff.ToString();
                            dgvTimeKeeping.Rows[row].Cells[1].Value = slr.IdStaff.ToString();
                            dgvTimeKeeping.Rows[row].Cells[2].Value = slr.nameStaff.ToString();
                            dgvTimeKeeping.Rows[row].Cells[3].Value = timekeep.ToString("dd/MM/yyyy");
                            dgvTimeKeeping.Rows[row].Cells[4].Value = slr.WorkingTime.ToString();
                            dgvTimeKeeping.Rows[row].Cells[5].Value = slr.HoursOverTime.ToString();
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
           
        }

        private void dgvTimeKeeping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTimeKeeping.Rows[row].Cells[0].Value == null)
                    throw new Exception("Chưa chọn nhà cung cấp");
                Int32 idSalary = Int32.Parse(dgvTimeKeeping.Rows[row].Cells[0].Value.ToString());

                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa chấm công không " ,"" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Salary sup = (from sp in db.Salaries
                                    where sp.IdSalary == idSalary
                                  select sp).FirstOrDefault();
                    db.Salaries.Remove(sup);
                    db.SaveChanges();
                    row--;
                    MessageBox.Show("Xóa chấm công thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSalary();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
