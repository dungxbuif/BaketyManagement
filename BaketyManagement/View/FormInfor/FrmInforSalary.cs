
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

namespace BaketyManagement.View.FormInfor
{
    public partial class FrmInforSalary : Form
    {
        public static Int32 idStaff;
        public static Int32 checkSender;
        BakeryManagementContext db = BakeryManagementContext.Instance;
        public FrmInforSalary()
        {
            InitializeComponent();
            cboStaffName.DataSource = db.staff.ToList();
            cboStaffName.DisplayMember = "nameStaff";
            txtSalaryDate.Text = "100000";
            txtSalaryOverTime.Text = "30000";
            txtWorkDays.Text = "1";
            txtSalaryDate.Enabled = false;
            txtSalaryOverTime.Enabled = false;
            txtWorkDays.Enabled = false;
            if(checkSender == 2)
            {
                btnTimeKeeping.Text = "Thêm Chấm Công";
            } else
            {
                txtWorkDays.Enabled = true;
                btnTimeKeeping.Text = "Sửa thông tin";
                Salary sl = (from slr in db.Salaries
                             where slr.IdStaff == idStaff
                             select slr).FirstOrDefault();
                txtIDStaff.Text = idStaff.ToString();
                txtHoursOverTime.Text = sl.HoursOverTime.ToString();
                txtRewards.Text = sl.Rewards.ToString();
                txtSalaryDate.Text = sl.SalaryDate.ToString();
                txtSalaryOverTime.Text = sl.SalaryOverTime.ToString();
                txtWorkDays.Text = sl.WorkDay.ToString();
                cboStaffName.Enabled = false;
            }
        }

        private void cboStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIDStaff.Text = (cboStaffName.SelectedItem as staff).IdStaff.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimeKeeping_Click(object sender, EventArgs e)
        {
            if(checkSender == 2)
            {
                AddSalary();
            }
            else
            {
                EditSalary();
            }
        }

        private void AddSalary()
        {
            try
            {
                string idStaff = txtIDStaff.Text;
                DateTime timeKeeped = DateTime.Now;
                Double salaryDate = Double.Parse(txtSalaryDate.Text);
                int workDay = int.Parse(txtWorkDays.Text);
                int hourOverTime = int.Parse(txtHoursOverTime.Text);
                Double reward = Double.Parse(txtRewards.Text);
                Double salaryOverTime = Double.Parse(txtSalaryOverTime.Text);

                if (hourOverTime.ToString() == "")
                {
                    throw new Exception("Chưa nhập số giờ tăng ca");
                }
                if (reward.ToString() == "")
                {
                    throw new Exception("Chưa nhập số tiền thưởng");
                }

                var query = from slr in db.Salaries select slr;

                foreach (var id in query)
                {
                    if (id.IdStaff == int.Parse(idStaff))
                    {
                        throw new Exception("Nhân viên này đã được chấm công, vui lòng chọn sửa hoặc chấm công để thay đổi");
                    }
                }

                Salary sl = new Salary();
                int max = 0;
                DateTime nowDate = DateTime.Now;
                var querySalary = from slr in db.Salaries select slr;
                foreach (var sala in querySalary)
                {
                    if (sala.IdSalary > max)
                    {
                        max = sala.IdSalary + 1;
                    }
                }
                sl.IdSalary = max;
                sl.IdStaff = int.Parse(idStaff);
                sl.SalaryDate = salaryDate;
                sl.TimeKeeped = nowDate;
                sl.SalaryTime = DateTime.Parse("2021-12-01");
                sl.WorkDay = workDay;
                sl.SalaryOverTime = salaryOverTime;
                sl.Rewards = reward;
                sl.HoursOverTime = hourOverTime;
                db.Salaries.Add(sl);
                db.SaveChanges();
                DialogResult result = MessageBox.Show("Chấm công mới thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditSalary()
        {
            try
            {
                Salary slrSua = (from sl in db.Salaries
                                 where sl.IdStaff == idStaff
                                 select sl).FirstOrDefault();
                slrSua.HoursOverTime = int.Parse(txtHoursOverTime.Text);
                if (slrSua.WorkDay < int.Parse(txtWorkDays.Text))
                {
                    throw new Exception("Ngày công mới không được lớn hơn ngày công cũ");
                }
                slrSua.WorkDay = int.Parse(txtWorkDays.Text);
                slrSua.Rewards = int.Parse(txtRewards.Text);
                db.SaveChanges();
                DialogResult result = MessageBox.Show("Sửa chấm công thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                    this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
