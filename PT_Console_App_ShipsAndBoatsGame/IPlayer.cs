
namespace PT_Console_App_ShipsAndBoatsGame
{
    public interface IPlayer
    {
        public void Attack(int row, int col, string result);

        public string GetAttacked(int row, int col);

        public void BotAttack(int row, int col, string result);

        public string GetAttackMessage(string result);
                
        public bool CheckIfWinner();
    }
}
