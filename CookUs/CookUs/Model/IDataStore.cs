using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Model
{
    public interface IDataStore
    {
        //create all functions useful to manage a list of recipes async
        List<Recipe> Recipes { get; set; }
        List<Ingredient> Cart { get; set; }
        Task<List<Recipe>> GetRecipesAsync(int start, int count);
        Task<List<Recipe>> GetAllRecipesAsync();
        Task<List<Recipe>> GetSeasonalRecipesAsync(int count);
        Task<bool> AddRecipeAsync(Recipe recipe);
        Task<bool> DeleteRecipeAsync(Recipe recipe);
        Task<List<Ingredient>> GetCartAsync();
        Task<bool> AddToCartAsync(Ingredient ingredient);
        Task<bool> AddAllToCartAsync(List<Ingredient> ingredient);
        Task<bool> DeleteFromCartAsync(Ingredient ingredient);
        Task<bool> DeleteMultipleFromCartAsync(List<Ingredient> ingredients);
    }
}
