using Assesment1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assesment1.ViewModel
{
    public class WelcomeViewModel : INotifyPropertyChanged
    {
        
        private WelcomeNameModel _welcomeName;
        public WelcomeNameModel WelcomeName { get=> _welcomeName; set { _welcomeName = value; OnPropertyChanged(); } }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
