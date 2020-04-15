using System;
using System.Collections.Generic;
using System.Text;

namespace PT_Console_App_ShipsAndBoatsGame
{
    public interface IPlayer
    {
        public void Attack(int row, int col, string result);

        public string GetAttackMessage(string result);

        public string GetAttacked(int row, int col);

        public bool CheckIfWinner();
    }
}
