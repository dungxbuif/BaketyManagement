using BaketyManagement.DataModels;
using BaketyManagement.DTO;
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

namespace BaketyManagement
{
    public partial class FrmAccountInfor : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        Account acc = MainDto.accountDto;
        public FrmAccountInfor()
        {
            InitializeComponent();
        }

        private void LoadInfor()
        {
            Account account = MainDto.accountDto;
            txtUserName.Text = account.UserName;
        }

        private void ChangePassword()
        {
            try
            {
                String newPass = txtNewPassword.Text;
                String reenter = txtReEnter.Text;
                if (newPass == "")
                {
                    throw new Exception("Vui lòng nhập mật khẩu mới!");
                }
                if (String.Compare(newPass, reenter, true) != 0)
                {
                    throw new Exception("Mật khẩu không khớp. Vui lòng nhập lại!");
                }
                Account account = MainDto.accountDto;
                Account accSua = (from acc in db.Accounts
                                  where acc.UserName == txtUserName.Text
                                  && acc.Pass == txtPassword.Text
                                  select acc).FirstOrDefault();
                if (accSua != null)
                {
                    accSua.Pass = txtNewPassword.Text;
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                    txtNewPassword.Text = "";
                    txtReEnter.Text = "";
                    txtPassword.Text = "";
                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmAccountInfor_Load(object sender, EventArgs e)
        {
            LoadInfor();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }
    }
}
