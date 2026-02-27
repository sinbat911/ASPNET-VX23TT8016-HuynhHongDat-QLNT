using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaThuocWeb.Models;

public partial class DanhMuc
{
    [Display(Name = "Mã Danh Mục")]
    public int MaDanhMuc { get; set; }

    [Display(Name = "Tên Danh Mục")]
    public string TenDanhMuc { get; set; } = null!;

    [Display(Name = "Mô Tả")]
    public string? MoTa { get; set; }

    public virtual ICollection<Thuoc> Thuocs { get; set; } = new List<Thuoc>();
}