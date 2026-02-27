using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaThuocWeb.Models;

public partial class TaiKhoan
{
    [Display(Name = "Mã Tài Khoản")]
    public int MaTaiKhoan { get; set; }

    [Display(Name = "Tên Đăng Nhập")]
    public string TenDangNhap { get; set; } = null!;

    [Display(Name = "Mật Khẩu")]
    public string MatKhau { get; set; } = null!;

    [Display(Name = "Họ Và Tên")]
    public string HoTen { get; set; } = null!;

    [Display(Name = "Vai Trò")]
    public string? VaiTro { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}