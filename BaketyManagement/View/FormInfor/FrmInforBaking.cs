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
using WinFormsApp13212.Models;

namespace BaketyManagement.View.FormInfor
{
    public partial class FrmInforBaking : Form
    {
        BakeryManagementContext db = new BakeryManagementContext();
        public static Int32 idRecipe, rowDetail;
        public FrmInforBaking()
        {
            InitializeComponent();
            txtNameCake.Enabled = false;
            LoadTextBox();
        }

        private void LoadTextBox()
        {
            try
            {
                var query = from sp in db.Recipes where (sp.IdRecipe == idRecipe) select sp;
                Recipe r = query.FirstOrDefault();
                txtNameCake.Text = r.NameCake;
                txtAmount.Text = "1";
                var queryDetail = from sp in db.RecipeDetails where (sp.IdRecipe == idRecipe) select sp;
                RecipeDetail recipeDetail = queryDetail.FirstOrDefault();
                LoadTabDetails(idRecipe,1);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadTabDetails(int idRecipe,int sl)
        {
            rowDetail = 0;
            var q = from c in db.RecipeDetails
                    where (c.IdRecipe == idRecipe)
                    select new
                    {
                        c.IdMaterial,
                        c.Amount
                    };
            dgvMaterial.Rows.Clear();
            foreach (var c in q)
            {
                dgvMaterial.Rows.Add();
                dgvMaterial.Rows[rowDetail].Cells[0].Value = c.IdMaterial.ToString();
                dgvMaterial.Rows[rowDetail].Cells[1].Value = (c.Amount*sl).ToString();
                rowDetail++;
            }

            for (int i = 0; i < rowDetail; i++)
            {
                int id = int.Parse(dgvMaterial.Rows[i].Cells[0].Value.ToString());

                dgvMaterial.Rows[i].Cells[0].Value = Find_NameMaterial(id);
                dgvMaterial.Rows[i].Cells[1].Value = dgvMaterial.Rows[i].Cells[1].Value.ToString() + " " + Find_UnitMaterial(id);
            }
        }
        private object Find_UnitMaterial(int id)
        {
            var query = from c in db.Materials where (c.IdMaterial == id) select c;
            Material mater = query.FirstOrDefault();
            return mater.Unit.ToString();
        }
        private string Find_NameMaterial(int id)
        {
            var query = from c in db.Materials where (c.IdMaterial == id) select c;
            Material mater = query.FirstOrDefault();
            return mater.NameMaterial.ToString();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadTabDetails(idRecipe, int.Parse(txtAmount.Text));
            }catch(Exception ex)
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ");
            }
        }

        private void btnBaking_Click(object sender, EventArgs e)
        {
            try
            {
                Cake cake = new Cake();
                bool ktTrung = true;
                int sl = int.Parse(txtAmount.Text);
                string date = dtpDate.Value.ToShortDateString();
                var query = from s in db.Cakes where(s.IdRecipe == idRecipe) select s;
                foreach (var c in query)
                {
                    if (c.ExpCake.Value.ToShortDateString() == date)
                    {
                        ktTrung = false;
                        cake = c;
                    }
                }
                bool check = checkMaterial();
                if(check == true)
                {
                    editMaterial();

                    if (ktTrung == false)
                    {
                        cake.Amount = cake.Amount + sl;
                        db.SaveChanges();
                    }
                    else
                    {
                        int idLast = (from s in db.Cakes orderby s.IdCake descending select s).FirstOrDefault().IdCake;
                        Recipe recipe = (from s in db.Recipes where (idRecipe == s.IdRecipe) select s).FirstOrDefault();
                        Cake newCake = new Cake();
                        newCake.IdCake = idLast + 1;
                        newCake.IdRecipe = idRecipe;
                        newCake.Price = recipe.Price;
                        newCake.Amount = sl;
                        newCake.MfgCake = DateTime.Now;
                        newCake.ExpCake = dtpDate.Value;
                        newCake.Size = "M";
                        db.Cakes.Add(newCake);
                        db.SaveChanges();
                        MessageBox.Show("Đã thêm bánh thành công");
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void editMaterial()
        {
            List<RecipeDetail> list1 = (from c in db.RecipeDetails
                                        where (c.IdRecipe == idRecipe)
                                        select c).ToList();
            for (int i = 0; i < list1.Count; i++)
            {
                string name = dgvMaterial.Rows[i].Cells[0].Value.ToString();
                Material check = (from s in db.Materials where (s.NameMaterial.Equals(name)) select s).FirstOrDefault();
                double slCan = double.Parse(txtAmount.Text) * double.Parse(list1[i].Amount.ToString());
                var query = from s in db.MaterialStores where (s.IdMaterial == check.IdMaterial) select s;
                MaterialStore materialStore = query.FirstOrDefault();
                materialStore.Amount = materialStore.Amount - slCan;
                db.SaveChanges();
            }
        }
        private bool checkMaterial()
        {
            bool kt = true;
            string thongbao1 = "Nguyên liệu thiếu: \n", thongbao2 = "Nguyên liệu chưa nhập: \n ";
            List<RecipeDetail> list1 = (from c in db.RecipeDetails
                                        where (c.IdRecipe == idRecipe)
                                        select c).ToList();
            for (int i = 0; i< list1.Count; i++)
            {
                string name = dgvMaterial.Rows[i].Cells[0].Value.ToString();
                Material check = (from s in db.Materials where (s.NameMaterial.Equals(name)) select s).FirstOrDefault();
                double slCan = double.Parse(txtAmount.Text) * double.Parse(list1[i].Amount.ToString());
                var query = from s in db.MaterialStores where (s.IdMaterial == check.IdMaterial) select s;
                if (query.FirstOrDefault() == null)
                {
                    thongbao2 = thongbao2 + "\t'" + check.NameMaterial + "' \n";
                    kt = false;
                }
                else if(slCan > query.FirstOrDefault().Amount)
                {
                    thongbao1 = thongbao1 + "\t'" +check.NameMaterial + "' : " + (slCan - query.FirstOrDefault().Amount).ToString() + check.Unit + "\n";
                    kt = false;
                }
                        
               
            }
            if (kt == false)
            {
                MessageBox.Show(thongbao1 + thongbao2);
                return false;
            }
            else return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
