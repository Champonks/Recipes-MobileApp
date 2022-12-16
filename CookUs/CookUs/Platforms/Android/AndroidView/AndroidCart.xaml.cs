using CookUs.ViewModel;

namespace CookUs.Platforms.Android.AndroidView;

public partial class AndroidCart : ContentPage
{
	public AndroidCart(CartViewModel cartViewModel)
	{
		InitializeComponent();
        BindingContext = cartViewModel;
    }
}