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
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Recipe = query["Recipe"] as Recipe;
            OnPropertyChanged("Recipe");
        }
    }
}
