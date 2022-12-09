using CookUs.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.ViewModel
{
    public class RecipesListViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; } = new();
        public RecipesListViewModel()
        {
            
        }
    }
}
