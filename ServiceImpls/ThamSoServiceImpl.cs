using QuanLyDaiLy.Interfaces;
using QuanLyDaiLy.Services;

namespace QuanLyDaiLy.ServiceImpls;

public class ThamSoServiceImpl : IThamSoService
{
    private readonly IThamSoRepository thamSoRepository;

    public ThamSoServiceImpl(IThamSoRepository thamSoRepository)
    {
        this.thamSoRepository = thamSoRepository;
    }

    public Task<string> GetThamSo(string key)
    {
        return thamSoRepository.GetThamSo(key);
    }
}
