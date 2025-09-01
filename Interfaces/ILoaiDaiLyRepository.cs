using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Interfaces;

public interface ILoaiDaiLyRepository
{
    Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLiesAsync();
}
