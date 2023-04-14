using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    public class PassLineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PassLineBet_CanPlace_BeforePointEstablished()
        {
            //Arrange
            Table table = new Table();

            PassLine pass = new PassLine(table);

            //Act & Assert
            Assert.IsTrue(pass.CanPlaceBet());
        }

        [Test]
        public void PassLineBet_CantPlace_AfterPointEstablished()
        {
            //Arrange
            Table table = new Table();
            table.Point = 4;

            PassLine pass = new PassLine(table);

            //Act & Assert
            Assert.IsFalse(pass.CanPlaceBet());            
        }

        [Test]
        public void PassLineBet_Wins1x_On7_BeforePointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            PassLine pass = new PassLine(table);
            pass.Wager = wager;

            Dice dice = new Dice(3, 4);

            //Act
            pass.ProcessRoll(dice);
            BetOutcome outcome = pass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }

        [Test]
        public void PassLineBet_Loses_On2_BeforePointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            PassLine pass = new PassLine(table);
            pass.Wager = wager;

            Dice dice = new Dice(1, 1);

            //Act
            pass.ProcessRoll(dice);
            BetOutcome outcome = pass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void PassLineBet_NoAction_On5()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            PassLine pass = new PassLine(table);
            pass.Wager = wager;

            Dice dice = new Dice(1, 4);

            //Act
            pass.ProcessRoll(dice);
            BetOutcome outcome = pass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void PassLineBet_NoAction_On2_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            PassLine pass = new PassLine(table);
            pass.Wager = wager;

            Dice dice = new Dice(1, 1);

            //Act
            pass.ProcessRoll(dice);
            BetOutcome outcome = pass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void PassLineBet_Loses_On7_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            PassLine pass = new PassLine(table);
            pass.Wager = wager;

            Dice dice = new Dice(3, 4);

            //Act
            pass.ProcessRoll(dice);
            BetOutcome outcome = pass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void PassLineBet_Wins1x_OnPoint_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 8;

            PassLine pass = new PassLine(table);
            pass.Wager = wager;

            Dice dice = new Dice(4, 4);

            //Act
            pass.ProcessRoll(dice);
            BetOutcome outcome = pass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }
    }
}
