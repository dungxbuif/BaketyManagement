
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

namespace BaketyManagement.View
{
    public partial class FrmInforTabProvider : Form
    {
        BakeryManagementContext db = BakeryManagementContext.Instance;
        public static Int32 id;
        public static string name;
        public static string phone;
        public static string address;
        public static Boolean isAdd;
        public FrmInforTabProvider()
        {
            InitializeComponent();
            txtIdSupplier.Enabled = false;
            if(isAdd == true)
            {
                txtIdSupplier.Enabled = false;
            }
            else
            {
                txtIdSupplier.Text = id.ToString();
                txtNameSupplier.Text = name;
                txtPhoneSupplier.Text = phone;
                txtAddressSupplier.Text = address;
                btnAddSupplier.Text = "Sửa";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if(isAdd == true)
            {
                AddSupplier();
            }
            else
            {
                editSupplier();
            }
        }

        private void AddSupplier()
        {
            try
            {
                string nameSupplier = txtNameSupplier.Text;
                string phoneSupplier = txtPhoneSupplier.Text;
                string address = txtAddressSupplier.Text;
                int max = 0;
                if (nameSupplier == "")
                    throw new Exception("Tên nhà cung cấp không được để trống");
                if (phoneSupplier == "")
                    throw new Exception("Số điện thoại không được để trống");
                if (address == "")
                    throw new Exception("Địa chỉ không được để trống");

                Supplier sup = new Supplier();
                var query = from sp in db.Suppliers
                            select sp;
                foreach(var sppl in query)
                {
                    if(sppl.IdSupplier > max)
                    {
                        max = sppl.IdSupplier;
                    }
                }
                sup.NameSupplier = nameSupplier;
                sup.Phone = phoneSupplier;
                sup.Address = address;
                sup.IdSupplier = max + 1;
                db.Suppliers.Add(sup);
                db.SaveChanges();

                DialogResult result = MessageBox.Show("Thêm nhà cung cấp thành công", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                    this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void editSupplier()
        {
            try
            {
                Supplier supSua = (from sp in db.Suppliers
                               where sp.IdSupplier == id
                               select sp).FirstOrDefault();
                String nameSupplier = txtNameSupplier.Text;
                String phoneSupplier = txtPhoneSupplier.Text;
                String addressSupplier = txtAddressSupplier.Text;
                if (nameSupplier == "" || phoneSupplier == "" || addressSupplier == "")
                {
                    throw new Exception("Vui lòng nhập đầy đủ thông tin nhà cung cấp!");
                }
                supSua.IdSupplier = id;
                supSua.NameSupplier = nameSupplier;
                supSua.Phone = phoneSupplier;
                supSua.Address = addressSupplier;
                db.SaveChanges();
                MessageBox.Show("Sửa nhân viên thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
