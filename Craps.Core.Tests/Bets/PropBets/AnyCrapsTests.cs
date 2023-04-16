using Craps.Core.Bets.PropBets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets.PropBets
{
    public class AnyCrapsTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void AnyCraps_WinsLoses_OnCorrectNumbers()
        {
            //Arrange
            Table table = new Table();

            AnyCraps ac2 = new AnyCraps(table) { Wager = 1 };
            AnyCraps ac3 = new AnyCraps(table) { Wager = 1 };
            AnyCraps ac6 = new AnyCraps(table) { Wager = 1 };
            AnyCraps ac12 = new AnyCraps(table) { Wager = 1 };

            Dice d2 = new Dice(1, 1);
            Dice d3 = new Dice(1, 2);
            Dice d6 = new Dice(2, 4);
            Dice d12 = new Dice(6, 6);

            //Act
            ac2.ProcessRoll(d2);
            ac3.ProcessRoll(d2);
            ac6.ProcessRoll(d6);
            ac12.ProcessRoll(d12);

            BetOutcome o2 = ac2.BetOutcome;
            BetOutcome o3 = ac3.BetOutcome;
            BetOutcome o6 = ac6.BetOutcome;
            BetOutcome o12 = ac12.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o2.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o3.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
                Assert.That(o6.BetStatus, Is.EqualTo(BetOutcome.Status.Lose));
                Assert.That(o12.BetStatus, Is.EqualTo(BetOutcome.Status.Win));
            });
        }

        [Test]
        public void AnyCraps_Payouts()
        {
            //Arrange
            Table table = new Table();

            AnyCraps ac2 = new AnyCraps(table) { Wager = 1 };
            AnyCraps ac3 = new AnyCraps(table) { Wager = 1 };
            AnyCraps ac6 = new AnyCraps(table) { Wager = 1 };
            AnyCraps ac12 = new AnyCraps(table) { Wager = 1 };

            Dice d2 = new Dice(1, 1);
            Dice d3 = new Dice(1, 2);
            Dice d6 = new Dice(2, 4);
            Dice d12 = new Dice(6, 6);

            //Act
            ac2.ProcessRoll(d2);
            ac3.ProcessRoll(d2);
            ac6.ProcessRoll(d6);
            ac12.ProcessRoll(d12);

            BetOutcome o2 = ac2.BetOutcome;
            BetOutcome o3 = ac3.BetOutcome;
            BetOutcome o6 = ac6.BetOutcome;
            BetOutcome o12 = ac12.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(o2.Payout, Is.EqualTo(7));
                Assert.That(o3.Payout, Is.EqualTo(7));
                Assert.That(o6.Payout, Is.EqualTo(0));
                Assert.That(o12.Payout, Is.EqualTo(7));
            });
        }
    }
}
