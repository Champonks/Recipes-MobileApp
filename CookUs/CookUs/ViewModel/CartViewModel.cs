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
        public ObservableCollection<Ingredient> Cart { get; } = new();
        public ObservableCollection<object> SelectedItemsInCart { get; set; } = new();
        public bool IsSwipeViewEnabled { get; set; } = true;
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
            RevomeSelectedIngredientsCommand = new Command(OnRemoveSelectedIngredientsAsync);
            RevomeAllIngredientsCommand = new Command(OnRemoveAllIngredients);
        }

        private void OnRemoveFromCart(object obj)
        {
            if (obj == null) return;
            Ingredient i = obj as Ingredient;
            DataStore.DeleteFromCartAsync(i);
        }
        
        private async void OnRemoveSelectedIngredientsAsync()
        {
            if (SelectedItemsInCart == null)
            {
                return;
            } else if (SelectedItemsInCart.Count == 1)
            {
                if(!(await DataStore.DeleteFromCartAsync(SelectedItemsInCart[0] as Ingredient)))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to remove from cart", "OK");
                }
            } else
            {
                if (!(await DataStore.DeleteMultipleFromCartAsync(SelectedItemsInCart.Cast<Ingredient>().ToList())))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Failed to remove from cart", "OK");
                }
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
            if (IsRefreshing) return;
            try
            {
                IsRefreshing = true;

                var cart = await DataStore.GetCartAsync();

                Cart.Clear();
                foreach (Ingredient ingredient in cart)
                {
                    Cart.Add(ingredient);
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
