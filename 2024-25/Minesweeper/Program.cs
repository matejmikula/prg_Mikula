﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(); //přebírání informací od třídy game
            game.Start();
        }
    }
}
