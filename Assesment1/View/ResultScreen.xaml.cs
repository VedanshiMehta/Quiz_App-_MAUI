using Assesment1.ViewModel;

namespace Assesment1.View;

public partial class ResultScreen : ContentPage
{
	private ResultViewModel _resultViewModel;
	public ResultScreen(Model.ResultModel _resultModel)
	{
		InitializeComponent();
		NavigationPage.SetHasBackButton(this, false);
		_resultViewModel = (ResultViewModel)BindingContext;
		_resultViewModel.Source = _resultModel.Source;
		_resultViewModel.Name = _resultModel.Name;
        _resultViewModel.ResultStatus = _resultModel.ResultStatus;
		_resultViewModel.Points = _resultModel.Points.ToString();

	}
    protected override bool OnBackButtonPressed()
    {
       
        return true;
    }

    private  async void ButtonReplay_Clicked(object sender, EventArgs e)
    {

        await Navigation.PopToRootAsync();
    }
}