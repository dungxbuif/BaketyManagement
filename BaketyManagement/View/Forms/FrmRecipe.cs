using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaketyManagement.DataModels;
using BaketyManagement.View.FormInfor;

namespace BaketyManagement.View.Forms
{
    public partial class FrmRecipe : Form
    {
        Int32 row,rowDetail;
        BakeryManagementContext db = new BakeryManagementContext();
        public FrmRecipe()
        {
            InitializeComponent();
        }
        private void LoadTabRecipe()
        {
            row = 0;
            var query = from c in db.Recipes
                        select new
                        {
                            c.IdRecipe,
                            c.IdCategory,
                            c.NameCake,
                            c.Price
                        };
            dgvRecipe.Rows.Clear();
            foreach (var c in query)
            {
                dgvRecipe.Rows.Add();
                dgvRecipe.Rows[row].Cells[0].Value = c.IdRecipe.ToString();
                dgvRecipe.Rows[row].Cells[1].Value = c.IdCategory.ToString();
                dgvRecipe.Rows[row].Cells[2].Value = c.NameCake.ToString();
                dgvRecipe.Rows[row].Cells[3].Value = c.Price.ToString();
                row++;
            }
            for (int i = 0; i < row; i++)
            {
                int id = int.Parse(dgvRecipe.Rows[i].Cells[1].Value.ToString());
                dgvRecipe.Rows[i].Cells[1].Value = Find_NameCategories(id);
            }

        }
        private string Find_NameCategories(int id)
        {
            var query = from c in db.Categories where (c.IdCategory == id) select c;
            Category cate = query.FirstOrDefault();
            return cate.NameCategory.ToString();
        }

        private void FrmRecipe_Load(object sender, EventArgs e)
        {
            LoadTabRecipe();
        }

        private void dgvRecipe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            int idRecipe = int.Parse(dgvRecipe.Rows[row].Cells[0].Value.ToString());
            LoadTabDetails(idRecipe);
        }

        private void btnRecipeDisplay_Click(object sender, EventArgs e)
        {
            LoadTabRecipe();
        }

        private void LoadTabDetails(int idRecipe)
        {
            rowDetail = 0;
            var q = from c in db.RecipeDetails where (c.IdRecipe == idRecipe)
                        select new
                        {
                            c.IdMaterial,
                            c.Amount     
                        };
            dgvDetail.Rows.Clear();
            foreach (var c in q)
            {
                dgvDetail.Rows.Add();
                dgvDetail.Rows[rowDetail].Cells[0].Value = c.IdMaterial.ToString();
                dgvDetail.Rows[rowDetail].Cells[1].Value = c.Amount.ToString();          
                rowDetail++;
            }
            for (int i = 0; i < rowDetail; i++)
            {
                int id = int.Parse(dgvRecipe.Rows[i].Cells[0].Value.ToString());
                dgvDetail.Rows[i].Cells[0].Value = Find_NameMaterial(id);
            }
        }

        private void btnRecipeSearch_Click(object sender, EventArgs e)
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

                    var query = from ct in db.Recipes where (ct.NameCake.Contains(keyWord)) select ct;
                    dgvRecipe.Rows.Clear();
                    foreach (var c in query)
                    {
                        dgvRecipe.Rows.Add();
                        dgvRecipe.Rows[row].Cells[0].Value = c.IdRecipe.ToString();
                        dgvRecipe.Rows[row].Cells[1].Value = c.IdCategory.ToString();
                        dgvRecipe.Rows[row].Cells[2].Value = c.NameCake.ToString();
                        dgvRecipe.Rows[row].Cells[3].Value = c.Price.ToString();
                        row++;
                    }
                    for (int i = 0; i < row; i++)
                    {
                        int id = int.Parse(dgvRecipe.Rows[i].Cells[1].Value.ToString());
                        dgvRecipe.Rows[i].Cells[1].Value = Find_NameCategories(id);
                    }
                }
                if (dgvRecipe.Rows.Count <= 1)
                {
                    MessageBox.Show("Không tồn tại sản phẩm nào có tên " + keyWord + "!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string Find_NameMaterial(int id)
        {
            var query = from c in db.Materials where (c.IdMaterial == id) select c;
            Material mater = query.FirstOrDefault();
            return mater.NameMaterial.ToString();
        }
        private void btnRecipeAdd_Click(object sender, EventArgs e)
        {
            AddRecipe();
        }

        private void btnRecipeEdit_Click(object sender, EventArgs e)
        {
            EditRecipe();
        }

        private void EditRecipe()
        {
            try
            {
                if (row < 0)
                    throw new Exception("Chọn công thức cần sửa");
                FrmInforTabRecipe.id = Int32.Parse(dgvRecipe.Rows[row].Cells[0].Value.ToString());
                FrmInforTabRecipe.isAdd = false;
                FrmInforTabRecipe frm = new FrmInforTabRecipe();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadTabRecipe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRecipeDel_Click(object sender, EventArgs e)
        {
            DeleteRecipe();
        }
        private void DeleteRecipe()
        {
            try
            {
                if (row < 0)
                    throw new Exception("Chọn loại bánh cần xóa");
                Int32 idRecipe = Int32.Parse(dgvRecipe.Rows[row].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa loại bánh có mã " + dgvRecipe.Rows[row].Cells[0].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var q = from sp in db.Cakes where (sp.IdRecipe == idRecipe) select sp;
                    if (q.FirstOrDefault() != null)
                        throw new Exception("Đang tồn tại bánh có công thức này, không thể xóa");
                    var query = from sp in db.Recipes where (sp.IdRecipe == idRecipe) select sp;
                    Recipe recipe = query.FirstOrDefault();
                    db.Recipes.Remove(recipe);
                    db.SaveChanges();
                    LoadTabRecipe();
                    MessageBox.Show("Xóa thành công");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddRecipe()
        {
            try
            {
                FrmInforTabRecipe.isAdd = true;
                FrmInforTabRecipe frm = new FrmInforTabRecipe();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadTabRecipe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
