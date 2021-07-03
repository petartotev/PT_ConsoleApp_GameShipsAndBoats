namespace GameShipsAndBoats.Game.Models.Contracts
{
    public interface IPlayer
    {
        Battlefield PlayerBattlefield { get; }

        Battlefield EnemyBattlefield { get; }

        void Attack(int row, int col, string result);

        string GetAttacked(int row, int col);

        string GetAttackedMessage(string result);

        bool CheckIfWinner();
    }
}
