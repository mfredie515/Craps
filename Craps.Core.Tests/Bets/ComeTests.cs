using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    public class ComeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComeBet_CantPlace_BeforePointEstablished()
        {
            //Arrange
            Table table = new Table();

            Come come = new Come(table);

            //Act & Assert
            Assert.IsFalse(come.CanPlaceBet());
        }

        [Test]
        public void ComeBet_CanPlace_AfterPointEstablished()
        {
            //Arrange
            Table table = new Table();
            table.Point = 4;

            Come come = new Come(table);

            //Act & Assert
            Assert.IsTrue(come.CanPlaceBet());
        }

        [Test]
        public void ComeBet_Wins1x_On7_NotOnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Come come = new Come(table);
            come.Wager = wager;

            Dice dice = new Dice(3, 4);

            //Act
            come.ProcessRoll(dice);
            BetOutcome outcome = come.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }

        [Test]
        public void ComeBet_Loses_On2_NotOnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Come come = new Come(table);
            come.Wager = wager;

            Dice dice = new Dice(1, 1);

            //Act
            come.ProcessRoll(dice);
            BetOutcome outcome = come.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void ComeBet_NoAction_On5_MovesToPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Come come = new Come(table);
            come.Wager = wager;

            Dice dice = new Dice(1, 4);

            //Act
            come.ProcessRoll(dice);
            BetOutcome outcome = come.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction && come.Point == 5);
        }

        [Test]
        public void ComeBet_NoAction_On2_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Come come = new Come(table);
            come.Wager = wager;
            come.Point = 5;


            Dice dice = new Dice(1, 1);

            //Act
            come.ProcessRoll(dice);
            BetOutcome outcome = come.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void ComeBet_Loses_On7_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Come come = new Come(table);
            come.Wager = wager;
            come.Point = 5;

            Dice dice = new Dice(3, 4);

            //Act
            come.ProcessRoll(dice);
            BetOutcome outcome = come.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void ComeBet_Wins1x_OnPoint_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Come come = new Come(table);
            come.Wager = wager;
            come.Point = 8;

            Dice dice = new Dice(4, 4);

            //Act
            come.ProcessRoll(dice);
            BetOutcome outcome = come.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }
    }
}
