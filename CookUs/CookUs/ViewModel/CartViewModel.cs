using CookUs.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookUs.ViewModel
{
    public class CartViewModel : BaseViewModel
    {
        public ObservableCollection<Ingredient> Cart { get; set; } = new();
        public ObservableCollection<object> SelectedItemsInCart { get; set; } = new();
        public Command RefreshCart { get; }
        public Command RemoveFromCartCommand { get; }
        public Command RevomeSelectedIngredientsCommand { get; }
        public Command RevomeAllIngredientsCommand { get; }

        public CartViewModel()
        {
            Title = "Cart";
            LoadCartAsync();
            RefreshCart = new Command(LoadCartAsync);
            RemoveFromCartCommand = new Command(OnRemoveFromCart);
            RevomeSelectedIngredientsCommand = new Command(OnRemoveSelectedIngredients);
            RevomeAllIngredientsCommand = new Command(OnRemoveAllIngredients);

        }

        private void OnRemoveFromCart(object obj)
        {
            if (obj == null) return;
            Ingredient i = obj as Ingredient;
            DataStore.DeleteFromCartAsync(i);
        }
        
        private void OnRemoveSelectedIngredients()
        {
            if (SelectedItemsInCart == null)
            {
                return;
            } else if (SelectedItemsInCart.Count == 1)
            {
                DataStore.DeleteFromCartAsync(SelectedItemsInCart[0] as Ingredient);
            } else
            {
                DataStore.DeleteMultipleFromCartAsync(SelectedItemsInCart.Cast<Ingredient>().ToList());
            }
            LoadCartAsync();
        }

        private void OnRemoveAllIngredients()
        {
            DataStore.DeleteMultipleFromCartAsync(Cart.ToList());
            LoadCartAsync();
        }

        public async void LoadCartAsync()
        {
            try
            {
                IsRefreshing = true;
                
                var cart = await DataStore.GetCartAsync();

                Cart.Clear();
                foreach (var ingredients in cart)
                {
                    Cart.Add(ingredients);
                }
               
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Loading error", ex.Message, "Cancel");
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
