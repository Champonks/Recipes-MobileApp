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
        public Command RefreshCart { get; }
        public Command RemoveFromCartCommand { get; }
        public CartViewModel()
        {
            Title = "Cart";
            LoadCartAsync();
            RefreshCart = new Command(LoadCartAsync);
            RemoveFromCartCommand = new Command(OnRemoveFromCart);
        }

        private void OnRemoveFromCart(object obj)
        {
            if (obj == null) return;
            Ingredient i = obj as Ingredient;
            DataStore.DeleteFromCartAsync(i);
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
