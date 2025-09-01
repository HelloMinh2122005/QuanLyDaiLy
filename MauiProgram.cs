using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using QuanLyDaiLy.DI;
using QuanLyDaiLy.Services;

namespace QuanLyDaiLy
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.RegisterDependency();

            var appBuilder = builder.Build();

            _ = Task.Run(async () =>
            {
                using var scope = appBuilder.Services.CreateScope();
                await scope.ServiceProvider.GetRequiredService<DatabaseService>().InitializeAsync();
            });

            return appBuilder;
        }
    }
}
