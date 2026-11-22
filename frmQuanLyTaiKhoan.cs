using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        private DataTable _dt;// biến lưu dữ liệu


        public frmQuanLyTaiKhoan()//khởi tạo tài khoản 
        {
            InitializeComponent();// dựng giao diện thiết kế trong design
            this.Load += frmQuanLyTaiKhoan_Load;// dky sụ kiện load chuẩn bị dữ liệu lúc mở 
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            try
            {
                // Nạp các lựa chọn cho hai ComboBox
                cboLocVaiTro.Items.Clear(); // xoá cái cũ tránh lặp lại 
                cboLocVaiTro.Items.AddRange(   // thêm 3 lựa chọn cho combobox
                    new object[] { "(Tất cả)", "Admin", "NhanVien" });
                cboLocVaiTro.SelectedIndex = 0; // chọn tất cả làm lựa chọn ban đầu 

                cboVaiTro.Items.Clear();
                cboVaiTro.Items.AddRange(
                    new object[] { "Admin", "NhanVien" });// thêm hai vai trò 
                cboVaiTro.SelectedIndex = 1;

                // Tải danh sách từ SQL
                _dt = TaiKhoanDAL.LayDanhSach();// lấy danh sách từ sql
                dgvTaiKhoan.DataSource = _dt;

                ApDungLoc();// Áp dụng điều kiện tìm kiếm và lọc hiện tại, đồng thời cập nhật nhãn số tài khoản.
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi kết nối hoặc tải dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ApDungLoc()
        {
            if (_dt == null)
                return; //Nếu dữ liệu chưa được nạp thì thoát khỏi hàm, tránh thao tác trên giá trị rỗng.

            string tuKhoa = txtTim.Text.Trim().Replace("'", "''");//lấy nd người nhập bỏ ktrang đầu cuối 
            string vaiTro = Convert.ToString(cboLocVaiTro.SelectedItem);// lấy lựa chọn hiện tại của combobox
            string dieuKien = "";//chuỗi điều kiện lọc lúc đầu 

            if (tuKhoa.Length > 0)
            {
                dieuKien =
                    "(MaTaiKhoan LIKE '%" + tuKhoa +
                    "%' OR Username LIKE '%" + tuKhoa +
                    "%' OR HoTen LIKE '%" + tuKhoa +
                    "%' OR Email LIKE '%" + tuKhoa + "%')";
            }

            if (!string.IsNullOrEmpty(vaiTro) && vaiTro != "(Tất cả)")// thêm điều kiện vào vai trò 
            {
                if (dieuKien.Length > 0)
                    dieuKien += " AND ";

                dieuKien += "VaiTro = '" + vaiTro.Replace("'", "''") + "'";
            }

            _dt.DefaultView.RowFilter = dieuKien;//DefaultView.RowFilter lọc các dòng hiển thị từ _dt; không xóa dữ liệu trong SQL.
            lblSoDong.Text = "Số tài khoản: " + _dt.DefaultView.Count;//DefaultView.Count đếm số dòng sau lọc.
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            ApDungLoc();
        }
        //Mỗi khi nội dung TextBox thay đổi, gọi lại ApDungLoc(). Vì vậy bảng cập nhật ngay khi gõ, không cần bấm nút tìm.
        private void cboLocVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApDungLoc();
        }

        private void dgvTaiKhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null)
                return;

            DataRowView row =
                dgvTaiKhoan.CurrentRow.DataBoundItem as DataRowView;

            if (row == null)
                return;
            //DataBoundItem là đối tượng dữ liệu gắn với dòng hiện tại. Ép kiểu sang DataRowView để đọc các cột. Nếu không ép kiểu được thì thoát.
            lblMa.Text = Convert.ToString(row["MaTaiKhoan"]);
            lblUsername.Text = Convert.ToString(row["Username"]);
            txtHoTen.Text = Convert.ToString(row["HoTen"]);
            txtEmail.Text = Convert.ToString(row["Email"]);
            cboVaiTro.SelectedItem = Convert.ToString(row["VaiTro"]);
            //Mỗi dòng đọc một giá trị từ bản ghi đã chọn rồi gán vào control tương ứng.

            bool laNam = Convert.ToBoolean(row["GioiTinh"]);
            rdoNam.Checked = laNam;
            rdoNu.Checked = !laNam;

            lblNgayTao.Text = Convert.ToDateTime(row["NgayTao"])
                .ToString("dd/MM/yyyy HH:mm");
            // Chuyển giá trị ngày tạo thành kiểu ngày giờ rồi định dạng để hiển thị ngày/ tháng / năm và giờ/ phút.
        }

        private void gbChiTiet_Enter(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lblMa.Text) || lblMa.Text == "—")
            //kiểm tra mã tài khoản đang rỗng hoặc chỉ có khoảng trắng.
            //lblMa.Text == "—" kiểm tra đang ở trạng thái chưa chọn tài khoản.
            {
                MessageBox.Show("Bạn hãy chọn tài khoản cần sửa.");
                return;
            }

            if (!rdoNam.Checked && !rdoNu.Checked)//.Checked cho biết RadioButton có đang được chọn hay không.
            {
                MessageBox.Show("Hãy chọn giới tính.");
                return;
            }

            string vaiTro = Convert.ToString(cboVaiTro.SelectedItem);
            //Lấy mục đang chọn trong ComboBox vai trò và chuyển thành chuỗi

            if (string.IsNullOrWhiteSpace(vaiTro))
            {
                MessageBox.Show("Hãy chọn vai trò.");
                return;
            }

            try
            {
                int soDong = TaiKhoanDAL.CapNhat(
                    lblMa.Text.Trim(),
                    txtHoTen.Text.Trim(),
                    rdoNam.Checked,
                    txtEmail.Text.Trim(),
                    vaiTro);

                if (soDong > 0)
                {
                    MessageBox.Show("Đã lưu thay đổi.");
                    TaiKhoanTaiLai();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tài khoản để cập nhật.");
                }
            }
            catch (Exception ex) //Nếu SQL hoặc thao tác cập nhật gặp lỗi, catch bắt lỗi và hiển thị nội dung. Nhờ vậy ứng dụng không thoát đột ngột.
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
            }
        }
        //Trim() bỏ khoảng trắng thừa ở đầu và cuối chuỗi. Hàm CapNhat trong DAL thực hiện câu lệnh UPDATE trên SQL Server và trả về số dòng bị ảnh hưởng.
        private void TaiKhoanTaiLai()
        {
            _dt = TaiKhoanDAL.LayDanhSach();
            dgvTaiKhoan.DataSource = _dt;
            ApDungLoc();

            // Xóa nội dung chi tiết sau khi tải lại
            lblMa.Text = "—";
            lblUsername.Text = "—";
            lblNgayTao.Text = "—";
            txtHoTen.Clear();
            txtEmail.Clear();
            rdoNam.Checked = false;
            rdoNu.Checked = false;
        }

        private void dgvTaiKhoan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            string tenCot = dgvTaiKhoan.Columns[e.ColumnIndex].DataPropertyName;

            if (tenCot == "GioiTinh" && e.Value != null && e.Value != DBNull.Value)
            {
                bool laNam = Convert.ToBoolean(e.Value);
                e.Value = laNam ? "Nam" : "Nữ";
                e.FormattingApplied = true;
            }
        }
    }
}