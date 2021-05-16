using System;

namespace ImperialUr
{
    public class View
    {
        private Controller controller;
        private Square[,] field;
        private Player[] player;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controller">Class that controls the flow of the game</param>
        /// <param name="field">Game map</param>
        /// <param name="player">Players status</param>
        public View (Controller controller, Square[,] field, Player[] player)
        {
            this.controller = controller;
            this.field = field;
            this.player = player;
        }

        /// <summary>
        /// Clean all text from screen
        /// </summary>
        public static void CleanScreen ()
        {
            Console.Clear ();
        }

        /// <summary>
        /// Text to tell user how to go back to the menu
        /// </summary>
        public static void Back ()
        {
            Console.WriteLine ("\n");
            Console.WriteLine ("Press any key to go back to the Menu ...");
            Console.ReadKey ();
        }

        /// <summary>
        /// Text to tell user that his option doesn't exists
        /// </summary>
        public static void InexistentOption ()
        {
            View.CleanScreen ();
            Console.WriteLine ("\n");
            Console.WriteLine ("The option chosen does not exist!");
            Console.WriteLine ("Verify the option chosen and try again.");
            View.Back ();
        }

        /// <summary>
        /// Text to tell that this area is under construction
        /// </summary>
        public static void UnderConstruction ()
        {
            View.CleanScreen ();
            Console.WriteLine ("\n");
            Console.WriteLine ("We are sorry to inform you that this section is under construction and will be available soon.");
            View.Back ();
        }

        /// <summary>
        /// Text to show the main menu
        /// </summary>
        /// <returns>The input of the user</returns>
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

        /// <summary>
        /// Text to show the instructions
        /// </summary>
        /// <param name="c">Differentiate in which situation the method is called</param>
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

        /// <summary>
        /// Text to show game map
        /// </summary>
        /// <param name="field">Game map</param>
        public static void ShowBoardField (Square[,] field)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == 0) Console.Write ("\n");

                if (i == 4 || i == 5) Console.WriteLine ("\n                        _                         ++");
                else Console.WriteLine ("\n             _          _          _              ++");

                for (int j = 0; j < 3; j++)
                {
                    if (j == 0) Console.Write ("            ");
                    else Console.Write ("        ");

                    if ((i == 4 || i == 5) && (j == 0 || j == 2))
                    {
                        Console.Write ("  ");
                        Console.Write (field[i,j].Symbol);
                    }
                    else
                    {
                        Console.Write ("|");
                        Console.Write (field[i,j].Symbol);
                        Console.Write ("|");
                    }

                    if (j == 2) Console.Write("             ++");
                }

