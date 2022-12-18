using api.Model;
using api.Utilities;
using Microsoft.EntityFrameworkCore;

namespace api.Contexts
{
    public class CookUsContext : DbContext
    {
        public CookUsContext(DbContextOptions<CookUsContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().Property(r => r.Image).HasDefaultValue("default_recipe_img.jpg");
            //make token unique
            modelBuilder.Entity<User>().HasIndex(u => u.Token).IsUnique();
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<CartItem> Cart { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Step> Steps { get; set; }
    }
}