using System;

namespace Dampf
{
    public class DampfApp
    {
        /// <summary>
        /// Diese Methode setzt den Benutzernamen.
        /// </summary>
        /// <returns>Benutzernamen des Benutzers</returns>
        public static string SetUserName()
        {
            return "Name";
        }

        /// <summary>
        /// In dieser Methode wird das Guthaben aufgeladen. Dazu muss das neu aufgeladene Guthaben zum bereits
        /// vorhandenen Guthaben des Benutzers addiert werden.
        /// </summary>
        /// <param name="oldBalance">Bereits vorhandenes Guthaben des Benutzers</param>
        /// <param name="amount">Neu aufgeladenes Guthaben</param>
        /// <returns>Neues Gesamtguthaben des Benutzers</returns>
        public static double AddToBalance(double oldBalance, double amount)
        {
            return oldBalance + amount;
        }

        /// <summary>
        /// In dieser Methode wird ein Spiel aus dem Laden dem Einkaufswagen hinzugefügt.
        /// Dazu soll an das Array gamesInCart ein Element "angehängt" werden, welches den
        /// Titel des Spiels (per gameAddedToCart übergeben) enthält.
        /// (Aufrufreihenfolge: CalculateActualGamePrice -> *AddGameToCart* -> CalculateCartPrice)
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

        /// <summary>
        /// Hier sollte der tatsächliche Preis des aktuell hinzugefügten Spiels berechnet werden. Diese
        /// Methode wird jedes mal aufgerufen, wenn ein Spiel zum Warenkorb hinzugefügt wird. 
        /// (Aufrufreihenfolge: *CalculateActualGamePrice* -> AddGameToCart -> CalculateCartPrice)
        /// 
        /// Der Spielpreis berechnet sich wie folgt:
        /// - Wenn das Spiel NICHT im Angebot ist, dann gilt einfach Grundpreis = tatsächlicher Preis.
        /// - Wenn das Spiel im Angebot ist, dann gilt:
        ///     - Spiele UNTER      20€         erhalten    10% Rabatt
        ///     - Spiele ZWISCHEN   20€ und 50€ erhalten    25% Rabatt ("ZWISCHEN" schließt hier also 20€ und 50€ mitein)
        ///     - Spiele ÜBER       50€         erhalten    50% Rabatt
        /// 
        /// Der so berechnete Preis soll dann zurückgegeben werden.
        /// </summary>
        /// <param name="addedGameBasePrice">Der Grundpreis des Spiels, der den Rabatt NICHT berücksichtigt.</param>
        /// <param name="discounted">Gibt an, ob es für dieses Spiel einen Rabatt gibt.</param>
        /// <returns>Die tatsächlichen Kosten des Spiels nach Abzug des Rabatts.</returns>
        public static double CalculateActualGamePrice(double addedGameBasePrice, bool discounted)
        {
            double actualGamePrice = addedGameBasePrice;
            if(discounted)
            {
                if(addedGameBasePrice < 20)
                {
                    actualGamePrice = addedGameBasePrice * 0.9;
                }
                else if(addedGameBasePrice <= 50)
                {
                    actualGamePrice = addedGameBasePrice * 0.75;
                }
                else if(addedGameBasePrice > 50)
                {
                    actualGamePrice = addedGameBasePrice * 0.5;
                }
            }
            return actualGamePrice;
        }

        /// <summary>
        /// Hier soll einfach nur die Summe aller Spiele im Einkaufswagen berechnet werden. Diese
        /// Methode wird jedes Mal aufgerufen, wenn ein Spiel zum Warenkorb hinzugefügt wird.
        /// (Aufrufreihenfolge: CalculateActualGamePrice -> AddGameToCart -> *CalculateCartPrice*)
        /// </summary>
        /// <param name="pricesOfGamesInCart">Ein Array mit den Preisen aller Spiele im Warenkorb</param>
        /// <returns>Die Summe der tatsächlichen Preise aller Spiele im Warenkorb</returns>
        public static double CalculateCartPrice(double[] pricesOfGamesInCart)
        {
            double cartSum = 0;
            for(int i = 0; i < pricesOfGamesInCart.Length; i++)
            {
                cartSum += pricesOfGamesInCart[i];
            }

            return cartSum;
        }

