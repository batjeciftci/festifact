using festifact.client.Pages;
using festifact.client.Services;
using festifact.client.Services.Contracts;
using festifact.client.ViewModels;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace festifact.client;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		// Services
		builder.Services.AddScoped<IFestivalService, FestivalService>();

		// ViewModels
		builder.Services.AddTransient<MusicFestivalViewModel>();
		builder.Services.AddTransient<FilmFestivalViewModel>();
		builder.Services.AddTransient<DanceFestivalViewModel>();
		builder.Services.AddTransient<LiteratureFestivalViewModel>();
		builder.Services.AddTransient<HomeViewModel>();
		builder.Services.AddTransient<HomeDetailsViewModel>();


		// Pages
		builder.Services.AddTransient<MusicFestivalPage>();
		builder.Services.AddTransient<FilmFestivalPage>();
		builder.Services.AddTransient<DanceFestivalPage>();
		builder.Services.AddTransient<LiteratureFestivalPage>();
		builder.Services.AddTransient<HomePage>();
		builder.Services.AddTransient<HomeDetailsPage>();




#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

