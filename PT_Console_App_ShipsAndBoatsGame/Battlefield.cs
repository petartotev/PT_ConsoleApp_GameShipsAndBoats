using System;
using System.Collections.Generic;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public class Battlefield
    {
        private const string slotOccuppied = ". ";
        private const string slotEmpty = "  ";
        private const string slotHidden = "/ ";

        private const string slotFull = "B ";
        private const string slotCarrier = "C ";
        private const string slotSubmarine = "S ";
        private const string slotTanker = "T ";
        
        private List<int[]> slotsFullCoordinates = new List<int[]>();

        private string[,] field = new string[10, 10];

        public Battlefield()
        {
            SetEmptyBattlefield();
        }

        private void AddSlotsFullToList()
        {
            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (field[row,col] == slotFull)
                    {
                        int[] coordinates = new int[2] { row, col };
                        this.slotsFullCoordinates.Add(coordinates);
                    }
                }
            }
        }

        private void SetLettersToFullSlots()
        {
            for (int i = 0; i < slotsFullCoordinates.Count; i++)
            {
                field[slotsFullCoordinates[i][0], slotsFullCoordinates[i][1]] = slotCarrier;
            }
            for (int j = 0; j < 14; j++)
            {
                field[slotsFullCoordinates[j][0], slotsFullCoordinates[j][1]] = slotSubmarine;
            }
            for (int k = 0; k < 4; k++)
            {
                field[slotsFullCoordinates[k][0], slotsFullCoordinates[k][1]] = slotTanker;
            }
        }

        private void SetEmptyBattlefield()
        {
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = slotHidden;
                }
            }
        }

        public void SetRandomBattlefield()
        {
            Random rndm = new Random();

            // 1 x TANKER
            while (true)
            {
                int rowRandom = rndm.Next(0, 10);
                int colRandom = rndm.Next(0, 10);
                int horizontalOrVertical = rndm.Next(0, 2);
                int zeroOrOne = rndm.Next(0, 2);

                if ((rowRandom == 0 && colRandom == 0) || (rowRandom == 0 && colRandom == 9) || (rowRandom == 9 && colRandom == 0) || (rowRandom == 9 && colRandom == 9))
                {
                    continue;
                } // CORNER ISSUE - TRY AGAIN
                else if (rowRandom == 0)
                {
                    this.field[rowRandom, colRandom] = this.field[rowRandom + 1, colRandom] = this.field[rowRandom + 2, colRandom] = this.field[rowRandom + 3, colRandom] = slotFull;

                    this.field[rowRandom, colRandom - 1] = this.field[rowRandom, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom + 1, colRandom - 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom + 2, colRandom - 1] = this.field[rowRandom + 2, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom + 3, colRandom - 1] = this.field[rowRandom + 3, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom + 4, colRandom - 1] = this.field[rowRandom + 4, colRandom + 1] = this.field[rowRandom + 4, colRandom] = slotOccuppied;
                    break;
                } // UPPER ROW EDGE SITUATION
                else if (rowRandom == 9)
                {
                    this.field[rowRandom, colRandom] = this.field[rowRandom - 1, colRandom] = this.field[rowRandom - 2, colRandom] = this.field[rowRandom - 3, colRandom] = slotFull;

                    this.field[rowRandom, colRandom - 1] = this.field[rowRandom, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom - 1, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom - 2, colRandom - 1] = this.field[rowRandom - 2, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom - 3, colRandom - 1] = this.field[rowRandom - 3, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom - 4, colRandom - 1] = this.field[rowRandom - 4, colRandom + 1] = this.field[rowRandom - 4, colRandom] = slotOccuppied;
                    break;
                } // LOWER ROW EDGE SITUATION
                else if (colRandom == 0)
                {
                    this.field[rowRandom, colRandom] = this.field[rowRandom, colRandom + 1] = this.field[rowRandom, colRandom + 2] = this.field[rowRandom, colRandom + 3] = slotFull;

                    this.field[rowRandom - 1, colRandom] = this.field[rowRandom + 1, colRandom] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom + 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom + 2] = this.field[rowRandom + 1, colRandom + 2] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom + 3] = this.field[rowRandom + 1, colRandom + 3] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom + 4] = this.field[rowRandom + 1, colRandom + 4] = slotOccuppied;
                    this.field[rowRandom, colRandom + 4] = slotOccuppied;
                    break;
                } // LEFT COL EDGE SITUATION
                else if (colRandom == 9)
                {
                    this.field[rowRandom, colRandom] = this.field[rowRandom, colRandom - 1] = this.field[rowRandom, colRandom - 2] = this.field[rowRandom, colRandom - 3] = slotFull;

                    this.field[rowRandom - 1, colRandom] = this.field[rowRandom + 1, colRandom] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom + 1, colRandom - 1] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom - 2] = this.field[rowRandom + 1, colRandom - 2] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom - 3] = this.field[rowRandom + 1, colRandom - 3] = slotOccuppied;
                    this.field[rowRandom - 1, colRandom - 4] = this.field[rowRandom + 1, colRandom - 4] = slotOccuppied;
                    this.field[rowRandom, colRandom - 4] = slotOccuppied;
                    break;
                } // RIGHT COL EDGE SITUATION
                else 
                {
                    this.field[rowRandom, colRandom] = slotFull;

                    if (horizontalOrVertical == 0)
                    {
                        switch (colRandom)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                                this.field[rowRandom, colRandom + 1] = this.field[rowRandom, colRandom + 2] = this.field[rowRandom, colRandom + 3] = slotFull;

                                this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom + 1, colRandom - 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 0] = this.field[rowRandom + 1, colRandom + 0] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 2] = this.field[rowRandom + 1, colRandom + 2] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 3] = this.field[rowRandom + 1, colRandom + 3] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 4] = this.field[rowRandom + 1, colRandom + 4] = slotOccuppied;
                                this.field[rowRandom, colRandom - 1] = this.field[rowRandom, colRandom + 4] = slotOccuppied;
                                break;
                            case 6:
                                this.field[rowRandom, colRandom + 1] = this.field[rowRandom, colRandom + 2] = this.field[rowRandom, colRandom + 3] = slotFull;

                                this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom + 1, colRandom - 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 0] = this.field[rowRandom + 1, colRandom + 0] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 2] = this.field[rowRandom + 1, colRandom + 2] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 3] = this.field[rowRandom + 1, colRandom + 3] = slotOccuppied;
                                this.field[rowRandom, colRandom - 1] = slotOccuppied;
                                break;
                            case 7:
                                this.field[rowRandom, colRandom - 1] = this.field[rowRandom, colRandom + 1] = slotFull;

                                this.field[rowRandom - 1, colRandom - 2] = this.field[rowRandom + 1, colRandom - 2] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom + 1, colRandom - 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom - 0] = this.field[rowRandom + 1, colRandom - 0] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 2] = this.field[rowRandom + 1, colRandom + 2] = slotOccuppied;

                                if (zeroOrOne == 0)
                                {
                                    this.field[rowRandom, colRandom - 2] = slotFull;

                                    this.field[rowRandom, colRandom + 2] = this.field[rowRandom, colRandom - 3] = this.field[rowRandom + 1, colRandom - 3] = this.field[rowRandom - 1, colRandom - 3] = slotOccuppied;
                                }
                                else
                                {
                                    this.field[rowRandom, colRandom + 2] = slotFull;

                                    this.field[rowRandom, colRandom - 2] = slotOccuppied;
                                }
                                break;
                            case 8:
                                this.field[rowRandom, colRandom - 1] = this.field[rowRandom, colRandom - 2] = slotFull;

                                this.field[rowRandom - 1, colRandom - 3] = this.field[rowRandom + 1, colRandom - 3] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom - 2] = this.field[rowRandom + 1, colRandom - 2] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom + 1, colRandom - 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 0] = this.field[rowRandom + 1, colRandom + 0] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom + 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;

                                if (zeroOrOne == 0)
                                {
                                    this.field[rowRandom, colRandom - 3] = slotFull;

                                    this.field[rowRandom, colRandom + 1] = slotOccuppied;
                                    this.field[rowRandom - 1, colRandom - 4] = this.field[rowRandom, colRandom - 4] = this.field[rowRandom + 1, colRandom - 4] = slotOccuppied;
                                }
                                else
                                {
                                    this.field[rowRandom, colRandom + 1] = slotFull;

                                    this.field[rowRandom, colRandom - 3] = slotOccuppied;
                                }
                                break;
                        }
                    }
                    else if (horizontalOrVertical == 1)
                    {
                        switch (rowRandom)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                            case 5:
                                this.field[rowRandom + 1, colRandom] = this.field[rowRandom + 2, colRandom] = this.field[rowRandom + 3, colRandom] = slotFull;

                                this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom - 1, colRandom] = this.field[rowRandom - 1, colRandom + 1] = slotOccuppied; 
                                this.field[rowRandom, colRandom - 1] = this.field[rowRandom , colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 1, colRandom - 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 2, colRandom - 1] = this.field[rowRandom + 2, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 3, colRandom - 1] = this.field[rowRandom + 3, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 4, colRandom - 1] = this.field[rowRandom + 4, colRandom] = this.field[rowRandom + 4, colRandom + 1] = slotOccuppied;

                                break;
                            case 6:
                                this.field[rowRandom + 1, colRandom] = this.field[rowRandom + 2, colRandom] = this.field[rowRandom + 3, colRandom] = slotFull;

                                this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom - 1, colRandom] = this.field[rowRandom - 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom, colRandom - 1] = this.field[rowRandom, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 1, colRandom - 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 2, colRandom - 1] = this.field[rowRandom + 2, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 3, colRandom - 1] = this.field[rowRandom + 3, colRandom + 1] = slotOccuppied;
                                break;
                            case 7:
                                this.field[rowRandom - 1, colRandom] = this.field[rowRandom + 1, colRandom] = slotFull;

                                this.field[rowRandom - 2, colRandom - 1] = this.field[rowRandom - 2, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom - 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom - 0, colRandom - 1] = this.field[rowRandom - 0, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 1, colRandom - 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 2, colRandom - 1] = this.field[rowRandom + 2, colRandom + 1] = slotOccuppied;

                                if (zeroOrOne == 0)
                                {
                                    this.field[rowRandom - 2, colRandom] = slotFull;

                                    this.field[rowRandom - 3, colRandom - 1] = this.field[rowRandom - 3, colRandom] = this.field[rowRandom - 3, colRandom + 1] = slotOccuppied;
                                    this.field[rowRandom + 2, colRandom] = slotOccuppied;
                                }
                                else
                                {
                                    this.field[rowRandom + 2, colRandom] = slotFull;

                                    this.field[rowRandom - 2, colRandom] = slotOccuppied;
                                }
                                break;
                            case 8:
                                this.field[rowRandom - 1, colRandom] = this.field[rowRandom - 2, colRandom] = slotFull;

                                this.field[rowRandom - 3, colRandom - 1] = this.field[rowRandom - 3, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom - 2, colRandom - 1] = this.field[rowRandom - 2, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom - 1, colRandom - 1] = this.field[rowRandom - 1, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 0, colRandom - 1] = this.field[rowRandom + 0, colRandom + 1] = slotOccuppied;
                                this.field[rowRandom + 1, colRandom - 1] = this.field[rowRandom + 1, colRandom + 1] = slotOccuppied;

                                if (zeroOrOne == 0)
                                {
                                    this.field[rowRandom - 3, colRandom] = slotFull;

                                    this.field[rowRandom - 4, colRandom - 1] = this.field[rowRandom - 4, colRandom] = this.field[rowRandom - 4, colRandom + 1] = slotOccuppied;
                                    this.field[rowRandom + 1, colRandom] = slotOccuppied;
                                }
                                else
                                {
                                    this.field[rowRandom + 1, colRandom] = slotFull;

                                    this.field[rowRandom -3, colRandom] = slotOccuppied;
                                }
                                break;
                        }
                    }

                    break;
                } // SOMEWHERE IN THE MIDDLE                
            }

            AddSlotsFullToList();

            // 2 x SUBMARINE
            for (int i = 1; i <= 2; i++)
            {
                while (true)
                {
                    int rowR = rndm.Next(0, 10);
                    int colR = rndm.Next(0, 10);
                    int horizontalOrVertical = rndm.Next(0, 2);
                    int zeroOrOne = rndm.Next(0, 2);

                    if ((rowR == 0 && colR == 0) || (rowR == 0 && colR == 9) || (rowR == 9 && colR == 0) || (rowR == 9 && colR == 9))
                    {
                        continue;
                    } // CORNER ISSUE - TRY AGAIN
                    else if (rowR == 0 &&
                        (this.field[rowR, colR] != slotFull) && (this.field[rowR, colR - 1] != slotFull) && (this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR] != slotFull) && (this.field[rowR + 1, colR - 1] != slotFull) && (this.field[rowR + 1, colR + 1] != slotFull) &&
                        (this.field[rowR + 2, colR] != slotFull) && (this.field[rowR + 2, colR - 1] != slotFull) && (this.field[rowR + 2, colR + 1] != slotFull) &&
                        (this.field[rowR + 3, colR] != slotFull) && (this.field[rowR + 3, colR - 1] != slotFull) && (this.field[rowR + 3, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR + 1, colR] = this.field[rowR + 2, colR] = slotFull;

                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR + 1] = slotOccuppied;
                        this.field[rowR + 2, colR - 1] = this.field[rowR + 2, colR + 1] = slotOccuppied;
                        this.field[rowR + 3, colR - 1] = this.field[rowR + 3, colR + 1] = this.field[rowR + 3, colR] = slotOccuppied;

                        break;
                    }
                    else if (rowR == 9 &&
                        (this.field[rowR, colR] != slotFull) && (this.field[rowR, colR - 1] != slotFull) && (this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR - 1, colR] != slotFull) && (this.field[rowR - 1, colR - 1] != slotFull) && (this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR - 2, colR] != slotFull) && (this.field[rowR - 2, colR - 1] != slotFull) && (this.field[rowR - 2, colR + 1] != slotFull) &&
                        (this.field[rowR - 3, colR] != slotFull) && (this.field[rowR - 3, colR - 1] != slotFull) && (this.field[rowR - 3, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR - 1, colR] = this.field[rowR - 2, colR] = slotFull;

                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = slotOccuppied;
                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR - 2, colR - 1] = this.field[rowR - 2, colR + 1] = slotOccuppied;
                        this.field[rowR - 3, colR - 1] = this.field[rowR - 3, colR + 1] = this.field[rowR - 3, colR] = slotOccuppied;

                        break;
                    }
                    else if (colR == 0 &&
                        (this.field[rowR - 1, colR] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR + 1, colR] != slotFull) &&
                        (this.field[rowR - 1, colR + 1] != slotFull && this.field[rowR, colR + 1] != slotFull && this.field[rowR + 1, colR + 1] != slotFull) &&
                        (this.field[rowR - 1, colR + 2] != slotFull && this.field[rowR, colR + 2] != slotFull && this.field[rowR + 1, colR + 2] != slotFull) &&
                        (this.field[rowR - 1, colR + 3] != slotFull && this.field[rowR, colR + 3] != slotFull && this.field[rowR + 1, colR + 3] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR, colR + 1] = this.field[rowR, colR + 2] = slotFull;

                        this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = this.field[rowR - 1, colR + 2] = this.field[rowR - 1, colR + 3] = slotOccuppied;
                        this.field[rowR, colR + 3] = slotOccuppied;
                        this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = this.field[rowR + 1, colR + 2] = this.field[rowR + 1, colR + 3] = slotOccuppied;

                        break;
                    }
                    else if (colR == 9 &&
                        (this.field[rowR - 1, colR] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR + 1, colR] != slotFull) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR, colR - 1] != slotFull && this.field[rowR + 1, colR - 1] != slotFull) &&
                        (this.field[rowR - 1, colR - 2] != slotFull && this.field[rowR, colR - 2] != slotFull && this.field[rowR + 1, colR - 2] != slotFull) &&
                        (this.field[rowR - 1, colR - 3] != slotFull && this.field[rowR, colR - 3] != slotFull && this.field[rowR + 1, colR - 3] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR, colR - 1] = this.field[rowR, colR - 2] = slotFull;

                        this.field[rowR - 1, colR] = this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR - 2] = this.field[rowR - 1, colR - 3] = slotOccuppied;
                        this.field[rowR, colR - 3] = slotOccuppied;
                        this.field[rowR + 1, colR] = this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR - 2] = this.field[rowR + 1, colR - 3] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 0 && colR == 1 &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull && this.field[rowR, colR + 2] != slotFull) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull && this.field[rowR - 1, colR + 2] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull && this.field[rowR + 1, colR + 2] != slotFull))
                    {
                        this.field[rowR, colR - 1] = this.field[rowR, colR] = this.field[rowR, colR + 1] = slotFull;
                        this.field[rowR, colR + 2] = slotOccuppied;
                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = this.field[rowR - 1, colR + 2] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = this.field[rowR + 1, colR + 2] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 0 && colR == 8 && rowR != 0 && rowR != 8 &&
                        (this.field[rowR, colR - 2] != slotFull && this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR - 1, colR - 2] != slotFull && this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 2] != slotFull && this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR - 1] = this.field[rowR, colR] = this.field[rowR, colR + 1] = slotFull;
                        this.field[rowR, colR - 2] = slotOccuppied;
                        this.field[rowR - 1, colR - 2] = this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 2] = this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 0 && (colR == 2 || colR == 3 || colR == 4 || colR == 5 || colR == 6 || colR == 7) && (rowR != 0) && (rowR != 9) && 
                        (this.field[rowR, colR - 2] != slotFull && this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull && this.field[rowR, colR + 2] != slotFull) &&
                        (this.field[rowR - 1, colR - 2] != slotFull && this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull && this.field[rowR - 1, colR + 2] != slotFull) &&
                        (this.field[rowR + 1, colR - 2] != slotFull && this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull && this.field[rowR + 1, colR + 2] != slotFull))
                    {
                        this.field[rowR, colR - 1] = this.field[rowR, colR] = this.field[rowR, colR + 1] = slotFull;

                        this.field[rowR, colR - 2] = this.field[rowR, colR + 2] = slotOccuppied;
                        this.field[rowR - 1, colR - 2] = this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = this.field[rowR - 1, colR + 2] = slotOccuppied;
                        this.field[rowR + 1, colR - 2] = this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = this.field[rowR + 1, colR + 2] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 1 && rowR == 1 &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull) &&
                        (this.field[rowR + 2, colR - 1] != slotFull && this.field[rowR + 2, colR] != slotFull && this.field[rowR + 2, colR + 1] != slotFull))
                    {
                        this.field[rowR - 1, colR] = this.field[rowR, colR] = this.field[rowR + 1, colR] = slotFull;

                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR + 1] = slotOccuppied;
                        this.field[rowR + 2, colR - 1] = this.field[rowR + 2, colR] = this.field[rowR + 2, colR + 1] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 1 && rowR == 8 && (colR != 0) && (colR != 9) &&
                        (this.field[rowR - 2, colR - 1] != slotFull && this.field[rowR - 2, colR] != slotFull && this.field[rowR - 2, colR + 1] != slotFull) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull))
                    {
                        this.field[rowR - 1, colR] = this.field[rowR, colR] = this.field[rowR + 1, colR] = slotFull;

                        this.field[rowR - 2, colR - 1] = this.field[rowR - 2, colR] = this.field[rowR - 2, colR + 1] = slotOccuppied;
                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR + 1] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 1 && (rowR == 2 || rowR == 3 || rowR == 4 || rowR == 5 || rowR == 6 || rowR == 7) && (colR != 0) && (colR != 9) &&
                        (this.field[rowR - 2, colR - 1] != slotFull && this.field[rowR - 2, colR] != slotFull && this.field[rowR - 2, colR + 1] != slotFull) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull) &&
                        (this.field[rowR + 2, colR - 1] != slotFull && this.field[rowR + 2, colR] != slotFull && this.field[rowR + 2, colR + 1] != slotFull))
                    {
                        this.field[rowR - 1, colR] = this.field[rowR, colR] = this.field[rowR + 1, colR] = slotFull;

                        this.field[rowR - 2, colR - 1] = this.field[rowR - 2, colR] = this.field[rowR - 2, colR + 1] = slotOccuppied;
                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR + 1] = slotOccuppied;
                        this.field[rowR + 2, colR - 1] = this.field[rowR + 2, colR] = this.field[rowR + 2, colR + 1] = slotOccuppied;

                        break;
                    }
                }
            }

            AddSlotsFullToList();

            // 3 x SHIP
            for (int j = 1; j <= 3; j++)
            {
                while (true)
                {
                    int rowR = rndm.Next(0, 10);
                    int colR = rndm.Next(0, 10);
                    int horizontalOrVertical = rndm.Next(0, 2);
                    int zeroOrOne = rndm.Next(0, 2);

                    if ((rowR == 0 && colR == 0) || (rowR == 0 && colR == 9) || (rowR == 9 && colR == 0) || (rowR == 9 && colR == 9))
                    {
                        continue;
                    } // CORNER ISSUE - TRY AGAIN
                    else if (rowR == 0 &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull) &&
                        (this.field[rowR + 2, colR - 1] != slotFull && this.field[rowR + 2, colR] != slotFull && this.field[rowR + 2, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR + 1, colR] = slotFull;

                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR + 1] = this.field[rowR + 2, colR - 1] = this.field[rowR + 2, colR + 1] = this.field[rowR + 2, colR] = slotOccuppied;

                        break;
                    }
                    else if (rowR == 9 &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR - 2, colR - 1] != slotFull && this.field[rowR - 2, colR] != slotFull && this.field[rowR - 2, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR - 1, colR] = slotFull;

                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR + 1] = this.field[rowR - 2, colR - 1] = this.field[rowR - 2, colR + 1] = this.field[rowR - 2, colR] = slotOccuppied;

                        break;
                    }
                    else if (colR == 0 &&
                        (this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull && this.field[rowR - 1, colR + 2] != slotFull) &&
                        (this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull && this.field[rowR, colR + 2] != slotFull) &&
                        (this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull && this.field[rowR + 1, colR + 2] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR, colR + 1] = slotFull;

                        this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = this.field[rowR - 1, colR + 2] = slotOccuppied;
                        this.field[rowR, colR + 2] = slotOccuppied;
                        this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = this.field[rowR + 1, colR + 2] = slotOccuppied;

                        break;
                    }
                    else if (colR == 9 &&
                        (this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR - 2] != slotFull) &&
                        (this.field[rowR, colR] != slotFull && this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR - 2] != slotFull) &&
                        (this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR - 2] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR, colR - 1] = slotFull;

                        this.field[rowR - 1, colR] = this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR - 2] = slotOccuppied;
                        this.field[rowR, colR - 2] = slotOccuppied;
                        this.field[rowR + 1, colR] = this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR - 2] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 0 && (colR == 1 || colR == 2 || colR == 3 || colR == 4 || colR == 5 || colR == 6 || colR == 7) && (rowR != 0) && (rowR != 9) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull && this.field[rowR - 1, colR + 2] != slotFull) &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull && this.field[rowR, colR + 2] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull && this.field[rowR + 1, colR + 2] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR, colR + 1] = slotFull;

                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = this.field[rowR - 1, colR + 2] = slotOccuppied;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 2] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = this.field[rowR + 1, colR + 2] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 0 && (colR == 8) && (rowR != 0) && (rowR != 9) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR, colR + 1] = slotFull;

                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR, colR - 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 1 && (rowR == 1 || rowR == 2 || rowR == 3 || rowR == 4 || rowR == 5 || rowR == 6 || rowR == 7) && (colR != 0) && (colR != 9) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR -1, colR + 1] != slotFull) &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull) &&
                        (this.field[rowR + 2, colR - 1] != slotFull && this.field[rowR + 2, colR] != slotFull && this.field[rowR + 2, colR] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR + 1, colR] = slotFull;

                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR + 1] = slotOccuppied;
                        this.field[rowR + 2, colR - 1] = this.field[rowR + 2, colR] = this.field[rowR + 2, colR + 1] = slotOccuppied;

                        break;
                    }
                    else if (horizontalOrVertical == 1 && (rowR == 8) && (colR != 0) && (colR != 9) &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = this.field[rowR + 1, colR] = slotFull;

                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR + 1] = slotOccuppied;

                        break;
                    }
                }
            }

            AddSlotsFullToList();

            // 4 x BOAT
            for (int k = 1; k <= 4; k++)
            {
                while (true)
                {
                    int rowR = rndm.Next(0, 10);
                    int colR = rndm.Next(0, 10);

                    if (rowR == 0 && colR == 0 && this.field[0, 0] != slotFull && this.field[0, 1] != slotFull && this.field[1, 0] != slotFull && this.field[1, 1] != slotFull)
                    {
                        this.field[0, 0] = slotFull;
                        this.field[0, 1] = this.field[1, 0] = this.field[1, 1] = slotOccuppied;
                        break;
                    }
                    else if (rowR == 0 && colR == 9 && this.field[0, 9] != slotFull && this.field[0, 8] != slotFull && this.field[1, 9] != slotFull && this.field[1, 8] != slotFull)
                    {
                        this.field[0, 9] = slotFull;
                        this.field[0, 8] = this.field[1, 8] = this.field[1, 9] = slotOccuppied;
                        break;
                    }                    
                    else if (rowR == 9 && colR == 0 && this.field[9, 0] != slotFull && this.field[9, 1] != slotFull && this.field[8, 0] != slotFull && this.field[8, 1] != slotFull)
                    {
                        this.field[9, 0] = slotFull;
                        this.field[9, 1] = this.field[8, 0] = this.field[8, 1] = slotOccuppied;
                        break;
                    }
                    else if (rowR == 9 && colR == 9 && this.field[9, 9] != slotFull && this.field[9, 8] != slotFull && this.field[8, 9] != slotFull && this.field[8, 8] != slotFull)
                    {
                        this.field[9, 9] = slotFull;
                        this.field[8, 8] = this.field[8, 9] = this.field[9, 8] = slotOccuppied;
                        break;
                    }
                    else if (rowR == 0 && colR != 0 && colR != 9 &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull && this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull & this.field[rowR + 1, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = slotFull;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = slotOccuppied;
                        break;
                    }
                    else if (rowR == 9 && colR != 0 && colR != 9 &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull && this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull & this.field[rowR - 1, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = slotFull;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        break;
                    }
                    else if (colR == 0 && rowR != 0 && rowR != 9 &&
                        (this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull && this.field[rowR + 1, colR] != slotFull & this.field[rowR + 1, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = slotFull;
                        this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = this.field[rowR, colR + 1] = this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = slotOccuppied;
                        break;
                    }
                    else if (colR == 9 && rowR != 0 && rowR != 9 &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR + 1, colR - 1] != slotFull & (this.field[rowR + 1, colR] != slotFull)))
                    {
                        this.field[rowR, colR] = slotFull;
                        this.field[rowR - 1, colR] = this.field[rowR - 1, colR - 1] = this.field[rowR, colR - 1] = this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR] = slotOccuppied;
                        break;
                    }
                    else if (colR != 0 && colR != 9 && rowR != 0 && rowR != 9 &&
                        (this.field[rowR - 1, colR - 1] != slotFull && this.field[rowR - 1, colR] != slotFull && this.field[rowR - 1, colR + 1] != slotFull) &&
                        (this.field[rowR, colR - 1] != slotFull && this.field[rowR, colR] != slotFull && this.field[rowR, colR + 1] != slotFull) &&
                        (this.field[rowR + 1, colR - 1] != slotFull && this.field[rowR + 1, colR] != slotFull && this.field[rowR + 1, colR + 1] != slotFull))
                    {
                        this.field[rowR, colR] = slotFull;
                        this.field[rowR - 1, colR - 1] = this.field[rowR - 1, colR] = this.field[rowR - 1, colR + 1] = slotOccuppied;
                        this.field[rowR, colR - 1] = this.field[rowR, colR + 1] = slotOccuppied;
                        this.field[rowR + 1, colR - 1] = this.field[rowR + 1, colR] = this.field[rowR + 1, colR + 1] = slotOccuppied;
                        break;
                    }                   
                }
            }

            SetLettersToFullSlots();
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
                    mySB.Append(slotEmpty);
                }
                mySB.Append("║");
                mySB.AppendLine();
            }

            mySB.AppendLine($"   ╚═══╩═════════════════════╝");
            return mySB.ToString().TrimEnd();
        }
    }
}