        /// <summary>
        /// Diese Methode wird beim Klicken auf den Kaufen Button aufgerufen, um zu überprüfen, ob
        /// der Benutzer genug Geld auf seinem Account hat, um die Spiele im Warenkorb zu bezahlen. Die
        /// Methode wird also direkt vor der Pay Methode aufgerufen.
        /// </summary>
        /// <param name="cartPrice">Summe der Preise der Spiele im Warenkorb</param>
        /// <param name="accountBalance">Guthaben des Benutzers</param>
        /// <returns>true, falls genug Guthaben vorhanden ist, false andernfalls</returns>
        public static bool IsAmountLeft(double cartPrice, double accountBalance)
        {
            return cartPrice <= accountBalance;
        }

        /// <summary>
        /// Diese Methode wird beim Klicken auf den Kaufen Button aufgerufen, um die Spiele im
        /// Warenkorb zu bezahlen, insofern die vorherige Prüfung mit "IsAmountLeft" erfolgreich war.
        /// </summary>
        /// <param name="cartPrice">Summe der Preise der Spiele im Warenkorb</param>
        /// <param name="accountBalance">Guthaben des Benutzers</param>
        /// <returns>Das Guthaben des Benutzers nach Abzug des Preises der Spiele im Warenkorb</returns>
        public static double Pay(double cartPrice, double accountBalance)
        {
            return accountBalance - cartPrice;
        }

        /// <summary>
        /// Standardmäßig werden die Spielzeiten in Sekunden (s) angezeigt. Das ist unschön und nur
        /// schwer greifbar. Diese Methode soll daher die Sekunden in x Tage, x Stunden, x Minuten
        /// und x Sekunden umrechnen. 
        /// Das zurückgegebene Array soll dann folgendermaßen aussehen:
        /// {Tage, Stunden, Minuten, Sekunden}
        /// </summary>
        /// <param name="seconds">Die Spielzeit in Sekunden.</param>
        /// <returns>Ein Array mit den Tagen, Stunden, Minuten und Sekunden Spielzeit</returns>
        public static int[] ConvertPlaytime(int seconds)
        {
            int s = seconds % 60;
            int TotalMinutes = seconds / 60;
            int m = TotalMinutes % 60;
            int TotalHours = TotalMinutes / 60;
            int h = TotalHours % 24;
            int d = TotalHours / 24;
            return new int[] {d,h,m,s};
        }

        /// <summary>
        /// Hier soll der Gesamtwert der Spiele in der Bibliothek berechnet werden (Man will ja wissen, wie viel Geld
        /// man schon so verschwendet hat ;) ).
        /// (Zur Berechnung des Gesamtwerts werden die Grundpreise, also die Preise vor Abzug des Rabatts, berücksichtigt.
        /// Das hat auf die Implementierung dieser Methode aber keinen Einfluss!)
        /// </summary>
        /// <param name="prices">Ein Array mit den Preisen aller Spiele in der Bibliothek</param>
        /// <returns>Der Gesamtwert der Bibliothek</returns>
        public static double CalculateTotalLibraryValue(double[] prices)
        {
            double total = 0;
            for(int i = 0; i < prices.Length; i++)
            {
                total += prices[i];
            }
            return total;
        }

        /// <summary>
        /// Hier soll die Gesamtzeit der Spiele in der Bibliothek berechnet werden (Man will ja wissen, wie viel Zeit
        /// man schon so verschwendet hat ;) ).
        /// (Hier werden nur die Spiele in der Bibliothek berücksichtigt. Die Spielzeit von zurückgegebenen Spielen
        /// geht in dieser Statistik verloren!
        /// Das hat auf die Implementierung dieser Methode aber keinen Einfluss!)
        /// </summary>
        /// <param name="playTimes">Ein Array mit den Spielzeiten aller Spiele in der Bibliothek</param>
        /// <returns>Die Gesamtspielzeit der Spiele in der Bibliothek</returns>
        public static int CalculateTotalLibraryPlayTime(int[] playTimes)
        {
            int total = 0;
            for(int i = 0; i < playTimes.Length; i++)
            {
                total += playTimes[i];
            }
            return total;
        }
    }
}
