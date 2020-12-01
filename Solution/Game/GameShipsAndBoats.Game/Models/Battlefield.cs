using GameShipsAndBoats.Game.Models.Common;
using GameShipsAndBoats.Game.Models.Contracts;
using System.Text;

namespace GameShipsAndBoats.Game.Models
{
    public class Battlefield : IBattlefield
    {
        private string[,] field = new string[10, 10];

        public Battlefield()
        {
            SetEmptyBattlefield();
        }

        public string[,] Field
        {
            get
            {
                return this.field;
            }
        }

        public string GetSlot(int row, int col)
        {
            return field[row, col];
        }

        public void SetSlot(int row, int col, string value)
        {
            this.field[row, col] = value;
        }

        public void SetBotOpponentSlotsIfAnotherCarrierAround(int row, int col)
        {
            // CHECK FOR ANOTHER CARRIER SLOT ON TOP
            if ((row - 1 >= 1) && this.field[row - 1, col] == BattlefieldElements.slotCarrier)
            {
                this.field[row - 2, col] = this.field[row + 1, col] = BattlefieldElements.slotOccuppied;
            }
            // CHECK FOR ANOTHER CARRIER SLOT ON BOTTOM
            else if ((row + 1 <= 8) && this.field[row + 1, col] == BattlefieldElements.slotCarrier)
            {
                this.field[row + 2, col] = this.field[row - 1, col] = BattlefieldElements.slotOccuppied;
            }
            // CHECK FOR ANOTHER CARRIER SLOT ON LEFT
            else if ((col - 1 >= 1) && this.field[row, col - 1] == BattlefieldElements.slotCarrier)
            {
                this.field[row, col - 2] = this.field[row, col + 1] = BattlefieldElements.slotOccuppied;
            }
            // CHECK FOR ANOTHER CARRIER SLOT ON RIGHT
            else if ((col + 1 <= 8) && this.field[row, col + 1] == BattlefieldElements.slotCarrier)
            {
                this.field[row, col + 2] = this.field[row, col - 1] = BattlefieldElements.slotOccuppied;
            }
        }

        public void SetBotOpponentSlotsAllAroundToDot(int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if ((i >= 0 && i <= 9) && (j >= 0 && j <= 9))
                    {
                        this.field[i, j] = BattlefieldElements.slotOccuppied;
                    }
                }
            }
        }

        public void SetBotOpponentSlotsDiagonalToDot(int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i += 2)
            {
                for (int j = col - 1; j <= col + 1; j += 2)
                {
                    if ((i >= 0 && i <= 9) && (j >= 0 && j <= 9) && (i != row && j != col))
                    {
                        this.field[i, j] = BattlefieldElements.slotOccuppied;
                    }
                }
            }
        }

        public void SetBotOpponentSlotsVesselOnEdgeToDot(int row, int col, string result)
        {
            int lengthVessel = BattlefieldElements.GetVesselLength(result);

            if (row == 0)
            {
                for (int rowCurr = 0; rowCurr <= lengthVessel; rowCurr++)
                {
                    this.field[rowCurr, col - 1] = this.field[rowCurr, col + 1] = BattlefieldElements.slotOccuppied;
                    this.field[rowCurr, col] = result;

                    if (rowCurr == lengthVessel)
                    {
                        this.field[rowCurr, col] = BattlefieldElements.slotOccuppied;
                    }
                }
            } // UPPER EDGE
            else if (row == 9)
            {
                for (int rowCurr = 9; rowCurr >= 9 - lengthVessel; rowCurr--)
                {
                    this.field[rowCurr, col - 1] = this.field[rowCurr, col + 1] = BattlefieldElements.slotOccuppied;
                    this.field[rowCurr, col] = result;

                    if (rowCurr == 9 - lengthVessel)
                    {
                        this.field[rowCurr, col] = BattlefieldElements.slotOccuppied;
                    }
                }
            } // LOWER EDGE
            else if (col == 0)
            {
                for (int colCurr = 0; colCurr <= lengthVessel; colCurr++)
                {
                    this.field[row - 1, colCurr] = this.field[row + 1, colCurr] = BattlefieldElements.slotOccuppied;
                    this.field[row, colCurr] = result;

                    if (colCurr == lengthVessel)
                    {
                        this.field[row, colCurr] = BattlefieldElements.slotOccuppied;
                    }
                }
            } // LEFT EDGE
            else if (col == 9)
            {
                for (int colCurr = 9; colCurr >= 9 - lengthVessel; colCurr--)
                {
                    this.field[row - 1, colCurr] = this.field[row + 1, colCurr] = BattlefieldElements.slotOccuppied;
                    this.field[row, colCurr] = result;

                    if (colCurr == 9 - lengthVessel)
                    {
                        this.field[row, colCurr] = BattlefieldElements.slotOccuppied;
                    }
                }
            } // RIGHT EDGE
        }

        public override string ToString()
        {
            StringBuilder mySB = new StringBuilder();
            mySB.AppendLine($"   ╔═══╦═════════════════════╗");
            mySB.AppendLine($"   ║   ║ A B C D E F G H I J ║");
            mySB.AppendLine($"   ╠═══╬═════════════════════╣");

            for (int row = 0; row < this.field.GetLength(0); row++)
            {
                mySB.Append($"   ║ {row} ║ ");

                for (int col = 0; col < this.field.GetLength(1); col++)
                {
                    mySB.Append(this.field[row, col]);
                }
                mySB.Append("║");
                mySB.AppendLine();
            }

            mySB.AppendLine($"   ╚═══╩═════════════════════╝");
            return mySB.ToString().TrimEnd();
        }


        private void SetEmptyBattlefield()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = BattlefieldElements.slotHidden;
                }
            }
        }
    }
}