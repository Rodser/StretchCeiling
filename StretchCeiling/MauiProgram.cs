﻿using CommunityToolkit.Maui;
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

        builder.Services.AddSingleton<OrderService>();
        builder.Services.AddTransient<CeilingService>();

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<ListComponentsPage>();
        builder.Services.AddSingleton<ListOrdersPage>();
        builder.Services.AddTransient<OrderPage>();
        builder.Services.AddTransient<ComponentPage>();
        builder.Services.AddTransient<BuilderPage>();
        builder.Services.AddTransient<EditorSegmentPage>();

        builder.Services.AddSingleton<ListOrderViewModel>();
        builder.Services.AddTransient<OrderViewModel>();
        builder.Services.AddTransient<BuilderViewModel>();
        builder.Services.AddTransient<EditorSegmentViewModel>();
        builder.Services.AddTransient<CeilingViewModel>();
        builder.Services.AddTransient<ComponentViewModel>();

        return builder.Build();
    }
}
