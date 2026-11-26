// =====================================================================
// File: frmAccountManagement.Designer.cs
// Mô tả: File thiết kế giao diện (Designer) cho form Quản Lý Tài Khoản.
//         File này được Visual Studio tự sinh ra khi kéo thả control.
//         ⚠️  Ở đây ta chỉnh tay để làm đẹp giao diện (màu, font, bo góc...).
//         → Logic nghiệp vụ nằm trong frmAccountManagement.cs
//         → Kết nối SQL nằm trong Database.cs và AccountDAL.cs
//
// NGUYÊN TẮC CẢI THIỆN GIAO DIỆN:
//   • Bảng màu chính: xanh navy (#1B2A4A) + trắng + xám nhạt
//   • Font chữ: Segoe UI (sạch sẽ, hiện đại, có sẵn trên Windows)
//   • DataGridView: header xanh đậm, dòng xen kẽ màu, hover highlight
//   • Nút bấm: có màu nền, chữ trắng, viền bo
//   • GroupBox chi tiết: nền trắng, viền nhẹ
//   • Thanh tiêu đề tự vẽ: Panel gradient xanh navy ở trên cùng
// =====================================================================

namespace LibraryManagement
{
    partial class frmAccountManagement
    {
        /// <summary>
        /// Biến quản lý tài nguyên của form (bắt buộc, do Designer sinh ra).
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Giải phóng tài nguyên khi form bị đóng.
        /// disposing = true → giải phóng cả tài nguyên managed lẫn unmanaged.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose(); // Giải phóng các control con
            }
            base.Dispose(disposing); // Gọi Dispose của lớp cha (Form)
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Phương thức khởi tạo giao diện — tạo và cấu hình tất cả control.
        /// ⚠️  Không nên sửa bằng code editor nếu dùng Designer kéo thả,
        ///     nhưng ở đây ta sửa tay để tùy chỉnh giao diện đẹp hơn.
        /// </summary>
        private void InitializeComponent()
        {
            // ─────────────────────────────────────────────────────────
            // BƯỚC 1: KHAI BÁO (tạo đối tượng) tất cả control
            // ─────────────────────────────────────────────────────────

            // === Panel tiêu đề trên cùng (thay thế thanh title mặc định) ===
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();

            // === Khu vực tìm kiếm và lọc ===
            this.pnlTimKiem = new System.Windows.Forms.Panel();       // Panel chứa ô tìm + bộ lọc
            this.lblTim = new System.Windows.Forms.Label();           // Nhãn "🔍 Tìm kiếm"
            this.txtTim = new System.Windows.Forms.TextBox();         // Ô nhập từ khoá tìm kiếm
            this.lblLocVaiTro = new System.Windows.Forms.Label();     // Nhãn "Vai Trò"
            this.cboLocVaiTro = new System.Windows.Forms.ComboBox();  // ComboBox lọc theo vai trò
            this.lblSoDong = new System.Windows.Forms.Label();        // Nhãn hiển thị số tài khoản

            // === Bảng danh sách tài khoản (DataGridView) ===
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();

            // === Các cột của DataGridView ===
            this.colMa = new System.Windows.Forms.DataGridViewTextBoxColumn();       // Cột Mã TK
            this.colUsername = new System.Windows.Forms.DataGridViewTextBoxColumn();  // Cột Username
            this.colHoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();    // Cột Họ tên
            this.colVaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();   // Cột Vai trò
            this.colGioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn(); // Cột Giới tính
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();       // Cột Email
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();  // Cột Ngày tạo

            // === GroupBox chi tiết tài khoản (bên phải) ===
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.lblCapMa = new System.Windows.Forms.Label();         // Nhãn "Mã tài khoản"
            this.lblMa = new System.Windows.Forms.Label();            // Giá trị mã TK
            this.lblCapUsername = new System.Windows.Forms.Label();    // Nhãn "Username"
            this.lblUsername = new System.Windows.Forms.Label();       // Giá trị username
            this.lblCapHoTen = new System.Windows.Forms.Label();      // Nhãn "Họ Tên"
            this.txtHoTen = new System.Windows.Forms.TextBox();       // Ô nhập họ tên (có thể sửa)
            this.lblCapGioiTinh = new System.Windows.Forms.Label();   // Nhãn "Giới tính"
            this.rdoNam = new System.Windows.Forms.RadioButton();     // Nút chọn "Nam"
            this.rdoNu = new System.Windows.Forms.RadioButton();      // Nút chọn "Nữ"
            this.lblCapEmail = new System.Windows.Forms.Label();      // Nhãn "Email"
            this.txtEmail = new System.Windows.Forms.TextBox();       // Ô nhập email (có thể sửa)
            this.lblCapVaiTro = new System.Windows.Forms.Label();     // Nhãn "Vai Trò"
            this.cboVaiTro = new System.Windows.Forms.ComboBox();     // ComboBox chọn vai trò
            this.lblCapNgayTao = new System.Windows.Forms.Label();    // Nhãn "Ngày Tạo"
            this.lblNgayTao = new System.Windows.Forms.Label();       // Giá trị ngày tạo

            // === Hai nút hành động ===
            this.btnLuu = new System.Windows.Forms.Button();          // Nút "💾 Lưu thay đổi"
            this.btnXoa = new System.Windows.Forms.Button();          // Nút "🗑 Xoá tài khoản"

            // ─────────────────────────────────────────────────────────
            // BƯỚC 2: TẠM DỪNG CẬP NHẬT GIAO DIỆN (tăng hiệu suất)
            // ─────────────────────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlTimKiem.SuspendLayout();
            this.gbChiTiet.SuspendLayout();
            this.SuspendLayout();

            // ═════════════════════════════════════════════════════════
            //  BẢNG MÀU CHÍNH (thay đổi ở đây để đổi theme toàn bộ)
            // ═════════════════════════════════════════════════════════
            //  Màu header / nền chính:    Navy đậm   = (27, 42, 74)   ~ #1B2A4A
            //  Màu accent / nút Lưu:      Xanh dương = (0, 122, 204)  ~ #007ACC
            //  Màu nút Xoá:               Đỏ nhạt    = (220, 53, 69)  ~ #DC3545
            //  Màu nền form:              Xám rất nhạt = (243, 244, 246) ~ #F3F4F6
            //  Màu nền GroupBox:          Trắng      = (255, 255, 255)
            //  Màu chữ trên header:       Trắng      = (255, 255, 255)
            //  Màu chữ nhãn thường:       Xám đậm   = (55, 65, 81)   ~ #374151
            //  Màu dòng xen kẽ trong DGV: Xanh rất nhạt = (234, 242, 252)
            // ═════════════════════════════════════════════════════════

            // ─────────────────────────────────────────────────────────
            // PANEL HEADER — Thanh tiêu đề xanh navy trên cùng
            // ─────────────────────────────────────────────────────────
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(27, 42, 74);       // Nền xanh navy đậm
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;                    // Dính sát mép trên
            this.pnlHeader.Size = new System.Drawing.Size(1120, 56);                     // Cao 56 pixel
            this.pnlHeader.Controls.Add(this.lblTieuDe);                                 // Chứa nhãn tiêu đề

            // ─────────────────────────────────────────────────────────
            // LABEL TIÊU ĐỀ — Chữ trắng to nằm trong header
            // ─────────────────────────────────────────────────────────
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;                       // Chữ trắng
            this.lblTieuDe.Location = new System.Drawing.Point(20, 12);
            this.lblTieuDe.Text = "📋  QUẢN LÝ TÀI KHOẢN";                              // Tiêu đề có icon

            // ─────────────────────────────────────────────────────────
            // PANEL TÌM KIẾM — Thanh ngang chứa ô tìm, bộ lọc, số dòng
            // ─────────────────────────────────────────────────────────
            this.pnlTimKiem.BackColor = System.Drawing.Color.White;                      // Nền trắng
            this.pnlTimKiem.Location = new System.Drawing.Point(16, 68);                 // Vị trí dưới header
            this.pnlTimKiem.Size = new System.Drawing.Size(1088, 50);                    // Chiều rộng gần hết form
            this.pnlTimKiem.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlTimKiem.Controls.Add(this.lblTim);
            this.pnlTimKiem.Controls.Add(this.txtTim);
            this.pnlTimKiem.Controls.Add(this.lblLocVaiTro);
            this.pnlTimKiem.Controls.Add(this.cboLocVaiTro);
            this.pnlTimKiem.Controls.Add(this.lblSoDong);

            // ─────────────────────────────────────────────────────────
            // NHÃN "🔍 Tìm kiếm" — Bên trái thanh tìm kiếm
            // ─────────────────────────────────────────────────────────
            this.lblTim.AutoSize = true;
            this.lblTim.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblTim.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);           // Xám đậm
            this.lblTim.Location = new System.Drawing.Point(12, 14);
            this.lblTim.Text = "🔍 Tìm kiếm";

