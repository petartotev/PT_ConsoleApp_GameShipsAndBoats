using System;
using System.Collections.Generic;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public static class GameConsole
    {        
        public static void SetMainProperties()
        {
            Console.Title = "PT_ShipsAndBoatsGame";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetWindowSize(33, 50);
        }
    }
}
