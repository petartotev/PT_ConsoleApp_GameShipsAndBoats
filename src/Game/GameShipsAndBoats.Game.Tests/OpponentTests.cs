using GameShipsAndBoats.Game.Models;
using NUnit.Framework;
using System;

namespace GameShipsAndBoats.Game.Tests
{
    public class OpponentTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(-1, 0, "test")]
        [TestCase(0, -1, "test")]
        public void BotAttackWithRowOrColAreNotFromZeroToNine_ThrowsArgumentOutOfRangeException(int row, int col, string result)
        {
            Opponent testOpponent = new Opponent();
            Assert.Throws<ArgumentOutOfRangeException>(() => testOpponent.Attack(row, col, result));
        }

        [TestCase(0, 0, null)]
        [TestCase(9, 9, null)]
        public void BotAttackWithResultEqualsNull_ThrowsArgumentNullException(int row, int col, string result)
        {
            Opponent testOpponent = new Opponent();
            Assert.Throws<ArgumentNullException>(() => testOpponent.Attack(row, col, result));
        }
    }
}