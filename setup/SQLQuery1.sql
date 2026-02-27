-- 1. Ngắt kết nối và Xóa CSDL cũ (nếu đã tồn tại) để làm sạch
USE master;
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyNhaThuocDB')
BEGIN
    ALTER DATABASE QuanLyNhaThuocDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyNhaThuocDB;
END
GO

-- 2. Tạo CSDL mới
CREATE DATABASE QuanLyNhaThuocDB;
GO

USE QuanLyNhaThuocDB;
GO

-- 3. Bảng Danh mục
CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(255)
);

-- 4. Bảng Thuốc
CREATE TABLE Thuoc (
    MaThuoc INT IDENTITY(1,1) PRIMARY KEY,
    TenThuoc NVARCHAR(200) NOT NULL,
    HoatChat NVARCHAR(200),         
    DangBaoChe NVARCHAR(100),       
    SoDangKy NVARCHAR(50),          
    GiaBan DECIMAL(18,0) NOT NULL,  
    SoLuongTon INT NOT NULL,        
    HanSuDung DATE NOT NULL,        
    MaDanhMuc INT FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc),
    HinhAnh NVARCHAR(MAX)           
);

-- 5. Bảng Tài khoản
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    VaiTro NVARCHAR(50) DEFAULT 'NhanVien' 
);

-- 6. Bảng Hóa đơn
CREATE TABLE HoaDon (
    MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18,0) NOT NULL,
    MaTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(MaTaiKhoan),
    TenKhachHang NVARCHAR(100),
    SoDienThoai VARCHAR(15)
);

-- 7. Bảng Chi tiết Hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaChiTiet INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon INT FOREIGN KEY REFERENCES HoaDon(MaHoaDon),
    MaThuoc INT FOREIGN KEY REFERENCES Thuoc(MaThuoc),
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL
);