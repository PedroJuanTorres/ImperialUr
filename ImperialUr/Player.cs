namespace ImperialUr
{
    public class Player
    {
        public string Name {get; set;} // Property
        public int PiecesStart {get; set;} // Property
        public int PiecesFinish {get; set;} // Property
        public string Turn {get; set;} // Property

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Player name</param>
        /// <param name="piecesStart">Number of pieces that the player has to play still</param>
        /// <param name="piecesFinish">Number of pieces that the player has secure</param>
        /// <param name="turn">Which player turn is</param>
        public Player (string name, int piecesStart, int piecesFinish, string turn) 
        {
            Name = name;
            PiecesStart = 7;
            PiecesFinish = 0;
            Turn = turn;
        }
    }
}