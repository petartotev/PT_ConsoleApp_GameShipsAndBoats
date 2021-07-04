using GameShipsAndBoats.Game.Models;
using GameShipsAndBoats.Game.Models.Common;
using GameShipsAndBoats.Game.Models.Contracts;
using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading;

namespace GameShipsAndBoats.Game.Core
{
    public static class GameEngine
    {
        public static string GetMenuCommand()
        {
            while (true)
            {
                ConsolePrinter.Print($"   Press key: ");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        return "EXIT";
                    case ConsoleKey.Spacebar:
                        return "PLAY";
                    case ConsoleKey.I:
                        return "INSTRUCTIONS";
                    case ConsoleKey.S:
                        return "STATISTICS";
                    default:
                        ConsolePrinter.PrintLine(GameElements.ErrorMessages.InvalidInput, ConsoleColor.Red);
                        break;
                }
            }
        }

        public static void ShowInstructions()
        {
            Console.Clear();

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine(GameElements.Title);
            ConsolePrinter.PrintLine(GameElements.LineSolid);

            Battlefield instructionsBattlefield = BattlefieldGenerator.GenerateNewBattlefield();

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine($"   Instructions:");

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine(instructionsBattlefield.ToString());

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine(GameElements.Legend);

            Thread.Sleep(3000);
            ConsolePrinter.PrintLine("  Both opponents should place");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  - 1 tanker (TTTT),");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  - 2 submarines (SSS),");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  - 3 carriers (CC),");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  - 4 boats (B) on their field.");
            Thread.Sleep(1500);
            ConsolePrinter.PrintLine("\r\n  The 4 boats (B) can be placed ");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  anywhere.");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  The other vessels should be");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  placed in such a way that");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  0 or 1 of its modules lay on");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  the sides/edges of the field.");
            Thread.Sleep(5000);

            Console.Clear();

            ConsolePrinter.PrintLine(GameElements.Title);
            ConsolePrinter.PrintLine(GameElements.LineSolid);

            ConsolePrinter.PrintLine($"   Instructions:");
            ConsolePrinter.PrintLine($"   ╔═══╦═════════════════════╗");
            ConsolePrinter.PrintLine($"   ║   ║ A B C D E F G H I J ║");
            ConsolePrinter.PrintLine($"   ╠═══╬═════════════════════╣");

            for (int row = 0; row < 10; row++)
            {
                ConsolePrinter.Print($"   ║ {row} ║ ");

                for (int col = 0; col < 10; col++)
                {
                    if ((row == 2 && col == 0) || (row == 2 && col == 1) || (row == 2 && col == 2) || (row == 2 && col == 3)) // DRAW CORRECT TANKER (TTTT)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotTanker, ConsoleColor.Green);
                    }
                    else if ((row == 0 && col == 9)) // DRAW CORRECT BOAT (B)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotBoat, ConsoleColor.Green);
                    }
                    else if ((row == 9 && col == 5) || (row == 9 && col == 6) || (row == 9 && col == 7)) // DRAW INCORRECT SUBMARINE (SSS)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotSubmarine, ConsoleColor.Red);
                    }
                    else if ((row == 8 && col == 0) || (row == 9 && col == 0)) // DRAW INCORRECT CARRIER (CC)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotCarrier, ConsoleColor.Red);
                    }
                    else // DRAW EMPTY SLOT
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotEmpty);
                    }
                }
                ConsolePrinter.Print("║\r\n");
            }
            ConsolePrinter.PrintLine($"   ╚═══╩═════════════════════╝");

            ConsolePrinter.PrintLine(GameElements.Legend);

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine($"\r\n   CORRECT.", ConsoleColor.Green);

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine($"\r\n   NOT CORRECT!!!", ConsoleColor.Red);

            Thread.Sleep(5000);

            ConsolePrinter.PrintLine(GameElements.PressAnyKey);
            Console.ReadKey();

            Console.Clear();

            ConsolePrinter.PrintLine(GameElements.Title);
            ConsolePrinter.PrintLine(GameElements.LineSolid);

            ConsolePrinter.PrintLine($"   Instructions:");

            ConsolePrinter.PrintLine(instructionsBattlefield.ToString());

            ConsolePrinter.PrintLine(GameElements.Legend);

            Thread.Sleep(3000);
            ConsolePrinter.PrintLine("  There should be at least 1 ");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  empty slot between 2 vessels ");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  placed on the field.");
            Thread.Sleep(1500);
            ConsolePrinter.PrintLine("\r\n  In other words, 2 vessels ");
            Thread.Sleep(750);
            ConsolePrinter.PrintLine("  cannot \"touch\".");
            Thread.Sleep(5000);

            Console.Clear();

            ConsolePrinter.PrintLine(GameElements.Title);
            ConsolePrinter.PrintLine(GameElements.LineSolid);

            ConsolePrinter.PrintLine($"   Instructions:");
            ConsolePrinter.PrintLine($"   ╔═══╦═════════════════════╗");
            ConsolePrinter.PrintLine($"   ║   ║ A B C D E F G H I J ║");
            ConsolePrinter.PrintLine($"   ╠═══╬═════════════════════╣");

            for (int row = 0; row < 10; row++)
            {
                ConsolePrinter.Print($"   ║ {row} ║ ");

                for (int col = 0; col < 10; col++)
                {
                    if ((row == 2 && col == 3) || (row == 2 && col == 4) || (row == 2 && col == 5) || (row == 2 && col == 6)) // DRAW INCORRECT TANKER (TTTT)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotTanker, ConsoleColor.Red);
                    }
                    else if ((row == 4 && col == 1) || (row == 4 && col == 2) || (row == 4 && col == 3)) // DRAW CORRECT SUBMARINE (SSS)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotSubmarine, ConsoleColor.Green);
                    }
                    else if ((row == 3 && col == 7) || (row == 4 && col == 7) || (row == 5 && col == 7)) // DRAW INCORRECT SUBMARINE (SSS)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotSubmarine, ConsoleColor.Red);
                    }
                    else if ((row == 2 && col == 1)) // DRAW CORRECT BOAT (B)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotBoat, ConsoleColor.Green);
                    }
                    else if ((row == 9 && col == 2)) // DRAW INCORRECT BOAT (B)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotBoat, ConsoleColor.Red);
                    }
                    else if ((row == 8 && col == 3) || (row == 9 && col == 3)) // DRAW INCORRECT CARRIER (CC)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotCarrier, ConsoleColor.Red);
                    }
                    else if ((row == 6 && col == 1) || (row == 7 && col == 1)) // DRAW CORRECT CARRIER (CC)
                    {
                        ConsolePrinter.Print(BattlefieldElements.slotCarrier, ConsoleColor.Green);
                    }
                    else // DRAW EMPTY SLOT
                    {
                        ConsolePrinter.Print("  ");
                    }
                }
                ConsolePrinter.Print("║\r\n");
            }
            ConsolePrinter.PrintLine($"   ╚═══╩═════════════════════╝");

            ConsolePrinter.PrintLine(GameElements.Legend);

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine($"\r\n   CORRECT.\r\n", ConsoleColor.Green);

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine($"   NOT CORRECT!!!", ConsoleColor.Red);

            Thread.Sleep(5000);

            ConsolePrinter.PrintLine(GameElements.PressAnyKey);
            Console.ReadKey();

            Console.Clear();
        }

        public static void ShowStatistics()
        {
            Console.Clear();

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine(GameElements.Title);
            ConsolePrinter.PrintLine(GameElements.LineSolid);

            Thread.Sleep(1000);

            try
            {
                string[] gamesWonAndLost = GetStatistics();
                ConsolePrinter.PrintLine(string.Format(GameElements.Statistics, gamesWonAndLost[0], gamesWonAndLost[1]));
            }
            catch (Exception ex)
            {
                ConsolePrinter.PrintLine(ex.Message);
            }
            finally
            {
                Thread.Sleep(3000);
                ConsolePrinter.PrintLine(GameElements.PressAnyKey);
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void PlayIntro()
        {
            Thread.Sleep(1000);
            ConsolePrinter.PrintLine(GameElements.Title);
            ConsolePrinter.PrintLine(GameElements.LineSolid);

            Thread.Sleep(1000);
            ConsolePrinter.PrintLine(GameElements.Menu);

            Thread.Sleep(1000);
        }

        public static void PlayGame()
        {
            var stage = 1;
            var player = new Player();
            var opponent = new Opponent();

            bool isOpponentViewEnabled = GetUserInputIsOpponentViewEnabled();

            while (true)
            {
                while (true)
                {
                    PrintGameplayUI(player, opponent, stage, isOpponentViewEnabled);

                    Random random = new Random();

                    int randomRow;
                    int randomCol;

                    while (true)
                    {
                        randomRow = random.Next(0, 10);
                        randomCol = random.Next(0, 10);

                        if (opponent.EnemyBattlefield.Field[randomRow, randomCol] == BattlefieldElements.slotHidden)
                        {
                            break;
                        }
                    }

                    string slotResultPlayerAttacked = player.GetAttacked(randomRow, randomCol);

                    opponent.Attack(randomRow, randomCol, slotResultPlayerAttacked);

                    ConsolePrinter.PrintLine($" Opponent" + opponent.GetAttackedMessage(slotResultPlayerAttacked));
                    Thread.Sleep(1000);

                    if (opponent.CheckIfWinner() || !BattlefieldElements.listSlotsVessels.Contains(slotResultPlayerAttacked))
                    {
                        break;
                    }

                    if (BattlefieldValidator.CheckIfSlotIsOnEdge(randomRow, randomCol))
                    {
                        player.MarkShipOnEdgeAsDestroyed(randomRow, randomCol, slotResultPlayerAttacked);
                    }
                } // OPPONENT ATTACKS, PLAYER GETS ATTACKED

                if (opponent.CheckIfWinner())
                {
                    break;
                } //GAME ENDS - YOU LOSE

                while (true)
                {
                    PrintGameplayUI(player, opponent, stage, isOpponentViewEnabled);

                    int row = -1;
                    int col = -1;

                    while (true)
                    {
                        ConsolePrinter.Print($" Attack (i.e. A0/a0): ");
                        string command = Console.ReadLine();

                        if (Regex.IsMatch(command, @"^[A-Ja-j]{1}[0-9]{1}\b"))
                        {
                            char colChar = command[0];
                            char rowChar = command[1];

                            col = colChar >= 'A' && colChar <= 'J' ? colChar - 'A' : colChar - 'a';
                            row = rowChar - '0';

                            break;
                        }

                        ConsolePrinter.PrintLine(GameElements.ErrorMessages.InvalidInput, ConsoleColor.Red);
                    } // GET CORRECT INPUT

                    string slotResultOpponentAttacked = opponent.GetAttacked(row, col);

                    player.Attack(row, col, slotResultOpponentAttacked);

                    ConsolePrinter.PrintLine($" You" + player.GetAttackedMessage(slotResultOpponentAttacked));
                    Thread.Sleep(1000);

                    if (player.CheckIfWinner() || !BattlefieldElements.listSlotsVessels.Contains(slotResultOpponentAttacked))
                    {
                        break;
                    }
                } // PLAYER ATTACKS, OPPONENT GETS ATTACKED

                if (player.CheckIfWinner())
                {
                    break;
                } //GAME ENDS - YOU WIN

                stage++; // END OF STAGE
            }

            PrintGameplayUI(player, opponent, stage, isOpponentViewEnabled);

            bool isWinner = false;

            if (player.CheckIfWinner())
            {
                ConsolePrinter.PrintLine("\r\n   ~CONGRATULATIONS! YOU WON!~", ConsoleColor.Green);
                isWinner = true;
            }
            else if (opponent.CheckIfWinner())
            {
                ConsolePrinter.PrintLine("\r\n   ~CONDOLENCES... YOU LOST!~", ConsoleColor.Red);
            }

            ConsolePrinter.PrintLine($"\r\n   The game took {stage} stages.");

            try
            {
                UpdateDatabaseStatistics(isWinner);
            }
            catch (Exception ex)
            {
                Console.Clear();
                ConsolePrinter.PrintLine(GameElements.Title);
                ConsolePrinter.PrintLine(GameElements.LineSolid);
                Thread.Sleep(1000);
                ConsolePrinter.PrintLine(ex.Message);
            }
            finally
            {
                Thread.Sleep(3000);
                ConsolePrinter.PrintLine(GameElements.PressAnyKey);
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static bool GetUserInputIsOpponentViewEnabled()
        {
            while (true)
            {
                Console.Clear();
                ConsolePrinter.PrintLine(GameElements.Title);
                ConsolePrinter.PrintLine(GameElements.LineSolid);
                ConsolePrinter.PrintLine("  Do you want to see what the");
                ConsolePrinter.Print("  Opponent sees (Y/N): ");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Y:
                        return true;
                    case ConsoleKey.N:
                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:
                        return false;
                    default:
                        ConsolePrinter.PrintLine(GameElements.ErrorMessages.InvalidInput, ConsoleColor.Red);
                        break;
                }
            }
        }

        private static string[] GetStatistics()
        {
            int gamesWon = 0;
            int gamesLost = 0;

            var connection = new SqlConnection("Server=localhost;Database=ShipsAndBoatsGame;Integrated Security=True;");

            connection.Open();

            using (connection)
            {
                var commandGetWonResult = new SqlCommand("SELECT Won FROM Statisticsss WHERE ID=1", connection);
                var resultWon = commandGetWonResult.ExecuteScalar();
                gamesWon = (int)resultWon;

                var commandGetLostResult = new SqlCommand("SELECT Lost FROM Statisticsss WHERE ID=1", connection);
                var resultLost = commandGetLostResult.ExecuteScalar();
                gamesLost = (int)resultLost;
            }

            return new string[] { gamesWon.ToString("D4"), gamesLost.ToString("D4") };
        }

        private static void UpdateDatabaseStatistics(bool isWinner)
        {
            var connection = new SqlConnection("Server=localhost;Database=ShipsAndBoatsGame;Integrated Security=True;");

            connection.Open();
            using (connection)
            {
                var commandGetWon = new SqlCommand("SELECT [Won] FROM Statisticsss", connection);
                var resultWon = commandGetWon.ExecuteScalar();

                var commandGetLost = new SqlCommand("SELECT [Lost] FROM Statisticsss", connection);
                var resultLost = commandGetLost.ExecuteScalar();

                if (isWinner)
                {
                    int resultWonUpdated = (int)resultWon + 1;
                    var commandUpdateWon = new SqlCommand($"UPDATE Statisticsss SET Won = {resultWonUpdated}, Lost = {(int)resultLost} WHERE Id=1", connection);
                    commandUpdateWon.ExecuteScalar();
                }
                else
                {
                    var resultLostUpdated = (int)resultLost + 1;
                    var commandUpdateLost = new SqlCommand($"UPDATE Statisticsss SET Won = {(int)resultWon}, Lost = {resultLostUpdated} WHERE Id=1", connection);
                    commandUpdateLost.ExecuteScalar();
                }
            }
        }

        private static void PrintGameplayUI(IPlayer player, IPlayer opponent, int stage, bool isOpponentViewEnabled = false)
        {
            Console.Clear();
            ConsolePrinter.PrintLine(GameElements.Title);
            ConsolePrinter.PrintLine(GameElements.LineSolid);
            ConsolePrinter.PrintLine($"   Opponent:");
            ConsolePrinter.PrintLine(player.EnemyBattlefield.ToString());
            ConsolePrinter.PrintLine($"   You:");
            ConsolePrinter.PrintLine(player.PlayerBattlefield.ToString());

            if (isOpponentViewEnabled)
            {
                ConsolePrinter.PrintLine($"   Opponent sees:");
                ConsolePrinter.PrintLine(opponent.EnemyBattlefield.ToString());
            }

            ConsolePrinter.PrintLine(GameElements.Legend);
            ConsolePrinter.PrintLine(GameElements.LineSolid);
            ConsolePrinter.PrintLine(GameElements.Credits);
            ConsolePrinter.PrintLine($"\r\n Stage {stage}");
        }
    }
}
