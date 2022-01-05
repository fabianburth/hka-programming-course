using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;
using System.ComponentModel;

namespace Dampf.MVVM.Model
{
    public class Library : INotifyPropertyChanged
    {
        public ObservableCollection<Game> Games { get; set; }

        public Library(ObservableCollection<Game> libraryGames)
        {
            Games = libraryGames;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
