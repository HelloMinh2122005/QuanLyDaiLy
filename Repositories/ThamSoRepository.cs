using Microsoft.EntityFrameworkCore;
using QuanLyDaiLy.Data;
using QuanLyDaiLy.Interfaces;

namespace QuanLyDaiLy.Repositories;

public class ThamSoRepository : IThamSoRepository
{
    private readonly DataContext dataContext;

    public ThamSoRepository(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public Task<string> GetThamSo(string key)
    {
        return dataContext.ThamSos
            .Where(ts => ts.TenThamSo == key)
            .Select(ts => ts.GiaTri)
            .FirstOrDefaultAsync()!;
    }
}
