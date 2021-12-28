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
    public partial class FrmInforTabCategory : Form
    {
        BakeryManagementContext db = new BakeryManagementContext();
        public static Int32 id;
        public static Boolean isAdd;
        public FrmInforTabCategory()
        {

            InitializeComponent();
            txtIdCategory.Enabled = false;
            if (isAdd)
            {
                int idLast = (from s in db.Categories orderby s.IdCategory descending select s).FirstOrDefault().IdCategory;
                txtIdCategory.Text = (idLast + 1).ToString();
                btnEditCategory.Visible = false;
            }

            else
            {
                btnAddCategory.Visible = false;
                LoadTextBox();
            }
        }

        

        
        private void AddCategory()
        {

            try
            {
                if (txtNameCategory.Text == "")
                    throw new Exception("Nhập tên Loại bánh cần thêm");
                else
                {
                    int idLast = (from s in db.Categories orderby s.IdCategory descending select s).FirstOrDefault().IdCategory;
                    var query = from sp in db.Categories where (sp.NameCategory == txtNameCategory.Text) select sp;
                    if (query.FirstOrDefault() != null)
                    {
                        throw new Exception("Tên loại bánh đã trùng");
                    }
                    else
                    {
                        Category record = new Category();
                        record.IdCategory = idLast + 1;
                        record.NameCategory = txtNameCategory.Text;
                        db.Categories.Add(record);
                        db.SaveChanges();
                        MessageBox.Show("Thêm thành công");
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditCategory()
        {
            try
            {
                String nameCategory = txtNameCategory.Text;
                Int32 idCategory = id;
                if (nameCategory == "")
                    throw new Exception("Nhập tên cần sửa");
                else
                {
                    var query = from sp in db.Categories where (sp.IdCategory == id) select sp;
                    Category cate = query.FirstOrDefault();
                    cate.NameCategory = nameCategory;
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
        private void LoadTextBox()
        {
            var query = from sp in db.Categories where (sp.IdCategory == id) select sp;
            Category cate = query.FirstOrDefault();
            txtNameCategory.Text = cate.NameCategory;
            txtIdCategory.Text = cate.IdCategory.ToString();
        }


        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            EditCategory();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            AddCategory();
        }
    }
}
