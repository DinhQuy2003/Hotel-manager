
namespace BTL
{
    partial class ftimkiemphong
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblsophong = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.btnketthuc = new Guna.UI.WinForms.GunaButton();
            this.cmbtrangthai = new Guna.UI.WinForms.GunaComboBox();
            this.btnchon = new Guna.UI.WinForms.GunaButton();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.cmbsogiuong = new Guna.UI.WinForms.GunaComboBox();
            this.cmbloai = new Guna.UI.WinForms.GunaComboBox();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.grdPhong = new System.Windows.Forms.DataGridView();
            this.idphong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiphong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sogiuong1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaphong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gunaLabel6 = new Guna.UI.WinForms.GunaLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BTL.Properties.Resources._5c01afda97f678cf801271eebb041ba61;
            this.panel1.Controls.Add(this.lblsophong);
            this.panel1.Controls.Add(this.gunaLabel4);
            this.panel1.Controls.Add(this.btnketthuc);
            this.panel1.Controls.Add(this.cmbtrangthai);
            this.panel1.Controls.Add(this.btnchon);
            this.panel1.Controls.Add(this.btntimkiem);
            this.panel1.Controls.Add(this.cmbsogiuong);
            this.panel1.Controls.Add(this.cmbloai);
            this.panel1.Controls.Add(this.gunaLabel3);
            this.panel1.Controls.Add(this.gunaLabel2);
            this.panel1.Controls.Add(this.gunaLabel1);
            this.panel1.Controls.Add(this.grdPhong);
            this.panel1.Controls.Add(this.gunaLabel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 450);
            this.panel1.TabIndex = 2;
            // 
            // lblsophong
            // 
            this.lblsophong.AutoSize = true;
            this.lblsophong.BackColor = System.Drawing.Color.Transparent;
            this.lblsophong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblsophong.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblsophong.Location = new System.Drawing.Point(650, 182);
            this.lblsophong.Name = "lblsophong";
            this.lblsophong.Size = new System.Drawing.Size(34, 21);
            this.lblsophong.TabIndex = 56;
            this.lblsophong.Text = "P....";
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunaLabel4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gunaLabel4.Location = new System.Drawing.Point(519, 185);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(125, 19);
            this.gunaLabel4.TabIndex = 55;
            this.gunaLabel4.Text = "Phòng đang chọn: ";
            // 
            // btnketthuc
            // 
            this.btnketthuc.AnimationHoverSpeed = 0.07F;
            this.btnketthuc.AnimationSpeed = 0.03F;
            this.btnketthuc.BaseColor = System.Drawing.Color.Red;
            this.btnketthuc.BorderColor = System.Drawing.Color.Black;
            this.btnketthuc.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnketthuc.FocusedColor = System.Drawing.Color.Empty;
            this.btnketthuc.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnketthuc.ForeColor = System.Drawing.Color.White;
            this.btnketthuc.Image = null;
            this.btnketthuc.ImageSize = new System.Drawing.Size(20, 20);
            this.btnketthuc.Location = new System.Drawing.Point(735, 396);
            this.btnketthuc.Name = "btnketthuc";
            this.btnketthuc.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnketthuc.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnketthuc.OnHoverForeColor = System.Drawing.Color.White;
            this.btnketthuc.OnHoverImage = null;
            this.btnketthuc.OnPressedColor = System.Drawing.Color.Black;
            this.btnketthuc.Size = new System.Drawing.Size(83, 33);
            this.btnketthuc.TabIndex = 54;
            this.btnketthuc.Text = "Đóng";
            this.btnketthuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnketthuc.Click += new System.EventHandler(this.btnketthuc_Click);
            // 
            // cmbtrangthai
            // 
            this.cmbtrangthai.BackColor = System.Drawing.Color.Transparent;
            this.cmbtrangthai.BaseColor = System.Drawing.Color.White;
            this.cmbtrangthai.BorderColor = System.Drawing.Color.Silver;
            this.cmbtrangthai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbtrangthai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbtrangthai.FocusedColor = System.Drawing.Color.Empty;
            this.cmbtrangthai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbtrangthai.ForeColor = System.Drawing.Color.Black;
            this.cmbtrangthai.FormattingEnabled = true;
            this.cmbtrangthai.Items.AddRange(new object[] {
            "",
            "Trống",
            "Có người"});
            this.cmbtrangthai.Location = new System.Drawing.Point(626, 25);
            this.cmbtrangthai.Name = "cmbtrangthai";
            this.cmbtrangthai.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbtrangthai.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbtrangthai.Size = new System.Drawing.Size(160, 26);
            this.cmbtrangthai.TabIndex = 53;
            // 
            // btnchon
            // 
            this.btnchon.AnimationHoverSpeed = 0.07F;
            this.btnchon.AnimationSpeed = 0.03F;
            this.btnchon.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnchon.BorderColor = System.Drawing.Color.Black;
            this.btnchon.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnchon.FocusedColor = System.Drawing.Color.Empty;
            this.btnchon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnchon.ForeColor = System.Drawing.Color.White;
            this.btnchon.Image = null;
            this.btnchon.ImageSize = new System.Drawing.Size(20, 20);
            this.btnchon.Location = new System.Drawing.Point(607, 304);
            this.btnchon.Name = "btnchon";
            this.btnchon.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnchon.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnchon.OnHoverForeColor = System.Drawing.Color.White;
            this.btnchon.OnHoverImage = null;
            this.btnchon.OnPressedColor = System.Drawing.Color.Black;
            this.btnchon.Size = new System.Drawing.Size(95, 42);
            this.btnchon.TabIndex = 52;
            this.btnchon.Text = "Chọn";
            this.btnchon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnchon.Click += new System.EventHandler(this.btnchon_Click);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntimkiem.Location = new System.Drawing.Point(607, 227);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(95, 38);
            this.btntimkiem.TabIndex = 51;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // cmbsogiuong
            // 
            this.cmbsogiuong.BackColor = System.Drawing.Color.Transparent;
            this.cmbsogiuong.BaseColor = System.Drawing.Color.White;
            this.cmbsogiuong.BorderColor = System.Drawing.Color.Silver;
            this.cmbsogiuong.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbsogiuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbsogiuong.FocusedColor = System.Drawing.Color.Empty;
            this.cmbsogiuong.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbsogiuong.ForeColor = System.Drawing.Color.Black;
            this.cmbsogiuong.FormattingEnabled = true;
            this.cmbsogiuong.Items.AddRange(new object[] {
            "",
            "1",
            "2"});
            this.cmbsogiuong.Location = new System.Drawing.Point(626, 129);
            this.cmbsogiuong.Name = "cmbsogiuong";
            this.cmbsogiuong.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbsogiuong.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbsogiuong.Size = new System.Drawing.Size(160, 26);
            this.cmbsogiuong.TabIndex = 50;
            // 
            // cmbloai
            // 
            this.cmbloai.BackColor = System.Drawing.Color.Transparent;
            this.cmbloai.BaseColor = System.Drawing.Color.White;
            this.cmbloai.BorderColor = System.Drawing.Color.Silver;
            this.cmbloai.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbloai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbloai.FocusedColor = System.Drawing.Color.Empty;
            this.cmbloai.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbloai.ForeColor = System.Drawing.Color.Black;
            this.cmbloai.FormattingEnabled = true;
            this.cmbloai.Items.AddRange(new object[] {
            "",
            "Thường",
            "Vip"});
            this.cmbloai.Location = new System.Drawing.Point(626, 77);
            this.cmbloai.Name = "cmbloai";
            this.cmbloai.OnHoverItemBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.cmbloai.OnHoverItemForeColor = System.Drawing.Color.White;
            this.cmbloai.Size = new System.Drawing.Size(160, 26);
            this.cmbloai.TabIndex = 49;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunaLabel3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gunaLabel3.Location = new System.Drawing.Point(519, 134);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(74, 19);
            this.gunaLabel3.TabIndex = 47;
            this.gunaLabel3.Text = "Số giường:";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunaLabel2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gunaLabel2.Location = new System.Drawing.Point(519, 83);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(81, 19);
            this.gunaLabel2.TabIndex = 46;
            this.gunaLabel2.Text = "Loại phòng:";
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.gunaLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gunaLabel1.Location = new System.Drawing.Point(519, 32);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(73, 19);
            this.gunaLabel1.TabIndex = 45;
            this.gunaLabel1.Text = "Trạng thái:";
            // 
            // grdPhong
            // 
            this.grdPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idphong,
            this.loaiphong,
            this.sogiuong1,
            this.trangthai,
            this.giaphong});
            this.grdPhong.Location = new System.Drawing.Point(12, 32);
            this.grdPhong.Name = "grdPhong";
            this.grdPhong.Size = new System.Drawing.Size(449, 406);
            this.grdPhong.TabIndex = 44;
            // 
            // idphong
            // 
            this.idphong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idphong.DataPropertyName = "idphong";
            this.idphong.HeaderText = "Số phòng";
            this.idphong.Name = "idphong";
            this.idphong.Width = 78;
            // 
            // loaiphong
            // 
            this.loaiphong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.loaiphong.DataPropertyName = "loaiphong";
            this.loaiphong.HeaderText = "Loại phòng";
            this.loaiphong.Name = "loaiphong";
            this.loaiphong.Width = 85;
            // 
            // sogiuong1
            // 
            this.sogiuong1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sogiuong1.DataPropertyName = "sogiuong";
            this.sogiuong1.HeaderText = "Số giường";
            this.sogiuong1.Name = "sogiuong1";
            this.sogiuong1.Width = 80;
            // 
            // trangthai
            // 
            this.trangthai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.trangthai.DataPropertyName = "trangthai";
            this.trangthai.HeaderText = "Trạng thái";
            this.trangthai.Name = "trangthai";
            this.trangthai.Width = 80;
            // 
            // giaphong
            // 
            this.giaphong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.giaphong.DataPropertyName = "giaphong";
            this.giaphong.HeaderText = "Giá phòng";
            this.giaphong.Name = "giaphong";
            this.giaphong.Width = 81;
            // 
            // gunaLabel6
            // 
            this.gunaLabel6.AutoSize = true;
            this.gunaLabel6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.gunaLabel6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaLabel6.ForeColor = System.Drawing.Color.White;
            this.gunaLabel6.Location = new System.Drawing.Point(13, 13);
            this.gunaLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gunaLabel6.Name = "gunaLabel6";
            this.gunaLabel6.Size = new System.Drawing.Size(86, 20);
            this.gunaLabel6.TabIndex = 25;
            this.gunaLabel6.Text = "Bảng phòng";
            // 
            // ftimkiemphong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 450);
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(473, 88);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ftimkiemphong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm phòng";
            this.Load += new System.EventHandler(this.ftimkiemphong_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel6;
        private System.Windows.Forms.DataGridView grdPhong;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private System.Windows.Forms.Button btntimkiem;
        private Guna.UI.WinForms.GunaComboBox cmbsogiuong;
        private Guna.UI.WinForms.GunaComboBox cmbloai;
        private Guna.UI.WinForms.GunaButton btnchon;
        private Guna.UI.WinForms.GunaComboBox cmbtrangthai;
        private System.Windows.Forms.DataGridViewTextBoxColumn idphong;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiphong;
        private System.Windows.Forms.DataGridViewTextBoxColumn sogiuong1;
        private System.Windows.Forms.DataGridViewTextBoxColumn trangthai;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaphong;
        private Guna.UI.WinForms.GunaButton btnketthuc;
        private Guna.UI.WinForms.GunaLabel lblsophong;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
    }
}