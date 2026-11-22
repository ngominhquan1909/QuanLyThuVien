// =====================================================================
// File: frmQuanLyTaiKhoan.cs
// Mô tả: File chứa LOGIC NGHIỆP VỤ cho form Quản Lý Tài Khoản.
//         - Nạp dữ liệu từ SQL Server khi form mở
//         - Lọc / tìm kiếm danh sách tài khoản real-time
//         - Hiển thị chi tiết khi chọn dòng trong bảng
//         - Lưu (cập nhật) thông tin tài khoản vào SQL Server
//         - Format cột GioiTinh (true→"Nam", false→"Nữ")
//
// LƯU Ý: File này KHÔNG chứa code giao diện (UI).
//         Giao diện nằm trong frmQuanLyTaiKhoan.Designer.cs
//         Truy vấn SQL nằm trong TaiKhoanDAL.cs
// =====================================================================

using System;              // Chứa các kiểu cơ bản: Exception, DateTime, Convert, ...
using System.Data;         // Chứa DataTable, DataRowView dùng để lưu dữ liệu tạm
using System.Drawing;      // Chứa Color, Font, ... để tùy chỉnh giao diện
using System.Windows.Forms; // Chứa Form, Button, TextBox, MessageBox, ... (WinForms)

namespace QuanLyThuVien
{
    /// <summary>
    /// Form chính — Quản lý danh sách tài khoản.
    /// "partial class" nghĩa là lớp được chia thành 2 file:
    ///   - frmQuanLyTaiKhoan.cs         → logic xử lý (file này)
    ///   - frmQuanLyTaiKhoan.Designer.cs → giao diện (Designer)
    /// </summary>
    public partial class frmQuanLyTaiKhoan : Form
    {
        // ─────────────────────────────────────────────────────────
        // BIẾN TOÀN CỤC — Lưu dữ liệu tạm cho cả form
        // ─────────────────────────────────────────────────────────

        /// <summary>
        /// DataTable lưu toàn bộ danh sách tài khoản từ SQL Server.
        /// Khi lọc/tìm kiếm, ta lọc trên _dt.DefaultView (không truy vấn lại SQL).
        /// </summary>
        private DataTable _dt;

        // ═════════════════════════════════════════════════════════
        // CONSTRUCTOR — Hàm khởi tạo form
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Constructor — được gọi khi tạo form (new frmQuanLyTaiKhoan()).
        /// </summary>
        public frmQuanLyTaiKhoan()
        {
            // Dựng (render) toàn bộ giao diện từ file Designer.cs
            InitializeComponent();

            // Đăng ký sự kiện Load: khi form hiện ra → gọi frmQuanLyTaiKhoan_Load
            this.Load += frmQuanLyTaiKhoan_Load;
        }

        // ═════════════════════════════════════════════════════════
        // SỰ KIỆN LOAD — Chạy 1 lần duy nhất khi form mở
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Sự kiện Load — được gọi tự động khi form hiển thị lần đầu.
        /// Nhiệm vụ: nạp dữ liệu ComboBox, lấy danh sách từ SQL, áp dụng bộ lọc.
        /// </summary>
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                // ── Nạp các lựa chọn cho ComboBox LỌC vai trò (trên thanh tìm kiếm) ──
                cboLocVaiTro.Items.Clear();                            // Xoá dữ liệu cũ (tránh lặp)
                cboLocVaiTro.Items.AddRange(                           // Thêm 3 lựa chọn:
                    new object[] { "(Tất cả)", "Admin", "NhanVien" }); //   - (Tất cả): hiển thị hết
                cboLocVaiTro.SelectedIndex = 0;                        // Mặc định chọn "(Tất cả)"

                // ── Nạp các lựa chọn cho ComboBox vai trò (trong chi tiết) ──
                cboVaiTro.Items.Clear();
                cboVaiTro.Items.AddRange(
                    new object[] { "Admin", "NhanVien" });             // Chỉ có 2 vai trò
                cboVaiTro.SelectedIndex = 1;                           // Mặc định chọn "NhanVien"

