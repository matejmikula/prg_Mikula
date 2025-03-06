using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Board
    {
        public int gridSizeColumns; //zavedení základních intu, listu, ...
        public int gridSizeRows;
        public List<int> columns;
        public List<char> rows;
        public Cell[,] board;
        public int maxMines;

        public Board()
        {
            while (true) // Loop pro sloupce
            {
                Console.Write("Enter number of columns: ");
                if (!int.TryParse(Console.ReadLine(), out gridSizeColumns) || gridSizeColumns <= 0) //kontrola zda je input správný
                {
                    Console.WriteLine("Invalid column input. Please enter a positive number.");
                    continue; 
                }
                break; 
            }
            while (true) // Loop pro řádky
            {
                Console.Write("Enter number of rows: ");
                if (!int.TryParse(Console.ReadLine(), out gridSizeRows) || gridSizeRows <= 0) //kontrola zda je input správný
                {
                    Console.WriteLine("Invalid row input. Please enter a positive number.");
                    continue; // Retry row input
                }
                break; // Exit row loop on valid input
            }


            columns = new List<int>();
            rows = new List<char>();
            board = new Cell[gridSizeRows, gridSizeColumns];
            maxMines = (gridSizeColumns * gridSizeRows) / 10; //nastavení maxima min podle velikosti pole

            for (int i = 1; i <= gridSizeColumns; i++)
            {
                columns.Add(i); //for loop pro přídání sloupců dle zadaní od hráče
            }

            for (int i = 0; i < gridSizeRows; i++)
            {
                rows.Add((char)('A' + i));
            }
            for (int i = 0; i < gridSizeRows; i++)
            {
                for (int j = 0; j < gridSizeColumns; j++)
                {
                    board[i, j] = new Cell(); 
                }
            }

        }

        public void PlaceMinesRandomly(int mineCount) //funkce pro náhodné přidání min do pole
        {
            Random random = new Random();
            for (int i = 0; i < mineCount; i++)
            {
                bool placed = false;
                while (!placed)
                {
                    int row = random.Next(gridSizeRows);
                    int col = random.Next(gridSizeColumns);

                    if (!board[row, col].IsMine) //přidání miny do pole, pokud tam není
                    {
                        board[row, col].IsMine = true; //zapsání buňky v které již mina je
                        placed = true;
                    }
                }
            }
        }

        public void FlagCell(int row, int col) // kontrola buňky kterou chceme flagnout, (zda již není odhalená apod.
        {
            if (IsValidCoordinate(row, col))
            {
                board[row, col].IsFlagged = !board[row, col].IsFlagged;
            }
        }
        public char GetCell(int row, int col) // získání buněk pro vygenerování do pole
        {
            if (IsValidCoordinate(row, col))
            {
                return board[row, col].Display();
            }
            return '\0'; 
        }
        public bool IsValidCoordinate(int row, int col) //kontrola zda jsou koordinace v poli nebo mimo něj
        {
            return row >= 0 && row < gridSizeRows && col >= 0 && col < gridSizeColumns;
        }

        public void PrintBoard() //fce. pro generaci pole graficky
        {
            Console.WriteLine("Printing board...");
            Console.Write("  ");
            for (int i = 0; i < gridSizeColumns; i++)
            {
                Console.Write((i + 1).ToString().PadLeft(2) + " ");
            }
            Console.WriteLine();

            Console.Write("  ");
            for (int i = 0; i < gridSizeColumns; i++)
            {
                Console.Write("---");
            }
            Console.WriteLine();

            for (int i = 0; i < gridSizeRows; i++)
            {
                Console.Write(rows[i] + "|");
                for (int j = 0; j < gridSizeColumns; j++)
                {
                    Console.Write(board[i, j].Display().ToString().PadLeft(2) + " "); 
                }
                Console.WriteLine();
            }
        }
        public void CalculateAdjacentMines()
        {
            for (int i = 0; i < gridSizeRows; i++)
            {
                for (int j = 0; j < gridSizeColumns; j++)
                {
                    if (!board[i, j].IsMine) // pouze pro buňky bez min
                    {
                        int count = 0;
                        for (int row = Math.Max(0, i - 1); row <= Math.Min(gridSizeRows - 1, i + 1); row++) //kontrola hranic pole pro řádky
                        {
                            for (int col = Math.Max(0, j - 1); col <= Math.Min(gridSizeColumns - 1, j + 1); col++) //kontrola hranic pole pro sloupce
                            {
                                if (IsValidCoordinate(row, col) && board[row, col].IsMine)
                                {
                                    count++;
                                }
                            }
                        }
                        board[i, j].AdjacentMines = count;
                    }
                }
            }
        }
        public void UncoverCell(int row, int col) //funkce pro odkrytí buňky
        {
            Console.WriteLine($"UncoverCell: row={row}, col={col}");
            if (IsValidCoordinate(row, col))
            {
                if (board[row, col].IsMine) //pokud je v buňce mina
                {
                    board[row, col].IsRevealed = true;
                }
                else //pokud není
                {
                    RevealCell(row, col);
                }
            }
        }
        private void RevealCell(int row, int col) //odhalení buňky
        {
            if (!IsValidCoordinate(row, col) || board[row, col].IsRevealed)
            {
                return;
            }

            board[row, col].IsRevealed = true;

            if (board[row, col].AdjacentMines == 0) // kontrola pole po odhalení nových buněk
            {
                for (int i = Math.Max(0, row - 1); i <= Math.Min(gridSizeRows - 1, row + 1); i++)
                {
                    for (int j = Math.Max(0, col - 1); j <= Math.Min(gridSizeColumns - 1, col + 1); j++)
                    {
                        RevealCell(i, j);
                    }
                }
            }
        }
        public bool CheckLoss() //funkce pokud hra skončí prohrou
        {
            for (int i = 0; i < gridSizeRows; i++)
            {
                for (int j = 0; j < gridSizeColumns; j++)
                {
                    if (board[i, j].IsMine && board[i, j].IsRevealed)
                    {
                        return true; // pokud se trefí hráč
                    }
                }
            }
            return false; // pokud se hráč netrefí
        }
        public bool CheckWin() //funkce pokud hra skončí výhrou
        {
            for (int i = 0; i < gridSizeRows; i++)
            {
                for (int j = 0; j < gridSizeColumns; j++)
                {
                    if (!board[i, j].IsMine && !board[i, j].IsRevealed)
                    {
                        return false; // pokud najde buňku bez miny
                    }
                }
            }
            return true; // pokud jsou již všechny miny odhaleny 
        }

    }
}