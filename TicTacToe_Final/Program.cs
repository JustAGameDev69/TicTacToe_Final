using System;
using System.Security.Cryptography;
using TicTacToe_Final;

namespace TicTacToeFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Start_Menu();
        }
    }
}