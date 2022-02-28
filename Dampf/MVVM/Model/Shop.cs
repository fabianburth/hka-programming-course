using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;
using System.ComponentModel;
using System.Runtime.ExceptionServices;

namespace Dampf.MVVM.Model
{
    public class Shop : INotifyPropertyChanged
    {
        public ObservableCollection<Game> Games { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Library Library { get; set; }
        public ObservableCollection<double> RechargeCredits { get; set; }
        public User User { get; set; }

        public Shop()
        {
            Games = new ObservableCollection<Game>(Model.Games.games.Values);
            ShoppingCart = new ShoppingCart(new ObservableCollection<Game>(), 0);
            Library = new Library(new ObservableCollection<Game>());
            try
            {
                string userName = DampfApp.SetUserName().ToLower();
                string formattedUserName = DampfApp.FormatUserName(userName);
                User = new User(formattedUserName.Length == 0 ? userName : formattedUserName, 0.00);
            }
            catch (Exception e)
            {
                ExceptionHandler.DispatchException(ExceptionDispatchInfo.Capture(e));
            }
            RechargeCredits = new ObservableCollection<double> { 5, 10, 25, 50, 100 };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // Method is called for every click on a shopping cart
        public void AddGameToCart(string gameTitle)
        {
            Game game = Model.Games.games[gameTitle];
            try
            {
                game.ActualPrice = DampfApp.CalculateActualGamePrice(game.Price, game.IsDiscounted);
            }
            catch (Exception e)
            {
                ExceptionHandler.DispatchException(ExceptionDispatchInfo.Capture(e));
            }

            string[] newCart = null;
            try
            {
                newCart = DampfApp.AddGameToCart(GameCollectionToTitleStringArray(ShoppingCart.Games), game.Title);
            }
            catch (Exception e)
            {
                ExceptionHandler.DispatchException(ExceptionDispatchInfo.Capture(e));
            }

            if (newCart != null)
            {
                foreach (string g in newCart)
                {
                    if (!ShoppingCart.Games.Contains(Model.Games.games[g]))
                    {
                        ShoppingCart.Games.Add(Model.Games.games[gameTitle]);
                    }
                }
            }

            // Prepare for and actually call student implemented method
            double[] pricesOfGamesInCart = new double[ShoppingCart.Games.Count];
            for (int i = 0; i < pricesOfGamesInCart.Length; i++)
            {
                pricesOfGamesInCart[i] = ShoppingCart.Games[i].ActualPrice;
            }
            try
            {
                ShoppingCart.CartSum = DampfApp.CalculateCartPrice(pricesOfGamesInCart);
            }
            catch (Exception e)
            {
                ExceptionHandler.DispatchException(ExceptionDispatchInfo.Capture(e));
            }
        }

        // Method is called for every click on trash can
        public void RemoveGameFromCart(string gameTitle)
        {
            Game game = Model.Games.games[gameTitle];
            string[] newCart = null;
            try
            {
                newCart = DampfApp.RemoveGameFromCart(GameCollectionToTitleStringArray(ShoppingCart.Games), game.Title);
            }
            catch(Exception e)
            {
                ExceptionHandler.DispatchException(ExceptionDispatchInfo.Capture(e));
            }

            if (ShoppingCart.Games.Count != 0 && newCart != null)
            {
                try
                {
                    Collection<string> newCartCollection = new Collection<string>(newCart);
                    Collection<Game> gamesToRemove = new Collection<Game>();
                    foreach (Game g in ShoppingCart.Games)
                    {
                        if (!newCartCollection.Contains(g.Title))
                        {
                            gamesToRemove.Add(g);
                        }
                    }

                    foreach (Game g in gamesToRemove)
                    {
                        ShoppingCart.Games.Remove(g);
                    }

                    double[] pricesOfGamesInCart = new double[ShoppingCart.Games.Count];
                    for (int i = 0; i < pricesOfGamesInCart.Length; i++)
                    {
                        pricesOfGamesInCart[i] = ShoppingCart.Games[i].ActualPrice;
                    }
                    try
                    {
                        ShoppingCart.CartSum = DampfApp.CalculateCartPrice(pricesOfGamesInCart);
                    }
                    catch (Exception e)
                    {
                        ExceptionHandler.DispatchException(ExceptionDispatchInfo.Capture(e));
                    }

                    foreach (Game g in gamesToRemove)
                    {
                        g.ActualPrice = 0;
                    }
                }
                catch (KeyNotFoundException e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            }
        }
        public void BuyCart()
        {
            try
            {
                if (!DampfApp.IsAmountLeft(ShoppingCart.CartSum, User.Balance))
                {
                    MessageBox.Show("Du hast nicht genug Guthaben, um diese Transaktion durchzuführen. Klicke auf den Betrag in der Menüleiste, um dein Guthaben aufzuladen.");
                    return;
                }
                User.Balance = DampfApp.Pay(ShoppingCart.CartSum, User.Balance);
            }
            catch (Exception e)
            {
                ExceptionHandler.DispatchException(ExceptionDispatchInfo.Capture(e));
            }
            foreach (Game g in ShoppingCart.Games)
            {
                Library.Games.Add(g);
                Games.Remove(g);
            }
            Library.RefreshStatistics();
            ShoppingCart.Games.Clear();
            ShoppingCart.CartSum = 0;

        }
        public void RefundGame(string gameTitle)
        {
            try
            {
                Game game = Model.Games.games[gameTitle];
                User.Balance += game.ActualPrice;
                Games.Add(game);
                Library.Games.Remove(game);
                Library.RefreshStatistics();
            }
            catch (KeyNotFoundException e)
            {
                Console.Error.WriteLine(e.Message);
            }

        }

        public static string[] GameCollectionToTitleStringArray(ObservableCollection<Game> Games)
        {
            string[] GameTitles = new string[Games.Count];
            for (int i = 0; i < Games.Count; i++)
            {
                GameTitles[i] = Games[i].Title;
            }
            return GameTitles;
        }
    }
}
