using QuanLyDaiLy.Data;
using System.Reflection;

namespace QuanLyDaiLy.Configs;

public class DatabaseConfig
{
    private readonly DataContext _dataContext;
    
    public DatabaseConfig(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public DataContext DataContext => _dataContext ?? throw new Exception("Database not initialized");

    // SQLite là tạo ra 1 file .db 
    // Làm sao để Entity Framework biết file .db nằm ở đâu? => GetResourcePath() 
    // ConnectionString 
    public static string GetResourcePath()
    {
        string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                              AppDomain.CurrentDomain.BaseDirectory;

        string relativePath = Path.Combine(appDirectory, @"..\..\..\..\..\Resources\Database");

        string databaseDirectory = Path.GetFullPath(relativePath);
        Directory.CreateDirectory(databaseDirectory);

        return Path.Combine(databaseDirectory, $"QuanLyDaiLy.db");
    }

    public async Task Initialize()
    {
        await _dataContext.Database.EnsureCreatedAsync();
    }
}
