
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
            try
            {
                string idStaff = txtIDStaff.Text;
                DateTime timeKeeped = DateTime.Now;
                Double salaryDate = Double.Parse(txtSalaryDate.Text);
                int workDay = int.Parse(txtWorkDays.Text);
                int hourOverTime = int.Parse(txtHoursOverTime.Text);
                Double reward = Double.Parse(txtRewards.Text);
                Double salaryOverTime = Double.Parse(txtSalaryOverTime.Text);

                var query = from acc in db.Accounts
                            select acc;
                int dem = 0;
                int checkTk = 0;
                foreach (var acc in query)
                {
                    dem++;
                    if (acc.IdStaff.ToString() == idStaff)
                    {
                        checkTk++;
                    }
                }

                //if (checkTk > 0)
                //    throw new Exception("Tên tài khoản này đã tồn tại");
                //if (userName == "")
                //    throw new Exception("Nhập tên tài khoản cần thêm");
                //if (passWord == "")
                //    throw new Exception("Nhập mật khẩu cần thêm");
                //if (idStaff < 0)
                //    throw new Exception("Chọn nhân viên cho tài khoản cần thêm");

                //if (checkAcc())
                //{
                //    Account acc = new Account();
                //    acc.IdStaff = idStaff;
                //    acc.UserName = userName;
                //    if (staff == true)
                //    {
                //        acc.TypeAccount = false;
                //    }
                //    else
                //    {
                //        acc.TypeAccount = true;
                //    }
                //    acc.Pass = passWord;
                //    db.Accounts.Add(acc);
                //    db.SaveChanges();

                //    DialogResult result = MessageBox.Show("Thêm tài khoản thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    if (result == DialogResult.OK)
                //        this.Close();
                //}
                //else
                //    throw new Exception("Nhân viên này đã có tài khoản");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
