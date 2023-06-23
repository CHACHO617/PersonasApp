using Microsoft.Extensions.DependencyInjection;
using PersonasApp.DataServices;
using PersonasApp.Pages;

namespace PersonasApp;

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

		//builder.Services.AddSingleton<IRestDataService, RestDatasService>();
		builder.Services.AddHttpClient<IRestDataService, RestDatasService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<ManagePersonaPage>();

		return builder.Build();
	}
}
