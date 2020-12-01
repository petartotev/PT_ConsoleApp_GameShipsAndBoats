namespace GameShipsAndBoats.Game.Core
{
    public static class BattlefieldValidator
    {
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
    }
}
