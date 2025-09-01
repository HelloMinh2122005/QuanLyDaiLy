using Microsoft.EntityFrameworkCore;
using QuanLyDaiLy.Data;
using QuanLyDaiLy.Interfaces;
using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Repositories;

public class LoaiDaiLyRepository : ILoaiDaiLyRepository
{
    private readonly DataContext _dataContext;

    public LoaiDaiLyRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLiesAsync()
    {
        return await _dataContext.LoaiDaiLies.ToListAsync();
    }
}
