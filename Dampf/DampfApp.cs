using System;

namespace Dampf
{
    public class DampfApp
    {
        public static bool Login(string userName, string password)
        {
            return true;
        }
        //Guthaben aufladen
        public static double AddToBalance(double oldBalance, double amount)
        {
            return 0.0;
        }

        /// <summary>
        /// In dieser Methode wird ein Spiel aus dem Laden dem Einkaufswagen hinzugefügt.
        /// Dazu soll an das Array gamesInCart ein Element "angehängt" werden, welches den 
        /// Titel des Spiels (per gameAddedToCart übergeben) enthält.
        /// 
        /// Beispiel:
        ///     gamesInCart enthält die Werte: 
        ///     {"Ruf der Pflicht: Vorhut","Welt der Kriegskunst","Der Hexer 3: Wilde Jagd"}.
        ///     Man klickt nun im Shop bei "Zeitalter der Imperien 4" auf den Einkaufswagen. Nun soll ein neues Array angelegt
        ///     und zurückgegeben werden, das folgende Werte enthält:
        ///     {"Ruf der Pflicht: Vorhut","Welt der Kriegskunst","Der Hexer 3: Wilde Jagd","Zeitalter der Imperien 4"}
        ///     
        /// </summary>
        /// <param name="gamesInCart">Das Array mit allen sich bisher im Einkaufswagen befindenden Spielen.</param>
        /// <param name="gameAddedToCart">Das Spiel das dem Einkaufswagen hinzugefügt werden soll.</param>
        /// <returns>Ein Array, das zusätzlich das neue Spiel beinhaltet.</returns>
        public static string[] AddGameToCart(string[] gamesInCart, string gameAddedToCart)
        {
            string[] newCart = new string[gamesInCart.Length + 1];

            for(int i = 0; i< gamesInCart.Length; i++)
            {
                newCart[i] = gamesInCart[i];
            }

            newCart[gamesInCart.Length] = gameAddedToCart;

            return newCart;
        }

        /// <summary>
        /// In dieser Methode wird ein Spiel aus dem Einkaufswagen entfernt.
        /// Dazu soll aus dem Array gamesInCart ein Element "entfernt" werden, welches den 
        /// Titel des Spiels (per gameRemovedFromCart übergeben) enthält.
        /// 
        /// Beispiel:
        ///     gamesInCart enthält die Werte: 
        ///     {"Ruf der Pflicht: Vorhut","Welt der Kriegskunst","Der Hexer 3: Wilde Jagd","Zeitalter der Imperien 4"}
        ///     Man klickt nun im Shop bei "Zeitalter der Imperien 4" auf den Mülleimer. Nun soll ein neues Array angelegt
        ///     und zurückgegeben werden, das folgende Werte enthält:
        ///     {"Ruf der Pflicht: Vorhut","Welt der Kriegskunst","Der Hexer 3: Wilde Jagd"}.
        ///     
        ///     
        /// </summary>
        /// <param name="gamesInCart">Das Array mit allen sich bisher im Einkaufswagen befindenden Spielen.</param>
        /// <param name="gameRemovedFromCart">Das Spiel das aus dem Einkaufswagen entfernt werden soll.</param>
        /// <returns>Ein Array, das das entfernte Spiel nichtmehr beinhaltet</returns>
        public static string[] RemoveGameFromCart(string[] gamesInCart, string gameRemovedFromCart)
        {
            string[] newCart = new string[gamesInCart.Length - 1];

            int j = 0;
            for( int i = 0; i < gamesInCart.Length ;i++)
            {
                if(!(gamesInCart[i] == gameRemovedFromCart))
                {
                    newCart[j] = gamesInCart[i];
                    j++;
                }
            }

            return newCart;
        }
        // What exactly is this supposed to do? Do we really want to do this? How to display bundles?
        //string[] AddBundleToCart(string[] gamesInCart, string[] gamesAddedToCart);

        // Wenn ein Discount auf dem Spiel ist, dann könnte man ein Switch-Case/If-Statement machen,
        // und abhängig vom Preis des Spiels die Höhe des Discounts festlegen
        public static double CalculateCartPrice(double gamesInCartPrice, double addedGamePrice, bool discounted)
        {
            return 0.0;
        }

        // Return new account balance
        public static double Pay(double cartPrice, double accountBalance)
        {
            return 0.0;
        }

        // Automatically triggered after Pay 
        public static string[] AddGamesToLibrary(string[] gamesInLibrary, string[] newGames)
        {
            return null;
        }

        // Automatically triggered after Pay 
        // Remove from Store after added to library
        public static string[] RemoveGamesFromStore(string[] gamesInStore, string[] newGames)
        {
            return null;
        }

        //Convert hours to Days/Hours/Minutes/Seconds
        public static int[] ConvertPlaytime(int seconds)
        {
            return null;
        }

        public static string[] OrderGamesInShopByPrice(string[] gamesInShop, bool ascending)
        {
            return null;
        }

        public static int CalculateTotalLibraryValue(double[] prices)
        {
            return 0;
        }

        //Optionally for pros - one line is [dd|hh|mm|ss], one line for each game (two dimensional array)
        public static int[] CalculateTotalLibraryPlaytime(int[][] playTime)
        {
            return null;
        }
    }
}
