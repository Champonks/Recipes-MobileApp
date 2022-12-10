using CookUs.Model;
using CookUs.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.ViewModel
{
    public class RecipesListViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; } = new();
        public Command AddRecipeCommand { get; }

        public RecipesListViewModel()
        {
            Title = "Recipes";
            LoadDataAsync();
            AddRecipeCommand = new Command(OnAddRecipe);
        }

        private async void ShowRecipesAsync(object sender, EventArgs e)
        {
            Recipe recipe = ((VisualElement)sender).BindingContext as Recipe;
            if (recipe == null) return;
            
            await Shell.Current.GoToAsync(nameof(ViewRecipePage), true, new Dictionary<string, object>
            {
                {"Recipe", recipe }
            });

        }

        private async void OnAddRecipe(object sender)
        {
            await Shell.Current.GoToAsync(nameof(AddRecipe), true);
        }

        public async void LoadDataAsync()
        {
            if (IsRefreshing) return;

            try
            {
                IsRefreshing = true;

                var recipes = await DataStore.GetRecipesAsync();
                Recipes.Clear();
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
