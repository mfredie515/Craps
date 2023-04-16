using Craps.Core.Bets.PropBets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets.PropBets
{
    public class AnySevenTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void AnySeven_WinLoses_OnCorrectNumbers()
        {
            //Arrange
            Table table = new Table();

            AnySeven as16 = new AnySeven(table) { Wager = 1 };
            AnySeven as25 = new AnySeven(table) { Wager = 1 };
            AnySeven as34 = new AnySeven(table) { Wager = 1 };
            AnySeven as55 = new AnySeven(table) { Wager = 1 };

            Dice d16 = new Dice(1, 6);
            Dice d25 = new Dice(2, 5);
            Dice d34 = new Dice(3, 4);
            Dice d55 = new Dice(5, 5);

            //Act
            as16.ProcessRoll(d16);
            as25.ProcessRoll(d25);
            as34.ProcessRoll(d34);
            as55.ProcessRoll(d55);
            BetOutcome b16 = as16.BetOutcome;
            BetOutcome b25 = as25.BetOutcome;
            BetOutcome b34 = as34.BetOutcome;
            BetOutcome b55 = as55.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(b16.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(b25.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(b34.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(b55.BetStatus, Is.EqualTo(BetOutcome.Status.Lose));
            });
        }

        [Test]
        public void AnySeven_Payouts()
        {
            //Arrange
            Table table = new Table();

            AnySeven as16 = new AnySeven(table) { Wager = 1 };
            AnySeven as25 = new AnySeven(table) { Wager = 1 };
            AnySeven as34 = new AnySeven(table) { Wager = 1 };
            AnySeven as55 = new AnySeven(table) { Wager = 1 };

            Dice d16 = new Dice(1, 6);
            Dice d25 = new Dice(2, 5);
            Dice d34 = new Dice(3, 4);
            Dice d55 = new Dice(5, 5);

            //Act
            as16.ProcessRoll(d16);
            as25.ProcessRoll(d25);
            as34.ProcessRoll(d34);
            as55.ProcessRoll(d55);
            BetOutcome b16 = as16.BetOutcome;
            BetOutcome b25 = as25.BetOutcome;
            BetOutcome b34 = as34.BetOutcome;
            BetOutcome b55 = as55.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(b16.Payout, Is.EqualTo(4));
                Assert.That(b25.Payout, Is.EqualTo(4));
                Assert.That(b34.Payout, Is.EqualTo(4));
                Assert.That(b55.Payout, Is.EqualTo(0));
            });
        }
    }
}
