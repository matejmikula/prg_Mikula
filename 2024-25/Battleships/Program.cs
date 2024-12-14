using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Battleships
{
    internal class Program
    {
        const int gridSize = 10; //zakreslení velikosti pole a pojmenování sloupců/řad
        static List<int> columns = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static List<char> rows = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
        static List<string> availableShips = new List<string> { "Kosatka [2/4, k]", "carrier [1/5, C]", "battleship[1/4, B]", "cruiser[1/3, R]", "submarine[1/3, S]", "destroyer[1/2, D]" };

        static bool carrierPlaced = false; //kontrola zda jsou lodě položené, tohle je ještě před začátkem hry tudíž = false
        static bool battleshipPlaced = false;
        static bool cruiserPlaced = false;
        static bool submarinePlaced = false;
        static bool destroyerPlaced = false;
        static bool kosatkaPlaced = false;



        static void Main(string[] args)
        {
            int shipCellsEnemy = 25; //kopletní počet bodů na kterých stojí lodě
            int shipCellsPlayer = 25;
            char[,] board = new char[gridSize, gridSize]; //vygenerování velikosti pole podle předešlého konstantního intu
            char[,] boardBot = new char[gridSize, gridSize];
            bool exitGame = false;

            
            while (!exitGame)
            {
                InitializeBoard(board); // vytvoření přímo pole
                InitializeBoard(boardBot);
                while (!exitGame)
                {
                    //znova kontrola zda nejsou lodě položené, na konci place tahu to breakne loop a pošle hráče na tah střelby
                    if (carrierPlaced && battleshipPlaced && cruiserPlaced && submarinePlaced && destroyerPlaced && kosatkaPlaced)
                    {
                        Console.WriteLine("All ships have been placed. Moving to the attack phase.");
                        Console.Write("\n");
                        break;
                    }

                    DisplayBoard(board); //zobrazení pole v konzoli
                    Console.WriteLine("Enter a cell (e.g., a5) or type 'quit' to exit:");
                    string cellInput = Console.ReadLine().ToLower(); // vezme si souřadnice od hráče

                    if (string.IsNullOrWhiteSpace(cellInput)) // kontrola zda je to ve správném formátu
                    {
                        Console.WriteLine("Invalid cell. Please try again.");
                        continue;
                    }

                    if (cellInput == "quit") //pokud hráč již nechce hrát, vypne hru
                    {
                        Console.WriteLine("Exiting the game. Goodbye!");
                        exitGame = true;
                        break;
                    }

                    if (cellInput.Length < 2) //opět kontrola formátu, musí být pouze dva charaktery bez mezer
                    {
                        Console.WriteLine("Invalid cell. Please enter a valid cell (e.g., a5).");
                        continue;
                    }

                    char row = cellInput[0]; // příjmá první chrakter, písmenka 
                    string columnPart = cellInput.Substring(1); // příjmá druhý chrakter, čísla

                    if (!rows.Contains(row)) //kontrola zda je zde řada s vloženým písmenem
                    {
                        Console.WriteLine("Invalid row. Please enter a valid row (a-j).");
                        continue;
                    }

                    if (!int.TryParse(columnPart, out int column) || column < 1 || column > gridSize) // opět kontrola zda jsou zde sloupce s vloženým číslem
                    {
                        Console.WriteLine("Invalid column. Please enter a valid column (1-10).");
                        continue;
                    }

                    int rowIndex = rows.IndexOf(row); // získání indexu řady
                    int colIndex = column - 1; // získání indexu sloupce (musí být o jeden míň než co napíšeme protože index začíná v 0, ale sloupce  v 1)

                    Console.WriteLine($"You selected Row: {row} (Index: {rowIndex}), Column: {column} (Index: {colIndex}).");
                    Console.WriteLine("Which ship do you want to place?");
                    foreach (var ship in availableShips)
                    {
                        Console.WriteLine($"{(ship)}");
                    }
                    Console.Write("\n");

                    string shipInput = Console.ReadLine().ToLower(); // zjistí jakou loď chce hráč položit

                    if (string.IsNullOrWhiteSpace(shipInput)) //opět jedna z kontrol formátu
                    {
                        Console.WriteLine("Invalid ship. Please try again.");
                        continue;
                    }

                    if ((shipInput == "carrier" && carrierPlaced) ||
                        (shipInput == "battleship" && battleshipPlaced) ||
                        (shipInput == "cruiser" && cruiserPlaced) ||
                        (shipInput == "submarine" && submarinePlaced) ||
                        (shipInput == "destroyer" && destroyerPlaced) ||
                        (shipInput == "kosatka" && kosatkaPlaced))
                    {
                        Console.WriteLine("This ship has already been placed.");
                        continue;
                    }

                    Console.WriteLine("Do you want it horizontal or vertical?"); //směr položení lodi hráče
                    string direction = Console.ReadLine().ToLower();
                    Console.Write("\n");

                    if (direction != "horizontal" && direction != "vertical") //další kontrola vstupu
                    {
                        Console.WriteLine("Invalid direction. Please choose 'horizontal' or 'vertical'.");
                        continue;
                    }

                    int shipLength = 0;
                    int shipWidth = 0;
                    char shipSymbol = '.';

                    switch (shipInput) // délky, šířky a znaky lodí, které se vloží do pole
                    {
                        case "kosatka":
                            shipLength = 4;
                            shipWidth = 2;
                            shipSymbol = 'K';
                            break;
                        case "carrier":
                            shipLength = 5;
                            shipWidth = 1;
                            shipSymbol = 'C';
                            break;
                        case "battleship":
                            shipLength = 4;
                            shipWidth = 1;
                            shipSymbol = 'B';
                            break;
                        case "cruiser":
                            shipLength = 3;
                            shipWidth = 1;
                            shipSymbol = 'R';
                            break;
                        case "submarine":
                            shipLength = 3;
                            shipWidth = 1;
                            shipSymbol = 'S';
                            break;
                        case "destroyer":
                            shipLength = 2;
                            shipWidth = 1;
                            shipSymbol = 'D';
                            break;
                        default:
                            Console.WriteLine("Invalid ship. Please try again.");
                            continue;
                    }

                    if (!CanPlaceShip(board, rowIndex, colIndex, shipLength, shipWidth, direction)) //kontrola zda by loď na určitém indexu v určitém směru nebyla mimo hrací pole
                    {
                        Console.WriteLine("Cannot place the ship here. Check for overlaps or out-of-bounds.");
                        continue;
                    }

                    PlaceShip(board, rowIndex, colIndex, shipLength, shipWidth, direction, shipSymbol); // funkce pro položení lodi

                    switch (shipInput)
                    {
                        case "carrier": carrierPlaced = true; break;
                        case "battleship": battleshipPlaced = true; break;
                        case "cruiser": cruiserPlaced = true; break;
                        case "submarine": submarinePlaced = true; break;
                        case "destroyer": destroyerPlaced = true; break;
                        case "kosatka": kosatkaPlaced = true; break;
                    }
                    availableShips.RemoveAll(s => s.ToLower().Contains(shipInput));

                    Console.WriteLine($"{shipInput} placed successfully!");
                }

                if (exitGame == true)
                {
                    break;
                }
                BotPlaceShips(boardBot); // zobrazení pole bota (samozřejmě bez ukázání jeho lodí



                while (!exitGame) //loop pro střelbu
                {
                    Console.WriteLine("Enter a cell (e.g., a5), where you want to shoot or type 'quit' to exit:");
                    string cellInput = Console.ReadLine().ToLower(); //stejná funkce jako zvolení souřadnic pro pokládání lodí

                    if (string.IsNullOrWhiteSpace(cellInput)) //opět kontrola
                    {
                        Console.WriteLine("Invalid cell. Please try again.");
                        continue;
                    }

                    if (cellInput == "quit") // opět ukončení hry pokud hráč chce
                    {
                        Console.WriteLine("Exiting the game. Goodbye!");
                        exitGame = true;
                        break;
                    }

                    if (cellInput.Length < 2) //opět kontrola délky charakterů a mezer
                    {
                        Console.WriteLine("Invalid cell. Please enter a valid cell (e.g., a5).");
                        continue;
                    }

                    char row = cellInput[0];
                    string columnPart = cellInput.Substring(1);

                    if (!rows.Contains(row))
                    {
                        Console.WriteLine("Invalid row. Please enter a valid row (a-j).");
                        continue;
                    }

                    if (!int.TryParse(columnPart, out int column) || column < 1 || column > gridSize)
                    {
                        Console.WriteLine("Invalid column. Please enter a valid column (1-10).");
                        continue;
                    }

                    int rowIndex = rows.IndexOf(row);
                    int colIndex = column - 1;

                    if (boardBot[rowIndex, colIndex] == 'X' || boardBot[rowIndex, colIndex] == 'O') //kontrola zda jsem na toto místo už netřílel X pro zasažené O pro Miss
                    {
                        Console.WriteLine("You already shot at this cell. Try another one.");
                        continue;
                    }

                    if (boardBot[rowIndex, colIndex] == '.') // při střílení na pole pokud tam není loď na O = miss
                    {
                        Console.WriteLine("Miss!");
                        boardBot[rowIndex, colIndex] = 'O';
                    }
                    else
                    {
                        Console.WriteLine($"Hit! You hit a {boardBot[rowIndex, colIndex]}."); // při střílení na pole pokud tam je loď na X = trefeno
                        boardBot[rowIndex, colIndex] = 'X';
                        shipCellsEnemy--; // snížení bodů na kterých stojí lodě
                    }

                    if (shipCellsEnemy == 0)
                    {
                        Console.WriteLine("You win! All of the enemy's ships have been sunk!");
                        break;
                        
                    }

                    Console.WriteLine("You shoot here:"); //zobrazení obou polí aby hráč věděl jak na tom je on a jak soupeř
                    DisplayBoardBot(boardBot);
                    Console.WriteLine("");

                    BotShoot(board, ref shipCellsPlayer); // Pass shipCellsPlayer by reference
                    if (shipCellsPlayer == 0)
                    {
                        Console.WriteLine("You Lose.... All your ships have been sunk.");
                        break;
                    }
                    Console.WriteLine("");

                    Console.WriteLine("Bot shoots here:");
                    DisplayBoard(board);

                    Console.WriteLine($"remaining cells to destroy: {shipCellsEnemy}");
                    Console.WriteLine($"your remaining ship cellls: {shipCellsPlayer}");

                    
                }
                if (shipCellsEnemy == 0 || shipCellsPlayer == 0)
                {
                    Console.WriteLine("co you want to play another game? (Y/N)");
                    string newGameW = Console.ReadLine().ToLower();
                    if (newGameW != "y")
                    {
                        break;
                    }
                }
                carrierPlaced = false;
                battleshipPlaced = false;
                cruiserPlaced = false;
                submarinePlaced = false;
                destroyerPlaced = false;
                kosatkaPlaced = false;
                availableShips = new List<string> { "Kosatka [2/4, k]", "carrier [1/5, C]", "battleship[1/4, B]", "cruiser[1/3, R]", "submarine[1/3, S]", "destroyer[1/2, D]" };

            }
        }
            

        static void InitializeBoard(char[,] board) //vytvoření pole
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    board[i, j] = '.';
                }
            }
        }

        static void DisplayBoard(char[,] board) // vygenerování do konzole
        {
            Console.Write("   "); // vytvoření horního řádku s čísly po šířku pole
            for (int i = 1; i <= gridSize; i++)
            {
                Console.Write($"{i,3}"); // formátování tak aby mezi nimi byla vždy délka mezery 3
            }
            Console.WriteLine();

            // to samé akorát pro sloupec vlevo s čísly
            for (int i = 0; i < gridSize; i++)
            {
                Console.Write($"{rows[i]}  ");
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write($"[{board[i, j]}]");
                }
                Console.WriteLine();
            }
        }

        static void DisplayBoardBot(char[,] boardBot) //funkce pro zobrazení pole proti
        {
            Console.Write("   ");
            for (int i = 1; i <= gridSize; i++)
            {
                Console.Write($"{i,3}");
            }
            Console.WriteLine();

            for (int i = 0; i < gridSize; i++)
            {
                Console.Write($"{rows[i]}  ");
                for (int j = 0; j < gridSize; j++)
                {
                    char cell = boardBot[i, j];
                    if (cell != 'X' && cell != 'O')
                    {
                        cell = '.';
                    }
                    Console.Write($"[{cell}]");
                }
                Console.WriteLine();
            }
        }

        static bool CanPlaceShip(char[,] board, int startRow, int startCol, int length, int width, string direction)
        {
            if (direction == "horizontal")
            {
                if (startCol + length > gridSize || startRow + width > gridSize)
                    return false;

                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (startRow + j >= gridSize || startCol + i >= gridSize || board[startRow + j, startCol + i] != '.')
                            return false;
                    }
                }
            }
            else if (direction == "vertical")
            {
                if (startRow + length > gridSize || startCol + width > gridSize)
                    return false;

                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (startRow + i >= gridSize || startCol + j >= gridSize || board[startRow + i, startCol + j] != '.')
                            return false;
                    }
                }
            }

            return true;
        }

        static void PlaceShip(char[,] board, int startRow, int startCol, int length, int width, string direction, char symbol)
        {
            if (direction == "horizontal")
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        board[startRow + j, startCol + i] = symbol;
                    }
                }
            }
            else if (direction == "vertical")
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        board[startRow + i, startCol + j] = symbol;
                    }
                }
            }
        }
        static void BotPlaceShips(char[,] boardBot) // funkce pro pokládání lodí bota
        {
            var ships = new List<(int length, int width, char symbol)> // list všech přístupných lodí
            {
                (5, 1, 'C'), // Carrier
                (4, 1, 'B'), // Battleship
                (3, 1, 'R'), // Cruiser
                (3, 1, 'S'), // Submarine
                (2, 1, 'D'), // Destroyer
                (4, 2, 'K')  // Kosatka
            };

            Random random = new Random();

            foreach (var ship in ships) // loop pro položení lodí
            {
                bool placed = false;

                while (!placed) // pokud nějaká lodě není položena tak se loop opakuje
                {
                    int startRow = random.Next(gridSize); // náhodný výběr sloupce a řádku
                    int startCol = random.Next(gridSize); 
                    string direction = random.Next(0, 2) == 0 ? "horizontal" : "vertical"; // opět náhodný výběr směru

                    // kontrola zda loď s těmito parametry smí být položena
                    if (CanPlaceShip(boardBot, startRow, startCol, ship.length, ship.width, direction))
                    {
                        PlaceShip(boardBot, startRow, startCol, ship.length, ship.width, direction, ship.symbol);
                        placed = true; // označení lodi jako položená
                    }
                }
            }
        }




        static void BotShoot(char[,] board, ref int shipCellsPlayer)
        {
            Random rand = new Random();
            bool shot = false;

            while (!shot)
            {
                int row = rand.Next(gridSize);
                int col = rand.Next(gridSize);

                if (board[row, col] == '.') // Bot targets unexplored cells
                {
                    Console.WriteLine($"Bot missed at {rows[row]}{col + 1}.");
                    board[row, col] = 'O';
                    shot = true;
                }
                else if (board[row, col] != 'X' && board[row, col] != 'O') // Bot hits a ship
                {
                    Console.WriteLine($"Bot hit your ship at {rows[row]}{col + 1}!");
                    board[row, col] = 'X';
                    shot = true;
                    shipCellsPlayer--;
                }
            }
        }
    }
}