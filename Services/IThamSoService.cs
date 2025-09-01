namespace QuanLyDaiLy.Services;

public interface IThamSoService
{
    Task<string> GetThamSo(string key);
}
