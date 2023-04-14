namespace Craps.Core
{
    public class Dice
    {
        private static readonly Random rng;

        static Dice()
        {
            rng = new Random();
        }

        //Used for testing purposes
        internal Dice(int die1, int die2)
        {
            Die1 = die1;
            Die2 = die2;
        }

        internal Dice()
        {
            Die1 = rng.Next(1, 6);
            Die2 = rng.Next(1, 6);
        }

        public int Die1 { get; }
        public int Die2 { get; }

        public int Total { get { return Die1 + Die2; } }

        public static Dice Roll()
        {
            return new Dice();
        }
    }
}