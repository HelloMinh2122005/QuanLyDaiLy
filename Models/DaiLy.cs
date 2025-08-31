using System.ComponentModel.DataAnnotations;

namespace QuanLyDaiLy.Models;

public class DaiLy
{
    [Key]
    public int MaDaiLy { get; set; }
    public string Ten { get; set; } = "";
    public string DiaChi { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime NgayTiepNhan { get; set; } = DateTime.Now;
    public double NoDaiLy { get; set; }

    // Khoa ngoai
    public int MaLoaiDaiLy { get; set; }
    public virtual LoaiDaiLy LoaiDaiLy { get; set; } = null!;
    public int MaQuan { get; set; }
    public virtual Quan Quan { get; set; } = null!;
}
