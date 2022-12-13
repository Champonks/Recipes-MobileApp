using CookUs.ViewModel;

namespace CookUs.View;

public partial class Cart : ContentPage
{
    public CartViewModel ViewModel;
	public Cart(CartViewModel cartViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = cartViewModel;

        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            this.ToolbarItems.Add(new ToolbarItem("Refresh", "refresh.png", ViewModel.LoadCartAsync));
        }
    }
}