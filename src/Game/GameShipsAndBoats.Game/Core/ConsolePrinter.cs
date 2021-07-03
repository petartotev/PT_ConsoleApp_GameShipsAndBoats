using System;

namespace GameShipsAndBoats.Game.Core
{
    public static class ConsolePrinter
    {
        public static void Print(string line)
        {
            Console.Write(line);
        }

        public static void Print(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(line);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void PrintLine(string line)
        {
            Console.WriteLine(line);
        }

        public static void PrintLine(string line, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
