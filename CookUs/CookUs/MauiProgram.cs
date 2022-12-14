using Microsoft.Extensions.Logging;
using CookUs.ViewModel;
using CookUs.View;
using CookUs.Platforms.Android.AndroidView;

namespace CookUs;

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
		builder.Services.AddTransient<ViewRecipeViewModel>();
		builder.Services.AddTransient<ViewRecipePage>();
        
		builder.Services.AddTransient<RecipesListViewModel>();
		builder.Services.AddTransient<RecipesListPage>();
        
        builder.Services.AddTransient<HomeViewModel>();
        builder.Services.AddTransient<Home>();
        
        builder.Services.AddTransient<AddRecipeViewModel>();
		builder.Services.AddTransient<AddRecipe>();

        builder.Services.AddTransient<CartViewModel>();
        builder.Services.AddTransient<Cart>();
        builder.Services.AddTransient<AndroidCart>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}