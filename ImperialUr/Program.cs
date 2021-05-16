using System.Collections.Generic;
using System;

namespace ImperialUr
{
    public class Program
    {
        /// <summary>
        /// First method to be called
        /// </summary>
        private static void Main ()
        {
            Square[,] field = new Square [8,3] // Creation of the Game Field
            {
                { new Square(0, 0, 4, 'w', 'X'),   new Square(0, 1, 5, 'p', '_'),  new Square(0, 2, 4, 'e', 'X') },
                { new Square(1, 0, 3, 'w', '_'),   new Square(1, 1, 6, 'p', '_'),  new Square(1, 2, 3, 'e', '_') },
                { new Square(2, 0, 2, 'w', '_'),   new Square(2, 1, 7, 'p', '_'),  new Square(2, 2, 2, 'e', '_') },
                { new Square(3, 0, 1, 'w', '_'),   new Square(3, 1, 8, 'p', 'X'),  new Square(3, 2, 1, 'e', '_') },
                { new Square(4, 0, 0, 'w', ' '),   new Square(4, 1, 9, 'p', '_'),  new Square(4, 2, 0, 'e', ' ') },
                { new Square(5, 0, 15, 'w', ' '),  new Square(5, 1, 10, 'p', '_'), new Square(5, 2, 15, 'e', ' ') },
                { new Square(6, 0, 14, 'w', 'X'),  new Square(6, 1, 11, 'p', '_'), new Square(6, 2, 14, 'e', 'X') },
                { new Square(7, 0, 13, 'w', '_'),  new Square(7, 1, 12, 'p', '_'), new Square(7, 2, 13, 'e', '_') }
            };

            Player[] player = new Player[2] // Creation of the Players
            {
                new Player("King of the West", 7, 0, ""), new Player("King of the East", 7, 0, "")
            };

            Controller controller = new Controller (field, player); // Controller

            View view = new View (controller, field, player); // View

            controller.Execute (view); // Method to execute the program
        }
    }
}