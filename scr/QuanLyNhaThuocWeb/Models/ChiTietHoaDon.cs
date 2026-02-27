using System;
using System.Collections.Generic;

namespace QuanLyNhaThuocWeb.Models;

public partial class ChiTietHoaDon
{
    public int MaChiTiet { get; set; }

    public int? MaHoaDon { get; set; }

    public int? MaThuoc { get; set; }

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public virtual HoaDon? MaHoaDonNavigation { get; set; }

    public virtual Thuoc? MaThuocNavigation { get; set; }
}
