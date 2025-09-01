using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Interfaces;

public interface IDaiLyRepository
{
    Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync();
    Task<int> AddDaiLyAsync(DaiLy newDaiLy);

    Task<int> GetNextAvailableIdAsync();
}