                if (i == 7) 
                {   
                    Console.WriteLine ("\n                                                  ++");
                    Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++++++++++"  );
                    Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++++++++++\n");
                }
            }
        }

        /// <summary>
        /// Show game status
        /// </summary>
        /// <param name="player">Players status</param>
        /// <param name="turn">Which palyer turn is</param>
        /// <param name="roll">Sum of dices cast</param>
        public static void ShowBoardStatus (Player[] player, int turn, int roll)
        {
            Console.WriteLine ("                    ++++++++++                     ");
            Console.WriteLine ("                    ++ Turn ++                     ");
            if (turn < 10) Console.WriteLine ($"                    ++  0{turn}  ++                     ");
            else Console.WriteLine ($"                    ++  {turn}  ++                     ");
            Console.WriteLine ("                    ++++++++++                      ");  
            Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine ("++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine ($"    {player[0].Name}    ++    {player[1].Name}     ");
            Console.WriteLine ("                        ++                          ");
            if (player[0].Turn == "Our Turn") Console.WriteLine ($"Turn: {player[0].Turn}          ++ Turn: {player[1].Turn}");
            else Console.WriteLine ($"Turn: {player[0].Turn}      ++ Turn: {player[1].Turn}");
            Console.WriteLine ($"Pieces (Start): {player[0].PiecesStart}       ++ Pieces (Start): {player[1].PiecesStart}");
            Console.WriteLine ($"Pieces (Finish): {player[0].PiecesFinish}      ++ Pieces (Finish): {player[1].PiecesFinish}");
            if (player[0].Turn == "Our Turn") Console.WriteLine ($"Dices Roll: {roll}           ++");
            else Console.WriteLine ($"                        ++ Dices Roll: {roll}");
            Console.WriteLine ("                        ++");
            if (player[0].Turn == "Not Our Turn")
            {
                Console.WriteLine ("++++++++++++++++++++++++++");
                Console.WriteLine ("++++++++++++++++++++++++++");
                Console.Write ("\n"); 
            }
            else
            {
                Console.WriteLine ("                        ++++++++++++++++++++++++++++");
                Console.WriteLine ("                        ++++++++++++++++++++++++++++"); 
                Console.Write ("\n");   
            }
        }

        /// <summary>
        /// Text to the the user to roll the dices
        /// </summary>
        public static void RollDices ()
        {
            Console.WriteLine ("Press 'Enter' to roll the dices!");

            while (Console.ReadKey (true).Key != ConsoleKey.Enter) 
            {
                View.CleanScreen();

                Console.WriteLine ("\n");
                Console.WriteLine ("===============================");
                Console.WriteLine ("= I beg of you, your Majesty! =");
                Console.WriteLine ("=== Roll the goddamn dices! ===");
                Console.WriteLine ("===============================");
            }
            View.CleanScreen();
        }

        /// <summary>
        /// Text to show the possible plays
        /// </summary>
        /// <param name="plays">A list of possible plays</param>
        /// <param name="c">Differentiate in which situation the method is called</param>
        public static void ShowBoardPlays (string[] plays, string c)
        {
            Console.WriteLine ("+++++++++");
            Console.WriteLine ("+ Plays +");
            Console.WriteLine ("+++++++++");
            Console.Write("\n");

            if (c == "Available Moves")
            { 
                for (int i = 0 ; i < 7 ; i++)
                {
                    if (plays[i] == null) continue;
                    else Console.WriteLine (plays[i]);
                }
            }
            
            if (c == "Unavailable Moves")
            {
                Console.WriteLine ("=================================================================");
                Console.WriteLine ("= Your Majesty, I regret to inform that our troops cannot move. =");
                Console.WriteLine ("=================================================================");
                Console.WriteLine ("\n");
                Console.WriteLine ("Press 'Enter' to pass the turn.");

                while (Console.ReadKey (true).Key != ConsoleKey.Enter) 
                {
                    View.CleanScreen();

                    Console.WriteLine ("\n");
                    Console.WriteLine ("===========================================================");
                    Console.WriteLine ("= I understand your frustation your Highness, but please. =");
                    Console.WriteLine ("============= Let the opponent have his turn! =============");
                    Console.WriteLine ("===========================================================");
                }
                View.CleanScreen();               
            }
        }

        /// <summary>
        /// Receive plays input, check if its valid and telling what is necessary 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string VerifyandRetrieveImput (string[] p)
        {
            bool result = false;
            string imput = null;

            do
            {
                Console.WriteLine ("\n");
                Console.WriteLine ("Write the path you would like to take.");
                Console.Write ("\n>> ");
                imput = Console.ReadLine ();

                for (int i = 0 ; i < 7 ; i++)
                {
                    result = string.Equals(p[i], imput);
                    if (result == true) return (imput);
                }

                Console.WriteLine ("\n");
                Console.WriteLine ("==========================================================================================");
                Console.WriteLine ("= My King, we cannot move the legions into that area, please revise the available paths. =");
                Console.WriteLine ("==========================================================================================");

            } while (result != true);

            return ("false");
        }

        /// <summary>
        /// Message to tell who won
        /// </summary>
        /// <param name="king">Player name</param>
        public static void Victory (string king)
        {
            if (king == "West") 
            {
                Console.WriteLine ("\n");
                Console.WriteLine ("=========================================");
                Console.WriteLine ("= The King of the West won the match!!! =");
                Console.WriteLine ("=========================================");
                View.Back ();
            }

            if (king == "East") 
            {
                Console.WriteLine ("\n");
                Console.WriteLine ("=========================================");
                Console.WriteLine ("= The King of the East won the match!!! =");
                Console.WriteLine ("=========================================");
                View.Back ();
            }
        }

        /// <summary>
        /// Receive input while in pause
        /// </summary>
        /// <returns>Input of the player</returns>
        public static string PauseInput () 
        {
            string pause;

            do
            {   Console.WriteLine ("\n");
                Console.WriteLine ("Write 'Pause' if you want to pause or press 'Enter' to end the turn.");
                Console.Write ("\n>> ");
                pause = Console.ReadLine ();

                if (pause == "Pause") return ("Pause");
                else if (pause == "") return ("Continue");
                else 
                {
                    Console.WriteLine ("\n");
                    Console.WriteLine ("=====================================");
                    Console.WriteLine ("= That option is unavailable, Sire! =");
                    Console.WriteLine ("=====================================");
                }

            } while (pause != "Pause" && pause != "\n");

            return (pause);
        }

        /// <summary>
        /// Show pause menu
        /// </summary>
        /// <returns>Input written by the player</returns>
        public static string PauseMenu ()
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

        /// <summary>
        /// Resign of the match
        /// </summary>
        /// <param name="player">Player status</param>
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

        /// <summary>
        /// Show credits of the game
        /// </summary>
        public static void Credits () 
        {
            View.CleanScreen ();

            Console.WriteLine ("\n");
            Console.WriteLine ("==============================================");
            Console.WriteLine ("============= The Developer Team =============");
            Console.WriteLine ("=============================================="); 
            Console.WriteLine ("============================                  ");
            Console.WriteLine ("= Daniel Pinhão - 22007445 =                  ");
            Console.WriteLine ("============================                  ");
            Console.WriteLine ("===========================                   ");
            Console.WriteLine ("= Pedro Torres - 22007890 =                   ");
            Console.WriteLine ("===========================                   ");
            Console.WriteLine ("=========================                     ");
            Console.WriteLine ("= José Pires - 21701444 =                     ");
            Console.WriteLine ("=========================                     ");

            View.Back ();
        }

        /// <summary>
        /// Quit message
        /// </summary>
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