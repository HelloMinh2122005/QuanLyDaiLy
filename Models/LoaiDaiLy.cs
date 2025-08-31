using System.ComponentModel.DataAnnotations;

namespace QuanLyDaiLy.Models;

public class LoaiDaiLy
{
    [Key]
    public int MaLoaiDaiLy { get; set; }
    public string TenLoaiDaiLy { get; set; } = "";
    public double NoToiDa { get; set; }

    public virtual List<DaiLy> DaiLies { get; set; } = [];
}
