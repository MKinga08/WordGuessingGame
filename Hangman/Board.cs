using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Board
    {
        public int Wordlength { get; set; }
       
        public string ChoosingAWord()
        {
            string[] lines = File.ReadAllLines("C:\\Users\\User\\Desktop\\C#_Projects\\Hangman_CSharp\\words.txt");
            string[] arr1 = lines;
            var randomWord = new Random().Next(arr1.Length);
            return arr1[randomWord];
        }
        public void PrintBoard(string randomword)
        {
            var underscore = randomword.Length;
            for(int i = 0;i < underscore; i++)
            {
                Console.Write("_");
            }
        }

    }
}
