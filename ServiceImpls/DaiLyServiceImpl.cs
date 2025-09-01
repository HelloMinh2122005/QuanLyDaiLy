using QuanLyDaiLy.Interfaces;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;

namespace QuanLyDaiLy.ServiceImpls;

public class DaiLyServiceImpl : IDaiLyService
{
    private readonly IDaiLyRepository daiLyRepository;

    public DaiLyServiceImpl(IDaiLyRepository daiLyRepository)
    {
        this.daiLyRepository = daiLyRepository;
    }

    public async Task<IEnumerable<DaiLy>> GetAllDaiLiesAsync()
    {
        return await daiLyRepository.GetAllDaiLiesAsync();
    }

    public async Task<int> AddDaiLyAsync(DaiLy newDaiLy)
    {
        return await daiLyRepository.AddDaiLyAsync(newDaiLy);
    }

    public async Task<int> GetNextAvailableIdAsync()
    {
        return await daiLyRepository.GetNextAvailableIdAsync();
    }
}
