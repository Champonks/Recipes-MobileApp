using api.Contexts;
using api.Model;

namespace api.Datastores
{
    public class MySQLDataStore : IDataStore
    {
        private readonly RecipeContext _context;

        public MySQLDataStore(RecipeContext context)
        {
            _context = context;
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}