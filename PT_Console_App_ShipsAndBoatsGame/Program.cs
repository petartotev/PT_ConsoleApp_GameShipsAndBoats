using System;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameConsole.SetMainProperties();

            while (true)
            {
                GameScenario.PlayIntro();

                switch (GameScenario.GetMenuCommand())
                {
                    case "PLAY":
                        GameScenario.PlayGame();
                        break;
                    case "INSTRUCTIONS":
                        GameScenario.ShowInstructions();                        
                        break;
                    case "STATISTICS":
                        GameScenario.ShowStatistics();
                        break;
                    case "EXIT":
                        Environment.Exit(0);
                        break;
                }
            }
        }

    }
}
