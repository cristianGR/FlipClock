using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using FlipClock.Modelo;

namespace FlipClock.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        Clock _flipClock;
        public MainViewModel()
        {
            _flipClock = new Clock(0, 0, 0, 0, 0, 0);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
