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
            RecipeReadDTO recipeRead = _map.Map<RecipeReadDTO>(recipe);
            if (recipeRead == null)
                return NotFound();
            return Ok(recipeRead);
        }

        [HttpGet]
        public ActionResult GetAllRecipes()
        {
            IEnumerable<Recipe> recipes = _dataStore.GetAllRecipes();
            if (recipes == null)
                return NotFound();
            return Ok(_map.Map<IEnumerable<RecipeReadDTO>>(recipes));
        }

        [HttpGet("seasonal/{count}", Name = nameof(GetSeasonalRecipes))]
        public ActionResult GetSeasonalRecipes(int count)
        {
            IEnumerable<Recipe> recipes = _dataStore.GetSeasonalRecipes(count);
            if (recipes == null)
                return NotFound();
            return Ok(_map.Map<IEnumerable<RecipeReadDTO>>(recipes));
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

            recipe.UserLogin = user.Login;
            _dataStore.AddRecipe(recipe);
            _dataStore.SaveChanges();
            return CreatedAtRoute(nameof(GetRecipeById), new { id = recipe.Id }, recipe);
        }

        [HttpDelete("{userToken}", Name = nameof(DeleteRecipe))]
        public ActionResult DeleteRecipe(int id, string userToken)
        {
            User user = _dataStore.GetUserByToken(userToken);
            if (user == null)
                return BadRequest();

            Recipe recipe = _dataStore.GetRecipeById(id);
            if (recipe == null)
                return NotFound();
            if (recipe.UserLogin != user.Login)
                return Unauthorized();
            
            _dataStore.DeleteRecipe(recipe);
            _dataStore.SaveChanges();
            return Ok();
        }
    }
}