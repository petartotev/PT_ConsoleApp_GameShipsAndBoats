using GameShipsAndBoats.Game.Core;
using GameShipsAndBoats.Game.Models.Common;
using GameShipsAndBoats.Game.Models.Contracts;

namespace GameShipsAndBoats.Game.Models.Base
{
    public abstract class BasePlayer : IPlayer
    {
        protected readonly Battlefield _playerBattlefield;
        protected readonly Battlefield _opponentBattlefield;

        public BasePlayer()
        {
            _playerBattlefield = BattlefieldGenerator.GenerateNewBattlefield();
            _opponentBattlefield = new Battlefield();
        }

        public Battlefield PlayerBattlefield
        {
            get => _playerBattlefield;
        }

        public Battlefield EnemyBattlefield
        {
            get => _opponentBattlefield;
        }

        public abstract void Attack(int row, int col, string result);

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

        public string GetAttackedMessage(string result)
        {
            return result switch
            {
                BattlefieldElements.slotTanker => " hit a Tanker (TTTT)!",
                BattlefieldElements.slotSubmarine => " hit a Submarine (SSS)!",
                BattlefieldElements.slotCarrier => " hit a Carrier (CC)!",
                BattlefieldElements.slotBoat => " hit a Boat (B)!",
                BattlefieldElements.slotHit => " already hit that!",
                _ => " didn't hit anything..."
            };
        }
    }
}
