using System;
using System.Collections.Generic;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public class Player : IPlayer
    {
        private Battlefield playerBattlefield;
        private Battlefield opponentBattlefield;

        public Player()
        {
            this.playerBattlefield = new Battlefield();
            playerBattlefield.SetRandomBattlefield();

            this.opponentBattlefield = new Battlefield();
        }

        public Battlefield PlayerBattlefield
        {
            get
            {
                return this.playerBattlefield;
            }
        }

        public Battlefield OpponentBattlefield
        {
            get
            {
                return this.opponentBattlefield;
            }
        }


        public void BotAttack(int row, int col, string result)
        {
            if ((row < 0) || (row > 9) || (col < 0) || (col > 9))
            {
                throw new ArgumentOutOfRangeException($"The coordinates of the battlefield are out of range!");
            }
            else if (result == null)
            {
                throw new ArgumentNullException($"The coordinates of the battlefield are out of range!");
            }

            //CORNERS
            if (result == "B " && (row == 0) && (col == 0))
            {
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
            } // BOAT ON UPPER-LEFT-CORNER
            else if (result == "B " && (row == 0) && (col == 9))
            {
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
            } // BOAT ON UPPER-RIGHT CORNER
            else if (result == "B " && (row == 9) && (col == 0))
            {
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
            } // BOAT ON LOWER-LEFT-CORNER
            else if (result == "B " && (row == 9) && (col == 9))
            {
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
            } // BOAT ON LOWER-RIGHT-CORNER  

            //MIDDLE
            else if (result == "B " && (row >= 1) && (row <= 8) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
            } // BOAT IN THE MIDDLE
            else if ((result == "T " || result == "S " || result == "C " || result == "X ") && (row >= 1) && (row <= 8) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
            } // VESSEL IN THE MIDDLE

            //UPPER EDGE
            else if ((result == "T ") && (row == 0) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 2, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 2, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 3, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 3, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 4, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 4, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 4, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, "T ");
                this.opponentBattlefield.SetSlot(row + 2, col, "T ");
                this.opponentBattlefield.SetSlot(row + 3, col, "T ");
            } // TANKER ON UPPER EDGE
            else if ((result == "S ") && (row == 0) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 2, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 2, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 3, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 3, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 3, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, "S ");
                this.opponentBattlefield.SetSlot(row + 2, col, "S ");
            } // SUBMARINE ON UPPER EDGE
            else if ((result == "C ") && (row == 0) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 2, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 2, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 2, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, "C ");
            } // CARRIER ON UPPER EDGE
            else if ((result == "B ") && (row == 0) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
            } // BOAT ON UPPER EDGE
            else if ((result == "X ") && (row == 0) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
            } // X ON UPPER EDGE

            //LOWER EDGE
            else if ((result == "T ") && (row == 9) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 2, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 2, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 3, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 3, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 4, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 4, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 4, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col, "T ");
                this.opponentBattlefield.SetSlot(row - 2, col, "T ");
                this.opponentBattlefield.SetSlot(row - 3, col, "T ");
            } // TANKER ON LOWER EDGE
            else if ((result == "S ") && (row == 9) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 2, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 2, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 3, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 3, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 3, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col, "S ");
                this.opponentBattlefield.SetSlot(row - 2, col, "S ");
            } // SUBMARINE ON LOWER EDGE
            else if ((result == "C ") && (row == 9) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 2, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 2, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 2, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col, "C ");
            } // CARRIER ON LOWER EDGE
            else if ((result == "B ") && (row == 9) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
            } // BOAT ON LOWER EDGE
            else if ((result == "X ") && (row == 9) && (col >= 1) && (col <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
            } // X ON LOWER EDGE

            //LEFT EDGE
            else if ((result == "T ") && (col == 0) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 2, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 3, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 4, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 2, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 3, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 4, ". ");
                this.opponentBattlefield.SetSlot(row, col + 4, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, "T ");
                this.opponentBattlefield.SetSlot(row, col + 2, "T ");
                this.opponentBattlefield.SetSlot(row, col + 3, "T ");
            } // TANKER ON LEFT EDGE
            else if ((result == "S ") && (col == 0) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 2, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 3, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 2, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 3, ". ");
                this.opponentBattlefield.SetSlot(row, col + 3, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, "S ");
                this.opponentBattlefield.SetSlot(row, col + 2, "S ");
            } // SUBMARINE ON LEFT EDGE
            else if ((result == "C ") && (col == 0) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 2, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 2, ". ");
                this.opponentBattlefield.SetSlot(row, col + 2, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, "C ");
            } // CARRIER ON LEFT EDGE
            else if ((result == "B ") && (col == 0) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
            } // BOAT ON LEFT EDGE
            else if ((result == "X ") && (col == 0) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col + 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col + 1, ". ");
            } // X ON LEFT EDGE

            //RIGHT EDGE
            else if ((result == "T ") && (col == 9) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 2, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 3, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 4, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 2, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 3, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 4, ". ");
                this.opponentBattlefield.SetSlot(row, col - 4, ". ");
                this.opponentBattlefield.SetSlot(row, col - 1, "T ");
                this.opponentBattlefield.SetSlot(row, col - 2, "T ");
                this.opponentBattlefield.SetSlot(row, col - 3, "T ");
            } // TANKER ON RIGHT EDGE
            else if ((result == "S ") && (col == 9) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 2, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 3, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 2, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 3, ". ");
                this.opponentBattlefield.SetSlot(row, col - 3, ". ");
                this.opponentBattlefield.SetSlot(row, col - 1, "S ");
                this.opponentBattlefield.SetSlot(row, col - 2, "S ");
            } // SUBMARINE ON RIGHT EDGE
            else if ((result == "C ") && (col == 9) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col - 2, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 2, ". ");
                this.opponentBattlefield.SetSlot(row, col - 2, ". ");
                this.opponentBattlefield.SetSlot(row, col - 1, "C ");
            } // CARRIER ON RIGHT EDGE
            else if ((result == "B ") && (col == 9) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row - 1, col, ". ");
                this.opponentBattlefield.SetSlot(row, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col, ". ");
            } // BOAT ON RIGHT EDGE
            else if ((result == "X ") && (col == 9) && (row >= 1) && (row <= 8))
            {
                this.opponentBattlefield.SetSlot(row - 1, col - 1, ". ");
                this.opponentBattlefield.SetSlot(row + 1, col - 1, ". ");
            } // X ON RIGHT EDGE

            this.opponentBattlefield.SetSlot(row, col, result);
        }

        public void Attack(int row, int col, string result)
        {
            this.opponentBattlefield.SetSlot(row, col, result);
        }

        public string GetAttackMessage(string result)
        {
            StringBuilder attackMessage = new StringBuilder();
            switch (result)
            {
                case "T ":
                    attackMessage.AppendLine($" hit a Tanker (TTTT)!");
                    break;
                case "S ":
                    attackMessage.AppendLine($" hit a Submarine (SSS)!");
                    break;
                case "C ":
                    attackMessage.AppendLine($" hit a Carrier (CC)!");
                    break;
                case "B ":
                    attackMessage.AppendLine($" hit a Boat (B)!");
                    break;
                default:
                    attackMessage.AppendLine($" didn't hit anything.");
                    break;
            }
            return attackMessage.ToString().TrimEnd();
        }

        public string GetAttacked(int row, int col)
        {
            string slot = playerBattlefield.GetSlot(row, col);

            if (slot == "B " || slot == "C " || slot == "S " || slot == "T " || slot == "X ")
            {
                playerBattlefield.SetSlot(row, col, "X ");
                return slot;
            }
            else
            {
                playerBattlefield.SetSlot(row, col, "+ ");
                return "- ";
            }
        }

        public bool CheckIfWinner()
        {
            int hitTargets = 0;

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (this.opponentBattlefield.GetSlot(row, col) == "B " ||
                        this.opponentBattlefield.GetSlot(row, col) == "C " ||
                        this.opponentBattlefield.GetSlot(row, col) == "S " ||
                        this.opponentBattlefield.GetSlot(row, col) == "T " ||
                        this.opponentBattlefield.GetSlot(row, col) == "X ")
                    {
                        hitTargets++;
                    }
                }
            }

            if (hitTargets == 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}