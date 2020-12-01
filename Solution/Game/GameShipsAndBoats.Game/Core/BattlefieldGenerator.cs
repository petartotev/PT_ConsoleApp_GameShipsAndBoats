using GameShipsAndBoats.Game.Models;
using GameShipsAndBoats.Game.Models.Common;
using System;

namespace GameShipsAndBoats.Game.Core
{
    public static class BattlefieldGenerator
    {
        public static Battlefield GenerateNewBattlefield()
        {
            Battlefield battlefield = new Battlefield();

            GenerateVesselsOnBattlefield(battlefield);

            return battlefield;
        }


        private static void GenerateVesselsOnBattlefield(Battlefield battlefield)
        {
            var field = battlefield.Field;

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
                        if (BattlefieldValidator.CheckIfSlotIsInCorner(rowRandom, colRandom))
                        {
                            continue;
                        }
                        // IS IT ON EDGE?
                        else if (BattlefieldValidator.CheckIfSlotIsOnEdge(rowRandom, colRandom))
                        {
                            if (CheckIfPlacingVesselOnEdgeIsPossible(field, rowRandom, colRandom, vessel))
                            {
                                PlaceVesselOnEdge(field, rowRandom, colRandom, vessel);
                                break;
                            }
                        }
                        // IS IT IN THE MIDDLE?
                        else
                        {
                            // HORIZONTAL
                            if (horizontalOrVertical == 0)
                            {
                                if (CheckIfPlacingVesselInTheMiddleIsPossible(field, rowRandom, colRandom, horizontalOrVertical, vessel))
                                {
                                    PlaceVesselInTheMiddle(field, rowRandom, colRandom, horizontalOrVertical, vessel);
                                    break;
                                }
                            }
                            // VERTICAL
                            else
                            {
                                if (CheckIfPlacingVesselInTheMiddleIsPossible(field, rowRandom, colRandom, horizontalOrVertical, vessel))
                                {
                                    PlaceVesselInTheMiddle(field, rowRandom, colRandom, horizontalOrVertical, vessel);
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

                        if (CheckIfAllSlotsAroundAreEmptyOrOccuppied(field, rowRandom, colRandom))
                        {
                            PlaceBoat(field, rowRandom, colRandom);
                            break;
                        }
                    }
                }
            }
        }

        private static bool CheckIfSlotIsEmptyOrOccuppied(string[,] field, int row, int col)
        {
            if (field[row, col] == BattlefieldElements.slotHidden || field[row, col] == BattlefieldElements.slotOccuppied)
            {
                return true;
            }
            return false;
        }

        private static bool CheckIfAllSlotsAroundAreEmptyOrOccuppied(string[,] field, int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotHidden && field[i, j] != BattlefieldElements.slotOccuppied))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static bool CheckIfPlacingVesselOnEdgeIsPossible(string[,] field, int row, int col, string vessel)
        {
            int lengthVessel = BattlefieldElements.GetVesselLength(vessel);

            // IF ON TOP EDGE
            if (row == 0 && (col > 0 && col < 9))
            {
                for (int i = 0; i <= lengthVessel; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        if (field[i, j] != BattlefieldElements.slotOccuppied && field[i, j] != BattlefieldElements.slotHidden)
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
                        if (field[i, j] != BattlefieldElements.slotOccuppied && field[i, j] != BattlefieldElements.slotHidden)
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
                        if (field[i, j] != BattlefieldElements.slotOccuppied && field[i, j] != BattlefieldElements.slotHidden)
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
                        if (field[i, j] != BattlefieldElements.slotOccuppied && field[i, j] != BattlefieldElements.slotHidden)
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

        private static bool CheckIfPlacingVesselInTheMiddleIsPossible(string[,] field, int row, int col, int orientation, string vessel)
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
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotOccuppied && field[i, j] != BattlefieldElements.slotHidden))
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
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotOccuppied && field[i, j] != BattlefieldElements.slotHidden))
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
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotOccuppied && field[i, j] != BattlefieldElements.slotHidden))
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
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotOccuppied && field[i, j] != BattlefieldElements.slotHidden))
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
        }

        private static void PlaceVesselOnEdge(string[,] field, int row, int col, string vessel)
        {
            int lengthVessel = BattlefieldElements.GetVesselLength(vessel);

            // UPPER EDGE
            if (row == 0 && (col > 0 && col < 9))
            {
                for (int i = 0; i <= lengthVessel; i++)
                {
                    for (int j = col - 1; j <= col + 1; j++)
                    {
                        field[i, j] = BattlefieldElements.slotOccuppied;
                        if (j == col && i != lengthVessel)
                        {
                            field[i, j] = vessel;
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
                        field[i, j] = BattlefieldElements.slotOccuppied;

                        if (j == col && i != 9 - lengthVessel)
                        {
                            field[i, j] = vessel;
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
                        field[i, j] = BattlefieldElements.slotOccuppied;
                        if (i == row && j != lengthVessel)
                        {
                            field[i, j] = vessel;
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
                        field[i, j] = BattlefieldElements.slotOccuppied;
                        if (i == row && j != 9 - lengthVessel)
                        {
                            field[i, j] = vessel;
                        }
                    }
                }
            }
        }

        private static void PlaceVesselInTheMiddle(string[,] field, int row, int col, int orientation, string vessel)
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
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotOccuppied || field[i, j] != BattlefieldElements.slotHidden))
                            {
                                field[i, j] = BattlefieldElements.slotOccuppied;
                            }

                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (i == row) && (j != col - 1 && j != col + vesselLength))
                            {
                                field[i, j] = vessel;
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
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotOccuppied || field[i, j] != BattlefieldElements.slotHidden))
                            {
                                field[i, j] = BattlefieldElements.slotOccuppied;
                            }

                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && i == row && (j != col + 1 && j != col - vesselLength))
                            {
                                field[i, j] = vessel;
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
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotOccuppied || field[i, j] != BattlefieldElements.slotHidden))
                            {
                                field[i, j] = BattlefieldElements.slotOccuppied;
                            }

                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && j == col && (i != row - 1 && i != row + vesselLength))
                            {
                                field[i, j] = vessel;
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
                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (field[i, j] != BattlefieldElements.slotOccuppied || field[i, j] != BattlefieldElements.slotHidden))
                            {
                                field[i, j] = BattlefieldElements.slotOccuppied;
                            }

                            if ((i >= 0 && i <= 9 && j >= 0 && j <= 9) && (j == col) && (i != row + 1 && i != row - vesselLength))
                            {
                                field[i, j] = vessel;
                            }
                        }
                    }
                }
            }
        }

        private static void PlaceBoat(string[,] field, int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if ((i >= 0 && i <= 9 && j >= 0 && j <= 9))
                    {
                        field[i, j] = BattlefieldElements.slotOccuppied;
                    }
                }
            }
            field[row, col] = BattlefieldElements.slotBoat;
        }
    }
}
