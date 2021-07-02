using System;

namespace GameShipsAndBoats.Game.Core
{
    public static class ConsoleManager
    {
        public static void SetDefaultSettings()
        {
            Console.Title = "Ships&BoatsGame";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetWindowSize(33, 50);
            Console.SetWindowPosition(0, 0);
            Console.SetBufferSize(33, 50);

            Console.CursorVisible = false;
        }
    }
}
