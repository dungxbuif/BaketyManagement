
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
            try
            {
                row = 0;
                Int32 idStaff = Convert.ToInt32(dgvTimeKeeping.Rows[row].Cells[0].Value);
                FrmInforSalary frmInforSalary = new FrmInforSalary();
                FrmInforSalary.idStaff = idStaff;
                FrmInforSalary.checkSender = 3;
                frmInforSalary.ShowDialog();
                LoadSalary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
