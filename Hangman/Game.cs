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

    }
}
