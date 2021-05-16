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

        public Square (int x, int y, int number, char domain, char symbol) // Constructor
        {
            X = x;
            Y = y;
            Number = number;
            Domain = domain;
            Symbol = symbol;
        }

        public static int Dices () // Method that returns the sum of 4 random numbers between 0 and 1
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