using api.DTO;
using api.Model;

namespace api.Datastores
{
    public interface IDataStore
    {
        public IEnumerable<Recipe> GetAllRecipes();
        public void AddRecipe(Recipe recipe);
        public void SaveChanges();
    }
}
