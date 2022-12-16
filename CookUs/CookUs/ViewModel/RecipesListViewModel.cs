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
        static int RECIPES_LOADED = 0;
        public ObservableCollection<Recipe> Recipes { get; set; } = new();
        public Command AddRecipeCommand { get; }
        public Command RefreshRecipes { get; }
        public Command LoadMoreRecipes { get; }

        public RecipesListViewModel()
        {
            Title = "Recipes";
            LoadRecipesAsync();
            AddRecipeCommand = new Command(OnAddRecipe);
            RefreshRecipes = new Command(LoadRecipesAsync);
            LoadMoreRecipes = new Command(LoadMoreRecipesAsync);
        }

        private async void OnAddRecipe()
        {
            await Shell.Current.GoToAsync(nameof(AddRecipe), true);
        }

        public async void LoadRecipesAsync()
        {
            if (IsRefreshing) return;
            try
            {
                IsRefreshing = true;
                int nbRecipesToLoad = 7;
                //because on desktop, loading incrementally doesn't work
                if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
                {
                    nbRecipesToLoad = 200;
                }
                var recipes = await DataStore.GetRecipesAsync(0, nbRecipesToLoad);
                
                Recipes.Clear();
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
                }
                RECIPES_LOADED = Recipes.Count;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Loading error", ex.Message, "Cancel");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        async void LoadMoreRecipesAsync()
        {
            if (IsRefreshing) return;

            try
            {
                IsRefreshing = true;
                
               
                var recipes = await DataStore.GetRecipesAsync(RECIPES_LOADED, 5);
                foreach (var recipe in recipes)
                {
                    Recipes.Add(recipe);
                }
                RECIPES_LOADED = Recipes.Count;

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Loading error", ex.Message, "Cancel");
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
