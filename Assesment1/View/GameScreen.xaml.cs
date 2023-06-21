using Assesment1.Model;
using Assesment1.ViewModel;
using System.Reflection;

namespace Assesment1.View;

public partial class GameScreen : ContentPage
{
	private GameViewModel _gameViewModel;
    private ResultModel _resultModel;
    private string _playerName;
	public GameScreen(string playerName)
	{
        
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            _gameViewModel = (GameViewModel)BindingContext;
            _resultModel = new ResultModel();
            _playerName = playerName;
            _gameViewModel.ResultPage += GameViewModel_ResultPage;
        
	}
    
    private async void GameViewModel_ResultPage(object sender, GameViewModelEventArgs e)
    {
       
        _resultModel.Source = e.ImageSource;
        _resultModel.ResultStatus = e.ScoreStatus;
        _resultModel.Points = e.Points;
        _resultModel.Name = _playerName;
        await Navigation.PushAsync(new ResultScreen(_resultModel));
    }
    protected override bool OnBackButtonPressed()
    {
      
        return true;
    }

    private void RadtionButtonAnswers_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
		_gameViewModel.SelectAnswers.Execute(this);
    }
}