            // ─────────────────────────────────────────────────────────
            // Ô NHẬP TỪ KHOÁ TÌM KIẾM
            // ─────────────────────────────────────────────────────────
            this.txtTim.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTim.Location = new System.Drawing.Point(120, 11);
            this.txtTim.Size = new System.Drawing.Size(280, 30);
            this.txtTim.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);        // Nền xám nhạt
            this.txtTim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;      // Viền mỏng
            this.txtTim.TabIndex = 1;
            // Gắn sự kiện: mỗi khi gõ chữ → gọi lại bộ lọc (tìm kiếm real-time)
            this.txtTim.TextChanged += new System.EventHandler(this.txtTim_TextChanged);

            // ─────────────────────────────────────────────────────────
            // NHÃN "Vai Trò" — Bên phải ô tìm kiếm
            // ─────────────────────────────────────────────────────────
            this.lblLocVaiTro.AutoSize = true;
            this.lblLocVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLocVaiTro.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblLocVaiTro.Location = new System.Drawing.Point(430, 14);
            this.lblLocVaiTro.Text = "Vai Trò";

            // ─────────────────────────────────────────────────────────
            // COMBOBOX LỌC THEO VAI TRÒ
            // ─────────────────────────────────────────────────────────
            this.cboLocVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Chỉ chọn, không gõ
            this.cboLocVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocVaiTro.FormattingEnabled = true;
            this.cboLocVaiTro.Location = new System.Drawing.Point(500, 10);
            this.cboLocVaiTro.Size = new System.Drawing.Size(150, 30);
            this.cboLocVaiTro.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.cboLocVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocVaiTro.TabIndex = 3;
            // Gắn sự kiện: khi đổi lựa chọn → lọc lại danh sách
            this.cboLocVaiTro.SelectedIndexChanged += new System.EventHandler(this.cboLocVaiTro_SelectedIndexChanged);

            // ─────────────────────────────────────────────────────────
            // NHÃN SỐ TÀI KHOẢN — Hiển thị tổng số dòng sau lọc
            // ─────────────────────────────────────────────────────────
            this.lblSoDong.AutoSize = true;
            this.lblSoDong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoDong.ForeColor = System.Drawing.Color.FromArgb(0, 122, 204);       // Xanh dương nổi bật
            this.lblSoDong.Location = new System.Drawing.Point(690, 14);
            this.lblSoDong.Text = "Số tài khoản: 0";

            // ═════════════════════════════════════════════════════════
            // DATAGRIDVIEW — Bảng hiển thị danh sách tài khoản
            // ═════════════════════════════════════════════════════════

            // --- Cấu hình chung ---
            this.dgvTaiKhoan.AllowUserToAddRows = false;         // Không cho thêm dòng mới
            this.dgvTaiKhoan.AllowUserToDeleteRows = false;      // Không cho xoá dòng
            this.dgvTaiKhoan.ReadOnly = true;                    // Chỉ đọc (sửa trong GroupBox)
            this.dgvTaiKhoan.MultiSelect = false;                // Chỉ chọn 1 dòng
            this.dgvTaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // Chọn cả dòng
            this.dgvTaiKhoan.RowHeadersVisible = false;          // Ẩn cột header dòng (bên trái)
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Cột tự giãn

            // --- Vị trí và kích thước ---
            this.dgvTaiKhoan.Location = new System.Drawing.Point(16, 126);
            this.dgvTaiKhoan.Size = new System.Drawing.Size(700, 495);
            this.dgvTaiKhoan.TabIndex = 5;

            // --- Màu nền bảng ---
            this.dgvTaiKhoan.BackgroundColor = System.Drawing.Color.White;               // Nền trắng sạch
            this.dgvTaiKhoan.BorderStyle = System.Windows.Forms.BorderStyle.None;        // Không viền ngoài
            this.dgvTaiKhoan.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);   // Đường kẻ xám nhạt

            // --- Font chữ trong bảng ---
            this.dgvTaiKhoan.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvTaiKhoan.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);

            // --- Màu dòng xen kẽ (alternating rows) — dễ đọc hơn ---
            this.dgvTaiKhoan.AlternatingRowsDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(234, 242, 252);                            // Xanh rất nhạt

            // --- Màu khi chọn dòng (selection) ---
            this.dgvTaiKhoan.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(0, 122, 204);                              // Xanh dương đậm
            this.dgvTaiKhoan.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.White;                                               // Chữ trắng

            // --- Header cột: nền xanh navy, chữ trắng, đậm ---
            this.dgvTaiKhoan.EnableHeadersVisualStyles = false;                           // Tắt style mặc định
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(27, 42, 74);                               // Nền navy đậm
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.White;                                               // Chữ trắng
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold); // Đậm, 10pt
            this.dgvTaiKhoan.ColumnHeadersDefaultCellStyle.Padding =
                new System.Windows.Forms.Padding(5, 6, 5, 6);                            // Padding header
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;    // Tự co giãn chiều cao
            this.dgvTaiKhoan.ColumnHeadersBorderStyle =
                System.Windows.Forms.DataGridViewHeaderBorderStyle.None;                  // Không viền header

            // --- Chiều cao mỗi dòng ---
            this.dgvTaiKhoan.RowTemplate.Height = 32;
            this.dgvTaiKhoan.RowHeadersWidth = 51;

            // --- Thêm các cột vào DataGridView ---
            this.dgvTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colMa,
                this.colUsername,
                this.colHoTen,
                this.colVaiTro,
                this.colGioiTinh,
                this.Email,
                this.colNgayTao
            });

            // --- Gắn sự kiện ---
            this.dgvTaiKhoan.CellFormatting +=
                new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTaiKhoan_CellFormatting);
            this.dgvTaiKhoan.SelectionChanged +=
                new System.EventHandler(this.dgvTaiKhoan_SelectionChanged);

            // ─────────────────────────────────────────────────────────
            // CẤU HÌNH TỪNG CỘT (DataPropertyName phải khớp tên cột SQL)
            // ─────────────────────────────────────────────────────────

            // Cột Mã Tài Khoản
            this.colMa.DataPropertyName = "MaTaiKhoan";  // Tên cột trong DataTable
            this.colMa.HeaderText = "Mã TK";             // Tiêu đề hiển thị
            this.colMa.MinimumWidth = 6;
            this.colMa.Name = "colMa";
            this.colMa.ReadOnly = true;

            // Cột Username
            this.colUsername.DataPropertyName = "Username";
            this.colUsername.HeaderText = "Username";
            this.colUsername.MinimumWidth = 6;
            this.colUsername.Name = "colUsername";
            this.colUsername.ReadOnly = true;

            // Cột Họ Tên
            this.colHoTen.DataPropertyName = "HoTen";
            this.colHoTen.HeaderText = "Họ tên";
            this.colHoTen.MinimumWidth = 6;
            this.colHoTen.Name = "colHoTen";
            this.colHoTen.ReadOnly = true;

            // Cột Vai Trò
            this.colVaiTro.DataPropertyName = "VaiTro";
            this.colVaiTro.HeaderText = "Vai trò";
            this.colVaiTro.MinimumWidth = 6;
            this.colVaiTro.Name = "colVaiTro";
            this.colVaiTro.ReadOnly = true;

            // Cột Giới Tính (sẽ được format "Nam"/"Nữ" qua sự kiện CellFormatting)
            this.colGioiTinh.DataPropertyName = "GioiTinh";
            this.colGioiTinh.HeaderText = "Giới tính";
            this.colGioiTinh.MinimumWidth = 6;
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.ReadOnly = true;

            // Cột Email
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;

            // Cột Ngày Tạo
            this.colNgayTao.DataPropertyName = "NgayTao";
            this.colNgayTao.HeaderText = "Ngày tạo";
            this.colNgayTao.MinimumWidth = 6;
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;

            // ═════════════════════════════════════════════════════════
            // GROUPBOX CHI TIẾT TÀI KHOẢN — Panel bên phải
            // ═════════════════════════════════════════════════════════
            this.gbChiTiet.BackColor = System.Drawing.Color.White;                       // Nền trắng
            this.gbChiTiet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.gbChiTiet.ForeColor = System.Drawing.Color.FromArgb(27, 42, 74);        // Chữ tiêu đề xanh navy
            this.gbChiTiet.Location = new System.Drawing.Point(730, 126);
            this.gbChiTiet.Size = new System.Drawing.Size(374, 495);
            this.gbChiTiet.TabIndex = 6;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "  📝 Chi tiết tài khoản  ";
            this.gbChiTiet.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);

            // Thêm tất cả control con vào GroupBox
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
            // Gắn sự kiện Enter (khi focus vào GroupBox)
            this.gbChiTiet.Enter += new System.EventHandler(this.gbChiTiet_Enter);

            // ─────────────────────────────────────────────────────────
            // Font chung cho các nhãn trong GroupBox (không đậm)
            // ─────────────────────────────────────────────────────────
            System.Drawing.Font fontNhan = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            System.Drawing.Font fontGiaTri = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color mauNhan = System.Drawing.Color.FromArgb(107, 114, 128); // Xám trung bình
            System.Drawing.Color mauGiaTri = System.Drawing.Color.FromArgb(31, 41, 55);  // Gần đen

            // ─────────────────────────────────────────────────────────
            // NHÃN + GIÁ TRỊ: Mã tài khoản (chỉ hiển thị, không sửa)
            // ─────────────────────────────────────────────────────────
            this.lblCapMa.AutoSize = true;
            this.lblCapMa.Font = fontNhan;
            this.lblCapMa.ForeColor = mauNhan;
            this.lblCapMa.Location = new System.Drawing.Point(18, 38);
            this.lblCapMa.Text = "Mã tài khoản";

            this.lblMa.AutoSize = true;
            this.lblMa.Font = fontGiaTri;
            this.lblMa.ForeColor = mauGiaTri;
            this.lblMa.Location = new System.Drawing.Point(145, 38);
            this.lblMa.Text = "—";       // Giá trị mặc định khi chưa chọn dòng nào

            // ─────────────────────────────────────────────────────────
            // NHÃN + GIÁ TRỊ: Username (chỉ hiển thị, không sửa)
            // ─────────────────────────────────────────────────────────
            this.lblCapUsername.AutoSize = true;
            this.lblCapUsername.Font = fontNhan;
            this.lblCapUsername.ForeColor = mauNhan;
            this.lblCapUsername.Location = new System.Drawing.Point(18, 72);
            this.lblCapUsername.Text = "Username";

            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = fontGiaTri;
            this.lblUsername.ForeColor = mauGiaTri;
            this.lblUsername.Location = new System.Drawing.Point(145, 72);
            this.lblUsername.Text = "—";

            // ─────────────────────────────────────────────────────────
            // NHÃN + Ô NHẬP: Họ Tên (CÓ THỂ SỬA)
            // ─────────────────────────────────────────────────────────
            this.lblCapHoTen.AutoSize = true;
            this.lblCapHoTen.Font = fontNhan;
            this.lblCapHoTen.ForeColor = mauNhan;
            this.lblCapHoTen.Location = new System.Drawing.Point(18, 110);
            this.lblCapHoTen.Text = "Họ Tên";

            this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Location = new System.Drawing.Point(145, 107);
            this.txtHoTen.MaxLength = 50;                                                // Giới hạn 50 ký tự
            this.txtHoTen.Size = new System.Drawing.Size(210, 30);
            this.txtHoTen.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoTen.TabIndex = 5;

            // ─────────────────────────────────────────────────────────
            // NHÃN + RADIO BUTTON: Giới tính (Nam / Nữ)
            // ─────────────────────────────────────────────────────────
            this.lblCapGioiTinh.AutoSize = true;
            this.lblCapGioiTinh.Font = fontNhan;
            this.lblCapGioiTinh.ForeColor = mauNhan;
            this.lblCapGioiTinh.Location = new System.Drawing.Point(18, 150);
            this.lblCapGioiTinh.Text = "Giới tính";

            this.rdoNam.AutoSize = true;
            this.rdoNam.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoNam.ForeColor = mauGiaTri;
            this.rdoNam.Location = new System.Drawing.Point(145, 148);
            this.rdoNam.Text = "Nam";
            this.rdoNam.TabIndex = 7;
            this.rdoNam.UseVisualStyleBackColor = true;

            this.rdoNu.AutoSize = true;
            this.rdoNu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rdoNu.ForeColor = mauGiaTri;
            this.rdoNu.Location = new System.Drawing.Point(225, 148);
            this.rdoNu.Text = "Nữ";
            this.rdoNu.TabIndex = 8;
            this.rdoNu.UseVisualStyleBackColor = true;

            // ─────────────────────────────────────────────────────────
            // NHÃN + Ô NHẬP: Email (CÓ THỂ SỬA)
            // ─────────────────────────────────────────────────────────
            this.lblCapEmail.AutoSize = true;
            this.lblCapEmail.Font = fontNhan;
            this.lblCapEmail.ForeColor = mauNhan;
            this.lblCapEmail.Location = new System.Drawing.Point(18, 190);
            this.lblCapEmail.Text = "Email";

            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(145, 187);
            this.txtEmail.MaxLength = 100;                                               // Giới hạn 100 ký tự
            this.txtEmail.Size = new System.Drawing.Size(210, 30);
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.TabIndex = 11;

            // ─────────────────────────────────────────────────────────
            // NHÃN + COMBOBOX: Vai Trò (Admin / NhanVien)
            // ─────────────────────────────────────────────────────────
            this.lblCapVaiTro.AutoSize = true;
            this.lblCapVaiTro.Font = fontNhan;
            this.lblCapVaiTro.ForeColor = mauNhan;
            this.lblCapVaiTro.Location = new System.Drawing.Point(18, 230);
            this.lblCapVaiTro.Text = "Vai Trò";

            this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; // Chỉ chọn, không gõ
            this.cboVaiTro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboVaiTro.ForeColor = mauGiaTri;
            this.cboVaiTro.FormattingEnabled = true;
            this.cboVaiTro.Location = new System.Drawing.Point(145, 227);
            this.cboVaiTro.Size = new System.Drawing.Size(150, 30);
            this.cboVaiTro.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.cboVaiTro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboVaiTro.TabIndex = 13;

            // ─────────────────────────────────────────────────────────
            // NHÃN + GIÁ TRỊ: Ngày Tạo (chỉ hiển thị, không sửa)
            // ─────────────────────────────────────────────────────────
            this.lblCapNgayTao.AutoSize = true;
            this.lblCapNgayTao.Font = fontNhan;
            this.lblCapNgayTao.ForeColor = mauNhan;
            this.lblCapNgayTao.Location = new System.Drawing.Point(18, 272);
            this.lblCapNgayTao.Text = "Ngày Tạo";

            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Font = fontGiaTri;
            this.lblNgayTao.ForeColor = mauGiaTri;
            this.lblNgayTao.Location = new System.Drawing.Point(145, 272);
            this.lblNgayTao.Text = "—";

            // ─────────────────────────────────────────────────────────
            // NÚT "💾 Lưu thay đổi" — Màu xanh dương
            // ─────────────────────────────────────────────────────────
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;                 // Dùng flat style
            this.btnLuu.FlatAppearance.BorderSize = 0;                                   // Không viền
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);          // Nền xanh dương
            this.btnLuu.ForeColor = System.Drawing.Color.White;                          // Chữ trắng
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Location = new System.Drawing.Point(18, 320);
            this.btnLuu.Size = new System.Drawing.Size(165, 40);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "💾  Lưu thay đổi";
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;                      // Con trỏ tay khi hover
            this.btnLuu.UseVisualStyleBackColor = false;
            // Gắn sự kiện click → gọi hàm lưu dữ liệu
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);

            // ─────────────────────────────────────────────────────────
            // NÚT "🗑 Xoá tài khoản" — Màu đỏ
            // ─────────────────────────────────────────────────────────
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);          // Nền đỏ
            this.btnXoa.ForeColor = System.Drawing.Color.White;                          // Chữ trắng
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.Location = new System.Drawing.Point(193, 320);
            this.btnXoa.Size = new System.Drawing.Size(163, 40);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "🗑  Xoá tài khoản";
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.UseVisualStyleBackColor = false;

            // ═════════════════════════════════════════════════════════
            // CẤU HÌNH FORM CHÍNH
            // ═════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 640);                        // Kích thước cửa sổ
            this.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);               // Nền xám rất nhạt
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;     // Không resize
            this.MaximizeBox = false;                                                    // Ẩn nút phóng to
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;    // Mở giữa màn hình
            this.Text = "Quản Lý Thư Viện — Tài Khoản";                                 // Tiêu đề cửa sổ
            this.Name = "frmAccountManagement";

            // --- Thêm các control vào form (theo thứ tự vẽ) ---
            this.Controls.Add(this.gbChiTiet);     // GroupBox chi tiết
            this.Controls.Add(this.dgvTaiKhoan);   // Bảng danh sách
            this.Controls.Add(this.pnlTimKiem);     // Thanh tìm kiếm
            this.Controls.Add(this.pnlHeader);      // Header trên cùng

            // ─────────────────────────────────────────────────────────
            // BƯỚC 3: TIẾP TỤC CẬP NHẬT GIAO DIỆN (kết thúc Suspend)
            // ─────────────────────────────────────────────────────────
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.gbChiTiet.ResumeLayout(false);
            this.gbChiTiet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // ═════════════════════════════════════════════════════════════
        // KHAI BÁO BIẾN CONTROL — Mỗi control trên form là một biến
        // ═════════════════════════════════════════════════════════════

        // --- Panel ---
        private System.Windows.Forms.Panel pnlHeader;         // Thanh tiêu đề xanh navy
        private System.Windows.Forms.Label lblTieuDe;          // Chữ tiêu đề trắng
        private System.Windows.Forms.Panel pnlTimKiem;         // Thanh tìm kiếm trắng

        // --- Khu vực tìm kiếm và lọc ---
        private System.Windows.Forms.Label lblTim;             // Nhãn "Tìm kiếm"
        private System.Windows.Forms.TextBox txtTim;           // Ô nhập từ khoá
        private System.Windows.Forms.Label lblLocVaiTro;       // Nhãn "Vai Trò"
        private System.Windows.Forms.ComboBox cboLocVaiTro;    // ComboBox lọc vai trò
        private System.Windows.Forms.Label lblSoDong;          // Nhãn "Số tài khoản: X"

        // --- Bảng danh sách ---
        private System.Windows.Forms.DataGridView dgvTaiKhoan; // DataGridView chính

        // --- GroupBox chi tiết ---
        private System.Windows.Forms.GroupBox gbChiTiet;       // Khung chứa chi tiết
        private System.Windows.Forms.Label lblMa;              // Giá trị mã TK
        private System.Windows.Forms.Label lblCapMa;           // Nhãn "Mã tài khoản"
        private System.Windows.Forms.RadioButton rdoNu;        // Nút chọn Nữ
        private System.Windows.Forms.RadioButton rdoNam;       // Nút chọn Nam
        private System.Windows.Forms.Label lblCapGioiTinh;     // Nhãn "Giới tính"
        private System.Windows.Forms.TextBox txtHoTen;         // Ô nhập họ tên
        private System.Windows.Forms.Label lblCapHoTen;        // Nhãn "Họ Tên"
        private System.Windows.Forms.Label lblUsername;         // Giá trị username
        private System.Windows.Forms.Label lblCapUsername;      // Nhãn "Username"
        private System.Windows.Forms.Button btnLuu;            // Nút Lưu
        private System.Windows.Forms.Label lblCapNgayTao;      // Nhãn "Ngày Tạo"
        private System.Windows.Forms.ComboBox cboVaiTro;       // ComboBox vai trò
        private System.Windows.Forms.Label lblCapVaiTro;       // Nhãn "Vai Trò"
        private System.Windows.Forms.TextBox txtEmail;         // Ô nhập email
        private System.Windows.Forms.Label lblCapEmail;        // Nhãn "Email"
        private System.Windows.Forms.Button btnXoa;            // Nút Xoá
        private System.Windows.Forms.Label lblNgayTao;         // Giá trị ngày tạo

        // --- Các cột DataGridView ---
        private System.Windows.Forms.DataGridViewTextBoxColumn colMa;        // Cột mã TK
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsername;   // Cột username
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoTen;     // Cột họ tên
        private System.Windows.Forms.DataGridViewTextBoxColumn colVaiTro;    // Cột vai trò
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioiTinh;  // Cột giới tính
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;        // Cột email
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;   // Cột ngày tạo
    }
}
