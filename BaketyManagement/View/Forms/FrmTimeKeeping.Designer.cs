﻿
namespace BaketyManagement.View.Forms
{
    partial class FrmTimeKeeping
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
            this.tlpTimeKeeping = new System.Windows.Forms.TableLayoutPanel();
            this.pnFunctionTimeKeeping = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnFunctionSalary = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnTimeKeeping = new System.Windows.Forms.Button();
            this.btnDisplaySalary = new System.Windows.Forms.Button();
            this.btnEditSalary = new System.Windows.Forms.Button();
            this.btnPrintSalary = new System.Windows.Forms.Button();
            this.txtTimeKeepingSearch = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnTimeKeepingSearch = new System.Windows.Forms.Button();
            this.pnTimeKeeping = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTimeKeeping = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soGioLv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soGioLamThem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpTimeKeeping.SuspendLayout();
            this.pnFunctionTimeKeeping.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnFunctionSalary.SuspendLayout();
            this.pnTimeKeeping.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeKeeping)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpTimeKeeping
            // 
            this.tlpTimeKeeping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.tlpTimeKeeping.ColumnCount = 1;
            this.tlpTimeKeeping.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimeKeeping.Controls.Add(this.pnFunctionTimeKeeping, 0, 1);
            this.tlpTimeKeeping.Controls.Add(this.pnTimeKeeping, 0, 0);
            this.tlpTimeKeeping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTimeKeeping.Location = new System.Drawing.Point(0, 0);
            this.tlpTimeKeeping.Name = "tlpTimeKeeping";
            this.tlpTimeKeeping.Padding = new System.Windows.Forms.Padding(20);
            this.tlpTimeKeeping.RowCount = 2;
            this.tlpTimeKeeping.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTimeKeeping.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpTimeKeeping.Size = new System.Drawing.Size(1197, 617);
            this.tlpTimeKeeping.TabIndex = 0;
            this.tlpTimeKeeping.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpTimeKeeping_Paint);
            // 
            // pnFunctionTimeKeeping
            // 
            this.pnFunctionTimeKeeping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.pnFunctionTimeKeeping.Controls.Add(this.groupBox2);
            this.pnFunctionTimeKeeping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFunctionTimeKeeping.Location = new System.Drawing.Point(30, 207);
            this.pnFunctionTimeKeeping.Margin = new System.Windows.Forms.Padding(10);
            this.pnFunctionTimeKeeping.Name = "pnFunctionTimeKeeping";
            this.pnFunctionTimeKeeping.Size = new System.Drawing.Size(1137, 380);
            this.pnFunctionTimeKeeping.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.pnFunctionSalary);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1137, 380);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // pnFunctionSalary
            // 
            this.pnFunctionSalary.BackColor = System.Drawing.Color.White;
            this.pnFunctionSalary.Controls.Add(this.dateTimePicker2);
            this.pnFunctionSalary.Controls.Add(this.dateTimePicker1);
            this.pnFunctionSalary.Controls.Add(this.label2);
            this.pnFunctionSalary.Controls.Add(this.label1);
            this.pnFunctionSalary.Controls.Add(this.label21);
            this.pnFunctionSalary.Controls.Add(this.btnTimeKeeping);
            this.pnFunctionSalary.Controls.Add(this.btnDisplaySalary);
            this.pnFunctionSalary.Controls.Add(this.btnEditSalary);
            this.pnFunctionSalary.Controls.Add(this.btnPrintSalary);
            this.pnFunctionSalary.Controls.Add(this.txtTimeKeepingSearch);
            this.pnFunctionSalary.Controls.Add(this.btnFilter);
            this.pnFunctionSalary.Controls.Add(this.btnTimeKeepingSearch);
            this.pnFunctionSalary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnFunctionSalary.Location = new System.Drawing.Point(3, 22);
            this.pnFunctionSalary.Name = "pnFunctionSalary";
            this.pnFunctionSalary.Size = new System.Drawing.Size(1131, 355);
            this.pnFunctionSalary.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "MM-yyyy";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(546, 290);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(121, 26);
            this.dateTimePicker2.TabIndex = 11;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(546, 106);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(326, 26);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label2.Location = new System.Drawing.Point(28, 296);
            this.label2.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Chọn Tháng Xuất Lương";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label1.Location = new System.Drawing.Point(28, 111);
            this.label1.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tìm kiếm theo ngày";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.label21.Location = new System.Drawing.Point(21, 61);
            this.label21.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(233, 20);
            this.label21.TabIndex = 9;
            this.label21.Text = "Tìm kiếm theo tên nhân viên";
            // 
            // btnTimeKeeping
            // 
            this.btnTimeKeeping.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimeKeeping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.btnTimeKeeping.FlatAppearance.BorderSize = 0;
            this.btnTimeKeeping.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(107)))), ((int)(((byte)(18)))));
            this.btnTimeKeeping.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(140)))), ((int)(((byte)(36)))));
            this.btnTimeKeeping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeKeeping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTimeKeeping.ForeColor = System.Drawing.Color.White;
            this.btnTimeKeeping.Image = global::BaketyManagement.Properties.Resources.timekeepingSmaller;
            this.btnTimeKeeping.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTimeKeeping.Location = new System.Drawing.Point(387, 172);
            this.btnTimeKeeping.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.btnTimeKeeping.Name = "btnTimeKeeping";
            this.btnTimeKeeping.Size = new System.Drawing.Size(150, 70);
            this.btnTimeKeeping.TabIndex = 3;
            this.btnTimeKeeping.Text = "Chấm Công";
            this.btnTimeKeeping.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTimeKeeping.UseVisualStyleBackColor = false;
            this.btnTimeKeeping.Click += new System.EventHandler(this.btnTimeKeeping_Click);
            // 
            // btnDisplaySalary
            // 
            this.btnDisplaySalary.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDisplaySalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.btnDisplaySalary.FlatAppearance.BorderSize = 0;
            this.btnDisplaySalary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(126)))), ((int)(((byte)(38)))));
            this.btnDisplaySalary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(159)))), ((int)(((byte)(56)))));
            this.btnDisplaySalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisplaySalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDisplaySalary.ForeColor = System.Drawing.Color.White;
            this.btnDisplaySalary.Image = global::BaketyManagement.Properties.Resources.Display;
            this.btnDisplaySalary.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDisplaySalary.Location = new System.Drawing.Point(175, 172);
            this.btnDisplaySalary.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.btnDisplaySalary.Name = "btnDisplaySalary";
            this.btnDisplaySalary.Size = new System.Drawing.Size(150, 70);
            this.btnDisplaySalary.TabIndex = 4;
            this.btnDisplaySalary.Text = "Xem";
            this.btnDisplaySalary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDisplaySalary.UseVisualStyleBackColor = false;
            this.btnDisplaySalary.Click += new System.EventHandler(this.btnDisplaySalary_Click);
            // 
            // btnEditSalary
            // 
            this.btnEditSalary.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEditSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(83)))), ((int)(((byte)(137)))));
            this.btnEditSalary.FlatAppearance.BorderSize = 0;
            this.btnEditSalary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(63)))), ((int)(((byte)(109)))));
            this.btnEditSalary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(83)))), ((int)(((byte)(137)))));
            this.btnEditSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditSalary.ForeColor = System.Drawing.Color.White;
            this.btnEditSalary.Image = global::BaketyManagement.Properties.Resources.Edit;
            this.btnEditSalary.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditSalary.Location = new System.Drawing.Point(608, 172);
            this.btnEditSalary.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.btnEditSalary.Name = "btnEditSalary";
            this.btnEditSalary.Size = new System.Drawing.Size(150, 70);
            this.btnEditSalary.TabIndex = 5;
            this.btnEditSalary.Text = "Sửa";
            this.btnEditSalary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditSalary.UseVisualStyleBackColor = false;
            this.btnEditSalary.Click += new System.EventHandler(this.btnEditSalary_Click);
            // 
            // btnPrintSalary
            // 
            this.btnPrintSalary.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPrintSalary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(36)))), ((int)(((byte)(210)))));
            this.btnPrintSalary.FlatAppearance.BorderSize = 0;
            this.btnPrintSalary.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(167)))), ((int)(((byte)(32)))), ((int)(((byte)(18)))));
            this.btnPrintSalary.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(52)))), ((int)(((byte)(36)))));
            this.btnPrintSalary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrintSalary.ForeColor = System.Drawing.Color.White;
            this.btnPrintSalary.Image = global::BaketyManagement.Properties.Resources.print;
            this.btnPrintSalary.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrintSalary.Location = new System.Drawing.Point(925, 258);
            this.btnPrintSalary.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.btnPrintSalary.Name = "btnPrintSalary";
            this.btnPrintSalary.Size = new System.Drawing.Size(166, 70);
            this.btnPrintSalary.TabIndex = 6;
            this.btnPrintSalary.Text = "Xuất Lương";
            this.btnPrintSalary.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrintSalary.UseVisualStyleBackColor = false;
            this.btnPrintSalary.Click += new System.EventHandler(this.btnPrintSalary_Click);
            // 
            // txtTimeKeepingSearch
            // 
            this.txtTimeKeepingSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTimeKeepingSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTimeKeepingSearch.ForeColor = System.Drawing.Color.Black;
            this.txtTimeKeepingSearch.Location = new System.Drawing.Point(272, 58);
            this.txtTimeKeepingSearch.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.txtTimeKeepingSearch.Name = "txtTimeKeepingSearch";
            this.txtTimeKeepingSearch.Size = new System.Drawing.Size(600, 26);
            this.txtTimeKeepingSearch.TabIndex = 8;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(36)))), ((int)(((byte)(210)))));
            this.btnFilter.FlatAppearance.BorderSize = 0;
            this.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(18)))), ((int)(((byte)(167)))));
            this.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(36)))), ((int)(((byte)(210)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Image = global::BaketyManagement.Properties.Resources.filter;
            this.btnFilter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFilter.Location = new System.Drawing.Point(741, 260);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(166, 68);
            this.btnFilter.TabIndex = 7;
            this.btnFilter.Text = "Tính Lương Nhận";
            this.btnFilter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnTimeKeepingSearch
            // 
            this.btnTimeKeepingSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimeKeepingSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(36)))), ((int)(((byte)(210)))));
            this.btnTimeKeepingSearch.FlatAppearance.BorderSize = 0;
            this.btnTimeKeepingSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(18)))), ((int)(((byte)(167)))));
            this.btnTimeKeepingSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(36)))), ((int)(((byte)(210)))));
            this.btnTimeKeepingSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimeKeepingSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnTimeKeepingSearch.ForeColor = System.Drawing.Color.White;
            this.btnTimeKeepingSearch.Image = global::BaketyManagement.Properties.Resources.Search;
            this.btnTimeKeepingSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTimeKeepingSearch.Location = new System.Drawing.Point(925, 58);
            this.btnTimeKeepingSearch.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.btnTimeKeepingSearch.Name = "btnTimeKeepingSearch";
            this.btnTimeKeepingSearch.Size = new System.Drawing.Size(166, 70);
            this.btnTimeKeepingSearch.TabIndex = 7;
            this.btnTimeKeepingSearch.Text = "Tìm";
            this.btnTimeKeepingSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTimeKeepingSearch.UseVisualStyleBackColor = false;
            this.btnTimeKeepingSearch.Click += new System.EventHandler(this.btnTimeKeepingSearch_Click);
            // 
            // pnTimeKeeping
            // 
            this.pnTimeKeeping.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.pnTimeKeeping.Controls.Add(this.groupBox1);
            this.pnTimeKeeping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTimeKeeping.Location = new System.Drawing.Point(30, 30);
            this.pnTimeKeeping.Margin = new System.Windows.Forms.Padding(10);
            this.pnTimeKeeping.Name = "pnTimeKeeping";
            this.pnTimeKeeping.Size = new System.Drawing.Size(1137, 157);
            this.pnTimeKeeping.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1137, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách thông tin lương";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTimeKeeping);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1131, 132);
            this.panel1.TabIndex = 0;
            // 
            // dgvTimeKeeping
            // 
            this.dgvTimeKeeping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTimeKeeping.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimeKeeping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeKeeping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.maNhanVien,
            this.ngayChamCong,
            this.soGioLv,
            this.soGioLamThem});
            this.dgvTimeKeeping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimeKeeping.Location = new System.Drawing.Point(0, 0);
            this.dgvTimeKeeping.MultiSelect = false;
            this.dgvTimeKeeping.Name = "dgvTimeKeeping";
            this.dgvTimeKeeping.ReadOnly = true;
            this.dgvTimeKeeping.RowHeadersWidth = 51;
            this.dgvTimeKeeping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeKeeping.Size = new System.Drawing.Size(1131, 132);
            this.dgvTimeKeeping.TabIndex = 0;
            this.dgvTimeKeeping.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimeKeeping_CellClick);
            this.dgvTimeKeeping.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimeKeeping_CellContentClick);
            // 
            // name
            // 
            this.name.HeaderText = "Tên Nhân Viên";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // maNhanVien
            // 
            this.maNhanVien.HeaderText = "Mã Nhân Viên";
            this.maNhanVien.Name = "maNhanVien";
            this.maNhanVien.ReadOnly = true;
            // 
            // ngayChamCong
            // 
            this.ngayChamCong.HeaderText = "Ngày Chấm Công";
            this.ngayChamCong.Name = "ngayChamCong";
            this.ngayChamCong.ReadOnly = true;
            // 
            // soGioLv
            // 
            this.soGioLv.HeaderText = "Số giờ làm việc";
            this.soGioLv.Name = "soGioLv";
            this.soGioLv.ReadOnly = true;
            // 
            // soGioLamThem
            // 
            this.soGioLamThem.HeaderText = "Số giờ làm thêm";
            this.soGioLamThem.Name = "soGioLamThem";
            this.soGioLamThem.ReadOnly = true;
            // 
            // FrmTimeKeeping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 617);
            this.Controls.Add(this.tlpTimeKeeping);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmTimeKeeping";
            this.Text = "FrmTimeKeeping";
            this.Load += new System.EventHandler(this.FrmTimeKeeping_Load);
            this.tlpTimeKeeping.ResumeLayout(false);
            this.pnFunctionTimeKeeping.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pnFunctionSalary.ResumeLayout(false);
            this.pnFunctionSalary.PerformLayout();
            this.pnTimeKeeping.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeKeeping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpTimeKeeping;
        private System.Windows.Forms.Panel pnTimeKeeping;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnFunctionTimeKeeping;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTimeKeeping;
        private System.Windows.Forms.Panel pnFunctionSalary;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnTimeKeeping;
        private System.Windows.Forms.Button btnDisplaySalary;
        private System.Windows.Forms.Button btnEditSalary;
        private System.Windows.Forms.Button btnPrintSalary;
        private System.Windows.Forms.TextBox txtTimeKeepingSearch;
        private System.Windows.Forms.Button btnTimeKeepingSearch;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn soGioLv;
        private System.Windows.Forms.DataGridViewTextBoxColumn soGioLamThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
    }
}