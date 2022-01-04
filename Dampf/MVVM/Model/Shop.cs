using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using Dampf.Core;
using Dampf.MVVM.Model;

namespace Dampf.MVVM.Model
{
    public class Shop
    {
        public ObservableCollection<Game> Games { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public User User { get; set; }

        public Shop()
        {
            Games = new ObservableCollection<Game>(Model.Games.games.Values);
            ShoppingCart = new ShoppingCart(new ObservableCollection<Game>(), 0);
            User = new User("Spieler", "Passwort", 0.00);
        }

        public void AddGameToCart(string gameTitle)
        {
            try
            {
                Game game = Model.Games.games[gameTitle];
                string[] newCart = DampfApp.AddGameToCart(GameCollectionToTitleStringArray(ShoppingCart.Games), game.Title);
                foreach (string g in newCart)
                {
                    if (!ShoppingCart.Games.Contains(Model.Games.games[g]))
                    {
                        ShoppingCart.Games.Add(Model.Games.games[gameTitle]);
                    }
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

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
