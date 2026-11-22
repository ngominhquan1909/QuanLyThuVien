# 📚 Quản Lý Thư Viện — Hệ Thống Quản Lý Tài Khoản

> Ứng dụng Windows Forms (C# .NET Framework 4.7.2) quản lý tài khoản người dùng trong hệ thống thư viện, kết nối cơ sở dữ liệu SQL Server.

---

## 📋 Mục Lục

- [Tổng Quan](#-tổng-quan)
- [Tính Năng](#-tính-năng)
- [Yêu Cầu Hệ Thống](#-yêu-cầu-hệ-thống)
- [Cấu Trúc Dự Án](#-cấu-trúc-dự-án)
- [Hướng Dẫn Cài Đặt](#-hướng-dẫn-cài-đặt)
- [Hướng Dẫn Sử Dụng](#-hướng-dẫn-sử-dụng)
- [Cấu Trúc Database](#-cấu-trúc-database)
- [Kiến Trúc Phần Mềm](#-kiến-trúc-phần-mềm)
- [Giải Thích Từng File](#-giải-thích-từng-file)
- [Bảng Màu Giao Diện](#-bảng-màu-giao-diện)
- [Hướng Dẫn Mở Rộng](#-hướng-dẫn-mở-rộng)
- [Xử Lý Lỗi Thường Gặp](#-xử-lý-lỗi-thường-gặp)
- [Đóng Góp](#-đóng-góp)
- [Giấy Phép](#-giấy-phép)

---

## 🌟 Tổng Quan

**QuanLyThuVien** là một ứng dụng desktop Windows Forms được viết bằng **C#** trên nền tảng **.NET Framework 4.7.2**. Ứng dụng cho phép quản trị viên:

- Xem danh sách tài khoản từ cơ sở dữ liệu SQL Server
- Tìm kiếm và lọc tài khoản theo nhiều tiêu chí
- Cập nhật thông tin tài khoản (họ tên, giới tính, email, vai trò)

Dự án sử dụng kiến trúc **2 tầng (2-tier)** với tầng giao diện (UI) và tầng truy cập dữ liệu (DAL) tách biệt rõ ràng.

---

## ✨ Tính Năng

| Tính năng | Mô tả |
|-----------|-------|
| 📋 **Xem danh sách** | Hiển thị tất cả tài khoản trong bảng DataGridView với giao diện đẹp |
| 🔍 **Tìm kiếm real-time** | Gõ từ khoá → bảng lọc ngay lập tức (không cần bấm nút) |
| 🏷️ **Lọc theo vai trò** | Lọc nhanh Admin / NhanVien / Tất cả |
| ✏️ **Sửa thông tin** | Click chọn dòng → sửa thông tin → bấm Lưu |
| 🎨 **Giao diện hiện đại** | Bảng màu navy + xanh dương, font Segoe UI, dòng xen kẽ màu |
| ⚡ **Hiệu suất** | Lọc dữ liệu trên DataTable (bộ nhớ), không truy vấn lại SQL |

---

## 💻 Yêu Cầu Hệ Thống

| Thành phần | Yêu cầu tối thiểu |
|------------|-------------------|
| **Hệ điều hành** | Windows 7 trở lên (khuyến nghị Windows 10/11) |
| **IDE** | Visual Studio 2019 trở lên |
| **.NET Framework** | 4.7.2 |
| **SQL Server** | SQL Server 2016 trở lên (Express, Developer, hoặc Standard) |
| **RAM** | 4 GB trở lên |
| **Ổ cứng** | 100 MB trống |

---

## 📁 Cấu Trúc Dự Án

```
QuanLyThuVien/
│
├── 📄 Program.cs                          # Điểm bắt đầu (entry point) của ứng dụng
├── 📄 Database.cs                         # Lớp kết nối cơ sở dữ liệu (đọc chuỗi từ App.config)
├── 📄 TaiKhoanDAL.cs                      # Tầng truy cập dữ liệu (SELECT, UPDATE)
│
├── 📄 frmQuanLyTaiKhoan.cs               # Logic xử lý nghiệp vụ của form chính
├── 📄 frmQuanLyTaiKhoan.Designer.cs       # Giao diện (UI) của form chính
├── 📄 frmQuanLyTaiKhoan.resx             # Tài nguyên (resource) của form
│
├── 📄 App.config                          # File cấu hình — chứa chuỗi kết nối SQL
├── 📄 QuanLyThuVien.csproj               # File dự án MSBuild
├── 📄 packages.config                     # Danh sách NuGet packages
├── 📄 README.md                           # File hướng dẫn (file này)
│
├── 📂 Properties/                         # Thông tin assembly & tài nguyên
│   ├── AssemblyInfo.cs
│   ├── Resources.resx
│   ├── Resources.Designer.cs
│   ├── Settings.settings
│   └── Settings.Designer.cs
│
├── 📂 bin/Debug/                          # Output sau khi build (file .exe)
└── 📂 obj/                               # File tạm của trình biên dịch
```

---

## 🚀 Hướng Dẫn Cài Đặt

### Bước 1: Tạo Database trên SQL Server

Mở **SQL Server Management Studio (SSMS)** và chạy script sau:

```sql
-- Tạo database
CREATE DATABASE QLThuVien;
GO

USE QLThuVien;
GO

-- Tạo bảng TaiKhoan
CREATE TABLE TaiKhoan (
    MaTaiKhoan  NVARCHAR(20)  PRIMARY KEY,          -- Mã tài khoản (khoá chính)
    Username    NVARCHAR(50)  NOT NULL UNIQUE,       -- Tên đăng nhập (duy nhất)
    HoTen       NVARCHAR(100) NOT NULL,              -- Họ tên đầy đủ
    VaiTro      NVARCHAR(20)  NOT NULL DEFAULT 'NhanVien', -- Vai trò: Admin / NhanVien
    GioiTinh    BIT           NOT NULL DEFAULT 1,    -- 1 = Nam, 0 = Nữ
    Email       NVARCHAR(100),                       -- Địa chỉ email
    NgayTao     DATETIME      NOT NULL DEFAULT GETDATE() -- Ngày tạo tài khoản
);
GO

-- Thêm dữ liệu mẫu
INSERT INTO TaiKhoan (MaTaiKhoan, Username, HoTen, VaiTro, GioiTinh, Email)
VALUES
    ('TK001', 'admin',     N'Nguyễn Văn Admin',  'Admin',    1, 'admin@thuvien.vn'),
    ('TK002', 'nhanvien1', N'Trần Thị Hoa',      'NhanVien', 0, 'hoa@thuvien.vn'),
    ('TK003', 'nhanvien2', N'Lê Minh Tuấn',      'NhanVien', 1, 'tuan@thuvien.vn'),
    ('TK004', 'nhanvien3', N'Phạm Thị Mai',      'NhanVien', 0, 'mai@thuvien.vn'),
    ('TK005', 'admin2',    N'Hoàng Đức Mạnh',    'Admin',    1, 'manh@thuvien.vn');
GO
```

### Bước 2: Cấu hình chuỗi kết nối

Mở file **`App.config`** và sửa `Data Source` thành tên SQL Server của bạn:

```xml
<connectionStrings>
    <add name="QLConn"
         connectionString="Data Source=TEN_MAY_BAN;Initial Catalog=QLThuVien;Integrated Security=True;TrustServerCertificate=True" />
</connectionStrings>
```

> **📝 Lưu ý:**
> - `Data Source=TEN_MAY_BAN` → thay bằng tên SQL Server của bạn (ví dụ: `LAPTOP-ABC`, `.\SQLEXPRESS`, `localhost`)
> - `Integrated Security=True` → dùng xác thực Windows (không cần nhập user/pass)
> - Nếu dùng SQL Authentication, thay bằng: `User ID=sa;Password=123456;`

### Bước 3: Mở và chạy dự án

1. Mở file **`QuanLyThuVien.csproj`** bằng **Visual Studio**
2. Nhấn **Ctrl + Shift + B** để Build
3. Nhấn **F5** (hoặc Ctrl + F5) để chạy

> ⚠️ Nếu thiếu NuGet packages, Visual Studio sẽ tự động restore khi build.

---

## 📖 Hướng Dẫn Sử Dụng

### 1. Xem danh sách tài khoản
Khi mở ứng dụng, bảng danh sách hiển thị tất cả tài khoản. Các cột bao gồm:
- **Mã TK** — Mã định danh tài khoản
- **Username** — Tên đăng nhập
- **Họ tên** — Họ tên đầy đủ
- **Vai trò** — Admin hoặc NhanVien
- **Giới tính** — Nam hoặc Nữ
- **Email** — Địa chỉ email
- **Ngày tạo** — Ngày tạo tài khoản

### 2. Tìm kiếm
Gõ từ khoá vào ô **"🔍 Tìm kiếm"** ở thanh công cụ. Bảng sẽ tự động lọc ngay khi bạn gõ, tìm kiếm trong cả 4 cột: Mã TK, Username, Họ tên, Email.

### 3. Lọc theo vai trò
Chọn vai trò trong ComboBox **"Vai Trò"**: `(Tất cả)`, `Admin`, hoặc `NhanVien`.

### 4. Sửa thông tin tài khoản
1. **Click** vào dòng cần sửa trong bảng → thông tin hiển thị ở panel **"Chi tiết tài khoản"** bên phải
2. **Sửa** các trường: Họ Tên, Giới tính, Email, Vai Trò
3. Bấm nút **"💾 Lưu thay đổi"**
4. Nếu thành công → hiện thông báo "Đã lưu thay đổi thành công!"

---

## 🗄️ Cấu Trúc Database

### Bảng `TaiKhoan`

| Cột | Kiểu dữ liệu | Ràng buộc | Mô tả |
|-----|---------------|-----------|-------|
| `MaTaiKhoan` | NVARCHAR(20) | PRIMARY KEY | Mã tài khoản (khoá chính) |
| `Username` | NVARCHAR(50) | NOT NULL, UNIQUE | Tên đăng nhập |
| `HoTen` | NVARCHAR(100) | NOT NULL | Họ tên đầy đủ |
| `VaiTro` | NVARCHAR(20) | NOT NULL, DEFAULT 'NhanVien' | Vai trò |
| `GioiTinh` | BIT | NOT NULL, DEFAULT 1 | 1 = Nam, 0 = Nữ |
| `Email` | NVARCHAR(100) | | Địa chỉ email |
| `NgayTao` | DATETIME | NOT NULL, DEFAULT GETDATE() | Thời điểm tạo |

### Sơ đồ quan hệ (hiện tại chỉ có 1 bảng)

```
┌─────────────────────────────────┐
│          TaiKhoan               │
├─────────────────────────────────┤
│ PK  MaTaiKhoan   NVARCHAR(20)  │
│     Username     NVARCHAR(50)  │
│     HoTen        NVARCHAR(100) │
│     VaiTro       NVARCHAR(20)  │
│     GioiTinh     BIT           │
│     Email        NVARCHAR(100) │
│     NgayTao      DATETIME      │
└─────────────────────────────────┘
```

---

## 🏗️ Kiến Trúc Phần Mềm

Dự án sử dụng kiến trúc **2 tầng (2-tier)**:

```
┌─────────────────────────────────────────────┐
│         TẦNG GIAO DIỆN (Presentation)       │
│  ┌─────────────────────────────────────┐    │
│  │  frmQuanLyTaiKhoan.cs              │    │  ← Logic xử lý sự kiện
│  │  frmQuanLyTaiKhoan.Designer.cs     │    │  ← Giao diện (UI)
│  │  Program.cs                         │    │  ← Entry point
│  └─────────────────────────────────────┘    │
├─────────────────────────────────────────────┤
│      TẦNG TRUY CẬP DỮ LIỆU (DAL)          │
│  ┌─────────────────────────────────────┐    │
│  │  TaiKhoanDAL.cs                     │    │  ← SELECT, UPDATE
│  │  Database.cs                        │    │  ← Kết nối SQL Server
│  └─────────────────────────────────────┘    │
├─────────────────────────────────────────────┤
│           CƠ SỞ DỮ LIỆU                    │
│  ┌─────────────────────────────────────┐    │
│  │  SQL Server — Database: QLThuVien   │    │
│  │  Bảng: TaiKhoan                     │    │
│  └─────────────────────────────────────┘    │
└─────────────────────────────────────────────┘
```

**Luồng dữ liệu:**
```
Người dùng → Form (UI) → DAL → SQL Server → DAL → Form (UI) → Hiển thị
```

---

## 📝 Giải Thích Từng File

### 1. `Program.cs` — Điểm khởi chạy
- Chứa hàm `Main()` — nơi chương trình bắt đầu
- Bật visual styles và khởi chạy form `frmQuanLyTaiKhoan`

### 2. `Database.cs` — Kết nối SQL Server
- Chứa 1 phương thức duy nhất: `GetConnection()`
- Đọc chuỗi kết nối từ `App.config` (thẻ `<connectionStrings>`)
- Trả về đối tượng `SqlConnection` (chưa mở)

### 3. `TaiKhoanDAL.cs` — Truy vấn SQL
- `LayDanhSach()`: SELECT tất cả tài khoản, trả về `DataTable`
- `CapNhat()`: UPDATE thông tin 1 tài khoản theo mã

### 4. `frmQuanLyTaiKhoan.cs` — Logic nghiệp vụ
- **Load**: nạp ComboBox, lấy dữ liệu SQL, áp bộ lọc
- **ApDungLoc()**: lọc DataTable theo từ khoá + vai trò
- **SelectionChanged**: chọn dòng → hiển thị chi tiết
- **btnLuu_Click**: kiểm tra → gọi DAL cập nhật → tải lại
- **CellFormatting**: chuyển GioiTinh (bit) → "Nam"/"Nữ"

### 5. `frmQuanLyTaiKhoan.Designer.cs` — Giao diện
- Tạo và cấu hình tất cả control (Panel, Label, TextBox, Button, DataGridView...)
- Thiết lập màu sắc, font chữ, vị trí, kích thước
- Gắn sự kiện cho từng control

### 6. `App.config` — Cấu hình
- Chứa chuỗi kết nối SQL Server (`QLConn`)
- Đây là file **DUY NHẤT** bạn cần sửa khi đổi máy/database

---

## 🎨 Bảng Màu Giao Diện

Dự án sử dụng bảng màu hiện đại, chuyên nghiệp:

| Thành phần | Màu | Mã HEX | RGB |
|------------|-----|---------|-----|
| Header / Tiêu đề | 🔵 Navy đậm | `#1B2A4A` | (27, 42, 74) |
| Nút Lưu / Accent | 🔷 Xanh dương | `#007ACC` | (0, 122, 204) |
| Nút Xoá | 🔴 Đỏ | `#DC3545` | (220, 53, 69) |
| Nền form | ⬜ Xám rất nhạt | `#F3F4F6` | (243, 244, 246) |
| Nền panel / GroupBox | ⬜ Trắng | `#FFFFFF` | (255, 255, 255) |
| Chữ tiêu đề | ⬜ Trắng | `#FFFFFF` | (255, 255, 255) |
| Chữ nhãn | 🔘 Xám trung | `#6B7280` | (107, 114, 128) |
| Chữ giá trị | ⚫ Gần đen | `#1F2937` | (31, 41, 55) |
| Dòng xen kẽ DGV | 🔵 Xanh rất nhạt | `#EAF2FC` | (234, 242, 252) |
| Dòng được chọn | 🔷 Xanh dương | `#007ACC` | (0, 122, 204) |
| Đường kẻ bảng | ⬜ Xám nhạt | `#E5E7EB` | (229, 231, 235) |

> 💡 **Muốn đổi theme?** Sửa các giá trị `Color.FromArgb(...)` trong file `frmQuanLyTaiKhoan.Designer.cs`. Tất cả màu được comment rõ ràng ở từng dòng.

---

## 🔧 Hướng Dẫn Mở Rộng

### Thêm chức năng Xoá tài khoản

Hiện nút **"Xoá tài khoản"** chưa có logic. Để thêm:

**1. Thêm phương thức trong `TaiKhoanDAL.cs`:**
```csharp
public static int Xoa(string maTaiKhoan)
{
    using (SqlConnection conn = Database.GetConnection())
    using (SqlCommand cmd = new SqlCommand(
        "DELETE FROM TaiKhoan WHERE MaTaiKhoan = @MaTaiKhoan", conn))
    {
        cmd.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
        conn.Open();
        return cmd.ExecuteNonQuery();
    }
}
```

**2. Gắn sự kiện trong `frmQuanLyTaiKhoan.cs`:**
```csharp
private void btnXoa_Click(object sender, EventArgs e)
{
    if (lblMa.Text == "—") return;

    var xacNhan = MessageBox.Show(
        "Bạn có chắc muốn xoá tài khoản này?",
        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (xacNhan == DialogResult.Yes)
    {
        TaiKhoanDAL.Xoa(lblMa.Text.Trim());
        TaiKhoanTaiLai();
    }
}
```

### Thêm form mới (ví dụ: Quản Lý Sách)

1. Tạo file `frmQuanLySach.cs` và `frmQuanLySach.Designer.cs`
2. Tạo file `SachDAL.cs` với các phương thức SELECT/INSERT/UPDATE/DELETE
3. Tham khảo cấu trúc `frmQuanLyTaiKhoan` làm mẫu

### Thêm bảng mới vào Database

1. Tạo bảng mới trong SQL Server
2. Tạo file DAL mới (ví dụ: `SachDAL.cs`)
3. Tạo form mới kèm Designer
4. Không cần sửa `Database.cs` hay `App.config`

---

## ❓ Xử Lý Lỗi Thường Gặp

### Lỗi: "Lỗi kết nối hoặc tải dữ liệu"
**Nguyên nhân:** Không kết nối được SQL Server.
**Cách sửa:**
1. Kiểm tra SQL Server đang chạy (mở **Services** → tìm **SQL Server**)
2. Kiểm tra tên máy trong `App.config` (`Data Source=...`)
3. Kiểm tra database `QLThuVien` đã tồn tại

### Lỗi: "Cannot find table 'TaiKhoan'"
**Nguyên nhân:** Bảng TaiKhoan chưa được tạo.
**Cách sửa:** Chạy script SQL ở mục [Hướng Dẫn Cài Đặt](#bước-1-tạo-database-trên-sql-server)

### Lỗi: Build failed — missing packages
**Nguyên nhân:** NuGet packages chưa được restore.
**Cách sửa:** Trong Visual Studio → **Tools** → **NuGet Package Manager** → **Restore NuGet Packages**

### Lỗi: "Login failed for user..."
**Nguyên nhân:** SQL Server không chấp nhận Windows Authentication.
**Cách sửa:** Đổi `Integrated Security=True` thành `User ID=sa;Password=YOUR_PASSWORD` trong `App.config`

---

## 🤝 Đóng Góp

Nếu bạn muốn đóng góp vào dự án:

1. **Fork** repository này
2. Tạo branch mới: `git checkout -b feature/ten-tinh-nang`
3. Commit thay đổi: `git commit -m "Thêm tính năng XYZ"`
4. Push lên: `git push origin feature/ten-tinh-nang`
5. Tạo **Pull Request**

---

## 📜 Giấy Phép

Dự án này được phát triển cho mục đích **học tập**. Bạn có thể tự do sử dụng, chỉnh sửa và phân phối.

---

## 👥 Thông Tin Liên Hệ

- **Dự án:** Quản Lý Thư Viện
- **Nền tảng:** C# WinForms (.NET Framework 4.7.2)
- **Database:** SQL Server
- **IDE khuyến nghị:** Visual Studio 2019+

---

> 💡 **Mẹo cho người mới:** Đọc code theo thứ tự: `Program.cs` → `Database.cs` → `TaiKhoanDAL.cs` → `frmQuanLyTaiKhoan.cs` → `frmQuanLyTaiKhoan.Designer.cs`. Mỗi file đều có comment giải thích chi tiết từng dòng!
