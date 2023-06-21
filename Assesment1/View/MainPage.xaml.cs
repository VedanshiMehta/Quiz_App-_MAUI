

using Assesment1.Model;
using Assesment1.View;
using CommunityToolkit.Maui.Alerts;

namespace Assesment1;

public partial class MainPage : ContentPage
{
	
	private WelcomeNameModel _welcomeName;
	public MainPage()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false);
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();
		entryPlayerName.Text = string.Empty;
    }

    private async void ButtonSubmit_Clicked(object sender, EventArgs e)
    {
		_welcomeName = new WelcomeNameModel()
		{
			Name = entryPlayerName.Text,
		};

		if(string.IsNullOrWhiteSpace(entryPlayerName.Text))
		{
			await Toast.Make("Please enter name",CommunityToolkit.Maui.Core.ToastDuration.Short).Show();
		}
		else
		{
			await Navigation.PushAsync(new WelcomeScreen(_welcomeName));
		}
    }
}

