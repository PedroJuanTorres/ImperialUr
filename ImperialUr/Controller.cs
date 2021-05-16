using System;

namespace ImperialUr
{
    public class Controller
    {
        private Square[,] field; // Instance Variable
        private Player[] player; // Instance Variable

        public Controller (Square[,] field, Player[] player) // Constructor 
        {
            this.field = field;
            this.player = player;
        }

        public void Execute (View view) // Main method of the Controller, and the one that will serve as the game base
        {
            string command = null;

            do 
            {

                View.CleanScreen();
                command = View.Menu();



                if (command == "New Game")
                {
                    int turn = 0;
                    int roll = 0;
                    int aux = 20;
                    string option = null;
                    string pause = null;
                    string[] plays = new string[7];

                    View.ShowInstructions("FirstTime");

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
                                View.ShowBoardPlays (plays, "Available Moves");

                                option = View.VerifyandRetrieveImput (player, plays);
                                aux = Controller.ApplyMove (field, player, option, roll);
                                pause = View.PauseInput();

                                if (pause == "Pause") // Pause Menu
                                {
                                    do
                                    {
                                        pause = View.PauseMenu (pause);

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
                                    View.ShowBoardPlays (plays, "Available Moves");

                                    option = View.VerifyandRetrieveImput (player, plays);
                                    aux = Controller.ApplyMove (field, player, option, roll);
                                    pause = View.PauseInput();

                                    if (option == "Pause") // Pause Menu
                                    {
                                        do
                                        {
                                            pause = View.PauseMenu (pause);

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



                else if (command == "Continue")
                {
                    View.UnderConstruction();
                }



                else if (command == "Team")
                {
                   View.Credits();
                }



                else if (command == "Quit") 
                {
                    continue;
                }



                else 
                {
                    View.InexistentOption();
                }
                

                
            } while (command != "Quit");

            View.Quit();

        }

        private static int CheckPieces (Square[,] field, Player[] player, int helper) // Check the position of the pieces on the Board
        {
            for (int i = 0 ; i < 8 ; i++)
            {
                for (int j = 0 ; j < 3 ; j++)
                {
                    if (player[0].Turn == "Our Turn")
                    {
                        if (field[i,j].Symbol == 'W' && field[i,j].Number != helper) 
                        {
                            helper = field[i,j].Number;
                            return (helper); 
                        }

                        if (player[0].PiecesStart > 0) return (0); 
                    }
                    else
                    {
                        if (field[i,j].Symbol == 'E' && field[i,j].Number != helper)
                        {
                            helper = field[i,j].Number;
                            return (helper); 
                        }

                        if (player[1].PiecesStart > 0) return (0);
                    } 
                }
            }
            return (20);
        }

        private static string CheckPlays (Square[,] field, Player[] player, int r, int helper) // Check if it's possible to move a piece
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


        private static void CheckMoves (Square[,] field, Player[] player, string[] p, int aux, int roll)
        {
            for (int i = 0 ; i < 7 ; i++)
            {
                aux = Controller.CheckPieces (field, player, aux);
                p[i] = Controller.CheckPlays (field, player, roll, aux);
            }
        }

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
                            if (field[i,j].Symbol == ' ') player[0].PiecesStart -= 1;
                            if (field[i,j].Symbol == 'W') field[i,j].Symbol = '_';
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
                        if (field[i,j].Number == (helper - roll) && (field[i,j].Domain == 'w' || field[i,j].Domain == 'p')) // Previous Square of the selected piece
                        {
                            if (field[i,j].Number == 4 || field[i,j].Number == 8 || field[i,j].Number == 14) 
                            {
                                field[i,j].Symbol = 'X';
                            }
                            if (field[i,j].Symbol == ' ') player[1].PiecesStart -= 1;
                            if (field[i,j].Symbol == 'E') field[i,j].Symbol = '_';
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
            return (0);
        }

    }
}