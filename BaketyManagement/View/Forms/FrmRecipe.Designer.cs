
namespace BaketyManagement.View.Forms
{
    partial class FrmRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpRecipe = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnFunctionRecipe = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.txtCakeSearch = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.btnRecipeAdd = new System.Windows.Forms.Button();
            this.btnRecipeDisplay = new System.Windows.Forms.Button();
            this.btnRecipeSearch = new System.Windows.Forms.Button();
            this.btnRecipeEdit = new System.Windows.Forms.Button();
            this.btnRecipeDel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.btnDelMaterial = new System.Windows.Forms.Button();
            this.btnEditMaterial = new System.Windows.Forms.Button();
            this.btnBaking = new System.Windows.Forms.Button();
            this.tlpRecipe.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnFunctionRecipe.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRecipe
            // 
            this.tlpRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.tlpRecipe.ColumnCount = 2;
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.90322F));
            this.tlpRecipe.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.09678F));
            this.tlpRecipe.Controls.Add(this.groupBox1, 0, 0);
            this.tlpRecipe.Controls.Add(this.groupBox2, 0, 1);
            this.tlpRecipe.Controls.Add(this.groupBox3, 1, 0);
            this.tlpRecipe.Controls.Add(this.groupBox4, 1, 1);
            this.tlpRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRecipe.Location = new System.Drawing.Point(0, 0);
            this.tlpRecipe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpRecipe.Name = "tlpRecipe";
            this.tlpRecipe.Padding = new System.Windows.Forms.Padding(15);
            this.tlpRecipe.RowCount = 2;
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRecipe.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpRecipe.Size = new System.Drawing.Size(1146, 492);
            this.tlpRecipe.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnDetail);
            this.groupBox1.Controls.Add(this.dgvRecipe);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Công thức";
            // 
            // dgvRecipe
            // 
            this.dgvRecipe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecipe.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecipe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecipe.GridColor = System.Drawing.Color.White;
            this.dgvRecipe.Location = new System.Drawing.Point(3, 26);
            this.dgvRecipe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvRecipe.MultiSelect = false;
            this.dgvRecipe.Name = "dgvRecipe";
            this.dgvRecipe.ReadOnly = true;
            this.dgvRecipe.RowHeadersWidth = 51;
            this.dgvRecipe.RowTemplate.Height = 29;
            this.dgvRecipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipe.Size = new System.Drawing.Size(690, 127);
            this.dgvRecipe.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mã công thức";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tên danh mục";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Tên bánh";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Giá";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.pnFunctionRecipe);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.groupBox2.Location = new System.Drawing.Point(18, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 294);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // pnFunctionRecipe
            // 
            this.pnFunctionRecipe.BackColor = System.Drawing.Color.White;
            this.pnFunctionRecipe.Controls.Add(this.txtCakeSearch);
            this.pnFunctionRecipe.Controls.Add(this.label22);
            this.pnFunctionRecipe.Controls.Add(this.btnRecipeAdd);
            this.pnFunctionRecipe.Controls.Add(this.btnRecipeDisplay);
            this.pnFunctionRecipe.Controls.Add(this.btnRecipeSearch);
            this.pnFunctionRecipe.Controls.Add(this.btnRecipeEdit);
            this.pnFunctionRecipe.Controls.Add(this.btnRecipeDel);
            this.pnFunctionRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFunctionRecipe.Location = new System.Drawing.Point(3, 26);
            this.pnFunctionRecipe.Name = "pnFunctionRecipe";
            this.pnFunctionRecipe.Size = new System.Drawing.Size(690, 265);
            this.pnFunctionRecipe.TabIndex = 0;
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(639, 40);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(51, 38);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = ">>";
            this.btnDetail.UseVisualStyleBackColor = true;
            // 
            // txtCakeSearch
            // 
            this.txtCakeSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCakeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCakeSearch.ForeColor = System.Drawing.Color.Black;
            this.txtCakeSearch.Location = new System.Drawing.Point(183, 53);
            this.txtCakeSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCakeSearch.Name = "txtCakeSearch";
            this.txtCakeSearch.Size = new System.Drawing.Size(304, 30);
            this.txtCakeSearch.TabIndex = 10;
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label22.Location = new System.Drawing.Point(16, 56);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(153, 25);
            this.label22.TabIndex = 9;
            this.label22.Text = "Nhập tên bánh";
            // 
            // btnRecipeAdd
            // 
            this.btnRecipeAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRecipeAdd.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnRecipeAdd.FlatAppearance.BorderSize = 0;
            this.btnRecipeAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(63)))), ((int)(((byte)(109)))));
            this.btnRecipeAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(83)))), ((int)(((byte)(137)))));
            this.btnRecipeAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeAdd.ForeColor = System.Drawing.Color.White;
            this.btnRecipeAdd.Image = global::BaketyManagement.Properties.Resources.Add;
            this.btnRecipeAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecipeAdd.Location = new System.Drawing.Point(183, 143);
            this.btnRecipeAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecipeAdd.Name = "btnRecipeAdd";
            this.btnRecipeAdd.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeAdd.TabIndex = 8;
            this.btnRecipeAdd.Text = "Thêm";
            this.btnRecipeAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecipeAdd.UseVisualStyleBackColor = false;
            // 
            // btnRecipeDisplay
            // 
            this.btnRecipeDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRecipeDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.btnRecipeDisplay.FlatAppearance.BorderSize = 0;
            this.btnRecipeDisplay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(126)))), ((int)(((byte)(38)))));
            this.btnRecipeDisplay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.btnRecipeDisplay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeDisplay.ForeColor = System.Drawing.Color.White;
            this.btnRecipeDisplay.Image = global::BaketyManagement.Properties.Resources.Display;
            this.btnRecipeDisplay.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecipeDisplay.Location = new System.Drawing.Point(16, 143);
            this.btnRecipeDisplay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecipeDisplay.Name = "btnRecipeDisplay";
            this.btnRecipeDisplay.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeDisplay.TabIndex = 7;
            this.btnRecipeDisplay.Text = "Xem";
            this.btnRecipeDisplay.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecipeDisplay.UseVisualStyleBackColor = false;
            // 
            // btnRecipeSearch
            // 
            this.btnRecipeSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRecipeSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(36)))), ((int)(((byte)(210)))));
            this.btnRecipeSearch.FlatAppearance.BorderSize = 0;
            this.btnRecipeSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(18)))), ((int)(((byte)(167)))));
            this.btnRecipeSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(36)))), ((int)(((byte)(210)))));
            this.btnRecipeSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeSearch.ForeColor = System.Drawing.Color.White;
            this.btnRecipeSearch.Image = global::BaketyManagement.Properties.Resources.Search;
            this.btnRecipeSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecipeSearch.Location = new System.Drawing.Point(512, 35);
            this.btnRecipeSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecipeSearch.Name = "btnRecipeSearch";
            this.btnRecipeSearch.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeSearch.TabIndex = 4;
            this.btnRecipeSearch.Text = "Tìm";
            this.btnRecipeSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecipeSearch.UseVisualStyleBackColor = false;
            // 
            // btnRecipeEdit
            // 
            this.btnRecipeEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRecipeEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(83)))), ((int)(((byte)(137)))));
            this.btnRecipeEdit.FlatAppearance.BorderSize = 0;
            this.btnRecipeEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(63)))), ((int)(((byte)(109)))));
            this.btnRecipeEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(83)))), ((int)(((byte)(137)))));
            this.btnRecipeEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeEdit.ForeColor = System.Drawing.Color.White;
            this.btnRecipeEdit.Image = global::BaketyManagement.Properties.Resources.Edit;
            this.btnRecipeEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecipeEdit.Location = new System.Drawing.Point(352, 143);
            this.btnRecipeEdit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecipeEdit.Name = "btnRecipeEdit";
            this.btnRecipeEdit.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeEdit.TabIndex = 6;
            this.btnRecipeEdit.Text = "Sửa";
            this.btnRecipeEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecipeEdit.UseVisualStyleBackColor = false;
            // 
            // btnRecipeDel
            // 
            this.btnRecipeDel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRecipeDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(52)))), ((int)(((byte)(36)))));
            this.btnRecipeDel.FlatAppearance.BorderSize = 0;
            this.btnRecipeDel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(32)))), ((int)(((byte)(18)))));
            this.btnRecipeDel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(52)))), ((int)(((byte)(36)))));
            this.btnRecipeDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipeDel.ForeColor = System.Drawing.Color.White;
            this.btnRecipeDel.Image = global::BaketyManagement.Properties.Resources.Delete;
            this.btnRecipeDel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRecipeDel.Location = new System.Drawing.Point(522, 143);
            this.btnRecipeDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecipeDel.Name = "btnRecipeDel";
            this.btnRecipeDel.Size = new System.Drawing.Size(150, 70);
            this.btnRecipeDel.TabIndex = 5;
            this.btnRecipeDel.Text = "Xóa";
            this.btnRecipeDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRecipeDel.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.dgvDetail);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.groupBox3.Location = new System.Drawing.Point(720, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(408, 156);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nguyên liệu";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column6});
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.Location = new System.Drawing.Point(3, 26);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 29;
            this.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetail.Size = new System.Drawing.Size(402, 127);
            this.dgvDetail.TabIndex = 2;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tên nguyên liệu";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Số lượng cần";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.panel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(720, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(408, 294);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddMaterial);
            this.panel1.Controls.Add(this.btnDelMaterial);
            this.panel1.Controls.Add(this.btnEditMaterial);
            this.panel1.Controls.Add(this.btnBaking);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 268);
            this.panel1.TabIndex = 10;
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddMaterial.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnAddMaterial.FlatAppearance.BorderSize = 0;
            this.btnAddMaterial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(126)))), ((int)(((byte)(38)))));
            this.btnAddMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.btnAddMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddMaterial.ForeColor = System.Drawing.Color.White;
            this.btnAddMaterial.Image = global::BaketyManagement.Properties.Resources.Add;
            this.btnAddMaterial.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddMaterial.Location = new System.Drawing.Point(242, 26);
            this.btnAddMaterial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(150, 70);
            this.btnAddMaterial.TabIndex = 9;
            this.btnAddMaterial.Text = "Thêm NL";
            this.btnAddMaterial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddMaterial.UseVisualStyleBackColor = false;
            // 
            // btnDelMaterial
            // 
            this.btnDelMaterial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(52)))), ((int)(((byte)(36)))));
            this.btnDelMaterial.FlatAppearance.BorderSize = 0;
            this.btnDelMaterial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(32)))), ((int)(((byte)(18)))));
            this.btnDelMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(52)))), ((int)(((byte)(36)))));
            this.btnDelMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDelMaterial.ForeColor = System.Drawing.Color.White;
            this.btnDelMaterial.Image = global::BaketyManagement.Properties.Resources.Delete;
            this.btnDelMaterial.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelMaterial.Location = new System.Drawing.Point(242, 143);
            this.btnDelMaterial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelMaterial.Name = "btnDelMaterial";
            this.btnDelMaterial.Size = new System.Drawing.Size(150, 70);
            this.btnDelMaterial.TabIndex = 9;
            this.btnDelMaterial.Text = "Xóa NL";
            this.btnDelMaterial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelMaterial.UseVisualStyleBackColor = false;
            // 
            // btnEditMaterial
            // 
            this.btnEditMaterial.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(83)))), ((int)(((byte)(137)))));
            this.btnEditMaterial.FlatAppearance.BorderSize = 0;
            this.btnEditMaterial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(63)))), ((int)(((byte)(109)))));
            this.btnEditMaterial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(83)))), ((int)(((byte)(137)))));
            this.btnEditMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditMaterial.ForeColor = System.Drawing.Color.White;
            this.btnEditMaterial.Image = global::BaketyManagement.Properties.Resources.Edit;
            this.btnEditMaterial.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditMaterial.Location = new System.Drawing.Point(38, 143);
            this.btnEditMaterial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditMaterial.Name = "btnEditMaterial";
            this.btnEditMaterial.Size = new System.Drawing.Size(150, 70);
            this.btnEditMaterial.TabIndex = 9;
            this.btnEditMaterial.Text = "Sửa NL";
            this.btnEditMaterial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditMaterial.UseVisualStyleBackColor = false;
            // 
            // btnBaking
            // 
            this.btnBaking.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBaking.BackColor = System.Drawing.Color.SlateGray;
            this.btnBaking.FlatAppearance.BorderSize = 0;
            this.btnBaking.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(126)))), ((int)(((byte)(38)))));
            this.btnBaking.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.btnBaking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBaking.ForeColor = System.Drawing.Color.White;
            this.btnBaking.Image = global::BaketyManagement.Properties.Resources.Add;
            this.btnBaking.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBaking.Location = new System.Drawing.Point(38, 26);
            this.btnBaking.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBaking.Name = "btnBaking";
            this.btnBaking.Size = new System.Drawing.Size(150, 70);
            this.btnBaking.TabIndex = 8;
            this.btnBaking.Text = "Làm Bánh";
            this.btnBaking.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBaking.UseVisualStyleBackColor = false;
            // 
            // FrmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 492);
            this.Controls.Add(this.tlpRecipe);
            this.Name = "FrmRecipe";
            this.Text = "FrmRecipe";
            this.tlpRecipe.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.pnFunctionRecipe.ResumeLayout(false);
            this.pnFunctionRecipe.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpRecipe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnFunctionRecipe;
        private System.Windows.Forms.Button btnRecipeSearch;
        private System.Windows.Forms.Button btnRecipeDel;
        private System.Windows.Forms.Button btnRecipeEdit;
        private System.Windows.Forms.Button btnRecipeDisplay;
        private System.Windows.Forms.Button btnBaking;
        private System.Windows.Forms.DataGridView dgvRecipe;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnDelMaterial;
        private System.Windows.Forms.Button btnEditMaterial;
        private System.Windows.Forms.Button btnRecipeAdd;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtCakeSearch;
        private System.Windows.Forms.Panel panel1;
    }
}