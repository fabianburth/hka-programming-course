using System;
using System.Collections.ObjectModel;
using Dampf.Core;
using Dampf.MVVM.Model;


namespace Dampf.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand ShopViewCommand { get; set; }
        public RelayCommand LibraryViewCommand { get; set; }
        public RelayCommand BalanceViewCommand { get; set; }
        public ShopViewModel ShopViewModel { get; set; }
        public LibraryViewModel LibraryViewModel { get; set; }
        public BalanceViewModel BalanceViewModel { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Shop shop = new Shop();
            ShopViewModel = new ShopViewModel(shop);
            LibraryViewModel = new LibraryViewModel(shop);
            BalanceViewModel = new BalanceViewModel();
            CurrentView = ShopViewModel;

            ShopViewCommand = new RelayCommand(o =>
            {
                CurrentView = ShopViewModel;
            });

            LibraryViewCommand = new RelayCommand(o =>
            {
                CurrentView = LibraryViewModel;
            });

            BalanceViewCommand = new RelayCommand(o =>
            {
                CurrentView = BalanceViewModel;
            });
        }

    }
}