                // ── Lấy danh sách tài khoản từ SQL Server ──
                _dt = TaiKhoanDAL.LayDanhSach();                       // Gọi DAL để SELECT
                dgvTaiKhoan.DataSource = _dt;                          // Gán dữ liệu cho bảng

                // ── Áp dụng bộ lọc ban đầu và cập nhật số tài khoản ──
                ApDungLoc();
            }
            catch (Exception ex)
            {
                // Nếu kết nối SQL thất bại hoặc có lỗi → hiển thị thông báo
                MessageBox.Show(
                    ex.Message,                                        // Nội dung lỗi
                    "Lỗi kết nối hoặc tải dữ liệu",                   // Tiêu đề hộp thoại
                    MessageBoxButtons.OK,                              // Chỉ có nút OK
                    MessageBoxIcon.Error);                             // Icon lỗi đỏ
            }
        }

        // ═════════════════════════════════════════════════════════
        // HÀM LỌC — Áp dụng điều kiện tìm kiếm + lọc vai trò
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Áp dụng bộ lọc lên DataTable dựa trên:
        ///   1. Từ khoá tìm kiếm (txtTim) — tìm trong MaTaiKhoan, Username, HoTen, Email
        ///   2. Vai trò được chọn (cboLocVaiTro)
        /// Sau khi lọc, cập nhật nhãn hiển thị số tài khoản (lblSoDong).
        /// </summary>
        private void ApDungLoc()
        {
            // Nếu chưa có dữ liệu (chưa load xong) thì thoát
            if (_dt == null)
                return;

            // Lấy từ khoá tìm kiếm, bỏ khoảng trắng đầu cuối
            // Replace("'", "''") để tránh lỗi SQL khi từ khoá chứa dấu '
            string tuKhoa = txtTim.Text.Trim().Replace("'", "''");

            // Lấy vai trò đang chọn trong ComboBox lọc
            string vaiTro = Convert.ToString(cboLocVaiTro.SelectedItem);

            // Chuỗi điều kiện lọc — ban đầu rỗng (không lọc gì)
            string dieuKien = "";

            // ── Nếu có từ khoá → tìm kiếm trong 4 cột ──
            if (tuKhoa.Length > 0)
            {
                // LIKE '%...%' tìm kiếm chứa từ khoá (không phân biệt vị trí)
                dieuKien =
                    "(MaTaiKhoan LIKE '%" + tuKhoa +
                    "%' OR Username LIKE '%" + tuKhoa +
                    "%' OR HoTen LIKE '%" + tuKhoa +
                    "%' OR Email LIKE '%" + tuKhoa + "%')";
            }

            // ── Nếu chọn vai trò cụ thể (không phải "Tất cả") → thêm điều kiện ──
            if (!string.IsNullOrEmpty(vaiTro) && vaiTro != "(Tất cả)")
            {
                // Nếu đã có điều kiện tìm kiếm → nối thêm bằng AND
                if (dieuKien.Length > 0)
                    dieuKien += " AND ";

                // Thêm điều kiện lọc theo vai trò
                dieuKien += "VaiTro = '" + vaiTro.Replace("'", "''") + "'";
            }

            // Áp dụng bộ lọc lên DefaultView (lọc hiển thị, KHÔNG xoá dữ liệu gốc)
            _dt.DefaultView.RowFilter = dieuKien;

            // Cập nhật nhãn hiển thị số tài khoản sau khi lọc
            lblSoDong.Text = "Số tài khoản: " + _dt.DefaultView.Count;
        }

        // ═════════════════════════════════════════════════════════
        // SỰ KIỆN TÌM KIẾM REAL-TIME
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Sự kiện TextChanged của ô tìm kiếm — được gọi mỗi khi người dùng gõ.
        /// Gọi lại ApDungLoc() để bảng tự động cập nhật kết quả tìm kiếm.
        /// → Không cần bấm nút "Tìm", bảng lọc ngay khi gõ.
        /// </summary>
        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            ApDungLoc();
        }

        /// <summary>
        /// Sự kiện khi đổi lựa chọn trong ComboBox lọc vai trò.
        /// Gọi lại ApDungLoc() để cập nhật bảng theo vai trò mới.
        /// </summary>
        private void cboLocVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApDungLoc();
        }

        // ═════════════════════════════════════════════════════════
        // SỰ KIỆN CHỌN DÒNG TRONG BẢNG → HIỂN THỊ CHI TIẾT
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Sự kiện SelectionChanged — khi người dùng click chọn 1 dòng trong bảng.
        /// Đọc dữ liệu từ dòng được chọn rồi gán vào các control trong GroupBox chi tiết.
        /// </summary>
        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            // Nếu không có dòng nào được chọn → thoát
            if (dgvTaiKhoan.CurrentRow == null)
                return;

            // Lấy đối tượng dữ liệu gắn với dòng hiện tại
            // DataBoundItem chứa dữ liệu gốc (DataRowView) của dòng
            DataRowView row =
                dgvTaiKhoan.CurrentRow.DataBoundItem as DataRowView;

            // Nếu không ép kiểu được (dữ liệu không hợp lệ) → thoát
            if (row == null)
                return;

            // ── Gán giá trị từ dòng được chọn vào các control chi tiết ──
            lblMa.Text = Convert.ToString(row["MaTaiKhoan"]);      // Mã tài khoản
            lblUsername.Text = Convert.ToString(row["Username"]);   // Username
            txtHoTen.Text = Convert.ToString(row["HoTen"]);        // Họ tên (có thể sửa)
            txtEmail.Text = Convert.ToString(row["Email"]);        // Email (có thể sửa)
            cboVaiTro.SelectedItem = Convert.ToString(row["VaiTro"]); // Vai trò

            // ── Xử lý giới tính: true = Nam, false = Nữ ──
            bool laNam = Convert.ToBoolean(row["GioiTinh"]);
            rdoNam.Checked = laNam;      // Nếu Nam → tick vào rdoNam
            rdoNu.Checked = !laNam;      // Nếu Nữ → tick vào rdoNu

            // ── Hiển thị ngày tạo theo định dạng dd/MM/yyyy HH:mm ──
            lblNgayTao.Text = Convert.ToDateTime(row["NgayTao"])
                .ToString("dd/MM/yyyy HH:mm");
        }

        // ═════════════════════════════════════════════════════════
        // SỰ KIỆN GROUPBOX ENTER — (trống, dùng nếu cần xử lý)
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Sự kiện khi focus di chuyển vào GroupBox.
        /// Hiện tại chưa dùng, giữ lại để mở rộng sau.
        /// </summary>
        private void gbChiTiet_Enter(object sender, EventArgs e)
        {
            // Chưa có xử lý gì — có thể thêm logic sau
        }

        // ═════════════════════════════════════════════════════════
        // SỰ KIỆN NÚT "LƯU THAY ĐỔI" — Cập nhật dữ liệu vào SQL
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Sự kiện Click nút "Lưu thay đổi".
        /// Quy trình:
        ///   1. Kiểm tra đã chọn tài khoản chưa
        ///   2. Kiểm tra đã chọn giới tính chưa
        ///   3. Kiểm tra đã chọn vai trò chưa
        ///   4. Gọi TaiKhoanDAL.CapNhat() để UPDATE vào SQL Server
        ///   5. Nếu thành công → tải lại danh sách
        /// </summary>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            // ── BƯỚC 1: Kiểm tra đã chọn tài khoản chưa ──
            if (string.IsNullOrWhiteSpace(lblMa.Text) || lblMa.Text == "—")
            {
                MessageBox.Show(
                    "Bạn hãy chọn tài khoản cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return; // Dừng hàm, không thực hiện tiếp
            }

            // ── BƯỚC 2: Kiểm tra đã chọn giới tính chưa ──
            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show(
                    "Hãy chọn giới tính.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // ── BƯỚC 3: Lấy và kiểm tra vai trò ──
            string vaiTro = Convert.ToString(cboVaiTro.SelectedItem);
            if (string.IsNullOrWhiteSpace(vaiTro))
            {
                MessageBox.Show(
                    "Hãy chọn vai trò.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // ── BƯỚC 4: Gọi DAL để cập nhật vào SQL Server ──
            try
            {
                int soDong = TaiKhoanDAL.CapNhat(
                    lblMa.Text.Trim(),       // Mã tài khoản (WHERE)
                    txtHoTen.Text.Trim(),    // Họ tên mới
                    rdoNam.Checked,          // Giới tính (true = Nam)
                    txtEmail.Text.Trim(),    // Email mới
                    vaiTro);                 // Vai trò mới

                // ── BƯỚC 5: Kiểm tra kết quả ──
                if (soDong > 0)
                {
                    // Cập nhật thành công (ít nhất 1 dòng bị ảnh hưởng)
                    MessageBox.Show(
                        "Đã lưu thay đổi thành công!",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    TaiKhoanTaiLai(); // Tải lại bảng để hiển thị dữ liệu mới
                }
                else
                {
                    // Không tìm thấy tài khoản trong SQL (có thể đã bị xoá)
                    MessageBox.Show(
                        "Không tìm thấy tài khoản để cập nhật.",
                        "Cảnh báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Nếu có lỗi SQL hoặc kết nối → hiển thị lỗi, ứng dụng không crash
                MessageBox.Show(
                    "Lỗi khi lưu: " + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ═════════════════════════════════════════════════════════
        // HÀM TẢI LẠI DANH SÁCH — Sau khi cập nhật thành công
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Tải lại toàn bộ danh sách tài khoản từ SQL Server.
        /// Gọi sau khi cập nhật/xoá thành công để bảng hiển thị dữ liệu mới nhất.
        /// Đồng thời xoá trắng các ô chi tiết để tránh nhầm lẫn.
        /// </summary>
        private void TaiKhoanTaiLai()
        {
            // Truy vấn lại SQL để lấy dữ liệu mới nhất
            _dt = TaiKhoanDAL.LayDanhSach();
            dgvTaiKhoan.DataSource = _dt;

            // Áp dụng lại bộ lọc hiện tại (nếu đang lọc)
            ApDungLoc();

            // ── Xoá trắng vùng chi tiết — đưa về trạng thái "chưa chọn" ──
            lblMa.Text = "—";
            lblUsername.Text = "—";
            lblNgayTao.Text = "—";
            txtHoTen.Clear();        // Xoá nội dung ô họ tên
            txtEmail.Clear();        // Xoá nội dung ô email
            rdoNam.Checked = false;  // Bỏ chọn Nam
            rdoNu.Checked = false;   // Bỏ chọn Nữ
        }

        // ═════════════════════════════════════════════════════════
        // SỰ KIỆN FORMAT CỘT — Chuyển GioiTinh từ true/false → "Nam"/"Nữ"
        // ═════════════════════════════════════════════════════════

        /// <summary>
        /// Sự kiện CellFormatting — được gọi khi mỗi ô (cell) trong bảng chuẩn bị hiển thị.
        /// Dùng để chuyển đổi giá trị hiển thị:
        ///   - Cột GioiTinh: true → "Nam", false → "Nữ"
        ///   (vì trong SQL, GioiTinh là kiểu BIT: 1/0)
        /// </summary>
        private void dgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Bỏ qua nếu là header hoặc index âm
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Lấy tên cột dữ liệu (DataPropertyName) của ô hiện tại
            string tenCot = dgvTaiKhoan.Columns[e.ColumnIndex].DataPropertyName;

            // Nếu là cột GioiTinh và có giá trị → đổi hiển thị
            if (tenCot == "GioiTinh" && e.Value != null && e.Value != DBNull.Value)
            {
                bool laNam = Convert.ToBoolean(e.Value);    // Chuyển giá trị BIT → bool
                e.Value = laNam ? "Nam" : "Nữ";             // true → "Nam", false → "Nữ"
                e.FormattingApplied = true;                  // Báo cho DGV biết đã format xong
            }
        }
    }
}
