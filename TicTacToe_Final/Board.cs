using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_Final
{
    public class Board
    {
        public const int BOARD_SIZE = 3;    //kích thước cố định
        public Cell[,] board;               //ma trận 2 chiều
        //Khởi tạo bảng rỗng
        public Board()
        {
            board = new Cell[BOARD_SIZE, BOARD_SIZE];
            for (int i = 0; i < BOARD_SIZE; i++) //i la dòng
            {
                for (int j = 0; j < BOARD_SIZE; j++)//j là cột
                {
                    board[i, j] = new Cell();
                }
            }
        }
        //Hiển thị bảng
        public void printBoard()
        {
            int fieldNumber = 1;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----");
            for (int i = 0; i < BOARD_SIZE; i++)
            {
                for (int j = 0; j < BOARD_SIZE; j++)
                {
                    if (board[i, j].isEmpty())
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(fieldNumber);
                    }//hiện số
                    else
                    {
                        Console.Write((char)(board[i, j].getFieldState()));  //X hay
                    }
                    fieldNumber++;

                    if (j < BOARD_SIZE - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("|");
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("-----");
        }
        //Xác định tạo độ
        public void putMark(Player player, int fieldNumber)
        {
            int verticalY = (fieldNumber - 1) / BOARD_SIZE;
            int horizontalX = (fieldNumber - 1) % BOARD_SIZE;
            if (board[verticalY, horizontalX].isEmpty())
                board[verticalY, horizontalX].markField(player);
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("This place is taken. Select the field again: ");
                putMark(player, player.takeTurn());
            }
        }
        //Xóa bảng
        public void clearBoard()
        {
            Console.Clear();
        }

    }
}
