using System;
using System.Collections.Generic;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public static class GameConsole
    {        
        public static void SetConsoleProperties()
        {
            Console.Title = "Ships&BoatsGame";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetWindowSize(32, 50);
            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(32, 50);

            Console.CursorVisible = false;            
        }
    }
}
