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

namespace BaketyManagement.View.FormInfor
{
    public partial class FrmSumSalaryInfor : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        public static Int32 timeKeepedMonth;
        public static Int32 timeKeepedYear;
        Int32 row = -1;
        public FrmSumSalaryInfor()
        {
            InitializeComponent();
            var query = from slr in db.Salaries
                        select new
                        {
                            slr.IdStaff,
                            nameStaff = (from stf in db.staff
                                         where stf.IdStaff == slr.IdStaff
                                         select stf.NameStaff).FirstOrDefault(),
                            slr.WorkingTime,
                            slr.HoursOverTime,
                            slr.TimeKeeped,
                            slr.SalaryOver,
                            slr.SalaryOverTime,
                        };
            Int32 Tong = 0;
            foreach(var sl in query)
            {
                Int32 timeKeepMonth = sl.TimeKeeped.Value.Month;
                Int32 timeKeepYear = sl.TimeKeeped.Value.Year;
                if (timeKeepMonth == timeKeepedMonth && timeKeepYear == timeKeepedMonth)
                {

                }
            }
            
            dataGridView1.Rows.Add();
            //dataGridView1.Rows[row].Cells[0].Value = sl.IdStaff.ToString();
            //dataGridView1.Rows[row].Cells[1].Value = sl.nameStaff.ToString();
            row++;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
