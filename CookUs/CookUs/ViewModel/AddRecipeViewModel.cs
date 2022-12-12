using CookUs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace CookUs.ViewModel
{
    public class AddRecipeViewModel : BaseViewModel
    {
        public string InputName { get; set; }
        public string InputDescription { get; set; }
        public int InputServings { get; set; }
        public string InputTime { get; set; }
        public string[] InputIngredients { get; set; } = new string[10];
        public string[] InputQuantities { get; set; } = new string[10];
        public string[] InputSteps { get; set; } = new string[10];

        public Command AddRecipeCommand { get; }
        public AddRecipeViewModel()
        {
            Title = "Add a recipe";
            AddRecipeCommand = new Command(AddRecipeAsync);
        }

        public async void AddRecipeAsync()
        {
            if (InputName.Length != 0 && InputDescription.Length != 0 && InputTime.Length != 0 && InputIngredients.Length != 0 && InputSteps.Length != 0)
            {
                //retrieve ingredients
                Ingredient[] ingredients = new Ingredient[InputIngredients.Length / 2];
                for (int i = 0; i < InputIngredients.Length; i++)
                {
                    ingredients[i] = new Ingredient() { Name = InputIngredients[i], Quantity = InputQuantities[i] };
                }
                
                await DataStore.AddRecipeAsync(new Recipe(InputName, InputDescription, InputServings, InputTime, ingredients, InputSteps));
            } else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all the fields", "OK");
            }
        }
    }
}
