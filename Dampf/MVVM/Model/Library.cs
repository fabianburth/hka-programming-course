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

        private double _totalWorth;
        private string _totalWorthValue;
        private int _totalPlayTime;
        private string _totalPlayTimeValue;

        public Library(ObservableCollection<Game> libraryGames)
        {
            Games = libraryGames;
            RefreshStatistics();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public double TotalWorth
        {
            get { return _totalWorth; }
            set 
            { 
                _totalWorth = value; 
                _totalWorthValue = TotalWorth.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " €";
                OnPropertyChanged("TotalWorth");
                OnPropertyChanged("TotalWorthValue");
            }
        }

        public string TotalWorthValue
        {
            get { return _totalWorthValue; }
        }

        public int TotalPlayTime
        {
            get { return _totalPlayTime; }
            set
            {
                _totalPlayTime = value;
                _totalPlayTimeValue = Game.FormatPlayTime(TotalPlayTime);
                OnPropertyChanged("TotalPlayTime");
                OnPropertyChanged("TotalPlayTimeValue");
            }
        }

        public string TotalPlayTimeValue
        {
            get { return _totalPlayTimeValue; }
        }

        public void RefreshStatistics()
        {
            double[] prices = new double[Games.Count];
            int[] playTimes = new int[Games.Count];
            for(int i = 0; i < Games.Count; i++)
            {
                prices[i] = Games[i].Price;
                playTimes[i] = Games[i].PlayTime;
            }
            TotalWorth = DampfApp.CalculateTotalLibraryValue(prices);
            TotalPlayTime = DampfApp.CalculateTotalLibraryPlayTime(playTimes);
        }


    }
}
