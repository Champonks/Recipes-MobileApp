using CookUs.Model;
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
        public HomeViewModel()
        {
            Title = "Home";
            LoadSeasonalRecipesAsync();
        }

        private async void LoadSeasonalRecipesAsync()
        {
            SeasonalRecipes = await DataStore.GetSeasonalRecipesAsync(SEASONAL_RECIPES_TO_SHOW);
        }
    }
}
