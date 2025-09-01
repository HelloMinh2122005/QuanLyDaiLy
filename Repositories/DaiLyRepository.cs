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

    public async Task<int> AddDaiLyAsync(DaiLy newDaiLy)
    {
        await _dataContext.DaiLies.AddAsync(newDaiLy);
        return await _dataContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync()
    {
        //// Giả lập thời gian load lâu
        //await Task.Delay(5000);

        return await _dataContext.DaiLies
            .Include(dl => dl.Quan)
            .Include(dl => dl.LoaiDaiLy)
            .ToListAsync();
    }

    public async Task<int> GetNextAvailableIdAsync()
    {
        var maxId = await _dataContext.DaiLies.MaxAsync(dl => (int?)dl.MaDaiLy) ?? 0;
        return maxId + 1;
    }
}
