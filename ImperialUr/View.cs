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
    }
}