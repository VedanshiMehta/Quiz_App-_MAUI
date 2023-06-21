using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1.ViewModel
{
    public class ResultViewModel : INotifyPropertyChanged
    {
        private ImageSource _source { get; set; }
        private string _resultStatus { get; set; }
        private string _points { get; set; }
        private string _name { get; set; }
       
        public ImageSource Source { get => _source; set { _source = value; OnPropertyChanged(); } }
        public string ResultStatus { get => _resultStatus; set { _resultStatus = value; OnPropertyChanged(); } }
        public string Points { get => _points; set { _points = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
