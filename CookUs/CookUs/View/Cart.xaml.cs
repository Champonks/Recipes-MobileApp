using CookUs.ViewModel;

namespace CookUs.View;

public partial class Cart : ContentPage
{
    public CartViewModel ViewModel;
	public Cart(CartViewModel cartViewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = cartViewModel;

        this.ToolbarItems.Add(new ToolbarItem("Refresh", "refresh.png", ViewModel.LoadCartAsync));
    }

    //display the button only if there is selected items
    public void On_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (collectionView.SelectedItems.Count == 0)
        {
            RemoveWindowsButton.IsVisible = false;
        }
        else
        {
            RemoveWindowsButton.IsVisible = true;
        }
    }
}