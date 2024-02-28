namespace GameShipsAndBoats.Game.Models.Common
{
    public static class GameElements
    {
        public const string Title = "   SHIPS AND BOATS BATTLEFIELD";
        public const string LineSolid = " ───────────────────────────────";
        public const string Credits = "        www.petartotev.net";
        public const string PressAnyKey = "\r\n   Press any key to continue...";

        public const string Legend = "   Legend:\r\n" +
                                     "   ┌─────────────────────────┐\r\n" +
                                     "   │ 1 x T T T T      Tanker │\r\n" +
                                     "   │ 2 x S S S     Submarine │\r\n" +
                                     "   │ 3 x C C         Carrier │\r\n" +
                                     "   │ 4 x B              Boat │\r\n" +
                                     "   └─────────────────────────┘";

        public const string Menu = "   Menu:\r\n" +
                                   "   ┌───────┬─────────────────┐\r\n" +
                                   "   │ Space │ Play            │\r\n" +
                                   "   │  I/i  │ Instructions    │\r\n" +
                                   "   │  S/s  │ Statistics      │\r\n" +
                                   "   │  Esc  │ Exit            │\r\n" +
                                   "   └───────┴─────────────────┘";

        public const string Statistics = "   Statistics:\r\n" +
                                         "   ┌────────────┬────────────┐\r\n" +
                                         "   │            │            │\r\n" +
                                         "   │    YOU     │     PC     │\r\n" +
                                         "   │                         │\r\n" +
                                         "   │    {0}     :     {1}    │\r\n" +
                                         "   │                         │\r\n" +
                                         "   └────────────┴────────────┘";

        public static class ErrorMessages
        {
            public const string CoordinatesOutOfRange = "The coordinates of the battlefield are out of range!";
            public const string SlotResultNullOrEmpty = "The slot result could not be null or empty.";
            public const string InvalidInput = " Invalid input!";
        }
    }
}
