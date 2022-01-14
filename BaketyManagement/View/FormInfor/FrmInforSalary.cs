
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
using WinFormsApp13212.Models;

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
            dateTimeKeeped.CustomFormat = "dd-MM-yyyy";
            cboStaffName.DataSource = db.staff.ToList();
            cboStaffName.DisplayMember = "nameStaff";
            if(checkSender == 2)
            {
                btnTimeKeeping.Text = "Thêm Chấm Công";
                txtHoursOverTime.Text = "0";
                txtWorkingTime.Text = "8";
            }
            else
            {
                txtWorkingTime.Enabled = true;
                btnTimeKeeping.Text = "Sửa thông tin";
                Salary sl = (from slr in db.Salaries
                             where slr.IdSalary == idStaff
                             select slr).FirstOrDefault();
                txtIDStaff.Text = sl.IdStaff.ToString();
                dateTimeKeeped.Value = sl.TimeKeeped;
                cboStaffName.SelectedIndex = (int)(sl.IdStaff - 1);
                txtHoursOverTime.Text = sl.HoursOverTime.ToString();
                txtWorkingTime.Text = sl.WorkingTime.ToString();
                cboStaffName.Enabled = false;
                txtIDStaff.Enabled = false;
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
                DateTime timeKeeped = DateTime.Now;
                string m = timeKeeped.ToString("dd/MM/yyyy");
                if (txtWorkingTime.Text == "" || txtHoursOverTime.Text == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin");
                }
               
                int workingTime = int.Parse(txtWorkingTime.Text);
                int hourOverTime = int.Parse(txtHoursOverTime.Text);

                var query = from slr in db.Salaries
                            where slr.IdStaff.ToString() == txtIDStaff.Text
                            select slr;
                DateTime time = (DateTime)dateTimeKeeped.Value;
                string tim = time.ToString("dd/MM/yyyy");

                foreach (var id in query)
                {
                    DateTime timeKeep = (DateTime)id.TimeKeeped;
                    
                    string timeKeepDay = timeKeep.ToString("dd/MM/yyyy");
                    if (timeKeepDay == tim)
                    {
                        throw new Exception("Nhân viên này đã được chấm công ngày hôm nay rồi, vui lòng chọn sửa hoặc chấm công để thay đổi");
                    }
                }

                if(time > timeKeeped)
                {
                    throw new Exception("Ngày chọn chưa đến so với ngày hiện tại");
                }


                Salary sl = new Salary();
                int max = 0;
                DateTime nowDate = DateTime.Now;
                var querySalary = from slr in db.Salaries select slr;
                if(querySalary == null)
                {
                    max = 0;
                }
                else
                {
                    foreach (var sala in querySalary)
                    {
                        if (sala.IdSalary >= max)
                        {
                            max = sala.IdSalary + 1;
                        }
                    }
                }
                
                sl.IdSalary = max;
                sl.IdStaff = int.Parse(txtIDStaff.Text);
                sl.TimeKeeped = dateTimeKeeped.Value;
                sl.WorkingTime = workingTime;
                sl.HoursOverTime = hourOverTime;
                sl.SalaryOver = 25000;
                sl.SalaryOverTime = 35000;
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
                                 where sl.IdSalary == idStaff
                                 select sl).FirstOrDefault();
                if(txtWorkingTime.Text == "" || txtHoursOverTime.Text == "")
                {
                    throw new Exception("Thông tin sửa không được bỏ trống");
                }

                slrSua.WorkingTime = int.Parse(txtWorkingTime.Text);
                slrSua.HoursOverTime = int.Parse(txtHoursOverTime.Text);
                slrSua.TimeKeeped = dateTimeKeeped.Value;

                var query = from slr in db.Salaries
                            where slr.IdStaff.ToString() == idStaff.ToString()
                            select slr;

                foreach (var id in query)
                {
                    DateTime timeKeep = (DateTime)id.TimeKeeped;
                    DateTime timeEdit = (DateTime)dateTimeKeeped.Value;
                    string timeKeepDay = timeKeep.ToString("dd/MM/yyyy");
                    string timeedit = timeEdit.ToString("dd/MM/yyyy");
                    if (timeKeepDay == timeedit)
                    {
                        throw new Exception("Nhân viên này đã được chấm công ngày hôm đó rồi, vui lòng thay đổi");
                    }
                }

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
