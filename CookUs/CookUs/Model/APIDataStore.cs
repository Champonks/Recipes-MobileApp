using CookUs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Model
{
    public class APIDataStore : IDataStore
    {
        public List<Recipe> Recipes { get; set; }
        public List<Ingredient> Cart { get; set; }
        private RecipesServices RecipesServices { get; } = new RecipesServices();

        public Task<bool> AddAllToCartAsync(List<Ingredient> ingredient)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddRecipeAsync(Recipe recipe)
        {
            return await RecipesServices.AddRecipeAsync(recipe) != null;
        }

        public Task<bool> AddToCartAsync(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFromCartAsync(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMultipleFromCartAsync(List<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRecipeAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await RecipesServices.GetAllRecipesAsync();
        }

        public Task<List<Ingredient>> GetCartAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetRecipesAsync(int start, int count)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetSeasonalRecipesAsync(int count)
        {
            throw new NotImplementedException();
        }
    }
}
