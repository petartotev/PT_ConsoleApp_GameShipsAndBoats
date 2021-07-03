namespace GameShipsAndBoats.Game.Models.Contracts
{
    public interface IPlayer
    {
        Battlefield EnemyBattlefield { get; }

        Battlefield PlayerBattlefield { get; }

        void Attack(int row, int col, string result);

        bool CheckIfWinner();

        string GetAttacked(int row, int col);

        string GetAttackedMessage(string result);
    }
}
