namespace Hangman
{
    class Program
    {
        public static void Main(string[] args)
        {
            Board board = new Board();
            string word = board.ChoosingAWord();
            board.PrintBoard(word);
        }
    }
}