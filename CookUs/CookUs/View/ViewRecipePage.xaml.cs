using CookUs.Model;
using CookUs.ViewModel;

namespace CookUs.View;

public partial class ViewRecipePage : ContentPage
{
    public ViewRecipePage(ViewRecipeViewModel viewRecipeViewModel)
    {
        InitializeComponent();
        BindingContext = viewRecipeViewModel;
    }
}