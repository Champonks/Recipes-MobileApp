using CookUs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.ViewModel
{
    public class ViewRecipeViewModel : BaseViewModel, IQueryAttributable
    {
        Recipe _recipe;
        public Recipe Recipe
        {
            get => _recipe;
            set
            {
                _recipe = value;
                OnPropertyChanged();
            }
        }
        
        public Command AddToCartCommand { get; }
        public Command AddAllToCartCommand { get; }

        public ViewRecipeViewModel()
        {
            AddToCartCommand = new Command(OnAddToCartAsync);
            AddAllToCartCommand = new Command(OnAddAllToCartAsync);
        }

        private async void OnAddToCartAsync(object obj)
        {
            if (obj == null) return;
            Ingredient i = obj as Ingredient;
            if(!(await DataStore.AddToCartAsync(i))) {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to add to cart", "OK");
            }
        }

        private async void OnAddAllToCartAsync()
        {
            if (!(await DataStore.AddAllToCartAsync(Recipe.Ingredients)))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to add to cart", "OK");
            } else
            {
                await Application.Current.MainPage.DisplayAlert("Success", "Added to cart", "OK");
            }
            
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Recipe = query["Recipe"] as Recipe;
            OnPropertyChanged("Recipe");
        }
    }
}
