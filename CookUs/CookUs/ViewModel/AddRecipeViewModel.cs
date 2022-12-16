using CookUs.Model;
using CookUs.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace CookUs.ViewModel
{
    public class AddRecipeViewModel : BaseViewModel
    {
        public string InputName { get; set; } = "";
        public string InputDescription { get; set; } = "";
        public double InputServings { get; set; } = 1.0;
        public string InputTime { get; set; } = "";
        public ObservableCollection<Ingredient> InputIngredients { get; set; } = new();
        public ObservableCollection<string> InputSteps { get; set; } = new();

        public string InputFood { get; set; } = "";
        public string InputQuantity { get; set; } = "";
        public string InputStep { get; set; } = "";

        public Ingredient IngredientSelected { get; set; }
        public string StepSelected { get; set; }
        public string SeasonSelected { get; set; }

        public Command AddIngredientCommand { get; }
        public Command RemoveIngredientCommand { get; }
        public Command AddStepCommand { get; }
        public Command RemoveStepCommand { get; }
        
        public Command AddRecipeCommand { get; }
        public AddRecipeViewModel()
        {
            Title = "Add a recipe";
            AddIngredientCommand = new Command(OnAddIngredient);
            RemoveIngredientCommand = new Command(OnRemoveIngredient);
            AddRecipeCommand = new Command(AddRecipeAsync);
            AddStepCommand = new Command(OnAddStep);
            RemoveStepCommand = new Command(OnRemoveStep);
        }

        private void OnAddIngredient()
        {
            if (InputFood.Length != 0 && InputQuantity.Length != 0)
            {
                InputIngredients.Add(new Ingredient() { Name = InputFood, Quantity = InputQuantity });
                InputFood = "";
                InputQuantity = "";
                OnPropertyChanged(nameof(InputFood));
                OnPropertyChanged(nameof(InputQuantity));
            }
            
        }
        private void OnRemoveIngredient()
        {
            if (IngredientSelected != null)
            {
                InputIngredients.Remove(IngredientSelected);
            }
        }
        private void OnAddStep()
        {
            if (InputStep.Length != 0)
            {
                InputSteps.Add(InputStep);
                InputStep = "";
                OnPropertyChanged(nameof(InputStep));
            }
        }
        private void OnRemoveStep()
        {
            if (StepSelected != null)
            {
                InputSteps.Remove(StepSelected);
            }
        }

        public async void AddRecipeAsync()
        {
            if (InputName.Length != 0 && InputDescription.Length != 0 && InputTime.Length != 0 && InputIngredients.Count != 0 && InputSteps.Count != 0 && SeasonSelected != null)
            {
                Recipe recipe = new(InputName, InputDescription, InputServings, (CookingSeason)Int32.Parse(SeasonSelected) , InputTime, InputIngredients.ToList(), InputSteps.ToList());

                if (await DataStore.AddRecipeAsync(recipe))
                {
                    OnPropertyChanged(nameof(RecipesListPage));
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "An error occured while adding the recipe", "OK");
                }
            } else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all the fields", "OK");
            }
        }
    }
}
