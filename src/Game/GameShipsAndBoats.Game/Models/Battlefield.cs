using GameShipsAndBoats.Game.Models.Common;
using GameShipsAndBoats.Game.Models.Contracts;
using System.Text;

namespace GameShipsAndBoats.Game.Models
{
    public class Battlefield : IBattlefield
    {
        private readonly string[,] _field = new string[10, 10];

        public Battlefield()
        {
            SetEmptyBattlefield();
        }

        public string[,] Field
        {
            get => _field;
        }

        public string GetSlot(int row, int col)
        {
            return _field[row, col];
        }

        public void SetSlot(int row, int col, string value)
        {
            _field[row, col] = value;
        }

        public void SetBotOpponentSlotsIfAnotherCarrierAround(int row, int col)
        {
            // CHECK FOR ANOTHER CARRIER SLOT ON TOP
            if ((row - 1 >= 1) && _field[row - 1, col] == BattlefieldElements.slotCarrier)
            {
                _field[row - 2, col] = _field[row + 1, col] = BattlefieldElements.slotOccuppied;
            }
            // CHECK FOR ANOTHER CARRIER SLOT ON BOTTOM
            else if ((row + 1 <= 8) && _field[row + 1, col] == BattlefieldElements.slotCarrier)
            {
                _field[row + 2, col] = _field[row - 1, col] = BattlefieldElements.slotOccuppied;
            }
            // CHECK FOR ANOTHER CARRIER SLOT ON LEFT
            else if ((col - 1 >= 1) && _field[row, col - 1] == BattlefieldElements.slotCarrier)
            {
                _field[row, col - 2] = _field[row, col + 1] = BattlefieldElements.slotOccuppied;
            }
            // CHECK FOR ANOTHER CARRIER SLOT ON RIGHT
            else if ((col + 1 <= 8) && _field[row, col + 1] == BattlefieldElements.slotCarrier)
            {
                _field[row, col + 2] = _field[row, col - 1] = BattlefieldElements.slotOccuppied;
            }
        }

        public void SetBotOpponentSlotsAllAroundToDot(int row, int col)
        {
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if ((r >= 0 && r <= 9) && (c >= 0 && c <= 9))
                    {
                        _field[r, c] = BattlefieldElements.slotOccuppied;
                    }
                }
            }
        }

        public void SetBotOpponentSlotsDiagonalToDot(int row, int col)
        {
            for (int r = row - 1; r <= row + 1; r += 2)
            {
                for (int c = col - 1; c <= col + 1; c += 2)
                {
                    if ((r >= 0 && r <= 9) && (c >= 0 && c <= 9) && (r != row && c != col))
                    {
                        _field[r, c] = BattlefieldElements.slotOccuppied;
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
                    _field[rowCurr, col - 1] = _field[rowCurr, col + 1] = BattlefieldElements.slotOccuppied;
                    _field[rowCurr, col] = result;

                    if (rowCurr == lengthVessel)
                    {
                        _field[rowCurr, col] = BattlefieldElements.slotOccuppied;
                    }
                }
            } // UPPER EDGE
            else if (row == 9)
            {
                for (int rowCurr = 9; rowCurr >= 9 - lengthVessel; rowCurr--)
                {
                    _field[rowCurr, col - 1] = _field[rowCurr, col + 1] = BattlefieldElements.slotOccuppied;
                    _field[rowCurr, col] = result;

                    if (rowCurr == 9 - lengthVessel)
                    {
                        _field[rowCurr, col] = BattlefieldElements.slotOccuppied;
                    }
                }
            } // LOWER EDGE
            else if (col == 0)
            {
                for (int colCurr = 0; colCurr <= lengthVessel; colCurr++)
                {
                    _field[row - 1, colCurr] = _field[row + 1, colCurr] = BattlefieldElements.slotOccuppied;
                    _field[row, colCurr] = result;

                    if (colCurr == lengthVessel)
                    {
                        _field[row, colCurr] = BattlefieldElements.slotOccuppied;
                    }
                }
            } // LEFT EDGE
            else if (col == 9)
            {
                for (int colCurr = 9; colCurr >= 9 - lengthVessel; colCurr--)
                {
                    _field[row - 1, colCurr] = _field[row + 1, colCurr] = BattlefieldElements.slotOccuppied;
                    _field[row, colCurr] = result;

                    if (colCurr == 9 - lengthVessel)
                    {
                        _field[row, colCurr] = BattlefieldElements.slotOccuppied;
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

            for (int row = 0; row < _field.GetLength(0); row++)
            {
                mySB.Append($"   ║ {row} ║ ");

                for (int col = 0; col < _field.GetLength(1); col++)
                {
                    mySB.Append(_field[row, col]);
                }
                mySB.Append("║");
                mySB.AppendLine();
            }

            mySB.AppendLine($"   ╚═══╩═════════════════════╝");
            return mySB.ToString().TrimEnd();
        }

        private void SetEmptyBattlefield()
        {
            for (int row = 0; row < _field.GetLength(0); row++)
            {
                for (int col = 0; col < _field.GetLength(1); col++)
                {
                    _field[row, col] = BattlefieldElements.slotHidden;
                }
            }
        }
    }
}