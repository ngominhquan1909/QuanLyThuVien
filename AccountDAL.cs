// =====================================================================
// File: AccountDAL.cs
// Mô tả: Lớp Data Access Layer (DAL) cho bảng TaiKhoan.
//         Chứa các phương thức giao tiếp trực tiếp với SQL Server:
//           - LayDanhSach(): Lấy toàn bộ danh sách tài khoản
//           - CapNhat():     Cập nhật thông tin một tài khoản
//         Lớp này KHÔNG chứa giao diện, chỉ chứa logic truy vấn.
// =====================================================================

using Microsoft.Data.SqlClient;  // Thư viện kết nối SQL Server của Microsoft
using System.Data;               // Chứa DataTable, DataSet, ... dùng để lưu dữ liệu tạm
using System.Data.SqlClient;     // Thư viện SqlCommand, SqlDataAdapter (dự phòng)

/// <summary>
/// Lớp tĩnh AccountDAL — tầng truy cập dữ liệu cho bảng TaiKhoan.
/// "DAL" viết tắt của Data Access Layer (tầng truy cập dữ liệu).
/// Dùng "static" để gọi thẳng AccountDAL.LayDanhSach() mà không cần new.
/// </summary>
public static class AccountDAL
{
    /// <summary>
    /// Lấy danh sách tất cả tài khoản từ bảng TaiKhoan trong SQL Server.
    /// Kết quả trả về là DataTable — bảng dữ liệu tạm trong bộ nhớ.
    /// </summary>
    /// <returns>DataTable chứa các cột: MaTaiKhoan, Username, HoTen, VaiTro, GioiTinh, Email, NgayTao</returns>
    public static DataTable LayDanhSach()
    {
        // "using" tự động đóng và giải phóng tài nguyên khi kết thúc khối lệnh
        using (var conn = Database.GetConnection())             // Lấy kết nối từ lớp Database
        using (var cmd = new SqlCommand(
            @"SELECT MaTaiKhoan, Username, HoTen, VaiTro,
                     GioiTinh, Email, NgayTao
              FROM TaiKhoan
              ORDER BY MaTaiKhoan", conn))                      // Câu lệnh SQL lấy dữ liệu, sắp xếp theo mã
        using (var adapter = new SqlDataAdapter(cmd))            // Adapter giúp đổ dữ liệu từ SQL vào DataTable
        {
            var dt = new DataTable();   // Tạo bảng dữ liệu tạm rỗng
            adapter.Fill(dt);           // Thực thi câu SQL và đổ kết quả vào dt
            return dt;                  // Trả bảng dữ liệu về cho nơi gọi
        }
    }

    /// <summary>
    /// Cập nhật thông tin một tài khoản trong bảng TaiKhoan.
    /// Chỉ cập nhật: HoTen, GioiTinh, Email, VaiTro.
    /// Username và NgayTao KHÔNG được sửa.
    /// </summary>
    /// <param name="maTaiKhoan">Mã tài khoản cần cập nhật (khoá chính)</param>
    /// <param name="hoTen">Họ tên mới</param>
    /// <param name="gioiTinh">true = Nam, false = Nữ</param>
    /// <param name="email">Email mới</param>
    /// <param name="vaiTro">Vai trò mới ("Admin" hoặc "NhanVien")</param>
    /// <returns>Số dòng bị ảnh hưởng (thường = 1 nếu thành công, = 0 nếu không tìm thấy)</returns>
    public static int CapNhat(
        string maTaiKhoan,
        string hoTen,
        bool gioiTinh,
        string email,
        string vaiTro)
    {
        // Mở kết nối tới SQL Server
        using (SqlConnection conn = Database.GetConnection())
        // Tạo câu lệnh UPDATE với các tham số @... (tránh SQL Injection)
        using (SqlCommand cmd = new SqlCommand(
            @"UPDATE TaiKhoan
              SET HoTen    = @HoTen,
                  GioiTinh = @GioiTinh,
                  Email    = @Email,
                  VaiTro   = @VaiTro
              WHERE MaTaiKhoan = @MaTaiKhoan", conn))
        {
            // Gán giá trị cho từng tham số trong câu SQL
            cmd.Parameters.AddWithValue("@HoTen", hoTen);            // Họ tên
            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);      // Giới tính (bit: true/false)
            cmd.Parameters.AddWithValue("@Email", email);            // Email
            cmd.Parameters.AddWithValue("@VaiTro", vaiTro);          // Vai trò
            cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);  // Mã tài khoản (WHERE)

            conn.Open();                 // Mở kết nối đến SQL Server
            return cmd.ExecuteNonQuery(); // Thực thi UPDATE, trả về số dòng bị ảnh hưởng
        }
    }
}
