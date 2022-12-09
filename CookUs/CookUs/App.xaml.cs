using CookUs.Model;

namespace CookUs;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        DependencyService.Register<MockDataStore>();
        MainPage = new AppShell();
	}
}
