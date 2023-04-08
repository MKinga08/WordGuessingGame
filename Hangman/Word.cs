using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Word
    {
        public string ActualWord { get; set; }
        public string GuessingWord { get; set; }

        public Word()
        {
            ActualWord = ChoosingAWord();
            CreatingGuessingWord();
        }

        private string ChoosingAWord()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\User\\Desktop\\C#_Projects\\Hangman_CSharp\\words.txt");
            string[] arr1 = lines;
            var randomWord = new Random().Next(arr1.Length);
            //Console.WriteLine(arr1[randomWord]);
            return arr1[randomWord];
        }
        public void PrintBoard()
        {
            Console.WriteLine(GuessingWord);
        }
        private void CreatingGuessingWord()
        {
            string word = string.Empty;
            var underscore = ActualWord.Length;
            for (int i = 0; i < underscore; i++)
            {
                word += "_";
            }
            GuessingWord = word;
        }
    }
}
