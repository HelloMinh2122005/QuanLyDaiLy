using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Interfaces;

public interface IQuanRepository
{
    Task<IEnumerable<Quan>> GetAllQuansAsync();
}
