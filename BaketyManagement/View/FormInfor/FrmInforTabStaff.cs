
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
        public FrmInforTabStaff()
        {
            InitializeComponent();
            this.Text = "";
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.TopLevelControl.BackColor = this.BackColor;
            
        }
       

        
    }
}
