
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
    public partial class FrmInforTabStaff : Form
    {
        public static Boolean isAdd;
        public static Int32 idStaff;
        private BakeryManagementContext db = BakeryManagementContext.Instance;
        public FrmInforTabStaff()
        {
            InitializeComponent();
            this.Text = "";
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.TopLevelControl.BackColor = this.BackColor;
            
        }
              
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddStaff();
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            EditStaff();
        }
        private void ClearTextBox()
        {
            txtNameStaff.Clear();
            rdbMan.Checked = true;
            txtPhoneStaff.Clear();
            txtAddressStaff.Clear();
        }
        private void AddStaff()
        {
            try
            {
                var query = from sp in db.staff
                            select sp.IdStaff;
                int dem = 0;
                foreach(var nv in query)
                {
                    if (nv >= dem)
                        dem = nv;
                }
                    string nameStaff = txtNameStaff.Text;
                Boolean gender = false;
                if (rdbMan.Checked)
                    gender = true;
                if (rdbWoman.Checked)
                    gender = false;

                string phoneStaff = txtPhoneStaff.Text;
                string addressStaff = txtAddressStaff.Text;

                if (nameStaff == "")
                    throw new Exception("Cần nhập tên nhân viên");
                if (rdbMan.Checked == false && rdbWoman.Checked == false)
                    throw new Exception("Cần chọn giới tính");
                if (phoneStaff == "")
                    throw new Exception("Cần nhập số điện thoại");
                if (addressStaff == "")
                    throw new Exception("Cần nhập địa chỉ ");

                staff stf = new staff();
                stf.IdStaff = dem+=1;
                stf.NameStaff = nameStaff;
                stf.Gender = gender;
                stf.Phone = phoneStaff;
                stf.Address = addressStaff;
                db.staff.Add(stf);
                db.SaveChanges();
                MessageBox.Show("Thêm nhân viên thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EditStaff()
        {
            try
            {
                staff nvSua = (from stf in db.staff
                               where stf.IdStaff == idStaff
                               select stf).FirstOrDefault();
                String nameStaff = txtNameStaff.Text;
                String phoneStaff = txtPhoneStaff.Text;
                String addressStaff = txtAddressStaff.Text;
                if (nameStaff == "" || phoneStaff == "" || addressStaff == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin nhân viên!");
                }
                Boolean gender = false;
                if (rdbMan.Checked)
                    gender = false;
                if (rdbWoman.Checked)
                    gender = true;
                nvSua.IdStaff = idStaff;
                nvSua.NameStaff = nameStaff;
                nvSua.Gender = gender;
                nvSua.Phone = phoneStaff;
                nvSua.Address = addressStaff;
                db.SaveChanges();
                MessageBox.Show("Sửa nhân viên thành công");
                this.Close();
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
