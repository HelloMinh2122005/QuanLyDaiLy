using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Services;

public interface ILoaiDaiLyService
{
    Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLiesAsync();
}
