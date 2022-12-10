using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Model
{
    public interface IDataStore
    {
        //create all functions useful to manage a list of recipes async
        List<Recipe> Recipes { get; set; }
        Task<List<Recipe>> GetRecipesAsync();
        Task<Recipe> GetRecipeAsync(int id);
        Task<bool> AddRecipeAsync(Recipe recipe);
        Task<bool> DeleteRecipeAsync(Recipe recipe);
        Task<bool> UpdateRecipeAsync(Recipe recipe, int index);
    }
}
