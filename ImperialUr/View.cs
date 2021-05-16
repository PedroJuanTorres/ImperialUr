using System;

namespace ImperialUr
{
    public class View
    {
        private Controller controller; // Instance Variable
        private Square[,] field; // Instance Variable
        private Player[] player; // Instance Variable


        public View (Controller controller, Square[,] field, Player[] player) // Constructor
        {
            this.controller = controller;
            this.field = field;
            this.player = player;
        }


        public static void CleanScreen ()
        {
            Console.Clear ();
        }


        public static string Menu () 
        {   
            Console.WriteLine ("\n");
            Console.WriteLine ("==============================================");
            Console.WriteLine ("==================== Menu ====================");
            Console.WriteLine ("==============================================");
            Console.WriteLine ("                 ============                 ");
            Console.WriteLine ("                 = New Game =                 ");
            Console.WriteLine ("                 ============                 ");
            Console.WriteLine ("                 ============                 ");
            Console.WriteLine ("                 = Continue =                 ");
            Console.WriteLine ("                 ============                 ");
            Console.WriteLine ("                   ========                   ");
            Console.WriteLine ("                   = Team =                   ");
            Console.WriteLine ("                   ========                   ");
            Console.WriteLine ("                   ========                   ");
            Console.WriteLine ("                   = Quit =                   ");
            Console.WriteLine ("                   ========                   ");
            Console.WriteLine ("==============================================");
            Console.WriteLine ("\n");
            Console.WriteLine ("Which option would you like to choose?");
            Console.Write ("\n>> ");

            return (Console.ReadLine ());
        }
    }
}