using CookUs.Model;
using CookUs.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public static int SEASONAL_RECIPES_TO_SHOW = 3;
        public List<Recipe> SeasonalRecipes { get; set; } = new List<Recipe>();
        public Command CreateRecipeCommand { get; }
        public HomeViewModel()
        {
            Title = "Home";
            LoadSeasonalRecipesAsync();
            CreateRecipeCommand = new Command(OnCreateRecipe);
        }

        private async void OnCreateRecipe()
        {
            await Shell.Current.GoToAsync(nameof(AddRecipe), true);
        }

        private async void LoadSeasonalRecipesAsync()
        {
            SeasonalRecipes = await DataStore.GetSeasonalRecipesAsync(SEASONAL_RECIPES_TO_SHOW);
        }
    }
}
