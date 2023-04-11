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
        private Word word;
        public Game() 
        { 
            player = new Player();
            word = new Word();

        }
        public void GamePhase()
        {
            word.PrintBoard();
            while (player.Lives > 0)
            {
                string guessedLetter = Guessing();
                Console.Clear();
                word.GuessingWord = CheckLetterInGuessingWord(guessedLetter, word.ActualWord, word.GuessingWord);
                Console.WriteLine(word.GuessingWord);
                Lives(guessedLetter, word.ActualWord);
                GameEnd(word.ActualWord, word.GuessingWord);
            }
            

        }
        public string Guessing()
        {
            Console.Write("\nGuess a letter: ");
            string letter = Console.ReadLine()!;
            /*List<string> guessedletters = new List<string>
            {
                letter
            };
            Console.WriteLine("you guessed these letters: " + guessedletters);*/
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
            if (player.Lives > 1)
            {
                Console.WriteLine($"You have {player.Lives} lives left");
            }
            else
            {
                Console.WriteLine("You have 1 life left");
            }
            return player.Lives;
        }
        public void GameEnd(string word, string guessingWord)
        {
            if(player.Lives == 0)
            {
                Console.WriteLine($"You have lost the game! The word was {word}");
            }
            if(guessingWord == word)
            {
                Console.WriteLine("Congrats! You won the game!");
                Environment.Exit(0);
            }
        }
    }
}
