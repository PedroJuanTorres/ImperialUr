using System;

namespace ImperialUr
{
    public class Square
    {
        public int X {get; set;} // Property
        public int Y {get; set;} // Property
        public int Number {get; set;} // Property
        public char Domain {get; set;} // Property
        public char Symbol {get; set;} // Property
        private static readonly Random rand = new Random (); // Instance Variable

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X cordinate</param>
        /// <param name="y">Y cordinate</param>
        /// <param name="number">number of the square</param>
        /// <param name="domain">Which squares can players move into or not</param>
        /// <param name="symbol">current item on the square</param>
        public Square (int x, int y, int number, char domain, char symbol) 
        {
            X = x;
            Y = y;
            Number = number;
            Domain = domain;
            Symbol = symbol;
        }

        /// <summary>
        /// Roll the dices
        /// </summary>
        /// <returns>the sum of the rolls</returns>
        public static int Dices ()
        {
            int n = 0;

            for (int i = 0 ; i <= 3 ; i++)
            {
                n += rand.Next(0, 2);
            }

            return (n);
        }
    }
}