using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    public class LayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void LayBet_Vig_Minimum_1Dollar()
        {
            //Arrange
            Table table = new Table();

            Lay lay = new Lay(table);
            lay.Wager = 10;

            //Act & Assert
            Assert.That(lay.Vig, Is.EqualTo(1));
        }

        [Test]
        public void LayBet_Vig_RoundDown_Dollar()
        {
            //Arrange
            Table table = new Table();

            Lay lay1 = new Lay(table);
            lay1.Wager = 30;
            Lay lay2 = new Lay(table);
            lay2.Wager = 55;

            //Act & Assert
            //Act & Assert
            Assert.Multiple(() =>
            {
                Assert.That(lay1.Vig, Is.EqualTo(1));
                Assert.That(lay2.Vig, Is.EqualTo(2));
            });
        }

        [Test]
        public void LayBet_Vig_Equals_5Percent()
        {
            //Arrange
            Table table = new Table();

            Lay lay = new Lay(table);
            lay.Wager = 60;

            //Act & Assert
            Assert.That(lay.Vig, Is.EqualTo(3));
        }

        [Test]
        public void LayBet_Vig_CanPlaceBet_Vig()
        {
            //Arrange
            Table table = new Table();

            Lay lay = new Lay(table);
            lay.Wager = 60;

            //Act & Assert
            Assert.That(lay.CanPlaceBet(), Is.EqualTo(true));
        }

        [Test]
        public void LayBet_Vig_CantPlaceBet_Vig_ThrowsException()
        {
            //Arrange
            Table table = new Table();

            Lay lay = new Lay(table);
            lay.Wager = 60;

            //Act & Assert
            Assert.Throws<Exception>(() => lay.CanPlaceBet());
        }

        [Test]
        public void LayBet_Payouts()
        {
            //Arrange
            Table table = new Table();

            Lay l4 = new Lay(table) { Wager = 120, Point = 4 };
            Lay l5 = new Lay(table) { Wager = 120, Point = 5 };
            Lay l6 = new Lay(table) { Wager = 120, Point = 6 };

            Dice d4 = new Dice(2, 2);
            Dice d5 = new Dice(2, 3);
            Dice d6 = new Dice(2, 4);

            //Act
            l4.ProcessRoll(d4);
            l5.ProcessRoll(d5);
            l6.ProcessRoll(d6);

            BetOutcome bo4 = l4.BetOutcome;
            BetOutcome bo5 = l5.BetOutcome;
            BetOutcome bo6 = l6.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(bo4.Payout, Is.EqualTo(60));
                Assert.That(bo5.Payout, Is.EqualTo(80));
                Assert.That(bo6.Payout, Is.EqualTo(100));
            });
        }
    }
}
