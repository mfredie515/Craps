using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    public class DontComeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DontComeBet_CantPlace_BeforePointEstablished()
        {
            //Arrange
            Table table = new Table();

            DontCome dCome = new DontCome(table);

            //Act & Assert
            Assert.IsFalse(dCome.CanPlaceBet());
        }

        [Test]
        public void DontComeBet_CanPlace_AfterPointEstablished()
        {
            //Arrange
            Table table = new Table();
            table.Point = 4;

            DontCome dCome = new DontCome(table);

            //Act & Assert
            Assert.IsTrue(dCome.CanPlaceBet());
        }

        [Test]
        public void DontComeBet_Wins1x_On2_NotOnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontCome dCome = new DontCome(table);
            dCome.Wager = wager;

            Dice dice = new Dice(1, 1);

            //Act
            dCome.ProcessRoll(dice);
            BetOutcome outcome = dCome.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }

        [Test]
        public void DontComeBet_Loses_On11_NotOnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontCome dCome = new DontCome(table);
            dCome.Wager = wager;

            Dice dice = new Dice(5, 6);

            //Act
            dCome.ProcessRoll(dice);
            BetOutcome outcome = dCome.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void DontComeBet_Push_On12_NotOnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontCome dCome = new DontCome(table);
            dCome.Wager = wager;

            Dice dice = new Dice(6, 6);

            //Act
            dCome.ProcessRoll(dice);
            BetOutcome outcome = dCome.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Push);
        }

        [Test]
        public void DontComeBet_NoAction_On5_MovesToPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontCome dCome = new DontCome(table);
            dCome.Wager = wager;

            Dice dice = new Dice(1, 4);

            //Act
            dCome.ProcessRoll(dice);
            BetOutcome outcome = dCome.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction && dCome.Point == 5);
        }

        [Test]
        public void DontComeBet_NoAction_On2_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontCome dCome = new DontCome(table);
            dCome.Wager = wager;
            dCome.Point = 5;


            Dice dice = new Dice(1, 1);

            //Act
            dCome.ProcessRoll(dice);
            BetOutcome outcome = dCome.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void DontComeBet_Wins1x_On7_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontCome dCome = new DontCome(table);
            dCome.Wager = wager;
            dCome.Point = 5;

            Dice dice = new Dice(3, 4);

            //Act
            dCome.ProcessRoll(dice);
            BetOutcome outcome = dCome.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }

        [Test]
        public void DontComeBet_Loses_OnPoint_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            DontCome dCome = new DontCome(table);
            dCome.Wager = wager;
            dCome.Point = 8;

            Dice dice = new Dice(4, 4);

            //Act
            dCome.ProcessRoll(dice);
            BetOutcome outcome = dCome.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }
    }
}
