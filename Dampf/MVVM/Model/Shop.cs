using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;
using System.ComponentModel;

namespace Dampf.MVVM.Model
{
    public class Shop : INotifyPropertyChanged
    {
        public ObservableCollection<Game> Games { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Library Library { get; set; }
        public User User { get; set; }

        public Shop()
        {
            Games = new ObservableCollection<Game>(Model.Games.games.Values);
            ShoppingCart = new ShoppingCart(new ObservableCollection<Game>(), 0);
            Library = new Library(new ObservableCollection<Game>());
            User = new User("Spieler", "Passwort", 0.00);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        // Method is called for every click on a shopping cart
        public void AddGameToCart(string gameTitle)
        {
            try
            {
                Game game = Model.Games.games[gameTitle];

                // Call student implemented method
                game.ActualPrice = DampfApp.CalculateActualGamePrice(game.Price, game.IsDiscounted);

                // Call student implemented method
                string[] newCart = DampfApp.AddGameToCart(GameCollectionToTitleStringArray(ShoppingCart.Games), game.Title);

                foreach (string g in newCart)
                {
                    if (!ShoppingCart.Games.Contains(Model.Games.games[g]))
                    {
                        ShoppingCart.Games.Add(Model.Games.games[gameTitle]);
                    }
                }

                // Prepare for and actually call student implemented method
                double[] pricesOfGamesInCart = new double[ShoppingCart.Games.Count];
                for (int i = 0; i < pricesOfGamesInCart.Length; i++)
                {
                    pricesOfGamesInCart[i] = ShoppingCart.Games[i].ActualPrice;
                }
                ShoppingCart.CartSum = DampfApp.CalculateCartPrice(pricesOfGamesInCart);
            }
            catch (KeyNotFoundException e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        // Method is called for every click on trash can
        public void RemoveGameFromCart(string gameTitle)
        {
            try
            {
                Game game = Model.Games.games[gameTitle];
                string[] newCart = DampfApp.RemoveGameFromCart(GameCollectionToTitleStringArray(ShoppingCart.Games), game.Title);
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
                ShoppingCart.CartSum = DampfApp.CalculateCartPrice(pricesOfGamesInCart);

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
        public void BuyCart()
        {
            foreach(Game g in ShoppingCart.Games)
            {
                // In theory, you could also remove the games from shop here
                Library.Games.Add(g);
                this.Games.Remove(g);
            }
            ShoppingCart.Games.Clear();
            ShoppingCart.CartSum = 0;
            
        }
        public void RefundGame(string gameTitle)
        {

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
