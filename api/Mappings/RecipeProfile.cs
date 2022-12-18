using api.DTO;
using api.Model;
using AutoMapper;

namespace api.Mappings
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            // Source -> Target
            CreateMap<Recipe, RecipeReadDTO>();
            CreateMap<RecipeWriteDTO, Recipe>();

            CreateMap<Ingredient, IngredientReadDTO>();
            CreateMap<IngredientWriteDTO, Ingredient>();

            CreateMap<Step, StepReadDTO>();
            CreateMap<StepWriteDTO, Step>();
            
            CreateMap<User, UserReadDTO>();
            CreateMap<UserWriteDTO, User>();

            CreateMap<CartItem, CartItemReadDTO>();
            CreateMap<CartItemWriteDTO, CartItem>();
        }
    }
}