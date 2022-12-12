using CookUs.Model;
using CookUs.ViewModel;

namespace CookUs.View;

public partial class RecipesListPage : ContentPage
{
    readonly RecipesListViewModel ViewModel;
    public RecipesListPage(RecipesListViewModel recipesListViewModel)
    {
        InitializeComponent();
        BindingContext = ViewModel = recipesListViewModel;
    }

    private async void RecipeDetailsAsync_Tapped(object sender, EventArgs e)
    {
        Recipe recipe = ((VisualElement)sender).BindingContext as Recipe;
        await ViewModel.ShowRecipeAsync(recipe);
    }
}