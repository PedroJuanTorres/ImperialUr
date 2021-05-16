using System;

namespace ImperialUr
{
    public class Controller
    {
        private Square[,] field;
        private Player[] player;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="field">Game map</param>
        /// <param name="player">Players Status</param>
        public Controller (Square[,] field, Player[] player) // Constructor 
        {
            this.field = field;
            this.player = player;
        }

        /// <summary>
        /// Runs the game
        /// </summary>
        /// <param name="view">The class that print and receives input from the user</param>
        public void Execute (View view)
        {
            string command = null;

            do 
            {

                View.CleanScreen();
                command = View.Menu();
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (command == "New Game")
                {
                    int turn = 0;
                    int roll = 0;
                    int aux = 20;
                    string option = null;
                    string pause = null;
                    string[] plays = new string[7];

                    View.ShowInstructions ("FirstTime");

                    do
                    {
                        turn++;
                        roll = 0;
                        aux = 20;

                        do // King of the West Turn
                        {
                            player[0].Turn = "Our Turn";
                            player[1].Turn = "Not Our Turn";

                            View.ShowBoardField (field);
                            View.ShowBoardStatus (player, turn, roll);

                            View.RollDices ();
                            roll = Square.Dices ();

                            View.ShowBoardField (field);
                            View.ShowBoardStatus (player, turn, roll);

                            if (roll != 0)
                            {
                                Controller.CheckMoves (field, player, plays, aux, roll);
                                if (plays[0] != null || plays[1] != null || plays[2] == null ||
                                    plays[3] != null || plays[4] != null || plays[5] == null ||
                                    plays[6] != null)
                                {
                                    View.ShowBoardPlays (plays, "Available Moves");
                                    option = View.VerifyandRetrieveImput (plays);
                                    for (int i = 0 ; i < 7 ; i++)
                                    {
                                        plays[i] = null;
                                    }

                                    aux = Controller.ApplyMove (field, player, option, roll);

                                    View.CleanScreen();
                                    View.ShowBoardField (field);
                                    View.ShowBoardStatus (player, turn, roll);
                                        
                                    pause = View.PauseInput();

                                    if (option == "Pause") // Pause Menu
                                    {
                                        do
                                        {
                                            pause = View.PauseMenu ();

                                            if (pause == "Resume") View.CleanScreen();
                                            else if (pause == "Instructions")
                                            {
                                                View.ShowInstructions ("Instructions");
                                            }

                                            else if (pause == "Save Match")
                                            {
                                                View.UnderConstruction();
                                            }
                                            else if (pause == "Resign") View.CleanScreen();
                                            else
                                            {
                                                View.InexistentOption();
                                            }

                                        } while (pause != "Resume" && pause != "Resign");
                                    }
                                    View.CleanScreen(); 
                                } else View.ShowBoardPlays (plays, "Unavailable Moves");
                            }
                            else 
                            {
                                View.ShowBoardPlays (plays, "Unavailable Moves");
                                roll = 0;
                            }

                        } while (pause != "Resign" && roll != 0 && (aux == 4 || aux == 8 || aux == 14));
                        
                        aux = 20;

                        if (pause != "Resign") // If the King of the West resigned, then King of the East does not initiate turn
                        {
                            turn++;
                            roll = 0;

                            do // King of the East Turn
                            {
                                player[0].Turn = "Not Our Turn";
                                player[1].Turn = "Our Turn";
                                
                                View.ShowBoardField (field);
                                View.ShowBoardStatus (player, turn, roll);

                                View.RollDices ();
                                roll = Square.Dices ();

                                View.ShowBoardField (field);
                                View.ShowBoardStatus (player, turn, roll);


                                if (roll != 0)
                                {
                                    Controller.CheckMoves (field, player, plays, aux, roll);

                                    if (plays[0] != null || plays[1] != null || plays[2] == null ||
                                        plays[3] != null || plays[4] != null || plays[5] == null ||
                                        plays[6] != null)
                                    {
                                        View.ShowBoardPlays (plays, "Available Moves");
                                        option = View.VerifyandRetrieveImput (plays);
                                        for (int i = 0 ; i < 7 ; i++)
                                        {
                                            plays[i] = null;
                                        }

                                        aux = Controller.ApplyMove (field, player, option, roll);

                                        View.CleanScreen();
                                        View.ShowBoardField (field);
                                        View.ShowBoardStatus (player, turn, roll);
                                        
                                        pause = View.PauseInput();

                                        if (option == "Pause") // Pause Menu
                                        {
                                            do
                                            {
                                                pause = View.PauseMenu ();

                                                if (pause == "Resume") View.CleanScreen();
                                                else if (pause == "Instructions")
                                                {
                                                    View.ShowInstructions ("Instructions");
                                                }

                                                else if (pause == "Save Match")
                                                {
                                                    View.UnderConstruction();
                                                }
                                                else if (pause == "Resign") View.CleanScreen();
                                                else
                                                {
                                                    View.InexistentOption();
                                                }

                                            } while (pause != "Resume" && pause != "Resign");
                                        }
                                        View.CleanScreen(); 
                                    } else View.ShowBoardPlays (plays, "Unavailable Moves");   
                                }
                                else 
                                {
                                    View.ShowBoardPlays (plays, "Unavailable Moves");
                                    roll = 0;
                                }

                            } while (pause != "Resign" && roll != 0 && (aux == 4 || aux == 8 || aux == 14));
                        }            

                    } while ((player[0].PiecesFinish != 7 || player[1].PiecesFinish != 7) && pause != "Resign");

                    if (pause == "Resign") View.Resign(player);
                    else 
                    {
                        if (player[0].PiecesFinish == 7) View.Victory ("West");
                        else View.Victory ("East");
                    }
                }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (command == "Continue")
                {
                    View.UnderConstruction();
                }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (command == "Team")
                {
                    View.Credits();
                }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else if (command == "Quit") 
                {
                    continue;
                }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                else 
                {
                    View.InexistentOption();
                }
                
            } while (command != "Quit");

            View.Quit();
        }
        /// <summary>
        /// Check the position of the pieces on the Board
        /// </summary>
        /// <param name="field">Game map</param>
        /// <param name="player">Players status</param>
        /// <param name="helper">An int to help in the logic</param>
        /// <param name="bigHelper">Array of int to return data to its father method</param>
        private static void CheckPieces (Square[,] field, Player[] player, int helper, int[] bigHelper) 
        {
            for (int i = 0 ; i < 8 ; i++)
            {
                for (int j = 0 ; j < 3 ; j++)
                {
                    if (player[0].Turn == "Our Turn")
                    {
                        if (field[i,j].Symbol == 'W') 
                        {
                            for (int k = 0 ; k < 7 ; k++)
                            {
                                if (field[i,j].Number != bigHelper[k])
                                {
                                    bigHelper[k] = field[i,j].Number;
                                }
                            }
                        } 
                    }
                    else
                    {
                        if (field[i,j].Symbol == 'E') 
                        {
                            for (int g = 0 ; g < 7 ; g++)
                            {
                                if (field[i,j].Number != bigHelper[g])
                                {
                                    bigHelper[g] = field[i,j].Number;
                                }
                            }
                        }
                    } 
                }
            }
        }

