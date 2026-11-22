using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

public static class TaiKhoanDAL
{
    public static DataTable LayDanhSach()
    {
        using (var conn = Database.GetConnection())
        using (var cmd = new SqlCommand(
            @"SELECT MaTaiKhoan, Username, HoTen, VaiTro,
                     GioiTinh, Email, NgayTao
              FROM TaiKhoan
              ORDER BY MaTaiKhoan", conn))
        using (var adapter = new SqlDataAdapter(cmd))
        {
            var dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
    public static int CapNhat(
    string maTaiKhoan,
    string hoTen,
    bool gioiTinh,
    string email,
    string vaiTro)
    {
        using (SqlConnection conn = Database.GetConnection())
        using (SqlCommand cmd = new SqlCommand(
            @"UPDATE TaiKhoan
          SET HoTen = @HoTen,
              GioiTinh = @GioiTinh,
              Email = @Email,
              VaiTro = @VaiTro
          WHERE MaTaiKhoan = @MaTaiKhoan", conn))
        {
            cmd.Parameters.AddWithValue("@HoTen", hoTen);
            cmd.Parameters.AddWithValue("@GioiTinh", gioiTinh);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@VaiTro", vaiTro);
            cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);

            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }


}