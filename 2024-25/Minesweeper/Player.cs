using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Player
    {
        public void FlagCell(Board board) //funkce pro flagnutí polí s minami
        {
            while (true) // Loop pro kontrolu inputu
            {
                Console.Write("Enter row (A, B, ...) to flag: ");
                char rowChar = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.Write("Enter column (1, 2, ...) to flag: ");
                int col;
                if (!int.TryParse(Console.ReadLine(), out col))
                {
                    Console.WriteLine("Invalid column input. Please enter a number.");
                    continue; 
                }
                col--; // úprava indexu sloupců

                int row = rowChar - 'A';

                if (board.IsValidCoordinate(row, col))
                {
                    board.FlagCell(row, col);
                    break; // konec loopu po vepsání správného inputu
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
        }

        public void UncoverCell(Board board) //funkce pro odhalení min
        {
            while (true) // opět loop pro zadání správného inputu
            {
                Console.Write("Enter row (A, B, ...) to uncover: ");
                char rowChar = Console.ReadKey().KeyChar;
                Console.WriteLine();

                Console.Write("Enter column (1, 2, ...) to uncover: ");
                int col;
                if (!int.TryParse(Console.ReadLine(), out col))
                {
                    Console.WriteLine("Invalid column input. Please enter a number.");
                    continue; 
                }
                col--; 

                int row = rowChar - 'A';

                if (board.IsValidCoordinate(row, col))
                {
                    board.UncoverCell(row, col);
                    break; 
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
        }
    }
}
