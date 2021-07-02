using System.Collections.Generic;

namespace GameShipsAndBoats.Game.Models.Common
{
    public static class BattlefieldElements
    {
        public const string slotTanker = "T ";
        public const string slotSubmarine = "S ";
        public const string slotCarrier = "C ";
        public const string slotBoat = "B ";
        public const string slotHit = "X ";

        public const string slotEmpty = "  ";
        public const string slotHidden = "/ ";
        public const string slotOccuppied = ". ";

        public const string slotOpponentPlus = "+ ";
        public const string slotOpponentMinus = "- ";

        public static readonly List<string> listSlotsVessels = new List<string> { slotTanker, slotSubmarine, slotCarrier, slotBoat, slotHit };

        public static int GetVesselLength(string vessel)
        {
            return vessel switch
            {
                slotTanker => 4,
                slotSubmarine => 3,
                slotCarrier => 2,
                slotBoat => 1,
                slotHit => 1,
                _ => 0
            };
        }
    }
}
