using CommunityToolkit.Maui;
using StretchCeiling.Service;
using StretchCeiling.View.Pages;
using StretchCeiling.ViewModel;

namespace StretchCeiling;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ComponentPage>();
        builder.Services.AddTransient<BuilderPage>();
        builder.Services.AddTransient<EditorSegmentPage>();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<BuilderViewModel>();
        builder.Services.AddTransient<EditorSegmentViewModel>();
        builder.Services.AddTransient<CeilingViewModel>();
        builder.Services.AddTransient<ComponentViewModel>();

        builder.Services.AddSingleton<CeilingService>();

        return builder.Build();
	}
}
