
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

namespace BaketyManagement.View
{
    public partial class FrmInforTabImputCouponImport : Form
    {
        private BakeryManagementContext db = BakeryManagementContext.Instance;
        public Int32 idImport = -1;
        public FrmInforTabImputCouponImport()
        {
            InitializeComponent();
            cbbNameSupplier.DataSource = db.Suppliers.Select(s => s.NameSupplier).ToList();
            var query = db.Imports.Select(c => c);
            var count  = query.Count() + 1;
            txtId.Text = count.ToString();
            Importer.Text = db.staff.Where(s=> s.IdStaff == MainDto.accountDto.IdStaff).FirstOrDefault().NameStaff;
        }
        public FrmInforTabImputCouponImport(Int32 IdImport, string importer)
        {
            InitializeComponent();
            btnAddImportCoupon.Text = "Sửa";
            Importer.Text = importer;
            idImport = IdImport;
            txtId.Text = idImport.ToString();
            var import = db.Imports.Where(i => i.IdImport == idImport).FirstOrDefault();
            var query = (from metrial in db.Materials
                         where import.IdMaterial == metrial.IdMaterial
                         join supplier in db.Suppliers
                         on metrial.IdSupplier equals supplier.IdSupplier
                         select new
                         {
                             material = metrial.NameMaterial,
                             supplier = supplier.NameSupplier
                         }).FirstOrDefault();
            cbbMaterial.SelectedItem = query.material;
            cbbNameSupplier.SelectedItem = query.material;
            txtAmountImport.Text = import.Amount.ToString();
            txtImportPrice.Text = import.Price.ToString();
        }


        private void btnAddImportCoupon_Click(object sender, EventArgs e)
        {
            try
            {
                if (idImport == -1)
                {
                    if (txtImportPrice.Text == "" || txtAmountImport.Text == "")
                        throw new Exception("Hãy nhập đủ các trường");
                    var import = new Import();
                    var material = db.Materials.Where(m => m.NameMaterial == cbbMaterial.Text).FirstOrDefault();
                    var materialStore = db.MaterialStores.Where(m => m.IdMaterial == material.IdMaterial).FirstOrDefault();

                    import.IdImport = Convert.ToInt32(txtId.Text);
                    import.Price = Convert.ToDouble(txtImportPrice.Text);
                    import.Amount = Convert.ToDouble(txtAmountImport.Text);
                    import.CreatedAt = dtpDayImport.Value;
                    import.IdMaterial = material.IdMaterial;
                    import.Importer = Importer.Text;
                    if (materialStore == null)
                    {
                        materialStore = new MaterialStore();
                        materialStore.IdMaterialStore = db.Materials.Select(c => c).ToList().Count() + 1;
                        materialStore.IdMaterial = material.IdMaterial;
                        materialStore.Amount = import.Amount;
                        
                    } else
                    {
                        materialStore.Amount += import.Amount;
                    }

                        

                    db.Imports.Add(import);

                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công");
                }
                else
                {
                    if (txtImportPrice.Text == "" || txtAmountImport.Text == "")
                        throw new Exception("Hãy nhập đủ các trường");
                    var import = db.Imports.Where(i => i.IdImport == idImport).FirstOrDefault();
                    var materialStore = db.MaterialStores.Where(m => m.IdMaterial == import.IdMaterial).FirstOrDefault();

                    var editAmount = Convert.ToDouble(txtAmountImport.Text) - import.Amount;

                    if (materialStore.Amount + editAmount < 0)
                        throw new Exception("Số lượng trong kho không đủ");

                    import.Price = Convert.ToDouble(txtImportPrice.Text);
                    import.Amount = Convert.ToDouble(txtAmountImport.Text);
                    import.CreatedAt = dtpDayImport.Value;
                    materialStore.Amount += editAmount;

                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
