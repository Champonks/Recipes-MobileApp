using CookUs.Model;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace CookUs.Services
{
    public class RecipesServices : ApiServices
    {
        public RecipesServices()
        {
            client.BaseAddress = new Uri("http://localhost:8000/api/recipe/");
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            List<Recipe> recipes = await client.GetFromJsonAsync<List<Recipe>>("");
            return recipes;
        }

        public async Task<List<Recipe>> GetRecipeAsync(int id)
        {
            List<Recipe> recipes = await client.GetFromJsonAsync<List<Recipe>>(id.ToString());
            return recipes;
        }

        public async Task<List<Recipe>> GetSeasonalRecipesAsync(int count)
        {
            List<Recipe> recipes = await client.GetFromJsonAsync<List<Recipe>>($"seasonal/{count}");
            return recipes;
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("", recipe);
            if (response.IsSuccessStatusCode) return await response.Content.ReadFromJsonAsync<Recipe>();
            return null;
        }

        //public async Task<bool> DeleteRecipeAsync(Recipe recipe)
        //{
        //    var response = await client.DeleteAsync($"recipes/{recipe.Id}");
        //    string responseString = "";
        //    if (response.IsSuccessStatusCode) responseString = await response.Content.ReadAsStringAsync();
        //    return Newtonsoft.Json.JsonConvert.DeserializeObject<bool>(responseString);
        //}
    }
}
