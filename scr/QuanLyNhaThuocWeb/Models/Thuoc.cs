using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace QuanLyNhaThuocWeb.Models;

public partial class Thuoc
{
    [Display(Name = "Mã Thuốc")]
    public int MaThuoc { get; set; }

    [Display(Name = "Tên Dược Phẩm")]
    public string TenThuoc { get; set; } = null!;

    [Display(Name = "Hoạt Chất Chính")]
    public string? HoatChat { get; set; }

    [Display(Name = "Dạng Bào Chế")]
    public string? DangBaoChe { get; set; }

    [Display(Name = "Số Đăng Ký")]
    public string? SoDangKy { get; set; }

    [Display(Name = "Giá Bán (VNĐ)")]
    [DisplayFormat(DataFormatString = "{0:#,##0}")]
    public decimal GiaBan { get; set; }

    [Display(Name = "Số Lượng Tồn")]
    public int SoLuongTon { get; set; }

    [Display(Name = "Hạn Sử Dụng")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateOnly HanSuDung { get; set; }

    [Display(Name = "Danh Mục")]
    public int? MaDanhMuc { get; set; }

    [Display(Name = "Hình Ảnh")]
    public string? HinhAnh { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    [Display(Name = "Thuộc Danh Mục")]
    public virtual DanhMuc? MaDanhMucNavigation { get; set; }
}