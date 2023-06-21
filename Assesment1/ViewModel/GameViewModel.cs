using Assesment1.Model;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Graphics.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assesment1.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        private string _questionNumber;
        private string _totalPoints;
        private double _progressQuestionValue;
        private string _question;
        private string _option1;
        private string _option2;
        private string _option3;
        private string _option4;
        private bool _isNavigated;
        private double _percentage;
        private bool _isAnswer1Checked;
        private bool _isAnswer2Checked;
        private bool _isAnswer3Checked;
        private bool _isAnswer4Checked;
        private string _totalAttempts;
        private bool _isButtonEnabled;
        private Color _textColor1;
        private Color _backgroundColor1;
        private Color _textColor2;
        private Color _backgroundColor2;
        private Color _textColor3;
        private Color _backgroundColor3;
        private Color _textColor4;
        private Color _backgroundColor4;
        private GameModel _gameModel { get; set; }   
     

        public string QuestionNumber { get => _questionNumber; set { _questionNumber = value; OnPropertyChanged(); } }
        public string TotalPoints { get => _totalPoints; set { _totalPoints = value;OnPropertyChanged(); } }
        public double ProgressQuestionValue { get=>_progressQuestionValue; set { _progressQuestionValue = value;OnPropertyChanged(); } }
        public string Question { get=>_question; set { _question = value; OnPropertyChanged();} }
        public string Option1 { get => _option1; set { _option1 = value; OnPropertyChanged(); } }
        public string Option2 { get => _option2; set { _option2 = value; OnPropertyChanged(); } }
        public string Option3 { get => _option3; set { _option3 = value; OnPropertyChanged(); } }
        public string Option4 { get => _option4; set { _option4 = value; OnPropertyChanged(); } }
        public bool IsAnswer1Checked { get => _isAnswer1Checked; set { _isAnswer1Checked = value; OnPropertyChanged(); } }
        public bool IsAnswer2Checked { get => _isAnswer2Checked; set { _isAnswer2Checked = value; OnPropertyChanged(); } }
        public bool IsAnswer3Checked { get => _isAnswer3Checked; set { _isAnswer3Checked = value; OnPropertyChanged(); } }
        public bool IsAnswer4Checked { get => _isAnswer4Checked; set { _isAnswer4Checked = value; OnPropertyChanged(); } }
        public string TotalAttempts { get => _totalAttempts; set { _totalAttempts = value; OnPropertyChanged(); } }
        public bool IsButtonEnabled { get => _isButtonEnabled; set { _isButtonEnabled = value; OnPropertyChanged(); } }
        public Color TextColor1 { get=>_textColor1; set { _textColor1 = value;OnPropertyChanged(); } }
        public Color BackgroundColor1 { get => _backgroundColor1; set { _backgroundColor1 = value; OnPropertyChanged(); } }
        public Color TextColor2 { get => _textColor2; set { _textColor2 = value; OnPropertyChanged(); } }
        public Color BackgroundColor2 { get => _backgroundColor2; set { _backgroundColor2 = value; OnPropertyChanged(); } }
        public Color TextColor3 { get => _textColor3; set { _textColor3 = value; OnPropertyChanged(); } }
        public Color BackgroundColor3 { get => _backgroundColor3; set { _backgroundColor3 = value; OnPropertyChanged(); } }
        public Color TextColor4 { get => _textColor4; set { _textColor4 = value; OnPropertyChanged(); } }
        public Color BackgroundColor4 { get => _backgroundColor4; set { _backgroundColor4 = value; OnPropertyChanged(); } }

        public event EventHandler<GameViewModelEventArgs> ResultPage;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand SubmitAnswer { get; private set; }
        public ICommand SelectAnswers { get; private set; }

        public GameViewModel()
        {
            _gameModel = new GameModel();
            SelectAnswers = new Command(SelectAnswer);
            SubmitAnswer = new Command(GetResults);
            
            GetQuestion1Data();
        }

        private void GetQuestion1Data()
        {
            QuestionNumber = _gameModel.QuestionNumber.ToString()+"/5";
            IsButtonEnabled = _gameModel.IsButtonEnabled;
            Question = _gameModel.Question;
            Option1 = _gameModel.Option1;
            Option2 = _gameModel.Option2;
            Option3 = _gameModel.Option3;
            Option4 = _gameModel.Option4;
            IsAnswer1Checked = _gameModel.IsAnswer1Checked;
            IsAnswer2Checked = _gameModel.IsAnswer2Checked;
            IsAnswer3Checked = _gameModel.IsAnswer3Checked;
            IsAnswer4Checked = _gameModel.IsAnswer4Checked;
            ProgressQuestionValue = _gameModel.ProgressQuestionValue;
            TotalPoints = _gameModel.TotalPoints.ToString();
            BackgroundColor1 = _gameModel.BackgroundColor1;
            TextColor1 = _gameModel.TextColor1;
            BackgroundColor2 = _gameModel.BackgroundColor2;
            TextColor2 = _gameModel.TextColor2;
            BackgroundColor3 = _gameModel.BackgroundColor3;
            TextColor3 = _gameModel.TextColor3;
            BackgroundColor4 = _gameModel.BackgroundColor4;
            TextColor4 = _gameModel.TextColor4;
        }
        
        private void GetResults()
        {

            _gameModel.StartGame();
            QuestionNumber = _gameModel.QuestionNumber.ToString() + "/5";
            IsButtonEnabled = _gameModel.IsButtonEnabled;
            Question = _gameModel.Question;
            Option1 = _gameModel.Option1;
            Option2 = _gameModel.Option2;
            Option3 = _gameModel.Option3;
            Option4 = _gameModel.Option4;
            IsAnswer1Checked = _gameModel.IsAnswer1Checked;
            IsAnswer2Checked = _gameModel.IsAnswer2Checked;
            IsAnswer3Checked = _gameModel.IsAnswer3Checked;
            IsAnswer4Checked = _gameModel.IsAnswer4Checked;
            ProgressQuestionValue = _gameModel.ProgressQuestionValue;
            TotalPoints = _gameModel.TotalPoints.ToString();
           
            if (_gameModel.TotalAttempts == 0)
            {
                TotalAttempts = string.Empty;
            }
            else if (_gameModel.TotalAttempts == 1)
            {
                TotalAttempts = "This is your last attempt";
            }
            else
            {
                TotalAttempts = "You have " + _gameModel.TotalAttempts.ToString() + " attemps";
            }

            _isNavigated = _gameModel.IsNavigated;
            
            if (_isNavigated)
            {
                NavigateToNextPage();
            }
        }

        private void NavigateToNextPage()
        {
            _percentage = (_gameModel.TotalPoints / 50.0) * 100.0;
            if (_percentage == 100)
            {
                ResultPage?.Invoke(this, new GameViewModelEventArgs(){ ImageSource = "gold", Points = int.Parse(TotalPoints), ScoreStatus = "Excellent!!!" });
            }
            else if (_percentage >= 76 && _percentage <= 99)
            {
                ResultPage?.Invoke(this, new GameViewModelEventArgs(){ ImageSource = "silver", Points = int.Parse(TotalPoints), ScoreStatus = "Very Good!!!" });
            }
            else if (_percentage >= 51 && _percentage <= 75)
            {
                ResultPage?.Invoke(this, new GameViewModelEventArgs(){ ImageSource = "bronze", Points = int.Parse(TotalPoints), ScoreStatus = "Good!!!" });
            }
            else
            {
                ResultPage?.Invoke(this, new GameViewModelEventArgs(){ ImageSource = "ribbon", Points = int.Parse(TotalPoints), ScoreStatus = "Can do better..." });
            }
        }

        private void SelectAnswer()
        {

            _gameModel.IsAnswer1Checked = IsAnswer1Checked;
            _gameModel.IsAnswer2Checked = IsAnswer2Checked;
            _gameModel.IsAnswer3Checked = IsAnswer3Checked;
            _gameModel.IsAnswer4Checked = IsAnswer4Checked;
            _gameModel.EnableButton();
            IsButtonEnabled = _gameModel.IsButtonEnabled;
            BackgroundColor1 = _gameModel.BackgroundColor1;
            TextColor1 = _gameModel.TextColor1;
            BackgroundColor2 = _gameModel.BackgroundColor2;
            TextColor2 = _gameModel.TextColor2;
            BackgroundColor3 = _gameModel.BackgroundColor3;
            TextColor3 = _gameModel.TextColor3;
            BackgroundColor4 = _gameModel.BackgroundColor4;
            TextColor4 = _gameModel.TextColor4;

        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    public class GameViewModelEventArgs : EventArgs
    {
        public ImageSource ImageSource { get; set; }
        public string ScoreStatus { get; set; }
        public int Points { get; set; }
    }
}
