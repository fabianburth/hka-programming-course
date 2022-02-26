using System;

namespace Dampf
{
    public class DampfApp
    {
        public static bool Login(string userName, string password)
        {
            return true;
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

          // TODO

            return new string[];
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
          // TODO

          return new string[];
        }
        // What exactly is this supposed to do? Do we really want to do this? How to display bundles?
        //string[] AddBundleToCart(string[] gamesInCart, string[] gamesAddedToCart);

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

            // TODO

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

            // TODO

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

          // TODO

          return false
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

            // TODO

            return 0
        }

        // Ich würde sagen, wir lassen die Methode einfach weg, da es genau die gleiche Aufgabe wäre,
        // wie AddGameToCart.
        // (Alternativ könnte man auch AddGameToCart weglassen, aber dann würden fast alle Methoden
        // "hinter" dem Kaufen-Button hängen, was vielleicht nicht ganz so schön ist. So haben sie
        // das Gefühl, dass sie sowohl das Hinzufügen zum Warenkorb durch die AddGameToCart-Methode, als
        // auch das Kaufen durch die IsAmountLeft- und Pay-Methoden implementieren.
        //public static string[] AddGamesToLibrary(string[] gamesInLibrary, string[] newGames)
        //{
        //    return null;
        //}
        // Analoge Begründung zu AddGamesToLibrary
        //public static string[] RemoveGamesFromStore(string[] gamesInStore, string[] newGames)
        //{
        //    return null;
        //}

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

            // TODO
            return new int[] {};
        }

        // Sollen wir das wirklich machen?
        // Hatte hier keinen speziellen Grund das wegzulassen, außer dass es etwas aufwändiger umzusetzen ist
        // und wir wahrscheinlich schon genug Methoden haben.
        // Sortieraufgaben sind algorithmisch zudem schon relativ anspruchsvoll, vielleicht aber gerade deshalb eine nette Aufgabe
        // Können wir gerne nochmal diskutieren
        //public static string[] OrderGamesInShopByPrice(string[] gamesInShop, bool ascending)
        //{
        //    return null;
        //}

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

            // TODO

            return total;
        }

        // Die hier habe ich noch hinzugefügt, da ich das Gefühl hatte, dass ich mich als Student sonst
        // Fragen würde, warum ich den Total Value berechnen musste, nicht aber die Total Playtime.
        // Zudem ist das ja dann quasi nur noch Copy-Pase und damit ein schnelles und fast kostenloses
        // Erfolgsgefühl :)
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

            // TODO

            return total;
        }



        // Optionally for pros - one line is [dd|hh|mm|ss], one line for each game (two dimensional array)
        // Können wir so machen, damit 2-dimensionale Arrays dabei sind, ist aber etwas künstlich hier
        // das 2-dimensionale Array reinzugeben, anstatt einfach die Sekunden
        // Da sie wahrscheinlich aber keine 2-dimensionalen Arrays kennen, sollten wir das mit den 
        // Fachschaftlern absprechen, tendentiell würde ich das eher durch die aktuelle "CalculateTotalLibraryPlayTime"
        // ersetzen
        //public static int[] CalculateTotalLibraryPlaytime(int[][] playTime)
        //{
        //    return null;
        //}
    }
}
