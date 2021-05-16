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
    }
}