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
                    View.ShowInstructions("FirstTime");
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