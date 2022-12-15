using CookUs.Model;
using CookUs.ViewModel;

namespace CookUs.View;

public partial class Home : ContentPage
{
    readonly HomeViewModel ViewModel;
    public Home(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = homeViewModel;
        Title = "Home";
    }

    private async void OnImageButtonClickedAsync(object sender, EventArgs e)
    {
        Recipe recipe = ((VisualElement)sender).BindingContext as Recipe;
        await ViewModel.OnViewRecipeDetails(recipe);
    }
}

