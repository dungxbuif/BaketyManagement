
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
    public partial class FrmImportCoupon : Form
    {
        private BakeryManagementContext db = BakeryManagementContext.Instance;
        private int idImport = -1;
        public FrmImportCoupon()
        {
            InitializeComponent();
        }

        private void tlpCoupon_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmImportCoupon_Load(object sender, EventArgs e)
        {
            LoadTabImportCoupon();
        }

        private void LoadTabImportCoupon()
        {
            dgvCouponImport.DataSource = null;
            var query = from import in db.Imports
                        join metrial in db.Materials
                        on import.IdMaterial equals metrial.IdMaterial
                        join supplier in db.Suppliers
                        on metrial.IdSupplier equals supplier.IdSupplier
                        select new
                        {
                            import.IdImport,
                            supplier.NameSupplier,
                            import.CreatedAt
                        };

            dgvCouponImport.DataSource = query.ToList();
            dgvCouponImport.Columns[0].HeaderText = "Mã Phiếu";
            dgvCouponImport.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvCouponImport.Columns[2].HeaderText = "Ngày Nhập";
        }

        private void dgvCouponImport_CellClick(object sender, DataGridViewCellEventArgs e)
        {   
            var row = e.RowIndex;
            if (row < 0 || row == null) return;
            idImport = Convert.ToInt32(dgvCouponImport.Rows[row].Cells[0].Value);
            LoadDetailCouponById();
           
        }

        private void LoadDetailCouponById()
        {
            if (idImport < 0)
            {
                dgvDetailCouponImport.DataSource = null;
                return;
            }
            var query = from import in db.Imports
                        where import.IdImport == idImport
                        join metrial in db.Materials
                        on import.IdMaterial equals metrial.IdMaterial
                        select new
                        {
                            metrial.NameMaterial,
                            import.Amount,
                            metrial.Unit,
                            import.Price,
                            totalMoney = import.Price * import.Amount
                        };
            dgvDetailCouponImport.DataSource = query.ToList();
            dgvDetailCouponImport.Columns[0].HeaderText = "Tên Ngyên liệu";
            dgvDetailCouponImport.Columns[1].HeaderText = "Số Lượng Nhập";
            dgvDetailCouponImport.Columns[2].HeaderText = "Đơn vị";
            dgvDetailCouponImport.Columns[3].HeaderText = "Đơn Giá";
            dgvDetailCouponImport.Columns[4].HeaderText = "Tổng Tiền";
        }

        private void btnDisplayCouponImport_Click(object sender, EventArgs e)
        {
            LoadTabImportCoupon();
            dgvDetailCouponImport.DataSource = null;
        }

        private void SearchImportCoupon()
        {
            String keyWord = txtSearchImportCoupon.Text;
            if (keyWord == "")
            {
                MessageBox.Show("Mời nhập tên");
                return;
            }
            LoadImportByText(keyWord);
            LoadImportDetailByText(keyWord);
        }
        private void LoadImportByText(String keyWord)
        {
            dgvDetailCouponImport.DataSource = null;
            var query = from import in db.Imports
                        join metrial in db.Materials
                        on import.IdMaterial equals metrial.IdMaterial
                        join supplier in db.Suppliers
                        on metrial.IdSupplier equals supplier.IdSupplier
                        where supplier.NameSupplier.ToLower().Contains(keyWord.ToLower())
                        select new
                        {
                            import.IdImport,
                            supplier.NameSupplier,
                            import.CreatedAt
                        };

            dgvCouponImport.DataSource = query.ToList();
            dgvCouponImport.Columns[0].HeaderText = "Mã Phiếu";
            dgvCouponImport.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvCouponImport.Columns[2].HeaderText = "Ngày Nhập";
        }

        private void LoadImportDetailByText(String keyWord)
        {
            dgvDetailCouponImport.DataSource = null;

            var query = from import in db.Imports
                        where import.IdImport == idImport
                        join metrial in db.Materials
                        on import.IdMaterial equals metrial.IdMaterial
                        join supplier in db.Suppliers
                        on metrial.IdSupplier equals supplier.IdSupplier
                        where supplier.NameSupplier.ToLower().Contains(keyWord.ToLower())
                        select new
                        {
                            metrial.NameMaterial,
                            import.Amount,
                            metrial.Unit,
                            import.Price,
                            totalMoney = import.Price * import.Amount
                        };
            dgvDetailCouponImport.DataSource = query.ToList();
            dgvDetailCouponImport.Columns[0].HeaderText = "Tên Ngyên liệu";
            dgvDetailCouponImport.Columns[1].HeaderText = "Số Lượng Nhập";
            dgvDetailCouponImport.Columns[2].HeaderText = "Đơn vị";
            dgvDetailCouponImport.Columns[3].HeaderText = "Đơn Giá";
            dgvDetailCouponImport.Columns[4].HeaderText = "Tổng Tiền";
        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchCouponImport_Click(object sender, EventArgs e)
        {
            SearchImportCoupon();
        }

        private void btnFilterCouponImport_Click(object sender, EventArgs e)
        {
            FilterCouponImport();
        }

        private void FilterCouponImport()
        {
            try
            {
                dgvDetailCouponImport.DataSource = null;
                DateTime startDate = dtpStartImportDay.Value;
                DateTime endDate = dtpEndImportDay.Value;
                if (DateTime.Compare(startDate, endDate) < 0)
                {
                    throw new Exception("Vui lòng chọn ngày kết thúc sau hoặc bằng ngày bắt đầu!");
                }
                FilterImportByText(startDate, endDate);
                FilterImportDetailByText(startDate,endDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FilterImportByText(DateTime startDate, DateTime endDate)
        {
            dgvDetailCouponImport.DataSource = null;

            var query = from import in db.Imports
                        where import.CreatedAt >= startDate && import.CreatedAt <= endDate
                        join metrial in db.Materials
                        on import.IdMaterial equals metrial.IdMaterial
                        join supplier in db.Suppliers
                        on metrial.IdSupplier equals supplier.IdSupplier
                        select new
                        {
                            import.IdImport,
                            supplier.NameSupplier,
                            import.CreatedAt
                        };

            dgvCouponImport.DataSource = query.ToList();
            dgvCouponImport.Columns[0].HeaderText = "Mã Phiếu";
            dgvCouponImport.Columns[1].HeaderText = "Tên Nhà Cung Cấp";
            dgvCouponImport.Columns[2].HeaderText = "Ngày Nhập";
        }

        private void FilterImportDetailByText(DateTime startDate, DateTime endDate)
        {
            dgvDetailCouponImport.DataSource = null;

            var query = from import in db.Imports
                        join metrial in db.Materials
                        on import.IdMaterial equals metrial.IdMaterial
                        join supplier in db.Suppliers
                        on metrial.IdSupplier equals supplier.IdSupplier
                        where import.CreatedAt >= startDate && import.CreatedAt <= endDate
                        select new
                        {
                            metrial.NameMaterial,
                            import.Amount,
                            metrial.Unit,
                            import.Price,
                            totalMoney = import.Price * import.Amount
                        };
            dgvDetailCouponImport.DataSource = query.ToList();
            dgvDetailCouponImport.Columns[0].HeaderText = "Tên Ngyên liệu";
            dgvDetailCouponImport.Columns[1].HeaderText = "Số Lượng Nhập";
            dgvDetailCouponImport.Columns[2].HeaderText = "Đơn vị";
            dgvDetailCouponImport.Columns[3].HeaderText = "Đơn Giá";
            dgvDetailCouponImport.Columns[4].HeaderText = "Tổng Tiền";
        }

        private void btnDeleteImportCoupon_Click(object sender, EventArgs e)
        {
              
            try
            {
                if(idImport <= 0)
                    throw new Exception("Hãy chọn phiếu nhập");
                var import = db.Imports.Where(i=>i.IdImport == idImport).FirstOrDefault();
                var materialStore = db.MaterialStores.Where(m => m.IdMaterial == import.IdMaterial).FirstOrDefault();
                if(materialStore.Amount < import.Amount)
                    throw new Exception("Số lượng trong kho nhỏ hơn số lượng phiếu nhập");
                materialStore.Amount -= import.Amount;
                db.Imports.Remove(import);
                db.SaveChanges();
                dgvCouponImport.DataSource = null;
                dgvDetailCouponImport.DataSource = null;
                MessageBox.Show("Xóa thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddImportCoupon_Click(object sender, EventArgs e)
        {
            FrmInforTabImputCouponImport frmImportInfo = new FrmInforTabImputCouponImport();
            frmImportInfo.StartPosition = FormStartPosition.CenterScreen;
            frmImportInfo.ShowDialog();
        }

        private void btnEditImportCoupon_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (idImport <= 0)
                    throw new Exception("Hãy chọn phiếu nhập");

                FrmInforTabImputCouponImport frmImportInfo = new FrmInforTabImputCouponImport(idImport);
                frmImportInfo.StartPosition = FormStartPosition.CenterScreen;
                frmImportInfo.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      
    }
}
