using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Final
{
    public class TicTacToe
    {
        Board board;
        Player currentPlayer;
        Player nextPlayer;
        public TicTacToe()
        {
            board = new Board();
        }

        //Luot choi
        public void play()
        {
            int moveCounter = 1;

            bool play = true;
            while (play)
            {
                board.printBoard();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Player: {0} Enter the field in which you want to put the character: ", currentPlayer.getSign());

                try
                {
                    board.putMark(currentPlayer, currentPlayer.takeTurn());
                    if (currentPlayer.checkWin(board))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Player " + currentPlayer.getSign() + " wins!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        play = false;
                    }
                    else if (checkDraw(moveCounter))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Draw!");

                        play = false;
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Invalid Input. Please enter number between 1-9!");
                    Console.Clear();
                }

                Player temp = currentPlayer;
                currentPlayer = nextPlayer;
                nextPlayer = temp;
                moveCounter++;
            }
        }

        public bool checkDraw(int moveCounter)
        {
            if (moveCounter == 9)
                return true;

            return false;
        }

        //Kiểm tra hòa

        public void Start_Menu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose a game mode:");
            Console.WriteLine("1. Player vs Player");
            Console.WriteLine("2. Player vs Computer");
            Console.WriteLine("3.Computer vs Computer");
            int mode = int.Parse(Console.ReadLine());

            switch (mode)
            {
                case 1:
                    //Khởi tạo hai người chơi mới
                    currentPlayer = new HumanPlayer('X');
                    nextPlayer = new HumanPlayer('O');
                    break;
                case 2:
                    //Khởi tạo một người chơi và một máy tính
                    currentPlayer = new HumanPlayer('X');
                    nextPlayer = new Robot('O');
                    break;
                case 3:
                    //Khởi tạo hai máy tính mới
                    currentPlayer = new Robot('X');
                    nextPlayer = new Robot('O');
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    Start_Menu();
                    break;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" TIC TAC TOE !");
            play();
        }

        //Kiem tra luot di cuoi
    }
}
