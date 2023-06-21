using Assesment1.View;

namespace Assesment1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage())
		{
			BarBackgroundColor = Color.Parse("#5630D7"),
		};
	}
}
