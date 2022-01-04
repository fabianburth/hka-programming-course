using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;

namespace Dampf.MVVM.ViewModel
{
    public class ShopViewModel
    {
        public Shop Shop { get; set; }
        public RelayCommand AddToCartCommand { get; set; }
        public RelayCommand RemoveFromCartCommand { get; set; }

        public ShopViewModel()
        {
            Shop = new Shop();
            AddToCartCommand = new RelayCommand(o => Shop.AddGameToCart((string)o));
            RemoveFromCartCommand = new RelayCommand(o => Shop.RemoveGameFromCart((string)o));
        }

    }
}
