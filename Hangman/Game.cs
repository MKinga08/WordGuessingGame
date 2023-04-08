﻿using System;
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
            board.PrintBoard();

            string guessedLetter = Guessing();
            board.GuessingWord = CheckLetterInGuessingWord(guessedLetter, board.ActualWord, board.GuessingWord);
            Console.WriteLine(board.GuessingWord);
        }
        public string Guessing()
        {
            Console.WriteLine("\n\n\nGuess a letter:");
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
    }
}
