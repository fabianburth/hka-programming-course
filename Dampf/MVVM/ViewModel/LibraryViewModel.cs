using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;

namespace Dampf.MVVM.ViewModel
{
    public class LibraryViewModel
    {
        public Shop Shop { get; set; }

        public RelayCommand RefundGameCommand { get; set; }

        public LibraryViewModel(Shop shop)
        {
            Shop = shop;
            RefundGameCommand = new RelayCommand(o => Shop.RefundGame((string)o));
        }
    }
}
