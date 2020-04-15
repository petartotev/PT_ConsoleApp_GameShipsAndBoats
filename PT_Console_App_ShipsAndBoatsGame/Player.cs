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
