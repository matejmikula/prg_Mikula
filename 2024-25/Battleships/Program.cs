using System;
using System.Collections.Generic;
using System.Security.Permissions;

namespace Battleships
{
    internal class Program
    {
        const int gridSize = 10;
        List<int> columns = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        List<char> rows = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

        static void Main(string[] args)
        {
            
            
            ArrayDisp(rows, columns);

            Console.WriteLine("Enter a cell (e.g., a5):");
            string input = Console.ReadLine()?.ToLower(); // Safely handle null input

            if (input == null || input.Length < 2)
            {
                Console.WriteLine("Invalid input. Please enter a valid cell (e.g., a5).");
                return;
            }
            else
            {
                if (gridSize)
                {

                }
            }

            char row = input[0];
            int column;

            // Validate row input
            if (!rows.Contains(row))
            {
                Console.WriteLine("Invalid row. Please enter a valid row (a-j).");
                return;
            }

            // Validate and parse column input
            if (!int.TryParse(input.Substring(1), out column) || !columns.Contains(column))
            {
                Console.WriteLine("Invalid column. Please enter a valid column (1-10).");
                return;
            }

            int indexRow = rows.IndexOf(row);
            int indexColumn = columns.IndexOf(column);

            Console.WriteLine($"You selected Row: {row} (Index: {indexRow}), Column: {column} (Index: {indexColumn}).");
        }

        static void ArrayDisp(List<char> rows, List<int> columns)
        {
            foreach (int column in columns)
            {
                Console.Write($"{column,3}"); // Align columns to 3 spaces
            }
            Console.WriteLine();
            foreach (char row in rows)
            {
                Console.Write($"{row}  "); // Row label with space
                for (int i = 0; i < columns.Count; i++)
                {
                    Console.Write("[ ]"); // Empty cell
                }
                Console.WriteLine();
            }
        }
        static void InitializeBoard(char[,] board)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    board[i, j] = '.';
                }
            }
        }
    }
}
