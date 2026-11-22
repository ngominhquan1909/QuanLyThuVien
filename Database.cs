// =====================================================================
// File: Database.cs
// Mô tả: Lớp tiện ích (utility class) chứa phương thức kết nối
//         tới SQL Server. Tất cả các lớp DAL (Data Access Layer)
//         đều gọi Database.GetConnection() để lấy đối tượng kết nối.
// =====================================================================

using Microsoft.Data.SqlClient;       // Thư viện Microsoft dùng để làm việc với SQL Server
using System.Configuration;           // Thư viện đọc file cấu hình App.config
using System.Data.SqlClient;          // Thư viện System cũ hỗ trợ SqlConnection (dự phòng)

/// <summary>
/// Lớp tĩnh (static class) quản lý kết nối cơ sở dữ liệu.
/// Dùng "static" để không cần tạo đối tượng (new), gọi thẳng Database.GetConnection().
/// </summary>
public static class Database
{
    /// <summary>
    /// Tạo và trả về một đối tượng SqlConnection mới.
    /// Chuỗi kết nối được đọc từ file App.config với tên "QLConn".
    /// </summary>
    /// <returns>Đối tượng SqlConnection đã được cấu hình chuỗi kết nối</returns>
    public static SqlConnection GetConnection()
    {
        // Đọc chuỗi kết nối từ App.config → thẻ <connectionStrings> → name="QLConn"
        string cs = ConfigurationManager
            .ConnectionStrings["QLConn"].ConnectionString;

        // Trả về đối tượng kết nối mới (chưa mở, nơi gọi sẽ tự mở bằng conn.Open())
        return new SqlConnection(cs);
    }
}
