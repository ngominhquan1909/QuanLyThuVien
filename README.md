# Library Management — Account Management System

> A Windows Forms application (C# .NET Framework 4.7.2) for managing user accounts in a library system, connected to a SQL Server database.

---

## Table of Contents

- [Overview](#-overview)
- [Features](#-features)
- [System Requirements](#-system-requirements)
- [Project Structure](#-project-structure)
- [Setup Guide](#-setup-guide)
- [Usage Guide](#-usage-guide)
- [Database Structure](#-database-structure)
- [Software Architecture](#-software-architecture)
- [File-by-File Explanation](#-file-by-file-explanation)
- [UI Color Palette](#-ui-color-palette)
- [Extension Guide](#-extension-guide)
- [Troubleshooting](#-troubleshooting)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🌟 Overview

**LibraryManagement** is a Windows Forms desktop application written in **C#** on the **.NET Framework 4.7.2** platform. The application allows an administrator to:

- View the list of accounts from the SQL Server database
- Search and filter accounts by multiple criteria
- Update account information (full name, gender, email, role)

The project uses a clean **2-tier architecture**, with the presentation (UI) layer and the data access layer (DAL) clearly separated.

---

## ✨ Features

| Feature | Description |
|-----------|-------|
| 📋 **List view** | Displays all accounts in a DataGridView with a polished UI |
| 🔍 **Real-time search** | Type a keyword → the table filters instantly (no button needed) |
| 🏷️ **Filter by role** | Quick filter: Admin / Staff / All |
| ✏️ **Edit information** | Click a row → edit the details → click Save |
| 🎨 **Modern UI** | Navy + blue color palette, Segoe UI font, alternating row colors |
| ⚡ **Performance** | Filters data in-memory on the DataTable, with no repeated SQL queries |

---

## 💻 System Requirements

| Component | Minimum Requirement |
|------------|-------------------|
| **Operating System** | Windows 7 or later (Windows 10/11 recommended) |
| **IDE** | Visual Studio 2019 or later |
| **.NET Framework** | 4.7.2 |
| **SQL Server** | SQL Server 2016 or later (Express, Developer, or Standard) |
| **RAM** | 4 GB or more |
| **Disk space** | 100 MB free |

---

## 📁 Project Structure

```
LibraryManagement/
│
├── 📄 Program.cs                            # Application entry point
├── 📄 Database.cs                           # Database connection class (reads the connection string from App.config)
├── 📄 AccountDAL.cs                         # Data access layer (SELECT, UPDATE)
│
├── 📄 frmAccountManagement.cs               # Business logic for the main form
├── 📄 frmAccountManagement.Designer.cs      # UI layout of the main form
├── 📄 frmAccountManagement.resx             # Form resources
│
├── 📄 App.config                            # Configuration file — contains the SQL connection string
├── 📄 LibraryManagement.csproj              # MSBuild project file
├── 📄 packages.config                       # List of NuGet packages
├── 📄 README.md                             # This guide file
│
├── 📂 Properties/                           # Assembly info & resources
│   ├── AssemblyInfo.cs
│   ├── Resources.resx
│   ├── Resources.Designer.cs
│   ├── Settings.settings
│   └── Settings.Designer.cs
│
├── 📂 bin/Debug/                            # Build output (.exe file)
└── 📂 obj/                                  # Compiler intermediate files
```

---

## 🚀 Setup Guide

### Step 1: Create the database on SQL Server

Open **SQL Server Management Studio (SSMS)** and run the following script:

```sql
-- Create the database
CREATE DATABASE QLThuVien;
GO

USE QLThuVien;
GO

-- Create the TaiKhoan (Account) table
CREATE TABLE TaiKhoan (
    MaTaiKhoan  NVARCHAR(20)  PRIMARY KEY,          -- Account ID (primary key)
    Username    NVARCHAR(50)  NOT NULL UNIQUE,       -- Login username (unique)
    HoTen       NVARCHAR(100) NOT NULL,              -- Full name
    VaiTro      NVARCHAR(20)  NOT NULL DEFAULT 'NhanVien', -- Role: Admin / NhanVien (Staff)
    GioiTinh    BIT           NOT NULL DEFAULT 1,    -- 1 = Male, 0 = Female
    Email       NVARCHAR(100),                       -- Email address
    NgayTao     DATETIME      NOT NULL DEFAULT GETDATE() -- Account creation date
);
GO

-- Insert sample data
INSERT INTO TaiKhoan (MaTaiKhoan, Username, HoTen, VaiTro, GioiTinh, Email)
VALUES
    ('TK001', 'admin',     N'Nguyen Van Admin',  'Admin',    1, 'admin@thuvien.vn'),
    ('TK002', 'nhanvien1', N'Tran Thi Hoa',       'NhanVien', 0, 'hoa@thuvien.vn'),
    ('TK003', 'nhanvien2', N'Le Minh Tuan',       'NhanVien', 1, 'tuan@thuvien.vn'),
    ('TK004', 'nhanvien3', N'Pham Thi Mai',       'NhanVien', 0, 'mai@thuvien.vn'),
    ('TK005', 'admin2',    N'Hoang Duc Manh',     'Admin',    1, 'manh@thuvien.vn');
GO
```

> **Note:** The database name and table/column names (`QLThuVien`, `TaiKhoan`, `MaTaiKhoan`, `HoTen`, `VaiTro`, `GioiTinh`, `NgayTao`, etc.) are kept in Vietnamese on purpose, since the application's SQL queries in `AccountDAL.cs` and `App.config` reference these exact names. Rename them consistently on both sides if you want an all-English schema.

### Step 2: Configure the connection string

Open the **`App.config`** file and change `Data Source` to your SQL Server instance name:

```xml
<connectionStrings>
    <add name="QLConn"
         connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=QLThuVien;Integrated Security=True;TrustServerCertificate=True" />
</connectionStrings>
```

> **📝 Note:**
> - `Data Source=YOUR_SERVER_NAME` → replace with your SQL Server instance name (e.g. `LAPTOP-ABC`, `.\SQLEXPRESS`, `localhost`)
> - `Integrated Security=True` → uses Windows authentication (no username/password required)
> - If using SQL Authentication instead, replace with: `User ID=sa;Password=123456;`

### Step 3: Open and run the project

1. Open **`LibraryManagement.csproj`** in **Visual Studio**
2. Press **Ctrl + Shift + B** to build
3. Press **F5** (or Ctrl + F5) to run

> ⚠️ If any NuGet packages are missing, Visual Studio will automatically restore them on build.

---

## 📖 Usage Guide

### 1. View the account list
When the application opens, the table displays all accounts. The columns include:
- **Account ID** — Unique account identifier
- **Username** — Login username
- **Full Name** — The account holder's full name
- **Role** — Admin or Staff (NhanVien)
- **Gender** — Male or Female
- **Email** — Email address
- **Created Date** — The date the account was created

### 2. Search
Type a keyword into the **"🔍 Search"** box in the toolbar. The table filters automatically as you type, searching across all 4 columns: Account ID, Username, Full Name, and Email.

### 3. Filter by role
Choose a role from the **"Role"** ComboBox: `(All)`, `Admin`, or `Staff (NhanVien)`.

### 4. Edit account information
1. **Click** the row you want to edit in the table → its details appear in the **"Account Details"** panel on the right
2. **Edit** the fields: Full Name, Gender, Email, Role
3. Click the **"💾 Save Changes"** button
4. On success → a "Changes saved successfully!" message is shown

---

## 🗄️ Database Structure

### Table `TaiKhoan` (Account)

| Column | Data Type | Constraint | Description |
|-----|---------------|-----------|-------|
| `MaTaiKhoan` | NVARCHAR(20) | PRIMARY KEY | Account ID (primary key) |
| `Username` | NVARCHAR(50) | NOT NULL, UNIQUE | Login username |
| `HoTen` | NVARCHAR(100) | NOT NULL | Full name |
| `VaiTro` | NVARCHAR(20) | NOT NULL, DEFAULT 'NhanVien' | Role |
| `GioiTinh` | BIT | NOT NULL, DEFAULT 1 | 1 = Male, 0 = Female |
| `Email` | NVARCHAR(100) | | Email address |
| `NgayTao` | DATETIME | NOT NULL, DEFAULT GETDATE() | Creation timestamp |

### Entity diagram (currently a single table)

```
┌─────────────────────────────────┐
│          TaiKhoan                │
├─────────────────────────────────┤
│ PK  MaTaiKhoan   NVARCHAR(20)   │
│     Username     NVARCHAR(50)   │
│     HoTen        NVARCHAR(100)  │
│     VaiTro       NVARCHAR(20)   │
│     GioiTinh     BIT            │
│     Email        NVARCHAR(100)  │
│     NgayTao      DATETIME       │
└─────────────────────────────────┘
```

---

## 🏗️ Software Architecture

The project uses a **2-tier architecture**:

```
┌─────────────────────────────────────────────┐
│            PRESENTATION LAYER                │
│  ┌─────────────────────────────────────┐    │
│  │  frmAccountManagement.cs            │    │  ← Event-handling logic
│  │  frmAccountManagement.Designer.cs   │    │  ← UI layout
│  │  Program.cs                          │    │  ← Entry point
│  └─────────────────────────────────────┘    │
├─────────────────────────────────────────────┤
│         DATA ACCESS LAYER (DAL)              │
│  ┌─────────────────────────────────────┐    │
│  │  AccountDAL.cs                       │    │  ← SELECT, UPDATE
│  │  Database.cs                         │    │  ← SQL Server connection
│  └─────────────────────────────────────┘    │
├─────────────────────────────────────────────┤
│                  DATABASE                    │
│  ┌─────────────────────────────────────┐    │
│  │  SQL Server — Database: QLThuVien    │    │
│  │  Table: TaiKhoan                     │    │
│  └─────────────────────────────────────┘    │
└─────────────────────────────────────────────┘
```

**Data flow:**
```
User → Form (UI) → DAL → SQL Server → DAL → Form (UI) → Display
```

---

## 📝 File-by-File Explanation

### 1. `Program.cs` — Entry point
- Contains the `Main()` function — where the program starts
- Enables visual styles and launches the `frmAccountManagement` form

### 2. `Database.cs` — SQL Server connection
- Contains a single method: `GetConnection()`
- Reads the connection string from `App.config` (the `<connectionStrings>` tag)
- Returns a `SqlConnection` object (not yet opened)

### 3. `AccountDAL.cs` — SQL queries
- `LayDanhSach()`: SELECTs all accounts, returns a `DataTable`
- `CapNhat()`: UPDATEs a single account's information by ID

### 4. `frmAccountManagement.cs` — Business logic
- **Load**: populates the ComboBox, fetches SQL data, applies filters
- **ApDungLoc()**: filters the DataTable by keyword + role
- **SelectionChanged**: row selected → shows details
- **btnLuu_Click**: validates → calls the DAL to update → reloads
- **CellFormatting**: converts GioiTinh (bit) → "Male"/"Female"

### 5. `frmAccountManagement.Designer.cs` — UI layout
- Creates and configures every control (Panel, Label, TextBox, Button, DataGridView...)
- Sets colors, fonts, positions, and sizes
- Wires up the event handler for each control

### 6. `App.config` — Configuration
- Contains the SQL Server connection string (`QLConn`)
- This is the **ONLY** file you need to edit when changing machine/database

---

## 🎨 UI Color Palette

The project uses a modern, professional color palette:

| Element | Color | Hex | RGB |
|------------|-----|---------|-----|
| Header / Title | 🔵 Deep navy | `#1B2A4A` | (27, 42, 74) |
| Save button / Accent | 🔷 Blue | `#007ACC` | (0, 122, 204) |
| Delete button | 🔴 Red | `#DC3545` | (220, 53, 69) |
| Form background | ⬜ Very light gray | `#F3F4F6` | (243, 244, 246) |
| Panel / GroupBox background | ⬜ White | `#FFFFFF` | (255, 255, 255) |
| Header text | ⬜ White | `#FFFFFF` | (255, 255, 255) |
| Label text | 🔘 Medium gray | `#6B7280` | (107, 114, 128) |
| Value text | ⚫ Near-black | `#1F2937` | (31, 41, 55) |
| DataGridView alternating row | 🔵 Very light blue | `#EAF2FC` | (234, 242, 252) |
| Selected row | 🔷 Blue | `#007ACC` | (0, 122, 204) |
| Table gridlines | ⬜ Light gray | `#E5E7EB` | (229, 231, 235) |

> 💡 **Want to change the theme?** Edit the `Color.FromArgb(...)` values in `frmAccountManagement.Designer.cs`. Every color is clearly commented on its own line.

---

## 🔧 Extension Guide

### Add a "Delete account" feature

The **"Delete account"** button currently has no logic attached. To add it:

**1. Add a method in `AccountDAL.cs`:**
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

**2. Wire up the event in `frmAccountManagement.cs`:**
```csharp
private void btnXoa_Click(object sender, EventArgs e)
{
    if (lblMa.Text == "—") return;

    var confirm = MessageBox.Show(
        "Are you sure you want to delete this account?",
        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

    if (confirm == DialogResult.Yes)
    {
        AccountDAL.Xoa(lblMa.Text.Trim());
        TaiKhoanTaiLai();
    }
}
```

### Add a new form (e.g. Book Management)

1. Create `frmBookManagement.cs` and `frmBookManagement.Designer.cs`
2. Create `BookDAL.cs` with SELECT/INSERT/UPDATE/DELETE methods
3. Use `frmAccountManagement` as a reference template

### Add a new table to the database

1. Create the new table in SQL Server
2. Create a new DAL file (e.g. `BookDAL.cs`)
3. Create a new form with its Designer file
4. No need to modify `Database.cs` or `App.config`

---

## ❓ Troubleshooting

### Error: "Connection or data-loading error"
**Cause:** Could not connect to SQL Server.
**Fix:**
1. Check that SQL Server is running (open **Services** → look for **SQL Server**)
2. Check the server name in `App.config` (`Data Source=...`)
3. Check that the `QLThuVien` database exists

### Error: "Cannot find table 'TaiKhoan'"
**Cause:** The TaiKhoan table has not been created yet.
**Fix:** Run the SQL script in [Setup Guide](#step-1-create-the-database-on-sql-server)

### Error: Build failed — missing packages
**Cause:** NuGet packages have not been restored.
**Fix:** In Visual Studio → **Tools** → **NuGet Package Manager** → **Restore NuGet Packages**

### Error: "Login failed for user..."
**Cause:** SQL Server does not accept Windows Authentication.
**Fix:** Change `Integrated Security=True` to `User ID=sa;Password=YOUR_PASSWORD` in `App.config`

---

## 🤝 Contributing

If you'd like to contribute to this project:

1. **Fork** this repository
2. Create a new branch: `git checkout -b feature/your-feature-name`
3. Commit your changes: `git commit -m "Add XYZ feature"`
4. Push: `git push origin feature/your-feature-name`
5. Open a **Pull Request**

---

## 📜 License

This project was built for **learning purposes**. You're free to use, modify, and distribute it.

---

## 👥 Contact Information

- **Project:** Library Management
- **Platform:** C# WinForms (.NET Framework 4.7.2)
- **Database:** SQL Server
- **Recommended IDE:** Visual Studio 2019+

---

> 💡 **Tip for beginners:** Read the code in this order: `Program.cs` → `Database.cs` → `AccountDAL.cs` → `frmAccountManagement.cs` → `frmAccountManagement.Designer.cs`. Every file has detailed line-by-line comments!
