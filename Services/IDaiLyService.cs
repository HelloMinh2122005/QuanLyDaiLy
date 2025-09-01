using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Services;

public interface IDaiLyService
{
    Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync();
}
