
using BaketyManagement.DataModels;
using BaketyManagement.View.FormInfor;
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
    public partial class FrmTimeKeeping : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        Int32 row = -1;
        public FrmTimeKeeping()
        {
            InitializeComponent();
        }

        private void tlpTimeKeeping_Paint(object sender, PaintEventArgs e)
        {
            FrmMain.ShadowPanel(sender, e);
        }

        private void FrmTimeKeeping_Load(object sender, EventArgs e)
        {
            LoadSalary();
        }

        private void LoadSalary()
        {
            dgvTimeKeeping.Rows.Clear();
            row = 0;
            var query = from slr in db.Salaries
                        select new
                        { 
                            slr.IdStaff,
                            nameStaff = (from stf in db.staff
                                         where stf.IdStaff == slr.IdStaff
                                         select stf.NameStaff).FirstOrDefault(),
                            slr.TimeKeeped,
                            slr.SalaryDate,
                            slr.WorkDay,
                            slr.HoursOverTime,
                            slr.Rewards,
                            slr.SalaryOverTime,
                        };
            foreach (var slr in query)
            {
                DateTime timekeep = (DateTime)slr.TimeKeeped;
                dgvTimeKeeping.Rows.Add();
                dgvTimeKeeping.Rows[row].Cells[0].Value = slr.IdStaff.ToString();
                dgvTimeKeeping.Rows[row].Cells[1].Value = slr.nameStaff.ToString();
                dgvTimeKeeping.Rows[row].Cells[2].Value = timekeep.ToString("dd/MM/yyyy");
                dgvTimeKeeping.Rows[row].Cells[3].Value = slr.SalaryDate.ToString();
                dgvTimeKeeping.Rows[row].Cells[4].Value = slr.WorkDay.ToString();
                dgvTimeKeeping.Rows[row].Cells[5].Value = slr.HoursOverTime.ToString();
                dgvTimeKeeping.Rows[row].Cells[6].Value = slr.Rewards.ToString();
                dgvTimeKeeping.Rows[row].Cells[7].Value = slr.SalaryOverTime.ToString();
                row++;
            }
        }

        private void btnAddSalary_Click(object sender, EventArgs e)
        {
            addSalary();
        }

        private void addSalary()
        {
            try
            {
                row = 0;
                Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
                FrmInforSalary.idStaff = idStaff;
                FrmInforSalary.checkSender = 2;
                FrmInforSalary frmInforSalary = new FrmInforSalary();
                frmInforSalary.ShowDialog();
                LoadSalary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimeKeeping_Click(object sender, EventArgs e)
        {
            
        }

        private void editSalary()
        {
            try
            {
                if (row < 0 || row >= dgvTimeKeeping.Rows.Count - 1)
                {
                    throw new Exception("Vui lòng chọn nhân viên cần cập nhật!");
                }
                Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
                FrmInforSalary.idStaff = idStaff;
                FrmInforSalary.checkSender = 1;
                FrmInforSalary frmInforSalary = new FrmInforSalary();
                frmInforSalary.ShowDialog();
                LoadSalary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTimeKeeping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnEditSalary_Click(object sender, EventArgs e)
        {
            editSalary();
        }

        private void btnCancelTimeKeeping_Click(object sender, EventArgs e)
        {
            Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
            Salary slXoa = (from sl in db.Salaries
                            where sl.IdStaff == idStaff
                            select sl).FirstOrDefault();
            db.Salaries.Remove(slXoa);
            db.SaveChanges();
            row--;
            MessageBox.Show("Xóa chấm công thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadSalary();
        }
    }
}
