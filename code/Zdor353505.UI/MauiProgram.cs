using Microsoft.Extensions.Logging;
using Zdor__353505.Applicatiion;
using Zdor__353505.Persistance;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Maui;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Zdor__353505.Persistance.Data;
namespace Zdor353505.UI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string settingsStream = "Zdor353505.UI.appsettings.json";
        var builder = MauiApp.CreateBuilder();
        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream(settingsStream);

        builder.Configuration.AddJsonStream(stream);
        builder
            .UseMauiApp<App>().UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
        connStr = String.Format(connStr, dataDirectory);
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;
        builder.Services.AddApplicatiion()
                        .AddPersistance(options)
                        .RegisterPages()
                        .RegisterViewModels();
        DbInitializer.Initialize(builder.Services.BuildServiceProvider()).Wait();
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
