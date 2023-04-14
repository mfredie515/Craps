using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    public class DontPassLineTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DontPassLineBet_CanPlace_BeforePointEstablished()
        {
            //Arrange
            Table table = new Table();

            DontPassLine dPass = new DontPassLine(table);

            //Act & Assert
            Assert.IsTrue(dPass.CanPlaceBet());
        }

        [Test]
        public void DontPassLineBet_CantPlace_AfterPointEstablished()
        {
            //Arrange
            Table table = new Table();
            table.Point = 4;

            DontPassLine dPass = new DontPassLine(table);

            //Act & Assert
            Assert.IsFalse(dPass.CanPlaceBet());
        }

        [Test]
        public void DontPassLineBet_Wins1x_On2_BeforePointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontPassLine dPass = new DontPassLine(table);
            dPass.Wager = wager;

            Dice dice = new Dice(1, 1);

            //Act
            dPass.ProcessRoll(dice);
            BetOutcome outcome = dPass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }

        [Test]
        public void DontPassLineBet_Push_On12_BeforePointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontPassLine dPass = new DontPassLine(table);
            dPass.Wager = wager;

            Dice dice = new Dice(6, 6);

            //Act
            dPass.ProcessRoll(dice);
            BetOutcome outcome = dPass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Push);
        }

        [Test]
        public void DontPassLineBet_Loses_On11_BeforePointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontPassLine dPass = new DontPassLine(table);
            dPass.Wager = wager;

            Dice dice = new Dice(5, 6);

            //Act
            dPass.ProcessRoll(dice);
            BetOutcome outcome = dPass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void DontPassLineBet_NoAction_On5()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontPassLine dPass = new DontPassLine(table);
            dPass.Wager = wager;

            Dice dice = new Dice(1, 4);

            //Act
            dPass.ProcessRoll(dice);
            BetOutcome outcome = dPass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void DontPassLineBet_NoAction_On2_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            DontPassLine dPass = new DontPassLine(table);
            dPass.Wager = wager;

            Dice dice = new Dice(1, 1);

            //Act
            dPass.ProcessRoll(dice);
            BetOutcome outcome = dPass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void DontPassLineBet_Wins1x_On7_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 6;

            DontPassLine dPass = new DontPassLine(table);
            dPass.Wager = wager;

            Dice dice = new Dice(3, 4);

            //Act
            dPass.ProcessRoll(dice);
            BetOutcome outcome = dPass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }

        [Test]
        public void DontPassLineBet_Loses_OnPoint_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 8;

            DontPassLine dPass = new DontPassLine(table);
            dPass.Wager = wager;

            Dice dice = new Dice(4, 4);

            //Act
            dPass.ProcessRoll(dice);
            BetOutcome outcome = dPass.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }
    }
}
