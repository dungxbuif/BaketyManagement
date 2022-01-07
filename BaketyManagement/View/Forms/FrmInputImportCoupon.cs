
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
    public partial class FrmInputImportCoupon : Form
    {
        private BakeryManagementContext db = BakeryManagementContext.Instance;
        private int selectedId = -1;
        public FrmInputImportCoupon()
        {
            InitializeComponent();
            cbbNameSupplier.DataSource = db.Suppliers.Select(s => s.NameSupplier).ToList();
            LoadMaterialStore();
        }

        private void LoadMaterialStore()
        {
            dgvCouponImport.DataSource = null;
            var query = from ms in db.MaterialStores
                        join m in db.Materials
                        on ms.IdMaterial equals m.IdMaterial
                        join s in db.Suppliers
                        on m.IdSupplier equals s.IdSupplier
                        select new
                        {
                            ms.IdMaterialStore,
                            m.NameMaterial,
                            s.NameSupplier,
                            ms.Amount
                        };

            dgvCouponImport.DataSource = query.ToList();
            dgvCouponImport.Columns[0].HeaderText = "Mã Nguyên liệu trong kho";
            dgvCouponImport.Columns[1].HeaderText = "Nguyên liệu";
            dgvCouponImport.Columns[1].HeaderText = "Nhà cung cấp";
            dgvCouponImport.Columns[2].HeaderText = "Số lượng";
        }
        private void btnAddImportCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAmountImport.Text == "")
                    throw new Exception("Hãy nhập số lượng");
                var idMaterial = (from m in db.Materials
                                  join s in db.Suppliers
                                  on m.IdSupplier equals s.IdSupplier
                                  where m.NameMaterial == cbbMaterial.Text
                                  where s.NameSupplier == cbbNameSupplier.Text
                                  select m.IdMaterial).FirstOrDefault();
                var exitedMeterial = db.MaterialStores.Where(m => m.IdMaterial == idMaterial).FirstOrDefault();
                if (exitedMeterial != null) throw new Exception("Nguyên liệu đã tồn tại trong kho");

                var materialStore = new MaterialStore();
                var query = db.MaterialStores.Select(c => c).ToList();
                var id = query.Count() + 1;

                materialStore.IdMaterialStore = id;
                materialStore.Amount = Convert.ToInt32(txtAmountImport.Text);
                materialStore.IdMaterial = idMaterial;
                db.MaterialStores.Add(materialStore);

                db.SaveChanges();
                MessageBox.Show("Thêm thành công");
                LoadMaterialStore();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            
        }

        private void cbbNameSupplier_TextChanged(object sender, EventArgs e)
        {
            var query = from material in db.Materials
                        join supplier in db.Suppliers
                        on material.IdSupplier equals supplier.IdSupplier
                        where supplier.NameSupplier == cbbNameSupplier.SelectedValue
                        select material.NameMaterial;
            cbbMaterial.DataSource = query.ToList();  
        }

        private void btnDisplayCouponImport_Click(object sender, EventArgs e)
        {
            LoadMaterialStore();
        }

        private void btnDeleteImportCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedId <= 0)
                    throw new Exception("Hãy chọn một nguyên liệu");
                
                var exitedMeterial = db.MaterialStores.Where(m => m.IdMaterial == selectedId).FirstOrDefault();
                db.MaterialStores.Remove(exitedMeterial);
                db.SaveChanges();

                db.SaveChanges();
                MessageBox.Show("Xóa thành công");
                LoadMaterialStore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCouponImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var row = e.RowIndex;
                if (row < 0 || row == null) return;

                selectedId = Convert.ToInt32(dgvCouponImport.Rows[row].Cells[0].Value);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void btnEditImportCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedId <= 0)
                    throw new Exception("Hãy chọn một nguyên liệu");

                if (txtAmountImport.Text == "")
                    throw new Exception("Hãy nhập số lượng");

                var materialStore = db.MaterialStores.Where(c => c.IdMaterialStore == selectedId).FirstOrDefault();

                materialStore.Amount = Convert.ToInt32(txtAmountImport.Text);
                if (materialStore.Amount < 0)
                    throw new Exception("Số lượng phải lớn hơn hoặc bằng 0");
                
                db.SaveChanges();

                db.SaveChanges();
                MessageBox.Show("Sửa thành công");
                LoadMaterialStore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
