namespace GameShipsAndBoats.Game.Models.Contracts
{
    public interface IBattlefield
    {
        string GetSlot(int row, int col);

        void SetSlot(int row, int col, string value);
    }
}
