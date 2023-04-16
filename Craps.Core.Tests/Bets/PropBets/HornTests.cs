using Craps.Core.Bets.PropBets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets.PropBets
{
    public class HornTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void HornBet_CantPlaceBet_Wager_NotIncrementOf4()
        {
            //Arrange
            Table table = new Table();

            Horn horn1 = new Horn(table) { Wager = 1 };
            Horn horn7 = new Horn(table) { Wager = 7 };

            //Act & Assert
            Assert.Multiple(() =>
            {
                Assert.That(horn1.CanPlaceBet(), Is.False);
                Assert.That(horn7.CanPlaceBet(), Is.False);
            });
        }

        [Test]
        public void HornBet_CanPlaceBet_Wager_IncrementOf4()
        {
            //Arrange
            Table table = new Table();

            Horn horn4 = new Horn(table) { Wager = 4 };
            Horn horn16 = new Horn(table) { Wager = 16 };

            //Act & Assert
            Assert.Multiple(() =>
            {
                Assert.That(horn4.CanPlaceBet(), Is.True);
                Assert.That(horn16.CanPlaceBet(), Is.True);
            });
        }

        [Test]
        public void HornBet_WinsLoses_OnCorrectNumbers()
        {
            //Arrange
            Table table = new Table();

            Horn h2 = new Horn(table) { Wager = 4 };
            Horn h3 = new Horn(table) { Wager = 4 };
            Horn h11 = new Horn(table) { Wager = 4 };
            Horn h12 = new Horn(table) { Wager = 4 };
            Horn h8 = new Horn(table) { Wager = 4 };

            Dice d2 = new Dice(1, 1);
            Dice d3 = new Dice(1, 2);
            Dice d11 = new Dice(5, 6);
            Dice d12 = new Dice(6, 6);
            Dice d8 = new Dice(4, 4);

            //Act
            h2.ProcessRoll(d2);
            h3.ProcessRoll(d3);
            h11.ProcessRoll(d11);
            h12.ProcessRoll(d12);
            h8.ProcessRoll(d8);

            BetOutcome o2 = h2.BetOutcome;
            BetOutcome o3 = h3.BetOutcome;
            BetOutcome o11 = h11.BetOutcome;
            BetOutcome o12 = h12.BetOutcome;
            BetOutcome o8 = h8.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o2.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o3.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o11.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o12.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o8.BetStatus, Is.EqualTo(BetOutcome.Status.Lose));
            });
        }

        [Test]
        public void HornBet_Payouts()
        {
            //Arrange
            Table table = new Table();

            Horn h2 = new Horn(table) { Wager = 4 };
            Horn h3 = new Horn(table) { Wager = 4 };
            Horn h11 = new Horn(table) { Wager = 4 };
            Horn h12 = new Horn(table) { Wager = 4 };
            Horn h8 = new Horn(table) { Wager = 4 };

            Dice d2 = new Dice(1, 1);
            Dice d3 = new Dice(1, 2);
            Dice d11 = new Dice(5, 6);
            Dice d12 = new Dice(6, 6);
            Dice d8 = new Dice(4, 4);

            //Act
            h2.ProcessRoll(d2);
            h3.ProcessRoll(d3);
            h11.ProcessRoll(d11);
            h12.ProcessRoll(d12);
            h8.ProcessRoll(d8);

            BetOutcome o2 = h2.BetOutcome;
            BetOutcome o3 = h3.BetOutcome;
            BetOutcome o11 = h11.BetOutcome;
            BetOutcome o12 = h12.BetOutcome;
            BetOutcome o8 = h8.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o2.Payout, Is.EqualTo(27));
                Assert.That(o3.Payout, Is.EqualTo(12));
                Assert.That(o11.Payout, Is.EqualTo(12));
                Assert.That(o12.Payout, Is.EqualTo(27));
                Assert.That(o8.Payout, Is.EqualTo(0));
            });
        }
    }
}
