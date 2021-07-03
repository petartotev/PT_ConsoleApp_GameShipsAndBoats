using GameShipsAndBoats.Game.Core;
using GameShipsAndBoats.Game.Models.Base;
using GameShipsAndBoats.Game.Models.Common;
using System;

namespace GameShipsAndBoats.Game.Models
{
    public class Opponent : BasePlayer
    {
        public override void Attack(int row, int col, string resultSlot)
        {
            if (!BattlefieldValidator.CheckIfSlotIsInsideOfMatrix(row, col))
            {
                throw new ArgumentOutOfRangeException(GameElements.ErrorMessages.CoordinatesOutOfRange);
            }
            if (resultSlot == null)
            {
                throw new ArgumentNullException(GameElements.ErrorMessages.SlotResultNullOrEmpty);
            }

            if (resultSlot == BattlefieldElements.slotBoat)
            {
                _opponentBattlefield.SetBotOpponentSlotsAllAroundToDot(row, col);
            } // BOAT
            else if (BattlefieldElements.listSlotsVessels.Contains(resultSlot))
            {
                if (BattlefieldValidator.CheckIfSlotIsInTheMiddle(row, col))
                {
                    _opponentBattlefield.SetBotOpponentSlotsDiagonalToDot(row, col);

                    if (resultSlot == BattlefieldElements.slotCarrier)
                    {
                        _opponentBattlefield.SetBotOpponentSlotsIfAnotherCarrierAround(row, col);
                    }
                } // OTHER VESSEL IN THE MIDDLE
                else if (BattlefieldValidator.CheckIfSlotIsOnEdge(row, col))
                {
                    _opponentBattlefield.SetBotOpponentSlotsVesselOnEdgeToDot(row, col, resultSlot);
                } // OTHER VESSEL ON EDGE
            } // OTHER VESSEL

            _opponentBattlefield.SetSlot(row, col, resultSlot);
        }
    }
}
