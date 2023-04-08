using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Game : IGame
    {
        private Player player;
        private Board board;
        public Game() 
        { 
            player = new Player();
            board = new Board();

        }
        public void GamePhase()
        {
            GameStart();
            Guessing();
        }
        public void GameStart()
        {
            Board board = new Board();
            string word = board.ChoosingAWord();
            board.PrintBoard(word);
        }
        public string Guessing()
        {
            Console.WriteLine("\n\n\nGuess a letter:");
            string letter = Console.ReadLine()!;
            return letter;
        }
    }
}
