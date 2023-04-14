using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    public class PlaceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PlaceBet_CantPlace_BeforePointEstablished()
        {
            //Arrange
            Table table = new Table();

            Place place = new Place(table);

            //Act & Assert
            Assert.IsFalse(place.CanPlaceBet());
        }

        [Test]
        public void PlaceBet_CanPlace_AfterPointEstablished()
        {
            //Arrange
            Table table = new Table();
            table.Point = 4;

            Place place = new Place(table);

            //Act & Assert
            Assert.IsTrue(place.CanPlaceBet());
        }

        [Test]
        public void PlaceBet_Loses_On7()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Place place = new Place(table);
            place.Wager = wager;

            Dice dice = new Dice(3, 4);

            //Act
            place.ProcessRoll(dice);
            BetOutcome outcome = place.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void PlaceBet_NoAction_NotOnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Place place = new Place(table);
            place.Wager = wager;

            Dice dice = new Dice(1, 1);

            //Act
            place.ProcessRoll(dice);
            BetOutcome outcome = place.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void PlaceBet_Win_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();

            Place place = new Place(table);
            place.Wager = wager;
            place.Point = 5;

            Dice dice = new Dice(1, 4);

            //Act
            place.ProcessRoll(dice);
            BetOutcome outcome = place.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win);
        }

        [Test]
        public void PlaceBet_Payout()
        {
            //Arrange
            Table table = new Table();

            Place p4 = new Place(table) { Wager = 15, Point = 4 };
            Place p5 = new Place(table) { Wager = 15, Point = 5 };
            Place p6 = new Place(table) { Wager = 15, Point = 6 };
            Place p8 = new Place(table) { Wager = 18, Point = 8 };
            Place p9 = new Place(table) { Wager = 15, Point = 9 };
            Place p10 = new Place(table) { Wager = 5, Point = 10 };

            Dice d4 = new Dice(2, 2);
            Dice d5 = new Dice(2, 3);
            Dice d6 = new Dice(2, 4);
            Dice d8 = new Dice(2, 6);
            Dice d9 = new Dice(3, 6);
            Dice d10 = new Dice(4, 6);

            //Act
            p4.ProcessRoll(d4); 
            p5.ProcessRoll(d5);
            p6.ProcessRoll(d6);
            p8.ProcessRoll(d8);
            p9.ProcessRoll(d9);
            p10.ProcessRoll(d10);

            BetOutcome bo4 = p4.BetOutcome;
            BetOutcome bo5 = p5.BetOutcome;
            BetOutcome bo6 = p6.BetOutcome;
            BetOutcome bo8 = p8.BetOutcome;
            BetOutcome bo9 = p9.BetOutcome;
            BetOutcome bo10 = p10.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(bo4.Payout, Is.EqualTo(27));
                Assert.That(bo5.Payout, Is.EqualTo(21));
                Assert.That(bo6.Payout, Is.EqualTo(17));
                Assert.That(bo8.Payout, Is.EqualTo(21));
                Assert.That(bo9.Payout, Is.EqualTo(21));
                Assert.That(bo10.Payout, Is.EqualTo(9));
            });
        }
    }
}
