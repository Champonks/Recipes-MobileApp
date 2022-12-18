using api.Model;

namespace api.DTO
{
    public class CartItemReadDTO
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}