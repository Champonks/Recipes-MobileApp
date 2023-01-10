using api.DTO;
using api.Model;

namespace api.Datastores
{
    public interface IDataStore
    {

        public Ingredient GetIngredientById(int id);

        public IEnumerable<Recipe> GetAllRecipes();
        public Recipe GetRecipeById(int id);
        public IEnumerable<Recipe> GetSeasonalRecipes(int count);
        public void AddRecipe(Recipe recipe);
        public void DeleteRecipe(Recipe r);


        public IEnumerable<CartItem> GetCartItems(string userToken);
        public CartItem GetCartItemById(int id);
        public IEnumerable<CartItem> GetCartItemsById(IEnumerable<int> ids);
        public void AddCartItems(IEnumerable<CartItem> cartItems);
        public void DeleteCartItem(CartItem cartItem);

        public User GetUserByToken(string token);
        public User Connect(string login, string password);
        public User GetUserInfos(string login);
        public void AddUser(User user);
        public void DeleteUser(User user);

        public void SaveChanges();
    }
}
