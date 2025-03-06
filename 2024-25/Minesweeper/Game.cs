using System;

namespace Minesweeper
{
    internal class Game
    {
        private Board gameBoard;
        private Player player;
        private bool gameOver;

        public Game()
        {
            player = new Player();
            gameOver = false;
        }

        public void Start()
        {
            while (true) // hlavní loop hry
            {
                gameBoard = new Board(); // vytvoření nového pole pro každou hru
                gameOver = false;

                while (true) // Loop na kontrolu inputů min
                {
                    Console.Write($"Enter the number of mines (maximum {gameBoard.maxMines}): ");
                    int mineCount;
                    if (!int.TryParse(Console.ReadLine(), out mineCount))
                    {
                        Console.WriteLine("Invalid input. Please enter a number."); //zpráva pokud uživatel zadá symbol a ne číslo
                        continue;
                    }
                    if (mineCount > gameBoard.maxMines || mineCount < 0)
                    {
                        Console.WriteLine($"Invalid mine count. Please enter a number between 0 and {gameBoard.maxMines}."); //zpráva pokud zadá moc malé/velké číslo
                        continue;
                    }

                    Console.WriteLine("Game started!");
                    gameBoard.PlaceMinesRandomly(mineCount);
                    gameBoard.CalculateAdjacentMines();
                    gameBoard.PrintBoard();
                    break; // konec loopu pro miny
                }

                while (!gameOver) // loop pro tahy hry
                {
                    Console.WriteLine("1. Flag Cell");
                    Console.WriteLine("2. Uncover Cell");
                    Console.Write("Enter your choice: ");
                    int choice;
                    int.TryParse(Console.ReadLine(), out choice); //konvertování charu do integeru

                    switch (choice) //switch pro možnosti hráče
                    {
                        case 1:
                            player.FlagCell(gameBoard);
                            break;
                        case 2:
                            player.UncoverCell(gameBoard);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter 1 or 2."); //zpráva pokud uživatel nezadá jednu z možných možností 
                            continue;
                    }
                    gameBoard.PrintBoard(); //vyzuální nahrání pole
                    Console.Write($"remaining mines {gameBoard.maxMines}"); //mine counter, aby uživatel věděl kolik min mu zbývá
                    Console.Write('\n');

                    if (gameBoard.CheckLoss())
                    {
                        Console.WriteLine("You hit a mine! Game over.");
                        gameOver = true;
                    }
                    else if (gameBoard.CheckWin())
                    {
                        Console.WriteLine("Congratulations! You won!"); 
                        gameOver = true;
                    }
                    // pokud se hra ukončí (výhra nebo prohra), gameOver se dá na true aby se mohl loop ukončit, kdyby hráčjiž nechtěl hrát
                }

                if (gameOver)
                {
                    Console.WriteLine("Do you want to play another game? (Y/N)");
                    string newGameW = Console.ReadLine().ToLower();
                    if (newGameW != "y")
                    {
                        break;
                    }
                    //pokud by hráč chtěl zapnout novou hru, tak se ukončí tenhle inner loop a začne se opět v hlavním loopu
                }
            }
        }
    }
}