// =====================================================================
// File: Program.cs
// Mô tả: Điểm bắt đầu (entry point) của ứng dụng Windows Forms.
//         Khi chạy chương trình, hàm Main() được gọi đầu tiên.
// =====================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    /// <summary>
    /// Lớp Program chứa hàm Main — nơi chương trình bắt đầu chạy.
    /// Từ khóa "internal" nghĩa là lớp chỉ truy cập được trong cùng project.
    /// Từ khóa "static" nghĩa là không cần tạo đối tượng để dùng.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Hàm Main — điểm khởi chạy duy nhất của ứng dụng.
        /// [STAThread] bắt buộc cho ứng dụng Windows Forms (Single Thread Apartment).
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Bật kiểu giao diện đẹp hơn (visual styles) của hệ điều hành
            Application.EnableVisualStyles();

            // Dùng GDI+ để vẽ chữ (false = GDI+, true = GDI cũ)
            Application.SetCompatibleTextRenderingDefault(false);

            // Tạo và hiển thị form chính — form Quản Lý Tài Khoản
            // Chương trình sẽ chạy cho đến khi form này bị đóng
            Application.Run(new frmQuanLyTaiKhoan());
        }
    }
}
