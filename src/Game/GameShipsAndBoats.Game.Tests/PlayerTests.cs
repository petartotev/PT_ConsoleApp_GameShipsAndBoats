using GameShipsAndBoats.Game.Models;
using NUnit.Framework;
using System;

namespace GameShipsAndBoats.Game.Tests
{
    public class PlayerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(-1, 0, "test")]
        [TestCase(0, -1, "test")]
        public void BotAttackWithRowOrColAreNotFromZeroToNine_ThrowsArgumentOutOfRangeException(int row, int col, string result)
        {
            Player testPlayer = new Player();
            Assert.Throws<ArgumentOutOfRangeException>(() => testPlayer.BotAttack(row, col, result));
        }

        [TestCase(0, 0, null)]
        [TestCase(9, 9, null)]
        public void BotAttackWithResultEqualsNull_ThrowsArgumentNullException(int row, int col, string result)
        {
            Player testPlayer = new Player();
            Assert.Throws<ArgumentNullException>(() => testPlayer.BotAttack(row, col, result));
        }
    }
}