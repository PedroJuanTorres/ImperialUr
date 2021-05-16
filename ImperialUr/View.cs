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


         public static string VerifyandRetrieveImput (Player[] player, string[] p)
        {
            int result = 0;
            string imput = null;

            do
            {
                int i = -1;
                result = 0;
                imput = null;

                Console.WriteLine ("\n");
                Console.WriteLine ("Write the path you would like to take.");
                Console.Write ("\n>> ");
                imput = Console.ReadLine ();

                do
                {
                    i++;
                    result = String.Compare (p[i], imput, true);

                } while (result != 0 && i < 7);

                if (result != 0) Console.WriteLine ("\nThe path written is not possible, please write an available one!");

            } while (result != 0);

            for (int i = 0 ; i < 7 ; i++)
            {
                p[i] = null;
            }

            return (imput);
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


        public static void ShowInstructions (string c)
        {
            View.CleanScreen ();

            Console.WriteLine ("\n");
            Console.WriteLine ("=======================================================================================================================================================");
            Console.WriteLine ("                                                           Instructions to the Royal Game of Ur");
            Console.WriteLine ("=======================================================================================================================================================");
            Console.WriteLine ("1º - Throw the dice to decide who plays first - highest score goes first, if it's a draw, throw again.");  
            Console.WriteLine ("2º - Players take turns to throw four binary dices, which has 50% chance to get 1 square movement per each, making it possible to move up to 4 squares.");
            Console.WriteLine ("3º - Only one piece may be moved per throw of the dices and pieces must always move forward around the track.");
            Console.WriteLine ("4º - If a piece lands upon a square occupied by the opposing players piece, that piece is sent off the board and must start again from the beginning.");
            Console.WriteLine ("5º - However, if the piece lands on a flower square (X), then the player that performed the move gets to throw the dices again.");
            Console.WriteLine ("6º - Last, if a player has one of its pieces upon a flower square (X), that piece cannot be captured by the adversarie.");
            Console.WriteLine ("=======================================================================================================================================================");
            
            if (c == "FirstTime")
            {
                Console.WriteLine ("\nNote!");
                Console.WriteLine ("Feel free to type 'Pause', at the beginning of each round to see the instructions again, save the current game or forfeit the game.");
                Console.WriteLine ("\n\nPress any key to start the match!");
                Console.ReadKey ();
                View.CleanScreen ();
            }

            else if (c == "Instructions")
            {
                Console.WriteLine ("\n\nPress any key to go back to the Menu ...");
                Console.ReadKey ();
                View.CleanScreen ();
            }
        }


        public static void UnderConstruction ()
        {
            View.CleanScreen ();
            Console.WriteLine ("\n");
            Console.WriteLine ("We are sorry to inform you that this section is under construction and will be available soon.");
            View.Back ();
        }


        public static void InexistentOption ()
        {
            View.CleanScreen ();
            Console.WriteLine ("\n");
            Console.WriteLine ("The option chosen does not exist!");
            Console.WriteLine ("Verify the option chosen and try again.");
            View.Back ();
        }


        public static void Back ()
        {
            Console.WriteLine ("\n");
            Console.WriteLine ("Press any key to go back to the Menu ...");
            Console.ReadKey ();
        }


        public static void Credits () 
        {
            View.CleanScreen ();

            Console.WriteLine ("\n");
            Console.WriteLine ("========================");
            Console.WriteLine ("Daniel Pinhão - 22007445");
            Console.WriteLine ("========================");
            Console.WriteLine ("=======================");
            Console.WriteLine ("Pedro Torres - 22007890");
            Console.WriteLine ("=======================");
            Console.WriteLine ("=====================");
            Console.WriteLine ("José Pires - 21701444");
            Console.WriteLine ("=====================");

            View.Back ();
        }


        public static string PauseInput () 
        {
            string pause;

            do
            {   Console.WriteLine ("\n");
                Console.WriteLine ("Write 'Pause' if you want to pause or 'Continue' to end the turn.");
                Console.Write ("\n>> ");
                pause = Console.ReadLine ();

                if (pause == "Pause") return ("Pause");
                else if (pause == "Continue") return ("Continue");
                else Console.WriteLine ("\nChoise unavailable.");

            } while (pause != "Pause" && pause != "Continue");

            return (pause);
        }

        public static string PauseMenu (string pause)
        {
            View.CleanScreen ();

            Console.WriteLine ("\n");
            Console.WriteLine ("==============================================");
            Console.WriteLine ("================= Pause Menu =================");
            Console.WriteLine ("==============================================");
            Console.WriteLine ("                  ==========                  ");
            Console.WriteLine ("                  = Resume =                  ");
            Console.WriteLine ("                  ==========                  ");
            Console.WriteLine ("               ================               ");
            Console.WriteLine ("               = Instructions =               ");
            Console.WriteLine ("               ================               ");
            Console.WriteLine ("                ==============                ");
            Console.WriteLine ("                = Save Match =                ");
            Console.WriteLine ("                ==============                ");
            Console.WriteLine ("                  ==========                  ");
            Console.WriteLine ("                  = Resign =                  ");
            Console.WriteLine ("                  ==========                  ");
            Console.WriteLine ("==============================================");
            Console.WriteLine ("\n");
            Console.WriteLine ("Which option would you like to choose?");
            Console.Write ("\n>> ");

            return (Console.ReadLine ());
        }


         public static void Resign (Player[] player)
        {
            if (player[0].Turn == "Our Turn")
            {
                Console.WriteLine ("\n");
                Console.WriteLine ("================================================================");
                Console.WriteLine ("= The King of the West has decided to retreat from the battle! =");
                Console.WriteLine ("================================================================");
                View.Back ();
            }
            else
            {
                Console.WriteLine ("\n");
                Console.WriteLine ("================================================================");
                Console.WriteLine ("= The King of the East has decided to retreat from the battle! =");
                Console.WriteLine ("================================================================");
                View.Back (); 
            }
        }


        public static void Quit ()
        {
            View.CleanScreen ();
            Console.WriteLine ("\n");
            Console.WriteLine ("=============================================================================");
            Console.WriteLine ("= We will be ready to do battle once more upon your return, your Magesties! =");
            Console.WriteLine ("=============================================================================");
            Console.WriteLine ("\n");
            Console.WriteLine ("Press any key to go back to the console...");
            Console.ReadKey ();
            View.CleanScreen ();
        }
    }
}