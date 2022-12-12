using Microsoft.Extensions.Logging;
using CookUs.ViewModel;
using CookUs.View;

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
#if DEBUG
		builder.Logging.AddDebug();
#endif

        return builder.Build();
	}
}