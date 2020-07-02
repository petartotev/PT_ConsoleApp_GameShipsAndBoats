using System;
using System.Data.SqlClient;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public class Program
    {
        static void Main(string[] args)
        {            
            GameConsole.SetConsoleProperties();

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
