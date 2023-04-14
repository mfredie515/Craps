using Craps.Core.Bets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Craps.Core.Tests.Bets
{
    public class OddsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Odds_PassLine_CantPlace_BeforePointEstablished()
        {
            //Arrange
            Table table = new Table();

            PassLine pass = new PassLine(table);
            Odds<PassLine> odds = new Odds<PassLine>(pass);

            //Act & Assert
            Assert.IsFalse(odds.CanPlaceBet());
        }

        [Test]
        public void Odds_PassLine_CanPlace_AfterPointEstablished()
        {
            //Arrange
            Table table = new Table();
            table.Point = 5;

            PassLine pass = new PassLine(table);
            Odds<PassLine> odds = new Odds<PassLine>(pass);

            //Act & Assert
            Assert.IsTrue(odds.CanPlaceBet());
        }

        [Test]
        public void Odds_Come_CantPlace_NotOnPoint()
        {
            //Arrange
            Table table = new Table();

            Come come = new Come(table);
            Odds<Come> odds = new Odds<Come>(come);

            //Act & Assert
            Assert.IsFalse(odds.CanPlaceBet());
        }

        [Test]
        public void Odds_Come_CanPlace_OnPoint()
        {
            //Arrange
            Table table = new Table();

            Come come = new Come(table);
            come.Point = 5;
            Odds<Come> odds = new Odds<Come>(come);

            //Act & Assert
            Assert.IsTrue(odds.CanPlaceBet());
        }

        [Test]
        public void Odds_PassLine_Win_OnWin_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            PassLine pass = new PassLine(table);
            pass.BetOutcome = new BetOutcome() { BetStatus = BetOutcome.Status.Win };
            Odds<PassLine> odds = new Odds<PassLine>(pass);
            odds.Wager = wager;

            Dice dice = new Dice(3, 1);

            //Act
            odds.ProcessRoll(dice);
            BetOutcome outcome = odds.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win);
        }

        [Test]
        public void Odds_PassLine_Lose_OnLose_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            PassLine pass = new PassLine(table);
            pass.BetOutcome = new BetOutcome() { BetStatus = BetOutcome.Status.Lose };
            Odds<PassLine> odds = new Odds<PassLine>(pass);
            odds.Wager = wager;

            Dice dice = new Dice(3, 4);

            //Act
            odds.ProcessRoll(dice);
            BetOutcome outcome = odds.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void Odds_PassLine_NoAction_OnNoAction_AfterPointEstablished()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            PassLine pass = new PassLine(table);
            pass.BetOutcome = new BetOutcome() { BetStatus = BetOutcome.Status.NoAction };
            Odds<PassLine> odds = new Odds<PassLine>(pass);
            odds.Wager = wager;

            Dice dice = new Dice(3, 2);

            //Act
            odds.ProcessRoll(dice);
            BetOutcome outcome = odds.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void Odds_Come_Win_OnWin_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            Come come = new Come(table);
            come.BetOutcome = new BetOutcome() { BetStatus = BetOutcome.Status.Win };
            Odds<Come> odds = new Odds<Come>(come);
            odds.Wager = wager;

            Dice dice = new Dice(3, 1);

            //Act
            odds.ProcessRoll(dice);
            BetOutcome outcome = odds.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Win);
        }

        [Test]
        public void Odds_Come_Lose_OnLose_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            Come come = new Come(table);
            come.BetOutcome = new BetOutcome() { BetStatus = BetOutcome.Status.Lose };
            Odds<Come> odds = new Odds<Come>(come);
            odds.Wager = wager;

            Dice dice = new Dice(3, 4);

            //Act
            odds.ProcessRoll(dice);
            BetOutcome outcome = odds.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.Lose && outcome.Payout == 0);
        }

        [Test]
        public void Odds_Come_NoAction_OnNoAction_OnPoint()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            Come come = new Come(table);
            come.BetOutcome = new BetOutcome() { BetStatus = BetOutcome.Status.NoAction };
            Odds<Come> odds = new Odds<Come>(come);
            odds.Wager = wager;

            Dice dice = new Dice(3, 2);

            //Act
            odds.ProcessRoll(dice);
            BetOutcome outcome = odds.BetOutcome;

            //Assert
            Assert.IsTrue(outcome.BetStatus == BetOutcome.Status.NoAction);
        }

        [Test]
        public void Odds_Payouts_PassLineCome()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            Come c4 = new Come(table) { Wager = wager, Point = 4 };
            Come c5 = new Come(table) { Wager = wager, Point = 5 };
            Come c6 = new Come(table) { Wager = wager, Point = 6 };
            Come c8 = new Come(table) { Wager = wager, Point = 8 };
            Come c9 = new Come(table) { Wager = wager, Point = 9 };
            Come c10 = new Come(table) { Wager = wager, Point = 10 };
            BetOutcome bo = new BetOutcome() { BetStatus = BetOutcome.Status.Win };
            c4.BetOutcome = bo;
            c5.BetOutcome = bo;
            c6.BetOutcome = bo;
            c8.BetOutcome = bo;
            c9.BetOutcome = bo;
            c10.BetOutcome = bo;

            Odds<Come> c4o = new Odds<Come>(c4) { Wager = wager };
            Odds<Come> c5o = new Odds<Come>(c5) { Wager = wager };
            Odds<Come> c6o = new Odds<Come>(c6) { Wager = wager };
            Odds<Come> c8o = new Odds<Come>(c8) { Wager = wager };
            Odds<Come> c9o = new Odds<Come>(c9) { Wager = wager + 1};
            Odds<Come> c10o = new Odds<Come>(c10) { Wager = wager };

            Dice d4 = new Dice(1, 3);
            Dice d5 = new Dice(2, 3);
            Dice d6 = new Dice(1, 5);
            Dice d8 = new Dice(3, 5);
            Dice d9 = new Dice(4, 5);
            Dice d10 = new Dice(5, 5);

            //Act
            c4o.ProcessRoll(d4);
            c5o.ProcessRoll(d5);
            c6o.ProcessRoll(d6);
            c8o.ProcessRoll(d8);
            c9o.ProcessRoll(d9);
            c10o.ProcessRoll(d10);

            BetOutcome boc4o = c4o.BetOutcome;
            BetOutcome boc5o = c5o.BetOutcome;
            BetOutcome boc6o = c6o.BetOutcome;
            BetOutcome boc8o = c8o.BetOutcome;
            BetOutcome boc9o = c9o.BetOutcome;
            BetOutcome boc10o = c10o.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(boc4o.Payout == 30);
                Assert.IsTrue(boc5o.Payout == 22); //15 wager
                Assert.IsTrue(boc6o.Payout == 18);
                Assert.IsTrue(boc8o.Payout == 18);
                Assert.IsTrue(boc9o.Payout == 24); //16 wager
                Assert.IsTrue(boc10o.Payout == 30);

            });
        }

        [Test]
        public void Odds_Payouts_DontPassLineDontCome()
        {
            //Arrange
            int wager = 15;
            Table table = new Table();
            table.Point = 4;

            DontCome c4 = new DontCome(table) { Wager = wager, Point = 4 };
            DontCome c5 = new DontCome(table) { Wager = wager, Point = 5 };
            DontCome c6 = new DontCome(table) { Wager = wager, Point = 6 };
            DontCome c8 = new DontCome(table) { Wager = wager, Point = 8 };
            DontCome c9 = new DontCome(table) { Wager = wager, Point = 9 };
            DontCome c10 = new DontCome(table) { Wager = wager, Point = 10 };
            BetOutcome bo = new BetOutcome() { BetStatus = BetOutcome.Status.Win };
            c4.BetOutcome = bo;
            c5.BetOutcome = bo;
            c6.BetOutcome = bo;
            c8.BetOutcome = bo;
            c9.BetOutcome = bo;
            c10.BetOutcome = bo;

            Odds<DontCome> c4o = new Odds<DontCome>(c4) { Wager = 30 };
            Odds<DontCome> c5o = new Odds<DontCome>(c5) { Wager = 23 };
            Odds<DontCome> c6o = new Odds<DontCome>(c6) { Wager = 18 };
            Odds<DontCome> c8o = new Odds<DontCome>(c8) { Wager = 15 };
            Odds<DontCome> c9o = new Odds<DontCome>(c9) { Wager = 15 };
            Odds<DontCome> c10o = new Odds<DontCome>(c10) { Wager = 15 };

            Dice d7 = new Dice(3, 4);

            //Act
            c4o.ProcessRoll(d7);
            c5o.ProcessRoll(d7);
            c6o.ProcessRoll(d7);
            c8o.ProcessRoll(d7);
            c9o.ProcessRoll(d7);
            c10o.ProcessRoll(d7);

            BetOutcome boc4o = c4o.BetOutcome;
            BetOutcome boc5o = c5o.BetOutcome;
            BetOutcome boc6o = c6o.BetOutcome;
            BetOutcome boc8o = c8o.BetOutcome;
            BetOutcome boc9o = c9o.BetOutcome;
            BetOutcome boc10o = c10o.BetOutcome;

            //Assert
            Assert.Multiple(() =>
            {
                Assert.IsTrue(boc4o.Payout == 15);
                Assert.IsTrue(boc5o.Payout == 15);
                Assert.IsTrue(boc6o.Payout == 15);
                Assert.IsTrue(boc8o.Payout == 12);
                Assert.IsTrue(boc9o.Payout == 10);
                Assert.IsTrue(boc10o.Payout == 7);

            });
        }
    }
}
