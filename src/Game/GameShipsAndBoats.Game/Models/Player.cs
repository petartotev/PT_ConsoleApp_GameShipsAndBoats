using GameShipsAndBoats.Game.Core;
using GameShipsAndBoats.Game.Models.Common;
using GameShipsAndBoats.Game.Models.Contracts;
using System;

namespace GameShipsAndBoats.Game.Models
{
    public class Player : IPlayer
    {
        private readonly Battlefield _playerBattlefield;
        private readonly Battlefield _opponentBattlefield;

        public Player()
        {
            _playerBattlefield = BattlefieldGenerator.GenerateNewBattlefield();
            _opponentBattlefield = new Battlefield();
        }

        public Battlefield PlayerBattlefield
        {
            get => _playerBattlefield;
        }

        public Battlefield OpponentBattlefield
        {
            get => _opponentBattlefield;
        }

        public void Attack(int row, int col, string vessel)
        {
            _opponentBattlefield.SetSlot(row, col, vessel);
        }

        public void BotAttack(int row, int col, string resultSlot)
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

        public bool CheckIfWinner()
        {
            int hitTargets = 0;

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (BattlefieldElements.listSlotsVessels.Contains(_opponentBattlefield.GetSlot(row, col)))
                    {
                        hitTargets++;
                    }
                }
            }

            // 20 SLOTS = (4)TTTT + (2 * (3)SSS) + (3 * (2)CC) + (4 * (1)B)
            return hitTargets == 20;
        }

        public string GetAttacked(int row, int col)
        {
            string slotResult = _playerBattlefield.GetSlot(row, col);

            if (BattlefieldElements.listSlotsVessels.Contains(slotResult))
            {
                _playerBattlefield.SetSlot(row, col, BattlefieldElements.slotHit);
                return slotResult;
            }
            else
            {
                _playerBattlefield.SetSlot(row, col, BattlefieldElements.slotOpponentPlus);
                return BattlefieldElements.slotOpponentMinus;
            }
        }

        public string GetAttackMessage(string vessel)
        {
            return vessel switch
            {
                BattlefieldElements.slotTanker => " hit a Tanker (TTTT)!",
                BattlefieldElements.slotSubmarine => " hit a Submarine (SSS)!",
                BattlefieldElements.slotCarrier => " hit a Carrier (CC)!",
                BattlefieldElements.slotBoat => " hit a Boat (B)!",
                BattlefieldElements.slotHit => " already hit that!",
                _ => " didn't hit anything..."
            };
        }

        public void MarkShipOnEdgeAsDestroyed(int row, int col, string vessel)
        {
            int lengthVessel = BattlefieldElements.GetVesselLength(vessel);

            if (BattlefieldElements.listSlotsVessels.Contains(vessel))
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