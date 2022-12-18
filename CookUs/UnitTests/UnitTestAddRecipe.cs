using CookUs.Services;

namespace UnitTests
{
    public class UnitTestAddRecipe
    {
        
        [Fact]
        public async void TestAdding()
        {
            //arrange
            List<Ingredient> ingredients = new() { new Ingredient() { Name = "Milk", Quantity = "1L" }, new Ingredient() { Name = "Eggs", Quantity = "2" }, new Ingredient() { Name = "Flour", Quantity = "1 cup" } };
            List<string> steps = new() { "Mix all ingredients", "Bake for 30 minutes", "Enjoy!" };
            var expected = new Recipe("Banana Split", "A banana with split.", 1.0, (CookingSeason)0, "30min", ingredients, steps);

            var recipeServices = new RecipesServices();
            
            //act
            Recipe actual = await recipeServices.AddRecipeAsync(expected);

            //assert
            Assert.Equal(expected, actual);
            Assert.Equal("Banana Split", actual.Name);
            Assert.Equal("A banana with split.", actual.Description);
            Assert.Equal(1.0, actual.Servings);
            Assert.Equal((CookingSeason)0, actual.RecipeSeason);
            Assert.Equal("30min", actual.Time);
            Assert.Equal(ingredients, actual.Ingredients);
            Assert.Equal(steps, actual.Steps);
        }
    }
}
