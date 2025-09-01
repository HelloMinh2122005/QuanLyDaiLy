using Microsoft.EntityFrameworkCore;
using QuanLyDaiLy.Data;
using QuanLyDaiLy.Interfaces;
using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Repositories;

public class QuanRepository : IQuanRepository
{
    private readonly DataContext _dataContext;

    public QuanRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<Quan>> GetAllQuansAsync()
    {
        return await _dataContext.Quans.ToListAsync();
    }
}
