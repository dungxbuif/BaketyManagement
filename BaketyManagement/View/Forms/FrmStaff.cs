
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

namespace BaketyManagement.View.Forms
{
    public partial class FrmStaff : Form
    {
        BakeryManagementContext db = new BakeryManagementContext();
        private Int32 row;
        public FrmStaff()
        {
            InitializeComponent();
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            HienThi();
        }
        private void HienThi()
        {
            row = 0;
            var query = from sp in db.staff
                        select new
                        {
                            sp.IdStaff,
                            sp.NameStaff,
                            sp.Gender,
                            sp.Phone,
                            sp.Address
                        };
            dgvStaff.Rows.Clear();
            foreach(var stf in query)
            {
                dgvStaff.Rows.Add();
                dgvStaff.Rows[row].Cells[0].Value = stf.IdStaff.ToString();
                dgvStaff.Rows[row].Cells[1].Value = stf.NameStaff.ToString();
                if (stf.Gender == true)
                    dgvStaff.Rows[row].Cells[2].Value = "Nam";
                else
                    dgvStaff.Rows[row].Cells[2].Value = "Nữ";
                dgvStaff.Rows[row].Cells[3].Value = stf.Phone.ToString();
                dgvStaff.Rows[row].Cells[4].Value = stf.Address.ToString();
                row++;
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnDisplayStaff_Click(object sender, EventArgs e)
        {
            HienThi();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            AddStaff();
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            EditStaff();
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            DeletedStaff();
        }

        private void btnStaffSearch_Click(object sender, EventArgs e)
        {
            SearchStaff();
        }

        private void AddStaff()
        {
            try
            {
                FrmInforTabStaff.isAdd = true;
                FrmInforTabStaff frm = new FrmInforTabStaff();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                HienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DeletedStaff()
        {
            try
            {
                if (row < 0)
                    throw new Exception("Chọn nhân viên cần xóa");
                Int32 idStaff = Int32.Parse(dgvStaff.Rows[row].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa nhân viên có mã " + dgvStaff.Rows[row].Cells[0].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    staff nvXoa = (from sp in db.staff
                                   where sp.IdStaff == idStaff
                                   select sp).FirstOrDefault();
                    db.staff.Remove(nvXoa);
                    db.SaveChanges();
                    row--;
                    MessageBox.Show("Xóa nhân viên thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SearchStaff()
        {
            try
            {
                string nameStaff = txtStaffSearch.Text;
                if (nameStaff == "")
                    throw new Exception("Nhập tên nhân viên cần tìm");
                else
                {
                    dgvStaff.Rows.Clear();
                    var nvTim = from sp in db.staff
                                select sp;
                    row = 0;
                    foreach (var stf in nvTim)
                    {
                        if (stf.NameStaff.Contains(nameStaff))
                        {
                            dgvStaff.Rows.Add();
                            dgvStaff.Rows[row].Cells[0].Value = stf.IdStaff.ToString();
                            dgvStaff.Rows[row].Cells[1].Value = stf.NameStaff.ToString();
                            if (stf.Gender == true)
                                dgvStaff.Rows[row].Cells[2].Value = "Nam";
                            else
                                dgvStaff.Rows[row].Cells[2].Value = "Nữ";
                            dgvStaff.Rows[row].Cells[3].Value = stf.Phone.ToString();
                            dgvStaff.Rows[row].Cells[4].Value = stf.Address.ToString();
                            row++;
                        }
                    }
                }
                if (dgvStaff.Rows.Count <= 0)
                {
                    throw new Exception("Không tồn tại nhân viên có tên " + nameStaff + "!");
                }
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
                if (row < 0 || dgvStaff.Rows[row].Cells[0].Value == null)
                    throw new Exception("Chọn nhân viên cần sửa");
                FrmInforTabStaff.isAdd = false;
                FrmInforTabStaff.idStaff = Int32.Parse(dgvStaff.Rows[row].Cells[0].Value.ToString());
                FrmInforTabStaff frm = new FrmInforTabStaff();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                HienThi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
