using CookUs.ViewModel;

namespace CookUs.View;

public partial class Home : ContentPage
{
	public Home(HomeViewModel homeViewModel)
	{
		InitializeComponent();
		BindingContext = homeViewModel;

    }
}

