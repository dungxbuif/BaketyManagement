
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

namespace BaketyManagement.View.Forms
{
    public partial class FrmAccount : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        private Int32 row;
        public FrmAccount()
        {
            InitializeComponent();
        }

        private void LoadTabAccount()
        {
            row = 0;
            var query = from acc in db.Accounts
                        select new
                        {
                            nameStaff = (from stf in db.staff
                                         where stf.IdStaff == acc.IdStaff
                                         select stf.NameStaff).FirstOrDefault(),
                            acc.UserName,
                            acc.TypeAccount,
                        };
            dgvAccount.Rows.Clear();
            foreach (var acc in query)
            {
                dgvAccount.Rows.Add();
                dgvAccount.Rows[row].Cells[0].Value = acc.nameStaff.ToString();
                dgvAccount.Rows[row].Cells[1].Value = acc.UserName.ToString();
                if (acc.TypeAccount == true)
                    dgvAccount.Rows[row].Cells[2].Value = "Staff";
                else
                    dgvAccount.Rows[row].Cells[2].Value = "Admin";
                row++;
            }
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            LoadTabAccount();
        }

        public void AddAccount()
        {
            try
            {
                FrmInforTabAccount frmAccount = new FrmInforTabAccount();
                FrmInforTabAccount.row = row;
                frmAccount.StartPosition = FormStartPosition.CenterScreen;
                frmAccount.ShowDialog();
                LoadTabAccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAccount();
        }

        public void DeleteAccount()
        {
            try
            {
                string userName = dgvAccount.Rows[row].Cells[1].Value.ToString();
                if (row < 0 || userName == null)
                    throw new Exception("Vui lòng chọn tài khoản cần xóa!");
                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa tài khoản có tên " + dgvAccount.Rows[row].Cells[0].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Account nvXoa = (from nv in db.Accounts
                                   where nv.UserName == userName
                                   && nv.TypeAccount == true
                                   select nv).FirstOrDefault();
                    db.Accounts.Remove(nvXoa);
                    db.SaveChanges();
                    row--;
                    MessageBox.Show("Xóa tài khoản thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTabAccount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteAccount();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        public void SearchAccount()
        {
            try
            {
                string userName = txtAccountSearch.Text;
                if (userName == "")
                    throw new Exception("Nhập tên nhân viên cần tìm");
                else
                {
                    dgvAccount.Rows.Clear();
                    var accTim = from nv in db.staff
                                 where nv.NameStaff == userName
                                 select new
                                 {
                                     nv.NameStaff,
                                     userName = (from acc in db.Accounts
                                                 where acc.IdStaff == nv.IdStaff
                                                 select acc.UserName).FirstOrDefault(),
                                     typeAccount = (from acc in db.Accounts
                                                    where acc.IdStaff == nv.IdStaff
                                                    select acc.TypeAccount).FirstOrDefault(),
                                 };
                    row = 0;
                    foreach (var acc in accTim)
                    {
                        if(acc.NameStaff.Contains(userName))
                        {
                            dgvAccount.Rows.Add();
                            dgvAccount.Rows[row].Cells[0].Value = acc.NameStaff.ToString();
                            dgvAccount.Rows[row].Cells[1].Value = acc.userName.ToString();
                            if (acc.typeAccount == false)
                                dgvAccount.Rows[row].Cells[2].Value = "Admin";
                            else
                                dgvAccount.Rows[row].Cells[2].Value = "Member";
                            row++;
                        }
                    }
                }
                if (dgvAccount.Rows.Count <= 0)
                {
                    throw new Exception("Không tồn tại nhân viên có tên " + userName + "!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAccount();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            LoadTabAccount();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetPassword();
        }

        public void resetPassword()
        {
            try
            {
                string userName = dgvAccount.Rows[row].Cells[1].Value.ToString();
                if (row < 0 || userName == null)
                    throw new Exception("Vui lòng chọn tài khoản cần đặt lại mật khẩu!");
                DialogResult result = MessageBox.Show("Bạn thực sự muốn đặt lại mật khẩu cho tài khoản có tên " + dgvAccount.Rows[row].Cells[0].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Account nvXoa = (from nv in db.Accounts
                                     where nv.UserName == userName
                                     select nv).FirstOrDefault();
                    nvXoa.Pass = "123";
                    db.SaveChanges();
                    row--;
                    MessageBox.Show("Reset tài khoản thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTabAccount();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
