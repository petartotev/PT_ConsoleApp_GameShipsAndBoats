using System.Data.SqlClient;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public static class GameElements
    {
        public static string GetTitle()
        {
            StringBuilder title = new StringBuilder();
            title.AppendLine($"   SHIPS AND BOATS BATTLEFIELD");
            return title.ToString().TrimEnd();
        }

        public static string GetLineEmpty()
        {
            StringBuilder lineEmpty = new StringBuilder();
            lineEmpty.AppendLine();
            return lineEmpty.ToString();
        }        

        public static string GetLineSolid()
        {
            StringBuilder lineSolid = new StringBuilder();
            lineSolid.AppendLine(" " + new string('─', 31));
            return lineSolid.ToString().TrimEnd();
        }

        public static string GetCredits()
        {
            StringBuilder credits = new StringBuilder();
            credits.AppendLine($"        www.petartotev.net");
            return credits.ToString().TrimEnd();
        }

        public static string GetLegend()
        {
            StringBuilder legend = new StringBuilder();
            legend.AppendLine($"   Legend: ");
            legend.AppendLine($"   ┌─────────────────────────┐");
            legend.AppendLine($"   │ 1 x T T T T     (Tanker)│");
            legend.AppendLine($"   │ 2 x S S S    (Submarine)│");
            legend.AppendLine($"   │ 3 x C C   (Carrier ship)│");
            legend.AppendLine($"   │ 4 x B             (Boat)│");
            legend.AppendLine($"   └─────────────────────────┘");
            return legend.ToString().TrimEnd();
        }

        public static string GetMenu()
        {
            StringBuilder menu = new StringBuilder();
            menu.AppendLine($"   Menu: ");
            menu.AppendLine($"   ┌───────┬─────────────────┐");
            menu.AppendLine($"   │ Space │ Play            │");
            menu.AppendLine($"   │  I/i  │ Instructions    │");
            menu.AppendLine($"   │  S/s  │ Statistics      │");
            menu.AppendLine($"   │  Esc  │ Exit            │");
            menu.AppendLine($"   └───────┴─────────────────┘");
            return menu.ToString().TrimEnd();
        }

        public static string GetStatistics()
        {
            int gamesWon = 0;
            int gamesLost = 0;

            var connection = new SqlConnection("Server=PT\\SQLEXPRESS;Database=ShipsAndBoatsGame;Integrated Security=True;");

            connection.Open();

            using (connection)
            {
                var commandGetWonResult = new SqlCommand("SELECT Won FROM Statisticsss WHERE ID=1", connection);
                var resultWon = commandGetWonResult.ExecuteScalar();
                gamesWon = (int)resultWon;

                var commandGetLostResult = new SqlCommand("SELECT Lost FROM Statisticsss WHERE ID=1", connection);
                var resultLost = commandGetLostResult.ExecuteScalar();
                gamesLost = (int)resultLost;

            }

            StringBuilder statistics = new StringBuilder();
            statistics.AppendLine($"   Statistics: ");
            statistics.AppendLine($"   ┌────────────┬────────────┐");
            statistics.AppendLine($"   │            │            │");
            statistics.AppendLine($"   │    YOU     │     PC     │");
            statistics.AppendLine($"   │                         │");
            statistics.AppendLine($"   │    {gamesWon:D4}    :    {gamesLost:D4}    │");
            statistics.AppendLine($"   │                         │");
            statistics.AppendLine($"   └────────────┴────────────┘");

            return statistics.ToString().TrimEnd();
        }

        public static string GetInvalidMessage()
        {
            StringBuilder invalidMessage = new StringBuilder();
            invalidMessage.AppendLine($" Invalid!");
            return invalidMessage.ToString().TrimEnd();
        }

        public static string GetPressKeyMessage()
        {
            StringBuilder invalidMessage = new StringBuilder();
            invalidMessage.AppendLine($"\n   Press any key to continue...");
            return invalidMessage.ToString().TrimEnd();
        }
    }
}
