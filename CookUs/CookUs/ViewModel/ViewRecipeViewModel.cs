using CookUs.Model;
using CookUs.Platforms.Android.AndroidView;
using CookUs.View;
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
        public Command DeleteRecipeCommand { get; }

        public ViewRecipeViewModel()
        {
            AddToCartCommand = new Command(OnAddToCartAsync);
            AddAllToCartCommand = new Command(OnAddAllToCartAsync);
            DeleteRecipeCommand = new Command(OnDeleteRecipeAsync);
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

        private async void OnDeleteRecipeAsync(object obj)
        {
            if (obj == null) return;
            Recipe recipe = obj as Recipe;
            if (!(await DataStore.DeleteRecipeAsync(recipe)))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to add to cart", "OK");
            } else
            {
                await Shell.Current.GoToAsync("..");
            }
        }
        
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Recipe = query["Recipe"] as Recipe;
            OnPropertyChanged("Recipe");
        }
    }
}
