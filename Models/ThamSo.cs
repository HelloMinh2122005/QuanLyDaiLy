using System.ComponentModel.DataAnnotations;

namespace QuanLyDaiLy.Models;

public class ThamSo
{
    [Key] 
    public string TenThamSo { get; set; } = "";
    public string GiaTri { get; set; } = "";
}
