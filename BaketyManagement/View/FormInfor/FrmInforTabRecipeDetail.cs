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
    public partial class FrmInforTabRecipeDetail : Form
    {
        BakeryManagementContext db = new BakeryManagementContext();
        public static Int32 idRecipe;
        public static Boolean isAdd;
        public FrmInforTabRecipeDetail()
        {
            InitializeComponent();
            if (isAdd)
            {
                btnEditDetail.Visible = false;
            }

            else
            {
                btnAddDetail.Visible = false;
                LoadTextBox();
            }
        }
        private void LoadTextBox()
        {
            /*var query = from sp in db.M where (sp.IdRecipe == id) select sp;
            Recipe re = query.FirstOrDefault();
            txtIdRecipe.Text = re.IdRecipe.ToString();
            txtNameCake.Text = re.NameCake;
            txtPrice.Text = re.Price.ToString();
            var queryCate = from s in db.Categories where (s.IdCategory == re.IdCategory) select s;
            Category cate = queryCate.FirstOrDefault();
            comboBox1.Text = cate.NameCategory;*/
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditDetail_Click(object sender, EventArgs e)
        {

        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            AddRecipeDetail();
        }
        private void AddRecipeDetail()
        {

            try
            {
                if (cbbNameMaterial.Text == "")
                    throw new Exception("Nhập tên nguyên liệu cần thêm");
                if (txtAmount.Text == "")
                    throw new Exception("Nhập số lượng");  
                if (int.Parse(txtAmount.Text) < 0)
                    throw new Exception("Số lượng phải lớn hơn 0");
                else
                {
                    int index = int.Parse(cbbNameMaterial.SelectedIndex.ToString())+1;
                    var queryRecipe = from s in db.RecipeDetails where (s.IdRecipe == idRecipe && s.IdMaterial == index ) select s;
                    if (queryRecipe.FirstOrDefault() != null)
                    {
                        throw new Exception("Nguyên liệu đã có");
                    }
                    else
                    {
                        RecipeDetail record = new RecipeDetail();
                        record.IdRecipe = idRecipe;
                        record.IdMaterial = index;
                        record.Amount = int.Parse(txtAmount.Text);
                        db.RecipeDetails.Add(record);
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

        private void FrmInforTabRecipeDetail_Load(object sender, EventArgs e)
        {
            var query = from s in db.Materials select new { s.NameMaterial };

            foreach (var c in query)
            {
                cbbNameMaterial.Items.Add(c.NameMaterial);
            }
        }
    }
}
