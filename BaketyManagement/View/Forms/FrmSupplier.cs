
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
    public partial class FrmSupplier : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        private Int32 row = 0;
        public FrmSupplier()
        {
            InitializeComponent();
        }

        private void FrmSupplier_Load(object sender, EventArgs e)
        {
            LoadTabSupplier();
        }

        private void btnViewSupplier_Click(object sender, EventArgs e)
        {
            LoadTabSupplier();
        }

        private void LoadTabSupplier()
        {
            row = 0;
            var query = from spl in db.Suppliers
                        select spl;
            dgvSupplier.Rows.Clear();
            foreach (var sp in query)
            {
                dgvSupplier.Rows.Add();
                dgvSupplier.Rows[row].Cells[0].Value = sp.IdSupplier.ToString();
                dgvSupplier.Rows[row].Cells[1].Value = sp.NameSupplier.ToString();
                dgvSupplier.Rows[row].Cells[2].Value = sp.Phone.ToString();
                dgvSupplier.Rows[row].Cells[3].Value = sp.Address.ToString();
                row++;
            }
        }

        public void addSupplier()
        {
            try
            {
                FrmInforTabProvider.isAdd = true;
                FrmInforTabProvider frm = new FrmInforTabProvider();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadTabSupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void editSupplier()
        {
            try
            {
                var query = from sp in db.Suppliers select sp;
                FrmInforTabProvider.isAdd = false;
                int dem = 0;
                foreach (var spp in query)
                {
                    dem++;
                }
                if (dem > 0)
                {
                    if (dgvSupplier.Rows[row].Cells[0].Value == null)
                        throw new Exception("Chưa chọn nhà cung cấp");
                    FrmInforTabProvider.id = Int32.Parse(dgvSupplier.Rows[row].Cells[0].Value.ToString());
                    FrmInforTabProvider.name = dgvSupplier.Rows[row].Cells[1].Value.ToString();
                    FrmInforTabProvider.phone = dgvSupplier.Rows[row].Cells[2].Value.ToString();
                    FrmInforTabProvider.address = dgvSupplier.Rows[row].Cells[3].Value.ToString();
                }
                FrmInforTabProvider frm = new FrmInforTabProvider();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadTabSupplier();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteSupplier()
        {
            try
            {
                if (dgvSupplier.Rows[row].Cells[0].Value == null)
                    throw new Exception("Chưa chọn nhà cung cấp");
                Int32 idSupplier = Int32.Parse(dgvSupplier.Rows[row].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa nhà cung cấp tên " + dgvSupplier.Rows[row].Cells[1].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Supplier sup = (from sp in db.Suppliers
                                    where sp.IdSupplier == idSupplier
                                    select sp).FirstOrDefault();
                    db.Suppliers.Remove(sup);
                    db.SaveChanges();
                    row--;
                    MessageBox.Show("Xóa nhà cung cấp thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTabSupplier();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void searchSupplier()
        {
            try
            {
                string supName = txtSearchKeySupplier.Text;
                if (supName == "")
                    throw new Exception("Nhập tên nhà cung cấp cần tìm");
                else
                {
                    dgvSupplier.Rows.Clear();
                    var supTim = from nv in db.Suppliers select nv;
                    row = 0;
                    foreach (var sp in supTim)
                    {
                        if (sp.NameSupplier.Contains(supName))
                        {
                            dgvSupplier.Rows.Add();
                            dgvSupplier.Rows[row].Cells[0].Value = sp.IdSupplier.ToString();
                            dgvSupplier.Rows[row].Cells[1].Value = sp.NameSupplier.ToString();
                            dgvSupplier.Rows[row].Cells[2].Value = sp.Phone.ToString();
                            dgvSupplier.Rows[row].Cells[3].Value = sp.Address.ToString();
                            row++;
                        }
                    }
                }
                if (dgvSupplier.Rows.Count <= 0)
                {
                    throw new Exception("Không tồn tại nhân viên có tên " + supName + "!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            addSupplier();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            editSupplier();
        }

        private void btnDelSupplier_Click(object sender, EventArgs e)
        {
            deleteSupplier();
        }

        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            searchSupplier();
        }
    }

}
