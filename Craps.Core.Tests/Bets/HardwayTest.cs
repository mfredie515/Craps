using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    internal class HardwayTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HardwayBet_CantPlace_BeforePointEstablished()
        {
            //Arrange
            Table table = new Table();

            Hardway hardway = new Hardway(table, Hardway.HardwaysValue.Hard4);

            //Act & Assert
            Assert.IsFalse(hardway.CanPlaceBet());
        }

        [Test]
        public void HardwayBet_CanPlace_AfterPointEstablished()
        {
            //Arrange
            Table table = new Table();
            table.Point = 4;

            Hardway hardway = new Hardway(table, Hardway.HardwaysValue.Hard4);

            //Act & Assert
            Assert.IsTrue(hardway.CanPlaceBet());
        }

        [Test]
        public void HardwayBet_Loses_On7()
        {
            //Arrange
            Table table = new Table();

            Hardway hardway = new Hardway(table, Hardway.HardwaysValue.Hard4);
            hardway.Wager = 15;

            Dice dice = new Dice(3, 4);

            //Act
            hardway.ProcessRoll(dice);
            BetOutcome outcome = hardway.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void HardwayBet_Loses_OnEasy8()
        {
            //Arrange
            Table table = new Table();

            Hardway hardway = new Hardway(table, Hardway.HardwaysValue.Hard8);
            hardway.Wager = 15;

            Dice dice = new Dice(3, 5);

            //Act
            hardway.ProcessRoll(dice);
            BetOutcome outcome = hardway.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void HardwayBet_Wins_OnHard10()
        {
            //Arrange
            Table table = new Table();

            Hardway hardway = new Hardway(table, Hardway.HardwaysValue.Hard10);
            hardway.Wager = 15;

            Dice dice = new Dice(5, 5);

            //Act
            hardway.ProcessRoll(dice);
            BetOutcome outcome = hardway.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win);
        }

        [Test]
        public void HardwayBet_NoAction_OnNotNumber()
        {
            //Arrange
            Table table = new Table();

            Hardway hardway = new Hardway(table, Hardway.HardwaysValue.Hard4);
            hardway.Wager = 15;

            Dice dice = new Dice(2, 4);

            //Act
            hardway.ProcessRoll(dice);
            BetOutcome outcome = hardway.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void HardwayBet_Payout()
        {
            //Arrange
            int wager = 1;
            Table table = new Table();

            Hardway hard4 = new Hardway(table, Hardway.HardwaysValue.Hard4);
            Hardway hard6 = new Hardway(table, Hardway.HardwaysValue.Hard6);
            Hardway hard8 = new Hardway(table, Hardway.HardwaysValue.Hard8);
            Hardway hard10 = new Hardway(table, Hardway.HardwaysValue.Hard10);

            hard4.Wager = wager;
            hard6.Wager = wager;
            hard8.Wager = wager;
            hard10.Wager = wager;

            Dice d4 = new Dice(2, 2);
            Dice d6 = new Dice(3, 3);
            Dice d8 = new Dice(4, 4);
            Dice d10 = new Dice(5, 5);

            //Act
            hard4.ProcessRoll(d4);
            hard6.ProcessRoll(d6);
            hard8.ProcessRoll(d8);
            hard10.ProcessRoll(d10);
            BetOutcome outcome4 = hard4.BetOutcome;
            BetOutcome outcome6 = hard6.BetOutcome;
            BetOutcome outcome8 = hard8.BetOutcome;
            BetOutcome outcome10 = hard10.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(outcome4.Payout, Is.EqualTo(7 * wager));
                Assert.That(outcome6.Payout, Is.EqualTo(9 * wager));
                Assert.That(outcome8.Payout, Is.EqualTo(9 * wager));
                Assert.That(outcome10.Payout, Is.EqualTo(7 * wager));
            });
        }
    }
}
