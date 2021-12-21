
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

namespace BaketyManagement.View
{
    public partial class FrmInforTabAccount : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        public static Int32 row;
        public FrmInforTabAccount()
        {
            InitializeComponent();
            this.Text = "";
            cbbListStaff.DataSource = db.staff.ToList();
            cbbListStaff.DisplayMember = "nameStaff";
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbListStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdStaffAccount.Text = (cbbListStaff.SelectedItem as staff).IdStaff.ToString();
        }

        private Boolean checkAcc()
        {
            var query = from acc in db.Accounts
                        select acc;
            foreach(var acc in query)
            {
                if(acc.IdStaff == (cbbListStaff.SelectedItem as staff).IdStaff)
                {
                    return false;
                }
            }
            return true;
        }

        private void AddAnAcount()
        {
            try
            {
                string userName = txtUserName.Text;
                string passWord = txtPassword.Text;
                Boolean staff = ckbStaff.Checked;
                int idStaff = (cbbListStaff.SelectedItem as staff).IdStaff;

                var query = from acc in db.Accounts
                            select acc;
                int dem = 0;
                int checkTk = 0;
                foreach (var acc in query)
                {
                    dem++;
                    if(acc.UserName == userName)
                    {
                        checkTk++;
                    }
                }
                    
                if (checkTk > 0)
                    throw new Exception("Tên tài khoản này đã tồn tại");
                if (userName == "")
                    throw new Exception("Nhập tên tài khoản cần thêm");
                if (passWord == "")
                    throw new Exception("Nhập mật khẩu cần thêm");
                if (idStaff < 0)
                    throw new Exception("Chọn nhân viên cho tài khoản cần thêm");

                if (checkAcc())
                {
                    Account acc = new Account();
                    acc.IdStaff = idStaff;
                    acc.UserName = userName;
                    if (staff == true)
                    {
                        acc.TypeAccount = false;
                    }
                    else
                    {
                        acc.TypeAccount = true;
                    }
                    acc.Pass = passWord;
                    db.Accounts.Add(acc);
                    db.SaveChanges();

                    DialogResult result = MessageBox.Show("Thêm tài khoản thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                        this.Close();
                }
                else
                    throw new Exception("Nhân viên này đã có tài khoản");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAnAcount();
        }
    }
}
