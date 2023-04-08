using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Game : IGame
    {
        private Player player;
        private Word board;
        public Game() 
        { 
            player = new Player();
            board = new Word();

        }
        public void GamePhase()
        {
            board.PrintBoard();
            while (player.Lives > 0)
            {
                string guessedLetter = Guessing();
                Console.Clear();
                board.GuessingWord = CheckLetterInGuessingWord(guessedLetter, board.ActualWord, board.GuessingWord);
                Console.WriteLine(board.GuessingWord);
                Lives(guessedLetter, board.ActualWord);
            }
            Console.Clear();
        }
        public string Guessing()
        {
            Console.Write("\nGuess a letter: ");
            string letter = Console.ReadLine()!;
            return letter;
        }
        public string CheckLetterInGuessingWord(string guessedletter, string actualWord, string guessingWord)
        {
            var guessedlet = guessedletter[0];
            char[] actualwordarr = actualWord.ToCharArray();
            char[] guessingwordarr = guessingWord.ToCharArray();

            for (int i = 0; i < actualWord.Length; i++)
            {
                if (actualwordarr[i] == guessedlet)
                {
                    guessingwordarr[i] = guessedlet;
                }
            }
            return string.Join("", guessingwordarr);
        }

        public int Lives(string guessedletter, string actualWord)
        {
            bool found = false;
            foreach (char c in actualWord)
            {
                if (c.ToString() == guessedletter)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                player.Lives--;
            }
            Console.WriteLine(player.Lives);
            return player.Lives;
        }
    }
}
