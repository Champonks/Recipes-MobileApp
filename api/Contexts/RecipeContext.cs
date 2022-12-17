using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Contexts
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        //public DbSet<Ingredient> Cart { get; set; }
    }
}