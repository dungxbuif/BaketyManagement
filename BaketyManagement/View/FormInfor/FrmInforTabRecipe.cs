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
namespace BaketyManagement.View.FormInfor
{
    public partial class FrmInforTabRecipe : Form
    {
        BakeryManagementContext db = new BakeryManagementContext();
        public static Int32 id;
        public static Boolean isAdd;
        public FrmInforTabRecipe()
        {
            InitializeComponent();
            txtIdRecipe.Enabled = false;
            if (isAdd)
            {
                int idLast = (from s in db.Recipes orderby s.IdRecipe descending select s).FirstOrDefault().IdRecipe;
                txtIdRecipe.Text = (idLast +1).ToString();
                btnEditRecipe.Visible = false;
            }

            else
            {
                btnAddRecipe.Visible = false;
                LoadTextBox();              
            }        
        }
        private void LoadTextBox()
        {
            var query = from sp in db.Recipes where (sp.IdRecipe == id) select sp;
            Recipe re = query.FirstOrDefault();
            txtIdRecipe.Text = re.IdRecipe.ToString();
            txtNameCake.Text = re.NameCake;
            txtPrice.Text = re.Price.ToString();
            var queryCate = from s in db.Categories where(s.IdCategory == re.IdCategory) select s;
            Category cate = queryCate.FirstOrDefault();
            comboBox1.Text = cate.NameCategory;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditRecipe_Click(object sender, EventArgs e)
        {
            EditRecipe();
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            AddRecipe();
        }

        private void AddRecipe()
        {

            try
            {
                if (comboBox1.Text == "")
                    throw new Exception("Nhập tên Loại bánh cần thêm");
                if (txtNameCake.Text == "")
                    throw new Exception("Nhập tên bánh cần thêm");
                if (txtPrice.Text == "")
                    throw new Exception("Nhập giá bánh cần thêm");
                if (int.Parse(txtPrice.Text)<0)
                    throw new Exception("Giá bánh phải lớn hơn 0");
                else
                {
                    var query = from sp in db.Recipes where (sp.NameCake.Equals(txtNameCake.Text)) select sp;
                    if (query.FirstOrDefault() != null)
                    {
                        throw new Exception("Tên bánh đã trùng");
                    }
                    else
                    {
                        int idLast = (from s in db.Recipes orderby s.IdRecipe descending select s).FirstOrDefault().IdRecipe;
                        string nameCategory = comboBox1.Text.ToString();
                        var queryCate = from s in db.Categories where (s.NameCategory.Equals(nameCategory)) select s;
                        Category cate = queryCate.FirstOrDefault();
                        Recipe record = new Recipe();
                        record.IdRecipe = idLast + 1;
                        record.NameCake = txtNameCake.Text;
                        record.IdCategory = cate.IdCategory;
                        record.Price = double.Parse(txtPrice.Text);
                        db.Recipes.Add(record);
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
        private void EditRecipe()
        {
            try
            {
                Int32 idRecipe = id;
                if (comboBox1.Text == "")
                    throw new Exception("Nhập tên Loại bánh cần sửa");
                if (txtNameCake.Text == "")
                    throw new Exception("Nhập tên bánh cần sửa");
                if (txtPrice.Text == "")
                    throw new Exception("Nhập giá bánh cần sửa");
                if (int.Parse(txtPrice.Text) < 0)
                    throw new Exception("Giá bánh phải lớn hơn 0");
                else
                {
                    var q = from sp in db.Recipes where (sp.NameCake.Equals(txtNameCake.Text)) select sp;
                    if (q.FirstOrDefault() != null)
                    {
                        throw new Exception("Tên bánh đã trùng");
                    }

                    string nameCategory = comboBox1.Text.ToString();
                    var queryCate = from s in db.Categories where (s.NameCategory.Equals(nameCategory)) select s;
                    Category cate = queryCate.FirstOrDefault();
                    var query = from sp in db.Recipes where (sp.IdRecipe == id) select sp;
                    Recipe record = query.FirstOrDefault();
                    record.IdCategory = cate.IdCategory;
                    record.NameCake = txtNameCake.Text;
                    record.Price = double.Parse(txtPrice.Text);
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

        private void FrmInforTabRecipe_Load(object sender, EventArgs e)
        {
            var query = from s in db.Categories select new { s.NameCategory};

            foreach (var c in query)
            {
                comboBox1.Items.Add(c.NameCategory);
            }

        }
    }
}
