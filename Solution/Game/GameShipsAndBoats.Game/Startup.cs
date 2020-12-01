using GameShipsAndBoats.Game.Core;
using System;

namespace GameShipsAndBoats.Game
{
    public class Startup
    {
        static void Main(string[] args)
        {
            ConsoleManager.SetConsoleProperties();

            while (true)
            {
                GameEngine.PlayIntro();

                switch (GameEngine.GetMenuCommand())
                {
                    case "PLAY":
                        GameEngine.PlayGame();
                        break;
                    case "INSTRUCTIONS":
                        GameEngine.ShowInstructions();
                        break;
                    case "STATISTICS":
                        GameEngine.ShowStatistics();
                        break;
                    case "EXIT":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
