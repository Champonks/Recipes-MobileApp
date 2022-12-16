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
        public IList<Recipe> Recipes { get; set; } = new List<Recipe>();
        public Type SelectedItemNavigationTarget { get; set; }

        //we search each times the user types a character to have the latest recipes, good when the app is little only
        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                Recipes = await DependencyService.Get<IDataStore>().GetRecipesAsync(0, Int32.MaxValue);
                ItemsSource = Recipes
                    .Where(animal => animal.Name.ToLower().Contains(newValue.ToLower()))
                    .ToList();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;

            await Shell.Current.GoToAsync(nameof(ViewRecipePage), true, new Dictionary<string, object>
            {
                {"Recipe", item as Recipe }
            });
        }
    }
}
