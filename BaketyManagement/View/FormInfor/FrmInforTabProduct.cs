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

namespace BaketyManagement.View
{
    public partial class FrmInforTabProduct : Form
    {
        BakeryManagementContext db = new BakeryManagementContext();
        public static Int32 id;
        public static string name;

        public FrmInforTabProduct()
        {
            InitializeComponent();
            txtNameCake.Enabled = false;
            LoadTextBox();
        }
        private void LoadTextBox()
        {
            var query = from sp in db.Cakes where (sp.IdCake == id) select sp;
            Cake cake = query.FirstOrDefault();
            txtNameCake.Text = name;
            txtPrice.Text = cake.Price.ToString();
            txtSize.Text = cake.Size.ToString();
            txtSoLuongCon.Text = cake.Amount.ToString();
            dtpNgayRaLo.Value = cake.MfgCake.Value;
            dtpNgayHetHan.Value = cake.ExpCake.Value;
        }

        private void btnCakeEdit_Click(object sender, EventArgs e)
        {
            EditCake();
        }
        private void EditCake()
        {
            try
            {
                if (txtSoLuongCon.Text == "")
                    throw new Exception("Cần ghi số lượng!");
                if (txtPrice.Text == "")
                    throw new Exception("Cần ghi giá!");
                double price = double.Parse(txtPrice.Text);
                String size = txtSize.Text;
                double amount = double.Parse(txtSoLuongCon.Text);
                int year1 = DateTime.Now.Year - dtpNgayRaLo.Value.Year;
                int month1 = DateTime.Now.Month - dtpNgayRaLo.Value.Month;
                int Day1 = DateTime.Now.Day - dtpNgayRaLo.Value.Day;
                int year2 = DateTime.Now.Year - dtpNgayHetHan.Value.Year;
                int month2 = DateTime.Now.Month - dtpNgayHetHan.Value.Month;
                int day2 = DateTime.Now.Day - dtpNgayHetHan.Value.Day;
                
                if (price < 0)
                    throw new Exception("Giá bánh phải lớn hơn 0!");
                if (amount < 0)
                    throw new Exception("Số lượng phải lớn hơn 0!");
                if (size == "")
                    throw new Exception("Cần ghi size bánh!");
                if(year1 > 0 || month1 >0 || Day1 > 0)
                    throw new Exception("Ngày ra lò phải trước hôm nay!");
                if (year1 > year2 || month1 > month2 || Day1 > day2)
                    throw new Exception("Ngày ra lò không được lớn hơn ngày hết hạn!");
                else
                {
                    var query = from sp in db.Cakes where (sp.IdCake == id) select sp;
                    Cake cake = query.FirstOrDefault();
                    cake.Price = float.Parse(txtPrice.Text.ToString());
                    cake.Amount = int.Parse(txtSoLuongCon.Text.ToString());
                    cake.Size = txtSize.Text.ToString();
                    cake.MfgCake = dtpNgayRaLo.Value;
                    cake.ExpCake = dtpNgayRaLo.Value;
                    db.SaveChanges();
                    MessageBox.Show("Sửa thành công");
                    this.Close();
                }
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
    }
}
