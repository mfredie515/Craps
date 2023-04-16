using Craps.Core.Bets.PropBets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets.PropBets
{
    public class CAndETests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CAndEBet_WinsLoses_OnCorrectNumbers()
        {
            //Arrange
            Table table = new Table();

            CAndE ce2 = new CAndE(table) { Wager = 1 };
            CAndE ce3 = new CAndE(table) { Wager = 1 };
            CAndE ce12 = new CAndE(table) { Wager = 1 };
            CAndE ce11 = new CAndE(table) { Wager = 1 };
            CAndE ce8 = new CAndE(table) { Wager = 1 };

            Dice d2 = new Dice(1, 1);
            Dice d3 = new Dice(1, 2);
            Dice d12 = new Dice(6, 6);
            Dice d11 = new Dice(5, 6);
            Dice d8 = new Dice(4, 4);

            //Act
            ce2.ProcessRoll(d2);
            ce3.ProcessRoll(d3);
            ce12.ProcessRoll(d12);
            ce11.ProcessRoll(d11);
            ce8.ProcessRoll(d8);

            BetOutcome o2 = ce2.BetOutcome;
            BetOutcome o3 = ce3.BetOutcome;
            BetOutcome o12 = ce12.BetOutcome;
            BetOutcome o11 = ce11.BetOutcome;
            BetOutcome o8 = ce8.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o2.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o3.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o12.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o11.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o8.BetStatus, Is.EqualTo(BetOutcome.Status.Lose));
            });
        }

        [Test]
        public void CAndEBet_Payouts()
        {
            //Arrange
            Table table = new Table();

            CAndE ce2_1 = new CAndE(table) { Wager = 1 };
            CAndE ce2_2 = new CAndE(table) { Wager = 2 };
            CAndE ce11_1 = new CAndE(table) { Wager = 1 };
            CAndE ce11_2 = new CAndE(table) { Wager = 2 };
            CAndE ce8 = new CAndE(table) { Wager = 2 };

            Dice d2 = new Dice(1, 1);
            Dice d11 = new Dice(5, 6);
            Dice d8 = new Dice(4, 4);

            //Act
            ce2_1.ProcessRoll(d2);
            ce2_2.ProcessRoll(d2);
            ce11_1.ProcessRoll(d11);
            ce11_2.ProcessRoll(d11);
            ce8.ProcessRoll(d8);

            BetOutcome o2_1 = ce2_1.BetOutcome;
            BetOutcome o2_2 = ce2_2.BetOutcome;
            BetOutcome o11_1 = ce11_1.BetOutcome;
            BetOutcome o11_2 = ce11_2.BetOutcome;
            BetOutcome o8 = ce8.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o2_1.Payout, Is.EqualTo(3));
                Assert.That(o2_2.Payout, Is.EqualTo(6));
                Assert.That(o11_1.Payout, Is.EqualTo(7));
                Assert.That(o11_2.Payout, Is.EqualTo(14));
                Assert.That(o8.Payout, Is.EqualTo(0));
            });
        }
    }
}
