namespace QuanLyThuVien
{
    partial class frmQuanLyTaiKhoan
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
            this.lblTim = new System.Windows.Forms.Label();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.lblLocVaiTro = new System.Windows.Forms.Label();
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();
            this.lblSoDong = new System.Windows.Forms.Label();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.lblCapMa = new System.Windows.Forms.Label();
            this.lblMa = new System.Windows.Forms.Label();
            this.lblCapUsername = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblCapHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblCapGioiTinh = new System.Windows.Forms.Label();
            this.rdoNam = new System.Windows.Forms.RadioButton();
            this.rdoNu = new System.Windows.Forms.RadioButton();
            this.lblCapEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblCapVaiTro = new System.Windows.Forms.Label();
            this.cboVaiTro = new System.Windows.Forms.ComboBox();
            this.lblCapNgayTao = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.gbChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTim
            // 
            this.lblTim.AutoSize = true;
            this.lblTim.Location = new System.Drawing.Point(20, 58);
            this.lblTim.Name = "lblTim";
            this.lblTim.Size = new System.Drawing.Size(30, 16);
            this.lblTim.TabIndex = 0;
            this.lblTim.Text = "Tìm";
            // 
            // txtTim
            // 
            this.txtTim.Location = new System.Drawing.Point(55, 55);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(240, 22);
            this.txtTim.TabIndex = 1;
            this.txtTim.TextChanged += new System.EventHandler(this.cboLocVaiTro_SelectedIndexChanged);
            // 
            // lblLocVaiTro
            // 
            this.lblLocVaiTro.AutoSize = true;
            this.lblLocVaiTro.Location = new System.Drawing.Point(320, 58);
            this.lblLocVaiTro.Name = "lblLocVaiTro";
            this.lblLocVaiTro.Size = new System.Drawing.Size(51, 16);
            this.lblLocVaiTro.TabIndex = 2;
            this.lblLocVaiTro.Text = "Vai Trò";
            // 
            // cboLocVaiTro
            // 
            this.cboLocVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocVaiTro.FormattingEnabled = true;
            this.cboLocVaiTro.Location = new System.Drawing.Point(375, 55);
            this.cboLocVaiTro.Name = "cboLocVaiTro";
            this.cboLocVaiTro.Size = new System.Drawing.Size(130, 24);
            this.cboLocVaiTro.TabIndex = 3;
            this.cboLocVaiTro.SelectedIndexChanged += new System.EventHandler(this.cboLocVaiTro_SelectedIndexChanged);
            // 
            // lblSoDong
            // 
            this.lblSoDong.AutoSize = true;
            this.lblSoDong.Location = new System.Drawing.Point(530, 58);
            this.lblSoDong.Name = "lblSoDong";
            this.lblSoDong.Size = new System.Drawing.Size(94, 16);
            this.lblSoDong.TabIndex = 4;
            this.lblSoDong.Text = "Số tài khoản: 0";
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AllowUserToAddRows = false;
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMa,
            this.colUsername,
            this.colHoTen,
            this.colVaiTro,
            this.colGioiTinh,
            this.Email,
            this.colNgayTao});
            this.dgvTaiKhoan.Location = new System.Drawing.Point(2, 85);
            this.dgvTaiKhoan.MultiSelect = false;
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.ReadOnly = true;
            this.dgvTaiKhoan.RowHeadersVisible = false;
            this.dgvTaiKhoan.RowHeadersWidth = 51;
            this.dgvTaiKhoan.RowTemplate.Height = 24;
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaiKhoan.Size = new System.Drawing.Size(700, 525);
            this.dgvTaiKhoan.TabIndex = 5;
            this.dgvTaiKhoan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTaiKhoan_CellFormatting);
            this.dgvTaiKhoan.SelectionChanged += new System.EventHandler(this.dgvTaiKhoan_SelectionChanged);
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.lblNgayTao);
            this.gbChiTiet.Controls.Add(this.btnXoa);
            this.gbChiTiet.Controls.Add(this.btnLuu);
            this.gbChiTiet.Controls.Add(this.lblCapNgayTao);
            this.gbChiTiet.Controls.Add(this.cboVaiTro);
            this.gbChiTiet.Controls.Add(this.lblCapVaiTro);
            this.gbChiTiet.Controls.Add(this.txtEmail);
            this.gbChiTiet.Controls.Add(this.lblCapEmail);
            this.gbChiTiet.Controls.Add(this.rdoNu);
            this.gbChiTiet.Controls.Add(this.rdoNam);
            this.gbChiTiet.Controls.Add(this.lblCapGioiTinh);
            this.gbChiTiet.Controls.Add(this.txtHoTen);
            this.gbChiTiet.Controls.Add(this.lblCapHoTen);
            this.gbChiTiet.Controls.Add(this.lblUsername);
            this.gbChiTiet.Controls.Add(this.lblCapUsername);
            this.gbChiTiet.Controls.Add(this.lblMa);
            this.gbChiTiet.Controls.Add(this.lblCapMa);
            this.gbChiTiet.Location = new System.Drawing.Point(740, 95);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(340, 320);
            this.gbChiTiet.TabIndex = 6;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Chi tiết tài khoản";
            this.gbChiTiet.Enter += new System.EventHandler(this.gbChiTiet_Enter);
            // 
            // lblCapMa
            // 
            this.lblCapMa.AutoSize = true;
            this.lblCapMa.Location = new System.Drawing.Point(15, 28);
            this.lblCapMa.Name = "lblCapMa";
            this.lblCapMa.Size = new System.Drawing.Size(86, 16);
            this.lblCapMa.TabIndex = 0;
            this.lblCapMa.Text = "Mã tài khoản ";
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Location = new System.Drawing.Point(125, 28);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(0, 16);
            this.lblMa.TabIndex = 1;
            // 
            // lblCapUsername
            // 
            this.lblCapUsername.AutoSize = true;
            this.lblCapUsername.Location = new System.Drawing.Point(15, 58);
            this.lblCapUsername.Name = "lblCapUsername";
            this.lblCapUsername.Size = new System.Drawing.Size(70, 16);
            this.lblCapUsername.TabIndex = 2;
            this.lblCapUsername.Text = "Username";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(125, 58);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 16);
            this.lblUsername.TabIndex = 3;
            // 
            // lblCapHoTen
            // 
            this.lblCapHoTen.AutoSize = true;
            this.lblCapHoTen.Location = new System.Drawing.Point(15, 88);
            this.lblCapHoTen.Name = "lblCapHoTen";
            this.lblCapHoTen.Size = new System.Drawing.Size(55, 16);
            this.lblCapHoTen.TabIndex = 4;
            this.lblCapHoTen.Text = "Họ Tên ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(125, 85);
            this.txtHoTen.MaxLength = 50;
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(195, 22);
            this.txtHoTen.TabIndex = 5;
            // 
            // lblCapGioiTinh
            // 
            this.lblCapGioiTinh.AutoSize = true;
            this.lblCapGioiTinh.Location = new System.Drawing.Point(15, 120);
            this.lblCapGioiTinh.Name = "lblCapGioiTinh";
            this.lblCapGioiTinh.Size = new System.Drawing.Size(54, 16);
            this.lblCapGioiTinh.TabIndex = 6;
            this.lblCapGioiTinh.Text = "Giới tính";
            // 
            // rdoNam
            // 
            this.rdoNam.AutoSize = true;
            this.rdoNam.Location = new System.Drawing.Point(125, 121);
            this.rdoNam.Name = "rdoNam";
            this.rdoNam.Size = new System.Drawing.Size(57, 20);
            this.rdoNam.TabIndex = 7;
            this.rdoNam.TabStop = true;
            this.rdoNam.Text = "Nam";
            this.rdoNam.UseVisualStyleBackColor = true;
            // 
            // rdoNu
            // 
            this.rdoNu.AutoSize = true;
            this.rdoNu.Location = new System.Drawing.Point(200, 121);
            this.rdoNu.Name = "rdoNu";
            this.rdoNu.Size = new System.Drawing.Size(45, 20);
            this.rdoNu.TabIndex = 8;
            this.rdoNu.TabStop = true;
            this.rdoNu.Text = "Nữ";
            this.rdoNu.UseVisualStyleBackColor = true;
            // 
            // lblCapEmail
            // 
            this.lblCapEmail.AutoSize = true;
            this.lblCapEmail.Location = new System.Drawing.Point(15, 150);
            this.lblCapEmail.Name = "lblCapEmail";
            this.lblCapEmail.Size = new System.Drawing.Size(41, 16);
            this.lblCapEmail.TabIndex = 10;
            this.lblCapEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(125, 150);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(195, 22);
            this.txtEmail.TabIndex = 11;
            // 
            // lblCapVaiTro
            // 
            this.lblCapVaiTro.AutoSize = true;
            this.lblCapVaiTro.Location = new System.Drawing.Point(15, 182);
            this.lblCapVaiTro.Name = "lblCapVaiTro";
            this.lblCapVaiTro.Size = new System.Drawing.Size(51, 16);
            this.lblCapVaiTro.TabIndex = 12;
            this.lblCapVaiTro.Text = "Vai Trò";
            // 
            // cboVaiTro
            // 
            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(125, 179);
            this.cboVaiTro.Name = "cboVaiTro";
            this.cboVaiTro.Size = new System.Drawing.Size(130, 24);
            this.cboVaiTro.TabIndex = 13;
            // 
            // lblCapNgayTao
            // 
            this.lblCapNgayTao.AutoSize = true;
            this.lblCapNgayTao.Location = new System.Drawing.Point(15, 214);
            this.lblCapNgayTao.Name = "lblCapNgayTao";
            this.lblCapNgayTao.Size = new System.Drawing.Size(68, 16);
            this.lblCapNgayTao.TabIndex = 14;
            this.lblCapNgayTao.Text = "Ngày Tạo";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(15, 255);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 28);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "Lưu thay đổi";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(175, 255);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(145, 28);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xoá tài khoản";
            this.btnXoa.UseVisualStyleBackColor = true;
            // 
            // lblNgayTao
            // 
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Location = new System.Drawing.Point(102, 214);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Size = new System.Drawing.Size(0, 16);
            this.lblNgayTao.TabIndex = 18;
            // 
            // colMa
            // 
            this.colMa.DataPropertyName = "MaTaiKhoan";
            this.colMa.HeaderText = "Mã TK";
            this.colMa.MinimumWidth = 6;
            this.colMa.Name = "colMa";
            this.colMa.ReadOnly = true;
            // 
            // colUsername
            // 
            this.colUsername.DataPropertyName = "Username";
            this.colUsername.HeaderText = "Username";
            this.colUsername.MinimumWidth = 6;
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;
            // 
            // colHoTen
            // 
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;
            // 
            // colVaiTro
            // 
            this.colVaiTro.DataPropertyName = "VaiTro";
            this.colVaiTro.HeaderText = "Vai trò";
            this.colVaiTro.MinimumWidth = 6;
            this.colVaiTro.Name = "colVaiTro";
            this.colVaiTro.ReadOnly = true;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.DataPropertyName = "GioiTinh";
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.MinimumWidth = 6;
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // colNgayTao
            // 
            this.colNgayTao.DataPropertyName = "NgayTao";
            this.colNgayTao.HeaderText = "Ngày tạo";
            this.colNgayTao.MinimumWidth = 6;
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            // 
            // frmQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 593);
            this.Controls.Add(this.gbChiTiet);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.lblSoDong);
            this.Controls.Add(this.cboLocVaiTro);
            this.Controls.Add(this.lblLocVaiTro);
            this.Controls.Add(this.txtTim);
            this.Controls.Add(this.lblTim);
            this.Name = "frmQuanLyTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLyTaiKhoan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.gbChiTiet.ResumeLayout(false);
            this.gbChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTim;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Label lblLocVaiTro;
        private System.Windows.Forms.ComboBox cboLocVaiTro;
        private System.Windows.Forms.Label lblSoDong;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label lblCapMa;
        private System.Windows.Forms.RadioButton rdoNu;
        private System.Windows.Forms.RadioButton rdoNam;
        private System.Windows.Forms.Label lblCapGioiTinh;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblCapHoTen;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblCapUsername;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Label lblCapNgayTao;
        private System.Windows.Forms.ComboBox cboVaiTro;
        private System.Windows.Forms.Label lblCapVaiTro;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblCapEmail;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaiTro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
    }
}