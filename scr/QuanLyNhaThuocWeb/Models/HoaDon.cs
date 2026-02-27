using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaThuocWeb.Models;

public partial class HoaDon
{
    [Display(Name = "Mã Hóa Đơn")]
    public int MaHoaDon { get; set; }

    [Display(Name = "Ngày Lập")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
    public DateTime? NgayLap { get; set; }

    [Display(Name = "Tổng Tiền (VNĐ)")]
    [DisplayFormat(DataFormatString = "{0:#,##0}")]
    public decimal TongTien { get; set; }

    [Display(Name = "Mã Nhân Viên")]
    public int? MaTaiKhoan { get; set; }

    [Display(Name = "Tên Khách Hàng")]
    public string? TenKhachHang { get; set; }

    [Display(Name = "Số Điện Thoại")]
    public string? SoDienThoai { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    [Display(Name = "Người Lập Đơn")]
    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }
}