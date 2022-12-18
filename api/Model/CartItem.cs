using System.ComponentModel.DataAnnotations.Schema;

namespace api.Model
{
    public class CartItem
    {
        public int Id { get; set; }
        public string UserLogin { get; set; }
        [ForeignKey("UserLogin")]
        public User User { get; set; }
        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]
        public Ingredient Ingredient { get; set; }
    }
}