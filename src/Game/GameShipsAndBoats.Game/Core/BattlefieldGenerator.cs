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
                // GET THE TYPE OF VESSEL BASED ON VESSEL COUNT
                string vesselType = vesselCount switch
                {
                    1 => BattlefieldElements.slotTanker,
                    2 => BattlefieldElements.slotSubmarine,
                    3 => BattlefieldElements.slotSubmarine,
                    4 => BattlefieldElements.slotCarrier,
                    5 => BattlefieldElements.slotCarrier,
                    6 => BattlefieldElements.slotCarrier,
                    7 => BattlefieldElements.slotBoat,
                    8 => BattlefieldElements.slotBoat,
                    9 => BattlefieldElements.slotBoat,
                    10 => BattlefieldElements.slotBoat,
                    _ => string.Empty
                };

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
                            if (CheckIfPlacingVesselOnEdgeIsPossible(field, rowRandom, colRandom, vesselType))
                            {
                                PlaceVesselOnEdge(field, rowRandom, colRandom, vesselType);
                                break;
                            }
                        }
                        // IS IT IN THE MIDDLE?
                        else
                        {
                            // HORIZONTAL
                            if (horizontalOrVertical == 0)
                            {
                                if (CheckIfPlacingVesselInTheMiddleIsPossible(field, rowRandom, colRandom, horizontalOrVertical, vesselType))
                                {
                                    PlaceVesselInTheMiddle(field, rowRandom, colRandom, horizontalOrVertical, vesselType);
                                    break;
                                }
                            }
                            // VERTICAL
                            else
                            {
                                if (CheckIfPlacingVesselInTheMiddleIsPossible(field, rowRandom, colRandom, horizontalOrVertical, vesselType))
                                {
                                    PlaceVesselInTheMiddle(field, rowRandom, colRandom, horizontalOrVertical, vesselType);
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
            return (field[row, col] == BattlefieldElements.slotHidden || field[row, col] == BattlefieldElements.slotOccuppied);
        }

        private static bool CheckIfAllSlotsAroundAreEmptyOrOccuppied(string[,] field, int row, int col)
        {
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotHidden && field[r, c] != BattlefieldElements.slotOccuppied))
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
                for (int r = 0; r <= lengthVessel; r++)
                {
                    for (int c = col - 1; c <= col + 1; c++)
                    {
                        if (field[r, c] != BattlefieldElements.slotOccuppied && field[r, c] != BattlefieldElements.slotHidden)
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
                for (int r = 9; r >= 9 - lengthVessel; r--)
                {
                    for (int c = col - 1; c <= col + 1; c++)
                    {
                        if (field[r, c] != BattlefieldElements.slotOccuppied && field[r, c] != BattlefieldElements.slotHidden)
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
                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = 0; c <= lengthVessel; c++)
                    {
                        if (field[r, c] != BattlefieldElements.slotOccuppied && field[r, c] != BattlefieldElements.slotHidden)
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
                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = 9; c >= 9 - lengthVessel; c--)
                    {
                        if (field[r, c] != BattlefieldElements.slotOccuppied && field[r, c] != BattlefieldElements.slotHidden)
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
                    for (int r = row - 1; r <= row + 1; r++)
                    {
                        for (int c = col - 1; c <= col + vesselLength; c++)
                        {
                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotOccuppied && field[r, c] != BattlefieldElements.slotHidden))
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
                    for (int r = row - 1; r <= row + 1; r++)
                    {
                        for (int c = col + 1; c >= col - vesselLength; c--)
                        {
                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotOccuppied && field[r, c] != BattlefieldElements.slotHidden))
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
                    for (int r = row - 1; r <= row + vesselLength; r++)
                    {
                        for (int c = col - 1; c <= col + 1; c++)
                        {
                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotOccuppied && field[r, c] != BattlefieldElements.slotHidden))
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
                    for (int r = row + 1; r >= row - vesselLength; r--)
                    {
                        for (int c = col - 1; c <= col + 1; c++)
                        {
                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotOccuppied && field[r, c] != BattlefieldElements.slotHidden))
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
                for (int r = 0; r <= lengthVessel; r++)
                {
                    for (int c = col - 1; c <= col + 1; c++)
                    {
                        field[r, c] = BattlefieldElements.slotOccuppied;
                        if (c == col && r != lengthVessel)
                        {
                            field[r, c] = vessel;
                        }
                    }
                }
            }
            // LOWER EDGE
            else if (row == 9 && (col > 0 && col < 9))
            {
                for (int r = 9; r >= 9 - lengthVessel; r--)
                {
                    for (int c = col - 1; c <= col + 1; c++)
                    {
                        field[r, c] = BattlefieldElements.slotOccuppied;

                        if (c == col && r != 9 - lengthVessel)
                        {
                            field[r, c] = vessel;
                        }
                    }
                }
            }
            // LEFT EDGE
            else if ((row > 0 && row < 9) && col == 0)
            {
                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = 0; c <= lengthVessel; c++)
                    {
                        field[r, c] = BattlefieldElements.slotOccuppied;
                        if (r == row && c != lengthVessel)
                        {
                            field[r, c] = vessel;
                        }
                    }
                }
            }
            // RIGHT EDGE
            else if ((row > 0 && row < 9) && col == 9)
            {
                for (int r = row - 1; r <= row + 1; r++)
                {
                    for (int c = 9; c >= 9 - lengthVessel; c--)
                    {
                        field[r, c] = BattlefieldElements.slotOccuppied;
                        if (r == row && c != 9 - lengthVessel)
                        {
                            field[r, c] = vessel;
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
                    for (int r = row - 1; r <= row + 1; r++)
                    {
                        for (int c = col - 1; c < col + vesselLength; c++)
                        {
                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotOccuppied || field[r, c] != BattlefieldElements.slotHidden))
                            {
                                field[r, c] = BattlefieldElements.slotOccuppied;
                            }

                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (r == row) && (c != col - 1 && c != col + vesselLength))
                            {
                                field[r, c] = vessel;
                            }
                        }
                    }
                }
                // RIGHT HALF GOING LEFT
                else
                {
                    for (int r = row - 1; r <= row + 1; r++)
                    {
                        for (int c = col + 1; c >= col - vesselLength; c--)
                        {
                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotOccuppied || field[r, c] != BattlefieldElements.slotHidden))
                            {
                                field[r, c] = BattlefieldElements.slotOccuppied;
                            }

                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && r == row && (c != col + 1 && c != col - vesselLength))
                            {
                                field[r, c] = vessel;
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
                    for (int r = row - 1; r <= row + vesselLength; r++)
                    {
                        for (int c = col - 1; c <= col + 1; c++)
                        {
                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotOccuppied || field[r, c] != BattlefieldElements.slotHidden))
                            {
                                field[r, c] = BattlefieldElements.slotOccuppied;
                            }

                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && c == col && (r != row - 1 && r != row + vesselLength))
                            {
                                field[r, c] = vessel;
                            }
                        }
                    }
                }
                // LOWER PART GOING UP
                else
                {
                    for (int r = row + 1; r >= row - vesselLength; r--)
                    {
                        for (int c = col - 1; c <= col + 1; c++)
                        {
                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (field[r, c] != BattlefieldElements.slotOccuppied || field[r, c] != BattlefieldElements.slotHidden))
                            {
                                field[r, c] = BattlefieldElements.slotOccuppied;
                            }

                            if ((r >= 0 && r <= 9 && c >= 0 && c <= 9) && (c == col) && (r != row + 1 && r != row - vesselLength))
                            {
                                field[r, c] = vessel;
                            }
                        }
                    }
                }
            }
        }

        private static void PlaceBoat(string[,] field, int row, int col)
        {
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    if ((r >= 0 && r <= 9 && c >= 0 && c <= 9))
                    {
                        field[r, c] = BattlefieldElements.slotOccuppied;
                    }
                }
            }
            field[row, col] = BattlefieldElements.slotBoat;
        }
    }
}
