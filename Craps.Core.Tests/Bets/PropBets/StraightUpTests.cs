using Craps.Core.Bets.PropBets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets.PropBets
{
    public class StraightUpTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void StraightUpBet_Aces_WinsLoses_CorrectNumbers()
        {
            //Arrange
            Table table = new Table();

            StraightUp su2 = new StraightUp(table, StraightUp.StraightUpValue.Aces) { Wager = 1 };
            StraightUp su9 = new StraightUp(table, StraightUp.StraightUpValue.Aces) { Wager = 1 };

            Dice d2 = new Dice(1, 1);
            Dice d9 = new Dice(3, 6);

            //Act
            su2.ProcessRoll(d2);
            su9.ProcessRoll(d9);
            BetOutcome o2 = su2.BetOutcome;
            BetOutcome o9 = su9.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o2.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o9.BetStatus, Is.EqualTo(BetOutcome.Status.Lose));
            });
        }

        [Test]
        public void StraightUpBet_AceDeuce_WinsLoses_CorrectNumbers()
        {
            //Arrange
            Table table = new Table();

            StraightUp su3 = new StraightUp(table, StraightUp.StraightUpValue.AceDeuce) { Wager = 1 };
            StraightUp su9 = new StraightUp(table, StraightUp.StraightUpValue.AceDeuce) { Wager = 1 };

            Dice d3 = new Dice(1, 2);
            Dice d9 = new Dice(3, 6);

            //Act
            su3.ProcessRoll(d3);
            su9.ProcessRoll(d9);
            BetOutcome o3 = su3.BetOutcome;
            BetOutcome o9 = su9.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o3.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o9.BetStatus, Is.EqualTo(BetOutcome.Status.Lose));
            });
        }

        [Test]
        public void StraightUpBet_Yo_WinsLoses_CorrectNumbers()
        {
            //Arrange
            Table table = new Table();

            StraightUp su11 = new StraightUp(table, StraightUp.StraightUpValue.Yo) { Wager = 1 };
            StraightUp su9 = new StraightUp(table, StraightUp.StraightUpValue.Yo) { Wager = 1 };

            Dice d11 = new Dice(5, 6);
            Dice d9 = new Dice(3, 6);

            //Act
            su11.ProcessRoll(d11);
            su9.ProcessRoll(d9);
            BetOutcome o11 = su11.BetOutcome;
            BetOutcome o9 = su9.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o11.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o9.BetStatus, Is.EqualTo(BetOutcome.Status.Lose));
            });
        }

        [Test]
        public void StraightUpBet_Boxcars_WinsLoses_CorrectNumbers()
        {
            //Arrange
            Table table = new Table();

            StraightUp su12 = new StraightUp(table, StraightUp.StraightUpValue.Boxcars) { Wager = 1 };
            StraightUp su9 = new StraightUp(table, StraightUp.StraightUpValue.Boxcars) { Wager = 1 };

            Dice d12 = new Dice(6, 6);
            Dice d9 = new Dice(3, 6);

            //Act
            su12.ProcessRoll(d12);
            su9.ProcessRoll(d9);
            BetOutcome o12 = su12.BetOutcome;
            BetOutcome o9 = su9.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o12.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o9.BetStatus, Is.EqualTo(BetOutcome.Status.Lose));
            });
        }

        [Test]
        public void StraightUpBet_Payouts()
        {
            //Arrange
            Table table = new Table();

            StraightUp su2 = new StraightUp(table, StraightUp.StraightUpValue.Aces) { Wager = 1 };
            StraightUp su3 = new StraightUp(table, StraightUp.StraightUpValue.AceDeuce) { Wager = 1 };
            StraightUp su11 = new StraightUp(table, StraightUp.StraightUpValue.Yo) { Wager = 1 };
            StraightUp su12 = new StraightUp(table, StraightUp.StraightUpValue.Boxcars) { Wager = 1 };
            StraightUp su9 = new StraightUp(table, StraightUp.StraightUpValue.Boxcars) { Wager = 1 };

            Dice d2 = new Dice(1, 1);
            Dice d3 = new Dice(1, 2);
            Dice d11 = new Dice(5, 6);
            Dice d12 = new Dice(6, 6);
            Dice d9 = new Dice(3, 6);

            //Act
            su2.ProcessRoll(d2);
            su3.ProcessRoll(d3);
            su11.ProcessRoll(d11);
            su12.ProcessRoll(d12);
            su9.ProcessRoll(d9);
            BetOutcome o2 = su12.BetOutcome;
            BetOutcome o3 = su3.BetOutcome;
            BetOutcome o11 = su11.BetOutcome;
            BetOutcome o12 = su12.BetOutcome;
            BetOutcome o9 = su9.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o2.Payout, Is.EqualTo(30));
                Assert.That(o3.Payout, Is.EqualTo(15));
                Assert.That(o11.Payout, Is.EqualTo(15));
                Assert.That(o12.Payout, Is.EqualTo(30));
                Assert.That(o9.Payout, Is.EqualTo(0));
            });
        }
    }
}
