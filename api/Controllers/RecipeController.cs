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

        [HttpGet]
        public ActionResult GetAllRecipes()
        {
            return Ok(_map.Map<IEnumerable<RecipeReadDTO>>(_dataStore.GetAllRecipes()));
        }

        [HttpPost]
        public ActionResult AddRecipe(RecipeWriteDTO recipeDTO)
        {
            Recipe recipe = _map.Map<Recipe>(recipeDTO);
            _dataStore.AddRecipe(recipe);
            _dataStore.SaveChanges();
            return Ok();
        }
    }
}