using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;
using System.ComponentModel;

namespace Dampf.MVVM.Model
{
    public class ShoppingCart : INotifyPropertyChanged
    {
        public ObservableCollection<Game> Games { get; set; }
        private double _cartSum;
        private string _cartSumValue;

        public ShoppingCart(ObservableCollection<Game> cartGames, double cartSum)
        {
            Games = cartGames;
            _cartSum = cartSum;
            _cartSumValue = CartSum.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " €";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public double CartSum
        {
            get { return _cartSum; }
            set
            {
                _cartSum = value;
                _cartSumValue = CartSum.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " €";
                OnPropertyChanged("CartSum");
                OnPropertyChanged("CartSumValue");
            }
        }

        public string CartSumValue 
        { 
            get { return _cartSumValue; }
        }

    }
}