        /// <summary>
        /// Check if it's possible to move a piece
        /// </summary>
        /// <param name="field">Game map</param>
        /// <param name="player">Player Status</param>
        /// <param name="r">Result of the dice cast</param>
        /// <param name="helper">An int to help in the logic</param>
        /// <returns></returns>
        private static string CheckPlays (Square[,] field, Player[] player, int r, int helper)  
        {
            if (helper + r <= 15)
            {
                for (int i = 0 ; i < 8 ; i++)
                {
                    for (int j = 0 ; j < 3 ; j++)
                    {
                        if (player[0].Turn == "Our Turn")
                        {
                            if (field[i,j].Number == helper)
                            {
                                helper = field[i,j].Number + r;

                                for (int z = 0 ; z < 8 ; z++)
                                {
                                    for (int v = 0 ; v < 3 ; v++)
                                    {
                                        if (field[z,v].Number == helper)
                                        {
                                            if (field[z,v].Symbol == 'W') return (null);
                                            else return ($"W to {field[z,v].Number}");
                                        }
                                    }
                                } 
                            } 
                        }
                        else
                        {
                            if (field[i,j].Number == helper)
                            {
                                helper = field[i,j].Number + r;

                                for (int z = 0 ; z < 8 ; z++)
                                {
                                    for (int v = 0 ; v < 3 ; v++)
                                    {
                                        if (field[z,v].Number == helper)
                                        {
                                            if (field[z,v].Symbol == 'E') return (null);
                                            else return ($"E to {field[z,v].Number}");
                                        }
                                    }
                                } 
                            }
                        }
                    }
                }
                return (null);
            }
            else return (null); 
        }

