using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Craps.Core.Tests.Bets
{
    public class FieldTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void FieldBet_Wins2x_On2()
        {
            //Arrange
            int wager = 15;
            Field field = new Field(null);
            field.Wager = wager;
            Dice dice = new Dice(1, 1);

            //Act
            field.ProcessRoll(dice);
            BetOutcome outcome = field.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 2 * wager);
        }

        [Test]
        public void FieldBet_Wins1x_On4()
        {
            //Arrange
            int wager = 15;
            Field field = new Field(null);
            field.Wager = wager;
            Dice dice = new Dice(1, 3);

            //Act
            field.ProcessRoll(dice);
            BetOutcome outcome = field.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win && outcome.Payout == 1 * wager);
        }

        [Test]
        public void FieldBet_Loses_On6()
        {
            //Arrange
            int wager = 15;
            Field field = new Field(null);
            field.Wager = wager;
            Dice dice = new Dice(3, 3);

            //Act
            field.ProcessRoll(dice);
            BetOutcome outcome = field.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }
    }
}
