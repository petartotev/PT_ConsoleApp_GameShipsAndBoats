using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public class GameScenario
    {
        private static void PrintGameplayUI(Player player, int stage)
        {
            Console.Clear();

            Console.WriteLine(GameElements.GetTitle());
            Console.WriteLine(GameElements.GetLineSolid());

            Console.WriteLine($"   Opponent:");
            Console.WriteLine(player.OpponentBattlefield.Print());

            Console.WriteLine($"   You:");
            Console.WriteLine(player.PlayerBattlefield.Print());

            Console.WriteLine(GameElements.GetLegend());
            Console.WriteLine(GameElements.GetLineSolid());
            Console.WriteLine(GameElements.GetCredits());

            Console.WriteLine($"\n Stage {stage}");
        }
                
        public static void PlayIntro()
        {
            Thread.Sleep(1000);
            Console.WriteLine(GameElements.GetTitle());
            Console.WriteLine(GameElements.GetLineSolid());

            Thread.Sleep(1000);
            Console.WriteLine(GameElements.GetMenu());

            Thread.Sleep(1000);
        }

        public static string GetMenuCommand()
        {
            bool isTrue = true;

            while (isTrue)
            {
                Console.Write($"   Press key: ");

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
                        Console.WriteLine(GameElements.GetInvalidMessage());
                        break;
                }
            }
            return null;
        }

        public static void ShowInstructions()
        {
            Console.Clear();

            Thread.Sleep(1000);
            Console.WriteLine(GameElements.GetTitle());
            Console.WriteLine(GameElements.GetLineSolid());

            Battlefield instructionsBattlefield = new Battlefield();
            instructionsBattlefield.SetRandomBattlefield();

            Thread.Sleep(1000);
            Console.WriteLine($"   Instructions:");

            Thread.Sleep(1000);
            Console.WriteLine(instructionsBattlefield.PrintEmpty());

            Thread.Sleep(1000);
            Console.WriteLine(GameElements.GetLegend());

            Thread.Sleep(3000);
            Console.WriteLine("  Both opponents should place");
            Thread.Sleep(750);
            Console.WriteLine("  - 1 tanker (TTTT),");
            Thread.Sleep(750);
            Console.WriteLine("  - 2 submarines (SSS),");
            Thread.Sleep(750);
            Console.WriteLine("  - 3 carriers (CC),");
            Thread.Sleep(750);
            Console.WriteLine("  - 4 boats (B) on their field.");
            Thread.Sleep(1500);
            Console.WriteLine("\n  The 4 boats (B) can be placed ");
            Thread.Sleep(750);
            Console.WriteLine("  anywhere.");
            Thread.Sleep(750);
            Console.WriteLine("  The other vessels should be");
            Thread.Sleep(750);
            Console.WriteLine("  placed in such a way that");
            Thread.Sleep(750);
            Console.WriteLine("  0 or 1 of its modules lay on");
            Thread.Sleep(750);
            Console.WriteLine("  the sides/edges of the field.");
            Thread.Sleep(5000);


            Console.Clear();

            Console.WriteLine(GameElements.GetTitle());
            Console.WriteLine(GameElements.GetLineSolid());

            Console.WriteLine($"   Instructions:");
            Console.WriteLine($"   ╔═══╦═════════════════════╗");
            Console.WriteLine($"   ║   ║ A B C D E F G H I J ║");
            Console.WriteLine($"   ╠═══╬═════════════════════╣");

            for (int row = 0; row < 10; row++)
            {
                Console.Write($"   ║ {row} ║ ");

                for (int col = 0; col < 10; col++)
                {
                    if ((row == 2 && col == 0) || (row == 2 && col == 1) || (row == 2 && col == 2) || (row == 2 && col == 3)) // DRAW CORRECT TANKER (TTTT)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("T ");
                    }
                    else if ((row == 0 && col == 9)) // DRAW CORRECT BOAT (B)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("B ");
                    }
                    else if ((row == 9 && col == 5) || (row == 9 && col == 6) || ( row == 9 && col == 7)) // DRAW INCORRECT SUBMARINE (SSS)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("S ");
                    }                    
                    else if ((row == 8 && col == 0) || (row == 9 && col == 0)) // DRAW INCORRECT CARRIER (CC)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("C ");
                        
                    }
                    else // DRAW EMPTY SLOT
                    {
                        Console.Write("  ");
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Write("║\n");
            }
            Console.WriteLine($"   ╚═══╩═════════════════════╝");

            Console.WriteLine(GameElements.GetLegend());

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n   CORRECT.");

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n   NOT CORRECT!!!");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Thread.Sleep(5000);

            Console.WriteLine(GameElements.GetPressKeyMessage());
            Console.ReadKey();


            Console.Clear();

            Console.WriteLine(GameElements.GetTitle());
            Console.WriteLine(GameElements.GetLineSolid());

            Console.WriteLine($"   Instructions:");

            Console.WriteLine(instructionsBattlefield.PrintEmpty());

            Console.WriteLine(GameElements.GetLegend());

            Thread.Sleep(3000);
            Console.WriteLine("  There should be at least 1 ");
            Thread.Sleep(750);
            Console.WriteLine("  empty slot between 2 vessels ");
            Thread.Sleep(750);
            Console.WriteLine("  placed on the field.");
            Thread.Sleep(1500);
            Console.WriteLine("\n  In other words, 2 vessels ");
            Thread.Sleep(750);
            Console.WriteLine("  cannot \"touch\".");
            Thread.Sleep(5000);


            Console.Clear();

            Console.WriteLine(GameElements.GetTitle());
            Console.WriteLine(GameElements.GetLineSolid());

            Console.WriteLine($"   Instructions:");
            Console.WriteLine($"   ╔═══╦═════════════════════╗");
            Console.WriteLine($"   ║   ║ A B C D E F G H I J ║");
            Console.WriteLine($"   ╠═══╬═════════════════════╣");

            for (int row = 0; row < 10; row++)
            {
                Console.Write($"   ║ {row} ║ ");

                for (int col = 0; col < 10; col++)
                {
                    if ((row == 2 && col == 3) || (row == 2 && col == 4) || (row == 2 && col == 5) || (row == 2 && col == 6)) // DRAW INCORRECT TANKER (TTTT)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("K ");                        
                    }
                    else if ((row == 4 && col == 1) || (row == 4 && col == 2) || (row == 4 && col == 3)) // DRAW CORRECT SUBMARINE (SSS)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("S ");
                    }
                    else if ((row == 3 && col == 7) || (row == 4 && col == 7) || (row == 5 && col == 7)) // DRAW INCORRECT SUBMARINE (SSS)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("S ");
                    }
                    else if ((row == 2 && col == 1)) // DRAW CORRECT BOAT (B)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("B ");
                    }
                    else if ((row == 9 && col == 2)) // DRAW INCORRECT BOAT (B)
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                        Console.Write("B ");
                    }
                    else if ((row == 8 && col == 3) || (row == 9 && col == 3)) // DRAW INCORRECT CARRIER (CC)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("C ");
                    }
                    else if ((row == 6 && col == 1) || (row == 7 && col == 1)) // DRAW CORRECT CARRIER (CC)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("C ");
                    }
                    else // DRAW EMPTY SLOT
                    {
                        Console.Write("  ");
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                Console.Write("║\n");
            }
            Console.WriteLine($"   ╚═══╩═════════════════════╝");

            Console.WriteLine(GameElements.GetLegend());

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n   CORRECT.\n");            

            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"   NOT CORRECT!!!");

            Console.ForegroundColor = ConsoleColor.Cyan;

            Thread.Sleep(5000);

            Console.WriteLine(GameElements.GetPressKeyMessage());
            Console.ReadKey();


            Console.Clear();
        }

        public static void ShowStatistics()
        {
            Console.Clear();

            Thread.Sleep(1000);
            Console.WriteLine(GameElements.GetTitle());
            Console.WriteLine(GameElements.GetLineSolid());

            Thread.Sleep(1000);
            Console.WriteLine(GameElements.GetStatistics());

            Thread.Sleep(3000);

            Console.WriteLine(GameElements.GetPressKeyMessage());
            Console.ReadKey();

            Console.Clear();
        }            

        public static void PlayGame()
        {
            int stage = 1;

            Player player = new Player();
            Player opponent = new Player();

            while (true)
            {     
                while (true)
                {
                    PrintGameplayUI(player, stage);                                        

                    Random myRandom = new Random();

                    int rowRandom;
                    int colRandom;

                    while (true)
                    {
                        rowRandom = myRandom.Next(0, 10);
                        colRandom = myRandom.Next(0, 10);

                        if (opponent.OpponentBattlefield.Field[rowRandom, colRandom] != "/ ")
                        {
                            continue;
                        }                        
                        else
                        {
                            break;
                        }
                    }

                    string playerAttackedSlotResult = player.GetAttacked(rowRandom, colRandom);

                    opponent.BotAttack(rowRandom, colRandom, playerAttackedSlotResult);

                    Console.WriteLine($" Opponent" + opponent.GetAttackMessage(playerAttackedSlotResult));
                    Thread.Sleep(2500);

                    if (opponent.CheckIfWinner())
                    {
                        break;
                    }

                    if (playerAttackedSlotResult == "T " || playerAttackedSlotResult == "S " || playerAttackedSlotResult == "C " || playerAttackedSlotResult == "B " || playerAttackedSlotResult == "X ")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                } // OPPONENT ATTACKS, PLAYER GETS ATTACKED

                if (opponent.CheckIfWinner())
                {
                    break;
                } //GAME ENDS - YOU WIN

                while (true)
                {
                    PrintGameplayUI(player, stage);

                    int row = -1;
                    int col = -1;

                    while (true)
                    {
                        Console.Write($" Attack (i.e. A0/a0): ");
                        string command = Console.ReadLine();

                        if (command.Length != 2)
                        {
                            Console.WriteLine(GameElements.GetInvalidMessage());
                            continue;
                        }
                        else
                        {
                            char colChar = command[0];

                            if (colChar >= 'A' && colChar <= 'J')
                            {
                                col = colChar - 'A';
                            }
                            else if (colChar >= 'a' && colChar <= 'j')
                            {
                                col = colChar - 'a';
                            }
                            else
                            {
                                Console.WriteLine(GameElements.GetInvalidMessage());
                                continue;
                            }

                            char rowChar = command[1];

                            if (rowChar - '0' >= 0 && rowChar - '0' <= 9)
                            {
                                row = rowChar - '0';
                            }
                            else
                            {
                                Console.WriteLine(GameElements.GetInvalidMessage());
                                continue;
                            }

                            break;
                        }
                    } // GET CORRECT INPUT

                    string opponentAttackedSlotResult = opponent.GetAttacked(row, col);

                    player.Attack(row, col, opponentAttackedSlotResult);

                    Console.WriteLine($" You" + player.GetAttackMessage(opponentAttackedSlotResult));
                    Thread.Sleep(2500);

                    if (player.CheckIfWinner())
                    {
                        break;
                    }

                    if (opponentAttackedSlotResult == "T " || opponentAttackedSlotResult == "S " || opponentAttackedSlotResult == "C " || opponentAttackedSlotResult == "B " || opponentAttackedSlotResult == "X ")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                } // PLAYER ATTACKS, OPPONENT GETS ATTACKED

                if (player.CheckIfWinner())
                {
                    break;
                }

                stage++; // END OF STAGE
            }

            PrintGameplayUI(player, stage);

            int didYouWin = 0;

            if (player.CheckIfWinner())
            {                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n   ~CONGRATULATIONS! YOU WON!~");
                didYouWin = 1;
            } // YOU WON
            else if (opponent.CheckIfWinner())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n   ~CONDOLENCES... YOU LOST!~");
            } // YOU LOST

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n   The game took {stage} stages.");
            
            Thread.Sleep(5000);
            Console.Clear();

            WriteStatistics(didYouWin);
        }

        public static void WriteStatistics(int didYouWin)
        {
            var connection = new SqlConnection("Server=PT\\SQLEXPRESS;Database=ShipsAndBoatsGame;Integrated Security=True;");

            connection.Open();

            using (connection)
            {
                var commandGetWon = new SqlCommand("SELECT [Won] FROM Statisticsss", connection);
                var resultWon = commandGetWon.ExecuteScalar();

                var commandGetLost = new SqlCommand("SELECT [Lost] FROM Statisticsss", connection);
                var resultLost = commandGetLost.ExecuteScalar();

                if (didYouWin == 1)
                {
                    int resultWonUpdated = (int)resultWon + 1;

                    var commandUpdateWon = new SqlCommand($"UPDATE Statisticsss SET Won = {resultWonUpdated}, Lost = {(int)resultLost} WHERE Id=1", connection);
                    commandUpdateWon.ExecuteScalar();
                }
                else
                {
                    int resultLostUpdated = (int)resultLost + 1;

                    var commandUpdateLost = new SqlCommand($"UPDATE Statisticsss SET Won = {(int)resultWon}, Lost = {resultLostUpdated} WHERE Id=1", connection);
                    commandUpdateLost.ExecuteScalar();
                }
            }
        }
    }
}
