using api.Datastores;
using api.DTO;
using api.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/recipe")]
    public class RecipeController : ControllerBase
    {
        private readonly IDataStore _dataStore;
        private readonly IMapper _map;

        public RecipeController(IDataStore dataStore, IMapper mapper)
        {
            _dataStore = dataStore;
            _map = mapper;
        }

        [HttpGet("{id}", Name = nameof(GetRecipeById))]
        public ActionResult GetRecipeById(int id)
        {
            Recipe recipe = _dataStore.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            RecipeReadDTO recipeRead = _map.Map<RecipeReadDTO>(recipe);
            User u = _dataStore.GetUserInfos(recipe.UserLogin);
            if (u == null)
            {
                return NotFound();
            }
            recipeRead.Author = _map.Map<UserReadDTO>(u);
            IEnumerable<Ingredient> ingredients = _dataStore.GetIngredientsByRecipeId(recipe.Id);
            recipeRead.Ingredients = _map.Map<List<IngredientReadDTO>>(ingredients);
            IEnumerable<Step> steps = _dataStore.GetStepsByRecipeId(recipe.Id);
            recipeRead.Steps = _map.Map<List<StepReadDTO>>(steps);
            return Ok(recipeRead);
        }

        //not efficient, find how to do better, and do not work
        [HttpGet]
        public ActionResult GetAllRecipes()
        {
            IEnumerable<Recipe> recipes = _dataStore.GetAllRecipes();
            List<RecipeReadDTO> recipesRead = new List<RecipeReadDTO>();
            foreach (Recipe r in recipes)
            {
                RecipeReadDTO recipeRead = _map.Map<RecipeReadDTO>(r);
                User u = _dataStore.GetUserInfos(r.UserLogin);
                if (u == null)
                {
                    return NotFound();
                }
                recipeRead.Author = _map.Map<UserReadDTO>(u);
                IEnumerable<Ingredient> ingredients = _dataStore.GetIngredientsByRecipeId(r.Id);
                recipeRead.Ingredients = _map.Map<List<IngredientReadDTO>>(ingredients);
                IEnumerable<Step> steps = _dataStore.GetStepsByRecipeId(r.Id);
                recipeRead.Steps = _map.Map<List<StepReadDTO>>(steps);
                recipesRead.Add(recipeRead);
            }
            
            return Ok(recipesRead);
        }

        [HttpGet("seasonal/{count}", Name = nameof(GetSeasonalRecipes))]
        public ActionResult GetSeasonalRecipes(int count)
        {
            return Ok(_map.Map<IEnumerable<RecipeReadDTO>>(_dataStore.GetSeasonalRecipes(count)));
        }

        [HttpPost("{userToken}", Name = nameof(AddRecipe))]
        public ActionResult AddRecipe(RecipeWriteDTO recipeDTO, string userToken)
        {
            User user = _dataStore.GetUserByToken(userToken);
            if (user == null) {
                return BadRequest();
            }

            Recipe recipe = _map.Map<Recipe>(recipeDTO);
            if (recipe == null)
                return BadRequest();

            recipe.Author = user;
            _dataStore.AddRecipe(recipe);
            _dataStore.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}/{userToken}", Name = nameof(DeleteRecipe))]
        public ActionResult DeleteRecipe(int id, string userToken)
        {
            User user = _dataStore.GetUserByToken(userToken);
            if (user == null)
                return BadRequest();
            Recipe recipe = _dataStore.GetRecipeById(id);
            if (recipe.UserLogin != user.Login)
                return Unauthorized();
            if (recipe == null)
                return NotFound();
            _dataStore.DeleteRecipe(recipe);
            _dataStore.SaveChanges();
            return Ok();
        }
    }
}