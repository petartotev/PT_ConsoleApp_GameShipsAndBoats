using GameShipsAndBoats.Game.Models.Base;
using GameShipsAndBoats.Game.Models.Common;

namespace GameShipsAndBoats.Game.Models
{
    public class Player : BasePlayer
    {
        public override void Attack(int row, int col, string result)
        {
            _opponentBattlefield.SetSlot(row, col, result);
        }

        public void MarkShipOnEdgeAsDestroyed(int row, int col, string result)
        {
            int lengthVessel = BattlefieldElements.GetVesselLength(result);

            if (BattlefieldElements.listSlotsVessels.Contains(result))
            {
                // TOP EDGE
                if (row == 0 && (col > 0 && col < 9))
                {
                    for (int r = 0; r < lengthVessel; r++)
                    {
                        _playerBattlefield.SetSlot(r, col, BattlefieldElements.slotHit);
                    }
                }
                // BOTTOM EDGE
                else if (row == 9 && (col > 0 && col < 9))
                {
                    for (int r = 9; r > 9 - lengthVessel; r--)
                    {
                        _playerBattlefield.SetSlot(r, col, BattlefieldElements.slotHit);
                    }
                }
                // LEFT EDGE
                else if (col == 0 && (row > 0 && row < 9))
                {
                    for (int c = 0; c < lengthVessel; c++)
                    {
                        _playerBattlefield.SetSlot(row, c, BattlefieldElements.slotHit);
                    }
                }
                // RIGHT EDGE
                else if (col == 9 && (row > 0 && row < 9))
                {
                    for (int c = 9; c > 9 - lengthVessel; c--)
                    {
                        _playerBattlefield.SetSlot(row, c, BattlefieldElements.slotHit);
                    }
                }
            }
        }
    }
}