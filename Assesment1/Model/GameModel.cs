using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Assesment1.Model
{
    public class GameModel
    {
        private List<string> _questionsList;
        private List<string> _answersList;
        private int _totalAttempts = 3;       
        private int _count = 1;       
        public int QuestionNumber { get; set; }
        public int TotalPoints { get; set; }
        public double ProgressQuestionValue { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public bool IsAnswer1Checked { get; set; }
        public bool IsAnswer2Checked { get;set; }
        public bool IsAnswer3Checked { get; set;}
        public bool IsAnswer4Checked { get; set; }
        public int TotalAttempts { get; set; }
        public bool IsButtonEnabled { get; set; }
        public bool IsNavigated { get; private set; }
        public Color TextColor1 { get; set; }
        public Color BackgroundColor1 { get; set; }
        public Color TextColor2 { get; set; }
        public Color BackgroundColor2 { get; set; }
        public Color TextColor3 { get; set; }
        public Color BackgroundColor3 { get; set; }
        public Color TextColor4 { get; set; }
        public Color BackgroundColor4 { get; set; }

        public GameModel()
        {
            GetQuestionsList();
            GetAnswersList();
            SetIntialQuestionData();
           
        }

        private void SetIntialQuestionData()
        {
            QuestionNumber = 1;
            Question = _questionsList[0];
            Option1 = _answersList[0];
            Option2 = _answersList[1];
            Option3 = _answersList[2];
            Option4 = _answersList[3];
            IsButtonEnabled = false;
            IsAnswer1Checked = false;
            IsAnswer2Checked = false;
            IsAnswer3Checked = false;
            IsAnswer4Checked = false;
            TotalPoints = 0;
            TotalAttempts = 0;
            TextColor1 = Color.Parse("#ACACAC");
            BackgroundColor1 = Color.Parse("#FFFFFF");
            TextColor2 = Color.Parse("#ACACAC");
            BackgroundColor2 = Color.Parse("#FFFFFF");
            TextColor3 = Color.Parse("#ACACAC");
            BackgroundColor3 = Color.Parse("#FFFFFF");
            TextColor4 = Color.Parse("#ACACAC");
            BackgroundColor4 = Color.Parse("#FFFFFF");
            CalculateProgressValue(QuestionNumber);
        }

        public void StartGame()
        {
           
            if (Question.Equals(_questionsList[0]))
            {
                if (IsAnswer1Checked)
                {
                    CalculateTotalPlusPoints();  
                    QuestionNumber = 2;
                    Question = _questionsList[1];
                    Option1 = _answersList[4];
                    Option2 = _answersList[5];
                    Option3 = _answersList[6];
                    Option4 = _answersList[7];
                    ResetRadioButtons();
                 
                }
                else if(IsAnswer2Checked || IsAnswer3Checked || IsAnswer4Checked) 
                {
                    CalculateMinusPoints();
                }
            }
            if (Question.Equals(_questionsList[1]))
            {
                if(IsAnswer3Checked)
                {
                    CalculateTotalPlusPoints();
                    QuestionNumber = 3;
                    Question = _questionsList[2];
                    Option1 = _answersList[8];
                    Option2 = _answersList[9];
                    Option3 = _answersList[10];
                    Option4 = _answersList[11];
                    ResetRadioButtons();
                }
                else if(IsAnswer1Checked || IsAnswer2Checked || IsAnswer4Checked)
                {
                    CalculateMinusPoints();
                }
            }
            if (Question.Equals(_questionsList[2]))
            {
                if (IsAnswer3Checked)
                {
                    CalculateTotalPlusPoints();

                    QuestionNumber = 4;
                    Question = _questionsList[3];
                    Option1 = _answersList[12];
                    Option2 = _answersList[13];
                    Option3 = _answersList[14];
                    Option4 = _answersList[15];
                    ResetRadioButtons();
                }
                else if (IsAnswer1Checked || IsAnswer2Checked || IsAnswer4Checked)
                {
                    CalculateMinusPoints();
                }
            }
            if (Question.Equals(_questionsList[3]))
            {
                if (IsAnswer1Checked)
                {
                    CalculateTotalPlusPoints();

                    QuestionNumber = 5;
                    Question = _questionsList[4];
                    Option1 = _answersList[16];
                    Option2 = _answersList[17];
                    Option3 = _answersList[18];
                    Option4 = _answersList[19];
                    ResetRadioButtons();

                }
                else if (IsAnswer2Checked || IsAnswer3Checked || IsAnswer4Checked)
                {
                    CalculateMinusPoints();
                }
            }
            if (Question.Equals(_questionsList[4]))
            {
                if (IsAnswer2Checked)
                {
                    CalculateTotalPlusPoints();
                    IsNavigated = true;
                   

                }
                else if (IsAnswer1Checked || IsAnswer3Checked || IsAnswer4Checked)
                {
                    CalculateMinusPoints();
                    
                }
            }
            CalculateProgressValue(QuestionNumber);
            
            _count++;
        }

        private void CalculateProgressValue(int questionNumber)
        {
            double progress = (double)QuestionNumber / _questionsList.Count;
            ProgressQuestionValue = progress;
        }

        private void CalculateTotalPlusPoints()
        {
            TotalPoints = TotalPoints + 10;
        }

        private void CalculateMinusPoints()
        {
            TotalPoints = TotalPoints - 5;
            _totalAttempts--;
            TotalAttempts = _totalAttempts;

            IsNavigated = TotalAttempts==0?true:false;

        }

        private void ResetRadioButtons()
        {
            IsAnswer1Checked = false;
            IsAnswer2Checked = false;
            IsAnswer3Checked = false;
            IsAnswer4Checked = false;
            TotalAttempts = 0;
            _totalAttempts = 3;
        }

        public void EnableButton()
        {
            IsButtonEnabled = IsAnswer1Checked || IsAnswer2Checked || IsAnswer3Checked || IsAnswer4Checked? true : false;
            TextColor1 = IsAnswer1Checked ? Color.Parse("#FFFFFF") : Color.Parse("#ACACAC");
            BackgroundColor1 = IsAnswer1Checked ? Color.Parse("#6AA4A6") : Color.Parse("#FFFFFF");
            TextColor2 = IsAnswer2Checked ? Color.Parse("#FFFFFF") : Color.Parse("#ACACAC");
            BackgroundColor2 = IsAnswer2Checked ? Color.Parse("#6AA4A6") : Color.Parse("#FFFFFF");
            TextColor3 = IsAnswer3Checked ? Color.Parse("#FFFFFF") : Color.Parse("#ACACAC");
            BackgroundColor3 = IsAnswer3Checked ? Color.Parse("#6AA4A6") : Color.Parse("#FFFFFF");
            TextColor4 = IsAnswer4Checked ? Color.Parse("#FFFFFF") : Color.Parse("#ACACAC");
            BackgroundColor4 = IsAnswer4Checked ? Color.Parse("#6AA4A6") : Color.Parse("#FFFFFF");
        }

        private List<string> GetAnswersList()
        {
            _answersList = new List<string>();
            _answersList.Add("Delhi");
            _answersList.Add("Mumbai");
            _answersList.Add("Kolkata");
            _answersList.Add("Chennai");
            _answersList.Add("Asia");
            _answersList.Add("South America");
            _answersList.Add("Africa");
            _answersList.Add("Europe");
            _answersList.Add("Ganga");
            _answersList.Add("Yamuna");
            _answersList.Add("Sutlej");
            _answersList.Add("Ravi");
            _answersList.Add("1877");
            _answersList.Add("1891");
            _answersList.Add("1897");
            _answersList.Add("1899");
            _answersList.Add("ILO");
            _answersList.Add("ASEAN");
            _answersList.Add("WHO");
            _answersList.Add("All of the above");
            return _answersList;
        }

        private List<string> GetQuestionsList()
        {
            _questionsList = new List<string>();
            _questionsList.Add("What is the capital of India?");
            _questionsList.Add("On which continent is the Sahara Desert located?");
            _questionsList.Add("Which of the following is a trans-Himalayan river?");
            _questionsList.Add("Kutch is the oldest museum in Gujarat, was establish in year?");
            _questionsList.Add("Which one of the following is not associated with UNO?");
            return _questionsList;
        }
    }

}
