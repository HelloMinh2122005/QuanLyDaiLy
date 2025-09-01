using Microsoft.EntityFrameworkCore;
using QuanLyDaiLy.Data;
using QuanLyDaiLy.Interfaces;
using QuanLyDaiLy.Models;

namespace QuanLyDaiLy.Repositories;

public class DaiLyRepository : IDaiLyRepository
{
    private readonly DataContext _dataContext;

    public DaiLyRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync()
    {
        return await _dataContext.DaiLies
            .Include(dl => dl.Quan)
            .Include(dl => dl.LoaiDaiLy)
            .ToListAsync();
    }
}
