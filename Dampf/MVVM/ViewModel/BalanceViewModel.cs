using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;

namespace Dampf.MVVM.ViewModel
{
    public class BalanceViewModel
    {
        public Shop Shop { get; set; }

        public RelayCommand RechargeBalanceCommand { get; set; }

        public BalanceViewModel(Shop shop)
        {
            Shop = shop;
            RechargeBalanceCommand = new RelayCommand(o => Shop.User.RechargeBalance((double)o));
        }
    }
}
