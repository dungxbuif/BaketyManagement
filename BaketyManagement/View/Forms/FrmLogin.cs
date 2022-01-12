//using BaketyManagement.DAO;
using BaketyManagement.DataModels;
using BaketyManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp13212.Models;

namespace BaketyManagement
{
    public partial class FrmLogin : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            Account acc = (from sp in db.Accounts
                          where sp.UserName == txtUserName.Text
                          && sp.Pass == txtPassword.Text
                          select sp).FirstOrDefault();
            try
            {
                String user = txtUserName.Text;
                String pass = txtPassword.Text;
                if (user == "" || pass == "")
                    throw new Exception("Vui lòng nhập đầy đủ thông tin đăng nhập!");

                if (acc == null)
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không đúng!");

                FrmMain frmMain = new FrmMain();
                MainDto.accountDto = acc;

                frmMain.Tag = acc;
                this.Hide();
                frmMain.ShowDialog();
                this.Show();
                txtPassword.Clear();
                txtUserName.Clear();
                txtUserName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
