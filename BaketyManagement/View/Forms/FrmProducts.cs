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
    public partial class FrmProducts : Form
    {
        Int32 row;
      
        BakeryManagementContext db = new BakeryManagementContext();
        
        public FrmProducts()
        {
            InitializeComponent();
        }

        private void FrmProducts_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }
        private void LoadProduct()
        {
            row = 0;
            var query = from c in db.Cakes
                        select new
                        {
                            c.IdCake,
                            c.IdRecipe,
                            c.Price,
                            c.Amount,
                            c.ExpCake,
                            c.MfgCake
                        };
            dgvCake.Rows.Clear();
            foreach (var cake in query)
            {
                dgvCake.Rows.Add();
                dgvCake.Rows[row].Cells[0].Value = cake.IdCake.ToString();
                dgvCake.Rows[row].Cells[1].Value = cake.IdRecipe.ToString();
                dgvCake.Rows[row].Cells[2].Value = cake.Price.ToString();
                dgvCake.Rows[row].Cells[3].Value = cake.Amount.ToString();
                string dateex= String.Format("{0:dd-MM-yyyy}", cake.MfgCake);
                string datemfg = String.Format("{0:dd-MM-yyyy}", cake.ExpCake);
                dgvCake.Rows[row].Cells[5].Value = dateex;
                dgvCake.Rows[row].Cells[6].Value = datemfg;
                row++;
               
            }
            for(int i = 0; i< row;i++)
            {
                int id = int.Parse(dgvCake.Rows[i].Cells[1].Value.ToString());
                dgvCake.Rows[i].Cells[1].Value = Find_NameCake(id);
            }

        }
        private string Find_NameCake(int id)
        {
            var query = from c in db.Recipes where (c.IdRecipe == id) select c;
            Recipe recipe = query.FirstOrDefault();
            return recipe.NameCake.ToString();
        }

        private void btnCakeDisplay_Click(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnCakeSearch_Click(object sender, EventArgs e)
        {
            row = -1;
            Search();
        }
        private void Search()
        {
            try
            {
                String keyWord = txtCakeSearch.Text;
                if (keyWord == "")
                    throw new Exception("Nhập từ khóa tìm kiếm");
                else
                {
                    row = 0;
                    var queryR = from c in db.Recipes where (c.NameCake.Equals(keyWord)) select c;
                    Recipe recipe = queryR.FirstOrDefault();
                    if(recipe == null)
                    {
                        throw new Exception("Không có loại bánh này");
                    }
                    var queryC = from c in db.Cakes select c;

                    dgvCake.Rows.Clear();
                    foreach (var cake in queryC)
                    {
                        if(cake.IdRecipe == recipe.IdRecipe)
                        {
                            dgvCake.Rows.Add();
                            dgvCake.Rows[row].Cells[0].Value = cake.IdCake.ToString();
                            dgvCake.Rows[row].Cells[1].Value = cake.IdRecipe.ToString();
                            dgvCake.Rows[row].Cells[2].Value = cake.Price.ToString();
                            dgvCake.Rows[row].Cells[3].Value = cake.Amount.ToString();
                            dgvCake.Rows[row].Cells[5].Value = cake.MfgCake.ToString();
                            dgvCake.Rows[row].Cells[6].Value = cake.ExpCake.ToString();
                            row++;
                        }

                    }
                    for (int i = 0; i < row; i++)
                    {
                        int id = int.Parse(dgvCake.Rows[i].Cells[1].Value.ToString());
                        dgvCake.Rows[i].Cells[1].Value = Find_NameCake(id);
                    }
                }
                if (dgvCake.Rows.Count <= 1)
                {
                    MessageBox.Show("Không tồn tại sản phẩm nào có tên " + keyWord + "!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCakeDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (row < 0)
                    throw new Exception("Chọn loại bánh cần xóa");
                Int32 idCake = Int32.Parse(dgvCake.Rows[row].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa loại bánh có mã " + dgvCake.Rows[row].Cells[0].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var query = from sp in db.Cakes where (sp.IdCake == idCake) select sp;
                    Cake cake = query.FirstOrDefault();
                    db.Cakes.Remove(cake);
                    db.SaveChanges();
                    LoadProduct();
                    MessageBox.Show("Xóa thành công");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCakeEdit_Click(object sender, EventArgs e)
        {

            try
            {
                if (row < 0)
                    throw new Exception("Chọn bánh cần sửa");
                FrmInforTabProduct.id = Int32.Parse(dgvCake.Rows[row].Cells[0].Value.ToString());
                FrmInforTabProduct.name = dgvCake.Rows[row].Cells[1].Value.ToString();
                FrmInforTabProduct frm = new FrmInforTabProduct();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCake_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }
    }
}
