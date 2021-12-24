
using BaketyManagement.DataModels;
using BaketyManagement.View.FormInfor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                            slr.SalaryDate,
                            slr.WorkDay,
                            slr.HoursOverTime,
                            slr.Rewards,
                            slr.SalaryOverTime,
                        };
            dgvTimeKeeping.Rows.Clear();
            foreach (var slr in query)
            {
                DateTime timekeep = (DateTime)slr.TimeKeeped;
                dgvTimeKeeping.Rows.Add();
                dgvTimeKeeping.Rows[row].Cells[0].Value = slr.IdStaff.ToString();
                dgvTimeKeeping.Rows[row].Cells[1].Value = slr.nameStaff.ToString();
                dgvTimeKeeping.Rows[row].Cells[2].Value = timekeep.ToString("dd/MM/yyyy");
                dgvTimeKeeping.Rows[row].Cells[3].Value = slr.SalaryDate.ToString();
                dgvTimeKeeping.Rows[row].Cells[4].Value = slr.WorkDay.ToString();
                dgvTimeKeeping.Rows[row].Cells[5].Value = slr.HoursOverTime.ToString();
                dgvTimeKeeping.Rows[row].Cells[6].Value = slr.Rewards.ToString();
                dgvTimeKeeping.Rows[row].Cells[7].Value = slr.SalaryOverTime.ToString();
                double tong = ((double)((slr.WorkDay * slr.SalaryDate) + (slr.HoursOverTime * slr.SalaryOverTime) + slr.Rewards));
                string Tong = tong.ToString("#,###", cul.NumberFormat);
                dgvTimeKeeping.Rows[row].Cells[8].Value = Tong;
                row++;
            }
        }

        private void btnAddSalary_Click(object sender, EventArgs e)
        {
            addSalary();
        }

        private void addSalary()
        {
            try
            {
                row = 0;
                Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
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

        private void btnTimeKeeping_Click(object sender, EventArgs e)
        {
            timeKeeping();
        }

        private void timeKeeping()
        {
            try
            {
                if (row < 0 || row >= dgvTimeKeeping.Rows.Count - 1)
                {
                    throw new Exception("Vui lòng chọn nhân viên cần cập nhật!");
                }
                Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);

                var query = from slr in db.Salaries
                            where slr.IdStaff == idStaff
                            select slr;
                string nowDay = DateTime.Now.ToString("dd/MM/yyyy");
                foreach (var day in query)
                {
                    DateTime timeKeep = (DateTime)day.TimeKeeped;
                    string timeKeepDay = timeKeep.ToString("dd/MM/yyyy");
                    if (timeKeepDay == nowDay)
                    {
                        throw new Exception("Nhân viên này đã chấm công ngày hôm nay");
                    }
                }

                Salary sl = (from slry in db.Salaries
                             where slry.IdStaff == idStaff
                             select slry).FirstOrDefault();
                int m = (int)sl.WorkDay;
                sl.WorkDay = m + 1;
                sl.TimeKeeped = DateTime.Now;
                db.SaveChanges();
                MessageBox.Show("Chấm công thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
            Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
            Salary slTinh = (from sl in db.Salaries
                            where sl.IdStaff == idStaff
                            select sl).FirstOrDefault();
            Double tong = (double)((slTinh.WorkDay * slTinh.SalaryDate) + (slTinh.HoursOverTime * slTinh.SalaryOverTime) + slTinh.Rewards);
            string Tong = tong.ToString("#,###", cul.NumberFormat);
            double reward = (double)slTinh.Rewards;
            double salaryNgoaiGio = (double)(slTinh.HoursOverTime * slTinh.SalaryOverTime);
            double salary = (double)(slTinh.WorkDay * slTinh.SalaryDate);
            MessageBox.Show("Tiền lương thực nhận của "
                + dgvTimeKeeping.Rows[row].Cells[1].Value.ToString()
                + " là: Lương thưởng: " + reward.ToString()
                + " Lương ngoài giờ: " + salaryNgoaiGio.ToString()
                + " Lương chính : " + salary.ToString("#,###", cul.NumberFormat)
                + " Tổng lương thực nhận: " + Tong + " VND", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    db.SaveChanges();
                    MessageBox.Show("Xóa chấm công ngày hôm nay thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSalary();
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
                                     SalaryDate = (from sl in db.Salaries
                                                     where sl.IdStaff == nv.IdStaff
                                                     select sl.SalaryDate).FirstOrDefault(),
                                     WorkDay = (from sl in db.Salaries
                                                where sl.IdStaff == nv.IdStaff
                                                select sl.WorkDay).FirstOrDefault(),
                                     HoursOverTime = (from sl in db.Salaries
                                                      where sl.IdStaff == nv.IdStaff
                                                      select sl.HoursOverTime).FirstOrDefault(),
                                     Rewards = (from sl in db.Salaries
                                                where sl.IdStaff == nv.IdStaff
                                                select sl.Rewards).FirstOrDefault(),
                                     SalaryOverTime = (from sl in db.Salaries
                                                        where sl.IdStaff == nv.IdStaff
                                                        select sl.SalaryOverTime).FirstOrDefault(),
                                 };
                    row = 0;
                    foreach (var slr in accTim)
                    {
                        CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");
                        if (slr.NameStaff.Contains(userName))
                        {
                            DateTime timekeep = (DateTime)slr.TimeKeeped;
                            dgvTimeKeeping.Rows.Add();
                            dgvTimeKeeping.Rows[row].Cells[0].Value = slr.IdStaff.ToString();
                            dgvTimeKeeping.Rows[row].Cells[1].Value = slr.NameStaff.ToString();
                            dgvTimeKeeping.Rows[row].Cells[2].Value = timekeep.ToString("dd/MM/yyyy");
                            dgvTimeKeeping.Rows[row].Cells[3].Value = slr.SalaryDate.ToString();
                            dgvTimeKeeping.Rows[row].Cells[4].Value = slr.WorkDay.ToString();
                            dgvTimeKeeping.Rows[row].Cells[5].Value = slr.HoursOverTime.ToString();
                            dgvTimeKeeping.Rows[row].Cells[6].Value = slr.Rewards.ToString();
                            dgvTimeKeeping.Rows[row].Cells[7].Value = slr.SalaryOverTime.ToString();
                            double tong = ((double)((slr.WorkDay * slr.SalaryDate) + (slr.HoursOverTime * slr.SalaryOverTime) + slr.Rewards));
                            string Tong = tong.ToString("#,###", cul.NumberFormat);
                            dgvTimeKeeping.Rows[row].Cells[8].Value = Tong;
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
    }
}
