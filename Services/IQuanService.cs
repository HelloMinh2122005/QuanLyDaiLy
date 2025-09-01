using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Services;

public interface IQuanService
{
    Task<IEnumerable<Quan>> GetAlllQuansAsync();
}
