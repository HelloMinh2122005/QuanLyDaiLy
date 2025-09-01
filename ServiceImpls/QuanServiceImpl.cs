using QuanLyDaiLy.Interfaces;
using QuanLyDaiLy.Models;
using QuanLyDaiLy.Services;

namespace QuanLyDaiLy.ServiceImpls;

public class QuanServiceImpl : IQuanService
{
    private readonly IQuanRepository quanRepository;

    public QuanServiceImpl(IQuanRepository quanRepository)
    {
        this.quanRepository = quanRepository;
    }

    public Task<IEnumerable<Quan>> GetAlllQuansAsync()
    {
        return quanRepository.GetAllQuansAsync();
    }
}
