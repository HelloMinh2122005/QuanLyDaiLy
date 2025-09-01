using Microsoft.EntityFrameworkCore;
using QuanLyDaiLy.Configs;
using QuanLyDaiLy.Data;
using QuanLyDaiLy.Interfaces;
using QuanLyDaiLy.Repositories;
using QuanLyDaiLy.ServiceImpls;
using QuanLyDaiLy.Services;
using QuanLyDaiLy.ViewModels.DaiLyViewModels;
using QuanLyDaiLy.Views.DaiLyViews;

namespace QuanLyDaiLy.DI;

public static class AppModule
{
    // IServiceProvider: Dung de lay ra cac service da duoc dang ky
    public static IServiceCollection RegisterDependency(this IServiceCollection services)
    {
        // Đăng ký ở chỗ này
        services.AddSingleton<DatabaseConfig>();

        // Đăng ký cho SQLite 
        services.AddDbContext<DataContext>((serviceProvider, options) =>
        {
            var databasePath = DatabaseConfig.GetResourcePath();
            options.UseSqlite($"Data Source={databasePath}");
        });

        // Đăng ký các service khác ở đây
        services.AddScoped<DatabaseService, DatabaseServiceImpl>();
        services.AddScoped<IDaiLyService, DaiLyServiceImpl>();

        // Đăng ký Repository
        services.AddScoped<IDaiLyRepository, DaiLyRepository>();

        // Đăng ký Views 
        services.AddTransient<DanhSachDaiLyPage>();

        // Đăng ký ViewModels
        services.AddTransient<DanhSachDaiLyPageViewModel>();

        return services;
    }
}

// Singleton: Tao 1 lan, dung ca app 
// Transient: Can thi moi tao 
// Scoped: Tuong tu nhu Singleton, nhung chi tao 1 lan trong 1 scope (1 request)
