using CommunityToolkit.Maui;
using LoL_MVVM.Pages;
using LoL_MVVM.ViewModel;
using Microsoft.Extensions.Logging;
using Model;
using StubLib;
using ViewModel;

namespace LoL_MVVM;

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
			})
			.Services.AddSingleton<IDataManager, StubData>()
			.AddSingleton<ChampionsManagerVM>()
			.AddSingleton<SkinsManagerVM>()
            .AddSingleton<ApplicationVM>()
			.AddSingleton<App>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
