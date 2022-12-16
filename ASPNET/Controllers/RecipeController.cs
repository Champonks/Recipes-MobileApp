using Microsoft.AspNetCore.Mvc;

namespace NameSpace.Controllers
{
    [ApiController]
    [Route("[api/recipe]")]
    public class RecipeController : ControllerBase
    {
        public ActionResult GetAllRecipes()
        {
            return Ok();

        }
    }
}