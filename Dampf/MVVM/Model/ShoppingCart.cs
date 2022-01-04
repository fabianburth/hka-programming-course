using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;

namespace Dampf.MVVM.Model
{
    public class ShoppingCart
    {
        public ObservableCollection<Game> Games { get; set; }
        private double _cartSum;

        public double CartSum
        {
            get { return _cartSum; }
            set { _cartSum = value; }
        }

        public ShoppingCart(ObservableCollection<Game> cartGames, double cartSum)
        {
            Games = cartGames;
            CartSum = cartSum;
        }

        public string CartSumValue { get => CartSum.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + " €"; }
    }
}
