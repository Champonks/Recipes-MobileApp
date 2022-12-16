using CookUs.View;

namespace CookUs;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ViewRecipePage), typeof(ViewRecipePage));
        Routing.RegisterRoute(nameof(AddRecipe), typeof(AddRecipe));

        //if we're not on pc, we want the android cart (with swipe to delete and pull-to-refresh)
        //swipe view is not supported on pc and crash the program
        if (DeviceInfo.Idiom != DeviceIdiom.Desktop)
        {
            cartTab.ContentTemplate = new DataTemplate(() =>
            {
                return new Platforms.Android.AndroidView.AndroidCart();
            });
        }
    }
}
