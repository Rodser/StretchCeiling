﻿using StretchCeiling.View.Pages;
using StretchCeiling.ViewModel;

namespace StretchCeiling;

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

        builder.Services.AddSingleton<MainPage>()
						.AddSingleton<MainViewModel>();
		builder.Services.AddTransient<DetailPage>()
						.AddTransient<DetailViewModel>();
        builder.Services.AddTransient<BuilderPage>()
                        .AddTransient<BuilderViewModel>();

        return builder.Build();
	}
}
