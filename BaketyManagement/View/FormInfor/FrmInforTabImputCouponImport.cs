
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
        public static Int32 idCake = 0;
        public static Int32 idSupplierPresent;
        public static Int32 couponDetailRows;
        public static Int32 idCouponDetail;
        public static Int32 rowDetailCoupon;
        public static Boolean isAdd;
        public static Boolean isCancel = false;
        private Int32 amount;


        public int Amount { get => amount; set => amount = value; }

        public FrmInforTabImputCouponImport()
        {
            InitializeComponent();
        }
         
    }
}
