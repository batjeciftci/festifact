using festifact.client.Pages;
using festifact.client.Services;
using festifact.client.Services.Contracts;
using festifact.client.ViewModels;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using festifact.client.Auth0;

namespace festifact.client;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiMaps()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddScoped<IFestivalService, FestivalService>();
        builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

        // ViewModels
        builder.Services.AddTransient<MusicFestivalViewModel>();
        builder.Services.AddTransient<FilmFestivalViewModel>();
        builder.Services.AddTransient<DanceFestivalViewModel>();
        builder.Services.AddTransient<LiteratureFestivalViewModel>();
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddSingleton<HomeDetailsViewModel>();
        builder.Services.AddSingleton<ShoppingCartViewModel>();



        // Pages
        builder.Services.AddTransient<MusicFestivalPage>();
        builder.Services.AddTransient<FilmFestivalPage>();
        builder.Services.AddTransient<DanceFestivalPage>();
        builder.Services.AddTransient<LiteratureFestivalPage>();
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<HomeDetailsPage>();
        builder.Services.AddSingleton<ProfilePage>();
        builder.Services.AddSingleton<ShoppingCartPage>();

        builder.Services.AddSingleton(new Auth0Client(new()
        {
            Domain = "dev-kvs17oiaspe6pf12.us.auth0.com",
            ClientId = "5Zs9DRlDqILc8ywU8IALBw8ZprsiGeOf",
            Scope = "openid profile",
            RedirectUri = "myapp://callback"
        }));


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