        /// <summary>
        /// Method to join CheckPieces with CheckPlays and handle their logic 
        /// </summary>
        /// <param name="field">Game map</param>
        /// <param name="player">Players status</param>
        /// <param name="plays">List of available moves</param>
        /// <param name="aux">Auxiliary variable</param>
        /// <param name="roll">Sum of dice cast</param>
        private static void CheckMoves (Square[,] field, Player[] player, string[] plays, int aux, int roll)
        {
            aux = 20;
            int[] auxiliary = new int[7];

            for (int i = 0 ; i < 7 ; i++)
            {
                Controller.CheckPieces (field, player, aux, auxiliary);
                if (aux == -1) break;
                aux = auxiliary[i];
                plays[i] = Controller.CheckPlays (field, player, roll, aux);
            }
        }

        /// <summary>
        /// Update the game map
        /// </summary>
        /// <param name="field">Game map</param>
        /// <param name="player">Players status</param>
        /// <param name="path">Auxiliary string type variable</param>
        /// <param name="roll">Sum of dice cast</param>
        /// <returns></returns>
        private static int ApplyMove (Square[,] field, Player[] player, string path, int roll)
        {
            int aux = 0;

            string[] point = path.Split(" ");
            int helper = Int32.Parse(point[2]);

            if (player[0].Turn == "Our Turn")
            {
                for (int i = 0 ; i < 8 ; i++)
                {
                    for (int j = 0 ; j < 3 ; j++)
                    {
                        if (field[i,j].Number == (helper - roll) && (field[i,j].Domain == 'w' || field[i,j].Domain == 'p')) // Previous Square of the selected piece
                        {
                            if (field[i,j].Number == 4 || field[i,j].Number == 8 || field[i,j].Number == 14) 
                            {
                                field[i,j].Symbol = 'X';
                            }
                            if (field[i,j].Symbol == 'W') field[i,j].Symbol = '_';
                            if (field[i,j].Symbol == ' ') player[0].PiecesStart -= 1;
                            if (helper == 15) field[i,j].Symbol = '_';
                        }
                    }
                }

                for (int i = 0 ; i < 8 ; i++)
                {
                    for (int j = 0 ; j < 3 ; j++)
                    {
                        if (field[i,j].Number == helper && (field[i,j].Domain == 'w' || field[i,j].Domain == 'p')) // Future Square of the selected piece
                        {
                            if (field[i,j].Number == 4 || field[i,j].Number == 8 || field[i,j].Number == 14)
                            {
                                aux = field[i,j].Number;
                                field[i,j].Symbol = 'W';
                            }
                            if (field[i,j].Symbol == ' ') player[0].PiecesFinish += 1;
                            if (field[i,j].Symbol == '_') field[i,j].Symbol = 'W';
                            if (field[i,j].Symbol == 'E') 
                            {
                                field[i,j].Symbol = 'W';
                                player[1].PiecesStart += 1;
                            }
                        }
                    }
                }
                return (aux);
            }
            else
            {
                for (int i = 0 ; i < 8 ; i++)
                {
                    for (int j = 0 ; j < 3 ; j++)
                    {
                        if (field[i,j].Number == (helper - roll) && (field[i,j].Domain == 'e' || field[i,j].Domain == 'p')) // Previous Square of the selected piece
                        {
                            if (field[i,j].Number == 4 || field[i,j].Number == 8 || field[i,j].Number == 14) 
                            {
                                field[i,j].Symbol = 'X';
                            }
                            if (field[i,j].Symbol == 'E') field[i,j].Symbol = '_';
                            if (field[i,j].Symbol == ' ') player[1].PiecesStart -= 1;
                            if (helper == 15) field[i,j].Symbol = '_';
                        }
                    }
                }

                for (int i = 0 ; i < 8 ; i++)
                {
                    for (int j = 0 ; j < 3 ; j++)
                    {
                        if (field[i,j].Number == helper && (field[i,j].Domain == 'e' || field[i,j].Domain == 'p')) // Future Square of the selected piece
                        {
                            if (field[i,j].Number == 4 || field[i,j].Number == 8 || field[i,j].Number == 14)
                            {
                                aux = field[i,j].Number;
                                field[i,j].Symbol = 'E';
                            }
                            if (field[i,j].Symbol == ' ') player[1].PiecesFinish += 1;
                            if (field[i,j].Symbol == '_') field[i,j].Symbol = 'E';
                            if (field[i,j].Symbol == 'W') 
                            {
                                field[i,j].Symbol = 'E';
                                player[0].PiecesStart += 1;
                            }
                        }
                    }
                }
                return (aux);
            }
        }
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}