using CookUs.ViewModel;

namespace CookUs.Platforms.Android.AndroidView;

public partial class AndroidCart : ContentPage
{
	public AndroidCart()
	{
		InitializeComponent();
        BindingContext = new CartViewModel();
    }
}