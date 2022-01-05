using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dampf.MVVM.Model
{
    public static class Games
    {
        public static Dictionary<string, Game> games;
        public static Random random = new Random();

        static Games()
        {
            games = GenerateGameData();
        }

        private static Dictionary<string,Game> GenerateGameData()
        {
            return new Dictionary<string, Game>
            {
                { "Ruf der Pflicht: Vorhut", new Game("Ruf der Pflicht: Vorhut", new Game.OSPlatform[] { Game.OSPlatform.Windows, Game.OSPlatform.Linux, Game.OSPlatform.Mac }, new string[] { "Shooter" }, false, 30.00) },
                { "Welt der Kriegskunst", new Game("Welt der Kriegskunst", new Game.OSPlatform[] { Game.OSPlatform.Windows, Game.OSPlatform.Linux, Game.OSPlatform.Mac }, new string[] { "MMORPG" }, true, 50.00) },
                { "Der Hexer 3: Wilde Jagd", new Game("Der Hexer 3: Wilde Jagd", new Game.OSPlatform[] { Game.OSPlatform.Windows, Game.OSPlatform.Linux, Game.OSPlatform.Mac }, new string[] { "RPG" }, true, 40.00) },
                { "Großartiger Autodiebstahl 5", new Game("Großartiger Autodiebstahl 5", new Game.OSPlatform[] { Game.OSPlatform.Windows, Game.OSPlatform.Linux, Game.OSPlatform.Mac }, new string[] { "Krimi", "Shooter" }, true, 50.00) },
                { "Landwirtschaftssimulator 22", new Game("Landwirtschaftssimulator 22", new Game.OSPlatform[] { Game.OSPlatform.Windows, Game.OSPlatform.Linux, Game.OSPlatform.Mac }, new string[] { "Simulation" }, true, 60.00) },
                { "Zeitalter der Imperien 4", new Game("Zeitalter der Imperien 4", new Game.OSPlatform[] { Game.OSPlatform.Windows, Game.OSPlatform.Linux, Game.OSPlatform.Mac }, new string[] { "Strategie" }, true, 50.00) },
                { "Hochburg Kreuzritter 2", new Game("Hochburg Kreuzritter 2", new Game.OSPlatform[] { Game.OSPlatform.Windows, Game.OSPlatform.Linux, Game.OSPlatform.Mac }, new string[] { "Strategie" }, true, 10.00) }
            };
        }
    }
}
