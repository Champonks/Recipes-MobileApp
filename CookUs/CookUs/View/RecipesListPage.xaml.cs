using CookUs.Model;
using CookUs.ViewModel;

namespace CookUs.View;

public partial class RecipesListPage : ContentPage
{
    public RecipesListPage(RecipesListViewModel recipesListViewModel)
    {
        InitializeComponent();
        BindingContext = recipesListViewModel;
    }
}