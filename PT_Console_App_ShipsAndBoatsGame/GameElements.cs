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

        public static string GetInvalidMessage()
        {
            StringBuilder invalidMessage = new StringBuilder();
            invalidMessage.AppendLine($"Invalid!");

            return invalidMessage.ToString().TrimEnd();
        }
    }
}
