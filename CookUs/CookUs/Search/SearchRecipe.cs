using CookUs.Model;
using CookUs.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.Search
{
    class SearchRecipe : SearchHandler
    {
        public IList<Recipe> Recipes { get; set; }
        public Type SelectedItemNavigationTarget { get; set; }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Recipes
                    .Where(animal => animal.Name.ToLower().Contains(newValue.ToLower()))
                    .ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;

            await Shell.Current.GoToAsync(nameof(AddRecipe), true);
        }
    }
}
