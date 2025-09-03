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
        services.AddTransient<DatabaseService, DatabaseServiceImpl>();
        services.AddScoped<IDaiLyService, DaiLyServiceImpl>();
        services.AddScoped<ILoaiDaiLyService, LoaiDaiLyServiceImpl>();
        services.AddScoped<IQuanService, QuanServiceImpl>();
        services.AddScoped<IThamSoService, ThamSoServiceImpl>();

        // Đăng ký Repository
        services.AddScoped<IDaiLyRepository, DaiLyRepository>();
        services.AddScoped<ILoaiDaiLyRepository, LoaiDaiLyRepository>();
        services.AddScoped<IQuanRepository, QuanRepository>();
        services.AddScoped<IThamSoRepository, ThamSoRepository>();

        // Đăng ký Views 
        services.AddTransient<DanhSachDaiLyPage>();
        services.AddTransient<ThemDaiLyWindow>();

        // Đăng ký ViewModels
        services.AddTransient<DanhSachDaiLyPageViewModel>();
        services.AddTransient<ThemDaiLyWindowViewModel>();

        return services;
    }
}
