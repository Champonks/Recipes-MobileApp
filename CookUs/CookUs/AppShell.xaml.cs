using CookUs.View;

namespace CookUs;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(ViewRecipePage), typeof(ViewRecipePage));
        Routing.RegisterRoute(nameof(AddRecipe), typeof(AddRecipe));
    }
}
