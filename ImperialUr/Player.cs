namespace ImperialUr
{
    public class Player
    {
        public string Name {get; set;} // Property
        public int PiecesStart {get; set;} // Property
        public int PiecesFinish {get; set;} // Property
        public string Turn {get; set;} // Property


        public Player (string name, int piecesStart, int piecesFinish, string turn) // Constructor
        {
            Name = name;
            PiecesStart = 7;
            PiecesFinish = 0;
            Turn = turn;
        }
    }
}