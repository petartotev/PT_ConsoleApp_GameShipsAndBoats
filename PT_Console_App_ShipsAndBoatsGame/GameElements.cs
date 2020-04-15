using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
            StringBuilder menuMain = new StringBuilder();
            menuMain.AppendLine($"   Menu: ");
            menuMain.AppendLine($"   ┌───────┬─────────────────┐");
            menuMain.AppendLine($"   │ Space │ Play            │");
            menuMain.AppendLine($"   │  I/i  │ Instructions    │");
            menuMain.AppendLine($"   │  S/s  │ Statistics      │");
            menuMain.AppendLine($"   │  Esc  │ Exit            │");
            menuMain.AppendLine($"   └───────┴─────────────────┘");

            return menuMain.ToString().TrimEnd();
        }

        public static string GetInvalidMessage()
        {
            StringBuilder mySB = new StringBuilder();
            mySB.AppendLine($"Invalid!");

            return mySB.ToString().TrimEnd();
        }
    }
}
