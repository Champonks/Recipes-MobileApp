using api.DTO;
using api.Model;

namespace api.Datastores
{
    public interface IDataStore
    {
        public IEnumerable<Recipe> GetAllRecipes();
        public void AddRecipe(Recipe recipe);

        public IEnumerable<CartItem> GetCartItems(string userToken);
        public void AddCartItem(CartItem cartItem);
        //public void DeleteCartItem(CartItem cartItem);

        public User GetUser(string login, string password);
        public void AddUser(User user);

        public void SaveChanges();
    }
}
