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
    public partial class FrmCategory : Form
    {
        Int32 row;
        BakeryManagementContext db = new BakeryManagementContext();
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            LoadTabCategory();
        }

        private void btnDisplayCategory_Click(object sender, EventArgs e)
        {
            LoadTabCategory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory();
        }
        private void LoadTabCategory()
        {
            row = 0;
            var query = from cate in db.Categories
                        select new
                        {
                            cate.IdCategory,
                            cate.NameCategory,
                        };
            dgvCategory.Rows.Clear();
            foreach (var cate in query)
            {
            dgvCategory.Rows.Add();
            dgvCategory.Rows[row].Cells[0].Value = cate.IdCategory.ToString();
            dgvCategory.Rows[row].Cells[1].Value = cate.NameCategory.ToString();
  
                row++;
            }

        }
        private void AddCategory()
        {
            try
            {
                FrmInforTabCategory.isAdd = true;
                FrmInforTabCategory frm = new FrmInforTabCategory();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadTabCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            EditCategory();
        }
        private void EditCategory()
        {
            try
            {
                if (row < 0)
                    throw new Exception("Chọn loại bánh cần sửa");
                FrmInforTabCategory.id = Int32.Parse(dgvCategory.Rows[row].Cells[0].Value.ToString());
                FrmInforTabCategory.isAdd = false;
                FrmInforTabCategory frm = new FrmInforTabCategory();
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
                LoadTabCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            DeleteCategory();
        }
        private void DeleteCategory()
        {
            try
            {
                if (row < 0)
                    throw new Exception("Chọn loại bánh cần xóa");
                Int32 idCategory = Int32.Parse(dgvCategory.Rows[row].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Bạn thực sự muốn xóa loại bánh có mã " + dgvCategory.Rows[row].Cells[0].Value.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var q = from sp in db.Recipes where (sp.IdCategory == idCategory) select sp;
                    if (q.FirstOrDefault() != null)
                        throw new Exception("Danh mục này đang có bánh, không thể xóa");
                    var query = from sp in db.Categories where (sp.IdCategory == idCategory) select sp;
                    Category cate = query.FirstOrDefault();
                    db.Categories.Remove(cate);
                    db.SaveChanges();
                    LoadTabCategory();
                    MessageBox.Show("Xóa thành công");
                }    
                       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCategorySearch_Click(object sender, EventArgs e)
        {
            row = -1;
            SearchCategory();
        }
        private void SearchCategory()
        {
            try
            {
                String keyWord = txtCategorySearch.Text;
                if (keyWord == "")
                    throw new Exception("Nhập từ khóa tìm kiếm");
                else
                {
                    row = 0;
                    
                    var query = from ct in db.Categories where (ct.NameCategory.Contains(keyWord)) select ct;
                    dgvCategory.Rows.Clear();
                    foreach (var cate in query)
                    {
                        dgvCategory.Rows.Add();
                        dgvCategory.Rows[row].Cells[0].Value = cate.IdCategory.ToString();
                        dgvCategory.Rows[row].Cells[1].Value = cate.NameCategory.ToString();

                        row++;
                    }
                }    
                if (dgvCategory.Rows.Count <= 1)
                {
                    MessageBox.Show("Không tồn tại sản phẩm nào có tên " + keyWord + "!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
