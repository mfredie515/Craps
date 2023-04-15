using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    public class BuyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BuyBet_Vig_Minimum_1Dollar()
        {
            //Arrange
            Table table = new Table();

            Buy buy = new Buy(table);
            buy.Wager = 10;

            //Act & Assert
            Assert.That(buy.Vig, Is.EqualTo(1));
        }

        [Test]
        public void BuyBet_Vig_RoundDown_Dollar()
        {
            //Arrange
            Table table = new Table();

            Buy buy1 = new Buy(table);
            buy1.Wager = 30;
            Buy buy2 = new Buy(table);
            buy2.Wager = 55;

            //Act & Assert
            Assert.Multiple(() =>
            {
                Assert.That(buy1.Vig, Is.EqualTo(1));
                Assert.That(buy2.Vig, Is.EqualTo(2));
            });
        }

        [Test]
        public void BuyBet_Vig_Equals_5Percent()
        {
            //Arrange
            Table table = new Table();

            Buy buy = new Buy(table);
            buy.Wager = 60;

            //Act & Assert
            Assert.That(buy.Vig, Is.EqualTo(3));
        }

        [Test]
        public void BuyBet_Vig_CanPlaceBet_Vig()
        {
            //Arrange
            Table table = new Table();

            Buy buy = new Buy(table);
            buy.Wager = 60;

            //Act & Assert
            Assert.That(buy.CanPlaceBet(), Is.EqualTo(true));
        }

        [Test]
        public void BuyBet_Vig_CantPlaceBet_Vig_ThrowsException()
        {
            //Arrange
            Table table = new Table();

            Buy buy = new Buy(table);
            buy.Wager = 60;

            //Act & Assert
            Assert.Throws<Exception>(() => buy.CanPlaceBet());
        }

        [Test]
        public void BuyBet_Payouts()
        {
            //Arrange
            Table table = new Table();

            Buy b4 = new Buy(table) { Wager = 60, Point = 4 };
            Buy b5 = new Buy(table) { Wager = 60, Point = 5 };
            Buy b6 = new Buy(table) { Wager = 60, Point = 6 };

            Dice d4 = new Dice(2, 2);
            Dice d5 = new Dice(2, 3);
            Dice d6 = new Dice(2, 4);

            //Act
            b4.ProcessRoll(d4);
            b5.ProcessRoll(d5);
            b6.ProcessRoll(d6);

            BetOutcome bo4 = b4.BetOutcome;
            BetOutcome bo5 = b5.BetOutcome;
            BetOutcome bo6 = b6.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(bo4.Payout, Is.EqualTo(120));
                Assert.That(bo5.Payout, Is.EqualTo(90));
                Assert.That(bo6.Payout, Is.EqualTo(72));
            });
        }
    }
}
