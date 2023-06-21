using Assesment1.ViewModel;
using CommunityToolkit.Maui.Alerts;

namespace Assesment1.View;

public partial class WelcomeScreen : ContentPage
{
	private WelcomeViewModel _welcomeViewModel;
	private string _playerName;
	public WelcomeScreen(Model.WelcomeNameModel _welcomeName)
	{
		InitializeComponent();
		NavigationPage.SetHasBackButton(this, false);
		_welcomeViewModel = (WelcomeViewModel)BindingContext;
		_welcomeViewModel.WelcomeName = _welcomeName;
		_playerName = _welcomeName.Name;
	}

    private async void ButtonSubmit_Clicked(object sender, EventArgs e)
    {

			await Navigation.PushAsync(new GameScreen(_playerName));
    }
}