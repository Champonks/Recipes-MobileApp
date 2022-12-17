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
            CreateMap<Ingredient, IngredientReadDTO>();
            CreateMap<Step, StepReadDTO>();
            CreateMap<Recipe, RecipeWriteDTO>();
             CreateMap<Ingredient, IngredientWriteDTO>();
            CreateMap<Step, StepWriteDTO>();
        }
    }
}