using CookUs.Model;
using CookUs.ViewModel;

namespace CookUs.View;

public partial class RecipesListPage : ContentPage
{
    RecipesListViewModel ViewModel;
    public RecipesListPage(RecipesListViewModel recipesListViewModel)
    {
        InitializeComponent();
        BindingContext = ViewModel = recipesListViewModel;

        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            this.ToolbarItems.Add(new ToolbarItem("Refresh", "refresh.png", ViewModel.LoadRecipesAsync));
        }
    }

    private async void RecipeDetailsAsync_Tapped(object sender, EventArgs e)
    {
        Recipe recipe = ((VisualElement)sender).BindingContext as Recipe;
        await ViewModel.OnViewRecipeDetails(recipe);
    }
    //to reload the list of recipes when the page is displayed
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.LoadRecipesAsync();
    }
}