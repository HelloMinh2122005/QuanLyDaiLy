using QuanLyDaiLy.Configs;
using QuanLyDaiLy.Services;

namespace QuanLyDaiLy.ServiceImpls;

public class DatabaseServiceImpl : DatabaseService
{
    private readonly DatabaseConfig databaseConfig;

    public DatabaseServiceImpl(DatabaseConfig databaseConfig)
    {
        this.databaseConfig = databaseConfig;
    }

    public async Task InitializeAsync()
    {
        await databaseConfig.Initialize();
        await SeedData();
    }

    private async Task SeedData()
    {
        await Task.CompletedTask;
    }
}
