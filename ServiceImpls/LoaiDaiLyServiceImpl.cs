using QuanLyDaiLy.Interfaces;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;

namespace QuanLyDaiLy.ServiceImpls;

public class LoaiDaiLyServiceImpl : ILoaiDaiLyService
{
    private readonly ILoaiDaiLyRepository loaiDaiLyRepository;

    public LoaiDaiLyServiceImpl(ILoaiDaiLyRepository loaiDaiLyRepository)
    {
        this.loaiDaiLyRepository = loaiDaiLyRepository;
    }

    public Task<IEnumerable<LoaiDaiLy>> GetAllLoaiDaiLiesAsync()
    {
        return loaiDaiLyRepository.GetAllLoaiDaiLiesAsync();
    }
}
