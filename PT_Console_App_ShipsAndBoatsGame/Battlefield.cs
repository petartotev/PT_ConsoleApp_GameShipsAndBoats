using System;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public class Battlefield
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
          

        private bool CheckIfSlotIsEmptyOrOccuppied(int row, int col)
        {
            if (this.field[row, col] == BattlefieldElements.slotHidden || this.field[row, col] == BattlefieldElements.slotOccuppied)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfAllSlotsAroundAreEmptyOrOccuppied(int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i, j] != BattlefieldElements.slotHidden && this.field[i, j] != BattlefieldElements.slotOccuppied))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool CheckIfPlacingVesselOnEdgeIsPossible(int row, int col, string vessel)
        {
            int lengthVessel = BattlefieldElements.GetVesselLength(vessel);

            // IF ON TOP EDGE
            if (row == 0 && (col > 0 && col < 9))
            {
                for (int i = 0; i <= lengthVessel; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (this.field[i, j] != BattlefieldElements.slotOccuppied && this.field[i, j] != BattlefieldElements.slotHidden)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            // IF ON BOTTOM EDGE
            else if (row == 9 && (col > 0 && col < 9))
            {
                for (int i = 9; i >= 9 - lengthVessel; i--)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (this.field[i, j] != BattlefieldElements.slotOccuppied && this.field[i, j] != BattlefieldElements.slotHidden)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            // IF ON LEFT EDGE
            else if ((row > 0 && row < 9) && col == 0)
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = 0; j <= lengthVessel; j++)
                    {
                        if (this.field[i, j] != BattlefieldElements.slotOccuppied && this.field[i, j] != BattlefieldElements.slotHidden)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            // IF ON RIGHT EDGE
            else if ((row > 0 && row < 9) && col == 9)
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = 9; j >= 9 - lengthVessel; j--)
                    {
                        if (this.field[i, j] != BattlefieldElements.slotOccuppied && this.field[i, j] != BattlefieldElements.slotHidden)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfPlacingVesselInTheMiddleIsPossible(int row, int col, int orientation, string vessel)
        {
            int vesselLength = BattlefieldElements.GetVesselLength(vessel);

            //HORIZONTAL ORIENTATION
            if (orientation == 0)
            {
                // LEFT HALF GOING RIGHT
                if (col >= 0 && col <= 4)
                {
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = col - 1; j <= col + vesselLength; j++)
                        {
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i,j] != BattlefieldElements.slotOccuppied && this.field[i, j] != BattlefieldElements.slotHidden))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                // RIGHT HALF GOING LEFT
                else
                {
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = col + 1; j >= col - vesselLength; j--)
                        {
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i, j] != BattlefieldElements.slotOccuppied && this.field[i, j] != BattlefieldElements.slotHidden))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
            // VERTICAL ORIENTATION
            else
            {
                // UPPER PART GOING DOWN
                if (row >= 0 && row <= 4)
                {
                    for (int i = row - 1; i <= row + vesselLength; i++)
                    {
                        for (int j = col - 1; j <= col + 1; j++)
                        {
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i, j] != BattlefieldElements.slotOccuppied && this.field[i, j] != BattlefieldElements.slotHidden))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
                // LOWER PART GOING UP
                else
                {
                    for (int i = row + 1; i >= row - vesselLength; i--)
                    {
                        for (int j = col - 1; j <= col + 1; j++)
                        {
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i, j] != BattlefieldElements.slotOccuppied && this.field[i, j] != BattlefieldElements.slotHidden))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
        }


        private void PlaceVesselOnEdge(int row, int col, string vessel)
        {
            int lengthVessel = BattlefieldElements.GetVesselLength(vessel);

            // UPPER EDGE
            if (row == 0 && (col > 0 && col < 9))
            {
                for (int i = 0; i <= lengthVessel; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        this.field[i, j] = BattlefieldElements.slotOccuppied;
                        if (j == col && i != lengthVessel)
                        {
                            this.field[i, j] = vessel;
                        }
                    }
                }
            }
            // LOWER EDGE
            else if (row == 9 && (col > 0 && col < 9))
            {
                for (int i = 9; i >= 9 - lengthVessel; i--)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        this.field[i, j] = BattlefieldElements.slotOccuppied;

                        if (j == col && i != 9 - lengthVessel)
                        {
                            this.field[i, j] = vessel;
                        }
                    }
                }
            }
            // LEFT EDGE
            else if ((row > 0 && row < 9) && col == 0)
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = 0; j <= lengthVessel; j++)
                    {
                        this.field[i, j] = BattlefieldElements.slotOccuppied;
                        if (i == row && j != lengthVessel)
                        {
                            this.field[i, j] = vessel;
                        }
                    }
                }
            }
            // RIGHT EDGE
            else if ((row > 0 && row < 9) && col == 9)
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = 9; j >= 9 - lengthVessel; j--)
                    {
                        this.field[i, j] = BattlefieldElements.slotOccuppied;
                        if (i == row && j != 9 - lengthVessel)
                        {
                            this.field[i, j] = vessel;
                        }
                    }
                }
            }
        }

        private void PlaceVesselInTheMiddle(int row, int col, int orientation, string vessel)
        {
            int vesselLength = BattlefieldElements.GetVesselLength(vessel);

            //HORIZONTAL ORIENTATION
            if (orientation == 0)
            {
                // LEFT HALF GOING RIGHT
                if (col >= 0 && col <= 4)
                {
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = col - 1; j < col + vesselLength; j++)
                        {
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i, j] != BattlefieldElements.slotOccuppied || this.field[i, j] != BattlefieldElements.slotHidden))
                            {
                                this.field[i, j] = BattlefieldElements.slotOccuppied;
                            }

                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (i == row) && (j != col - 1 && j != col + vesselLength))
                            {
                                this.field[i, j] = vessel;
                            }
                        }
                    }
                }
                // RIGHT HALF GOING LEFT
                else
                {
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = col + 1; j >= col - vesselLength; j--)
                        {
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i, j] != BattlefieldElements.slotOccuppied || this.field[i, j] != BattlefieldElements.slotHidden))
                            {
                                this.field[i, j] = BattlefieldElements.slotOccuppied;
                            }

                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && i == row && (j != col + 1 && j != col - vesselLength))
                            {
                                this.field[i, j] = vessel;
                            }
                        }
                    }
                }
            }
            // VERTICAL ORIENTATION
            else
            {
                // UPPER PART GOING DOWN
                if (row >= 0 && row <= 4)
                {
                    for (int i = row - 1; i <= row + vesselLength; i++)
                    {
                        for (int j = col - 1; j <= col + 1; j++)
                        {
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i, j] != BattlefieldElements.slotOccuppied || this.field[i, j] != BattlefieldElements.slotHidden))
                            {
                                this.field[i, j] = BattlefieldElements.slotOccuppied;
                            }

                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && j == col && (i != row - 1 && i != row + vesselLength))
                            {
                                this.field[i, j] = vessel;
                            }
                        }
                    }
                }
                // LOWER PART GOING UP
                else
                {
                    for (int i = row + 1; i >= row - vesselLength; i--)
                    {
                        for (int j = col - 1; j <= col + 1; j++)
                        {
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (this.field[i, j] != BattlefieldElements.slotOccuppied || this.field[i, j] != BattlefieldElements.slotHidden))
                            {
                                this.field[i, j] = BattlefieldElements.slotOccuppied;
                            }

                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (j == col) && (i != row + 1 && i != row - vesselLength))
                            {
                                this.field[i, j] = vessel;
                            }
                        }
                    }
                }
            }
        }

        private void PlaceBoat(int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if ((i >= 0 && i <= 9 && j >= 0 && j <= 9))
                    {
                        this.field[i, j] = BattlefieldElements.slotOccuppied;
                    }
                }
            }
            this.field[row, col] = BattlefieldElements.slotBoat;
        }



        public void SetNewRandomBattlefield()
        {
            Random rndm = new Random();

            //LOOP THROUGH PLACING THE 10 VESSELS (1 TANKER => 2 SUBMARINES => 3 CARRIERS => 4 BOATS)
            for (int vesselCount = 1; vesselCount <= 10; vesselCount++)
            {
                string vessel = string.Empty;

                // GET THE TYPE OF VESSEL BASED ON VESSELCOUNT
                switch (vesselCount)
                {
                    case 1:
                        vessel = BattlefieldElements.slotTanker;
                        break;
                    case 2:
                    case 3:
                        vessel = BattlefieldElements.slotSubmarine;
                        break;
                    case 4:
                    case 5:
                    case 6:
                        vessel = BattlefieldElements.slotCarrier;
                        break;
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        vessel = BattlefieldElements.slotBoat;
                        break;
                }

                // PLACE TANKER / SUBMARINE / CARRIER
                if (vesselCount >= 1 && vesselCount <= 6)
                {
                    while (true)
                    {
                        int rowRandom = rndm.Next(0, 10);
                        int colRandom = rndm.Next(0, 10);
                        int horizontalOrVertical = rndm.Next(0, 2);

                        // IS IT IN CORNER?
                        if (CheckIfSlotIsInCorner(rowRandom, colRandom))
                        {
                            continue;
                        }
                        // IS IT ON EDGE?
                        else if (CheckIfSlotIsOnEdge(rowRandom, colRandom))
                        {
                            if (CheckIfPlacingVesselOnEdgeIsPossible(rowRandom, colRandom, vessel))
                            {
                                PlaceVesselOnEdge(rowRandom, colRandom, vessel);
                                break;
                            }
                        }
                        // IS IT IN THE MIDDLE?
                        else
                        {
                            // HORIZONTAL
                            if (horizontalOrVertical == 0)
                            {
                                if (CheckIfPlacingVesselInTheMiddleIsPossible(rowRandom, colRandom, horizontalOrVertical, vessel))
                                {
                                    PlaceVesselInTheMiddle(rowRandom, colRandom, horizontalOrVertical, vessel);
                                    break;
                                }
                            }
                            // VERTICAL
                            else
                            {
                                if (CheckIfPlacingVesselInTheMiddleIsPossible(rowRandom, colRandom, horizontalOrVertical, vessel))
                                {
                                    PlaceVesselInTheMiddle(rowRandom, colRandom, horizontalOrVertical, vessel);
                                    break;
                                }
                            }
                        }
                    }
                }
                // PLACE BOAT
                else
                {
                    while (true)
                    {
                        int rowRandom = rndm.Next(0, 10);
                        int colRandom = rndm.Next(0, 10);

                        if (CheckIfAllSlotsAroundAreEmptyOrOccuppied(rowRandom, colRandom))
                        {
                            PlaceBoat(rowRandom, colRandom);
                            break;
                        }
                    }
                }
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


        public string Print()
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

        public string PrintEmpty()
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
                    mySB.Append(BattlefieldElements.slotEmpty);
                }
                mySB.Append("║");
                mySB.AppendLine();
            }

            mySB.AppendLine($"   ╚═══╩═════════════════════╝");
            return mySB.ToString().TrimEnd();
        }


        public static bool CheckIfSlotIsInCorner(int row, int col)
        {
            if ((row == 0 && col == 0) || (row == 0 && col == 9) || (row == 9 && col == 0) || (row == 9 && col == 9))
            {
                return true;
            }
            return false;
        }

        public static bool CheckIfSlotIsOnEdge(int row, int col)
        {
            if (((row == 0 || row == 9) && (col > 0 && col < 9)) || (col == 0 || col == 9) && (row > 0 && row < 9))
            {
                return true;
            }
            return false;
        }

        public static bool CheckIfSlotIsInTheMiddle(int row, int col)
        {
            if ((row > 0 && row < 9) && (col > 0 && col < 9))
            {
                return true;
            }
            return false;
        }

        public static bool CheckIfSlotIsInsideOfMatrix(int row, int col)
        {
            if (row >= 0 && row <= 9 && col >= 0 && col <= 9)
            {
                return true;
            }
            return false;
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
    }
}