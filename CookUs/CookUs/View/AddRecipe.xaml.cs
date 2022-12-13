using CookUs.ViewModel;

namespace CookUs.View;

public partial class AddRecipe : ContentPage
{
    public AddRecipe(AddRecipeViewModel addRecipeViewModel)
    {
        InitializeComponent();
        BindingContext = addRecipeViewModel;
    }
}