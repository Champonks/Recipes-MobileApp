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

        public ViewRecipeViewModel()
        {
            AddToCartCommand = new Command(OnAddToCart);
        }

        private void OnAddToCart(object obj)
        {
            if (obj == null) return;
            Ingredient i = obj as Ingredient;
            DataStore.AddToCartAsync(i);
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Recipe = query["Recipe"] as Recipe;
            OnPropertyChanged("Recipe");
        }
    }
}
