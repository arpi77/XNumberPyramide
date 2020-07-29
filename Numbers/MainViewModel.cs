using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Numbers.Annotations;

namespace Numbers
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string _numbers = ".: some random numbers :.";
        int _count = 6;
        int _result = 0;
        private bool _resultVisibility;

        public string Numbers
        {
            get => _numbers;
            set 
            {
                _numbers = value;
                OnPropertyChanged(nameof(Numbers));
            }
        }

        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(CountText));
            }
        }

        public string CountText => Count.ToString();

        public int Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public bool ResultVisibility
        {
            get => _resultVisibility;
            set
            {
                _resultVisibility = value;
                OnPropertyChanged(nameof(ResultVisibility));
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
