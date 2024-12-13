using System;
using System.Collections.Generic;

namespace Battleships
{
    internal class Program
    {
        const int gridSize = 10; //zakreslení velikosti pole a pojmenování sloupců/řad
        static List<int> columns = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        static List<char> rows = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

        static bool carrierPlaced = false; //kontrola zda jsou lodě položené, tohle je ještě před začátkem hry tudíž = false
        static bool battleshipPlaced = false;
        static bool cruiserPlaced = false;
        static bool submarinePlaced = false;
        static bool destroyerPlaced = false;
        static bool kosatkaPlaced = false;
        static bool shipshot = false;

        static void Main(string[] args)
        {
            char[,] board = new char[gridSize, gridSize]; //vygenerování velikosti pole podle předešlého konstantního intu
            char[,] boardBot = new char[gridSize, gridSize];

            InitializeBoard(board); // vytvoření přímo pole
            InitializeBoard(boardBot);

            while (true)
            {
                //znova kontrola zda nejsou lodě položené, na konci place tahu to breakne loop a pošle hráče na tah střelby
                if (carrierPlaced && battleshipPlaced && cruiserPlaced && submarinePlaced && destroyerPlaced)
                { 
                    Console.WriteLine("All ships have been placed. Moving to the attack phase.");
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
                Console.WriteLine("Kosatka [2/4, K]");
                Console.WriteLine("Carrier [1/5,C]");
                Console.WriteLine("Battleship [1/4,B]");
                Console.WriteLine("Cruiser [1/3,R]");
                Console.WriteLine("Submarine [1/3,S]");
                Console.WriteLine("Destroyer [1/2,D]");

                string shipInput = Console.ReadLine().ToLower(); // zjistí jakou loď chce hráč položit

                if (string.IsNullOrWhiteSpace(shipInput)) //opět jedna z kontrol formátu
                {
                    Console.WriteLine("Invalid ship. Please try again.");
                    continue;
                }

                if ((shipInput == "carrier" && carrierPlaced) || //kontrola zda loď není už položena (kvůli dalším kolům v loopu)
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
                        shipSymbol = 'Ķ';
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

                if (!CanPlaceShip(board, rowIndex, colIndex, shipLength, shipWidth,direction)) //kontrola zda by loď na určitém indexu v určitém směru nebyla mimo hrací pole
                {
                    Console.WriteLine("Cannot place the ship here. Check for overlaps or out-of-bounds.");
                    continue;
                }

                PlaceShip(board, rowIndex, colIndex, shipLength, shipWidth, direction, shipSymbol); // funkce pro položení lodi

                switch (shipInput) // zapíše, že jsou lodě už položené, aby se nemohli pokládat znova, na začatku loopu ošetřeno
                {
                    case "carrier": carrierPlaced = true; break;
                    case "battleship": battleshipPlaced = true; break;
                    case "cruiser": cruiserPlaced = true; break;
                    case "submarine": submarinePlaced = true; break;
                    case "destroyer": destroyerPlaced = true; break;
                    case "kosatka": kosatkaPlaced = true; break;
                }

                Console.WriteLine($"{shipInput} placed successfully!");
            }

            BotPlaceShips(boardBot); // zobrazení pole bota (samozřejmě bez ukázání jeho lodí


            while (true) //loop pro střelbu
            {
                if (shipShot)
                {
                    Console.WriteLine("All ships have been placed. Moving to the attack phase.");
                    break;
                }
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
                    break;
                }

                if (cellInput.Length < 2) //opět kontrola délky charakterů a mezer
                {
                    Console.WriteLine("Invalid cell. Please enter a valid cell (e.g., a5).");
                    continue;
                }

                char row = cellInput[0]; // opět... už to nebudu znova psát je to to samé co u pokládání lodí
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
                }

                Console.WriteLine("You shoot here:"); //zobrazení obou polí aby hráč věděl jak na tom je on a jak soupeř
                DisplayBoardBot(boardBot);
                BotShoot(board);
                Console.WriteLine("Bot shoots here:");
                DisplayBoard(board);

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

        static void DisplayBoardBot(char[,] boardBot) //funkce pro zobrazení pole protihráče v konzoli
        {
            Console.Write("   "); //popsáno dříve v displayBoard
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
                    if (boardBot[i, j] == 'X' || boardBot[i, j] == 'O')
                    {
                        Console.Write($"[{boardBot[i, j]}]");
                    }
                    else
                    {
                        Console.Write("[.]");
                    }
                }
                Console.WriteLine();
            }
        }

        static void BotShoot(char[,] board) // funkce pro střelbu bota
        {
            Random random = new Random(); // vytvoření nového random
            while (true)
            {
                int row = random.Next(0, gridSize); // náhodné vybrání souřadnice v řádku
                int col = random.Next(0, gridSize); // to samé ale ve sloupci

                if (board[row, col] == '.' || char.IsLetter(board[row, col])) 
                {
                    if (board[row, col] == '.') // pokud bot vytřelí na prázdné pole se znakem [.] pak se zapíše nový znak [O]
                    {
                        Console.WriteLine($"Bot shoots at {rows[row]}{col + 1}: Miss!");
                        board[row, col] = 'O';
                    }
                    else // pokud se bot trefí do nějaké z lodí tak se její znak přepíše na [X]
                    {
                        Console.WriteLine($"Bot shoots at {rows[row]}{col + 1}: Hit {board[row, col]}!");
                        board[row, col] = 'X';
                    }
                    break;
                }
            }
        }

        static void BotPlaceShips(char[,] boardBot) //funkce pro place lodí bota 
        {
            var ships = new List<(string name, int length,int width, char symbol)> //list lodí pro bota
            {
                ("Carrier", 5, 1,'C'),
                ("Battleship", 4, 1, 'B'),
                ("Cruiser", 3, 1,'R'),
                ("Submarine", 3, 1,'S'),
                ("Destroyer", 2, 1, 'D'),
                ("Kosatka", 4, 2, 'K')
            };

            Random random = new Random(); // opět vytvoření nového randomu pro place lodí

            foreach (var ship in ships)
            {
                bool placed = false; //pokud nějaká z lodí není placenutá loop se opakuje

                while (!placed) 
                {
                    int startRow = random.Next(0, gridSize); //random výběr souřadnic opět
                    int startCol = random.Next(0, gridSize);
                    string direction = random.Next(0, 2) == 0 ? "horizontal" : "vertical"; // random výběr zda jsou horizontálně nebo vertikálně

                    if (CanPlaceShip(boardBot, startRow, startCol, ship.length, ship.width, direction)) // kontrola zda se souřadnice lodí nepřekrívají a že je loď v souřadnicích pole
                    {
                        PlaceShip(boardBot, startRow, startCol, ship.length, ship.width, direction, ship.symbol); // položení lodi
                        placed = true; //pokud jsou všechny lodě položené ukončí loop
                    }
                }
            }
        }

        static bool CanPlaceShip(char[,] board, int startRow, int startCol, int length, int width, string direction) // funkce pro kontrolu zda lze loď položit
        {
            if (direction == "vertical") // pokud je loď vertikálně
            {
                if (startRow + length > gridSize || startCol + width > gridSize) return false; //kontrola že loď není mimo hrací pole

                for (int i = startRow; i < startRow + length; i++) //kontrola pokud tato loď lze položit na určených souřadnicícha v určeném směru
                {
                    for (int j = startCol; j < startCol + width; j++)
                    {
                        if (board[i, j] != '.') return false;
                    }
                }
            }
            else if (direction == "horizontal") // to samé ale pro horizontální položení
            {
                if (startCol + length > gridSize || startRow + width > gridSize) return false;

                for (int i = startRow; i < startRow + width; i++)
                {
                    for (int j = startCol; j < startCol + length; j++)
                    {
                        if (board[i, j] != '.') return false;
                    }
                }
            }

            return true;
        }

        static void PlaceShip(char[,] board, int startRow, int startCol, int length, int width, string direction, char symbol)
        {
            if (direction == "vertical") // položení lodi
            {
                for (int i = startRow; i < startRow + length; i++) 
                {
                    for (int j = startCol; j < startCol + width; j++) 
                    {
                        board[i, j] = symbol; //napsání správného smybolu místo [.] na souřadnice kam chceme položit loď
                    }
                }
            }
            else if (direction == "horizontal") //to samé horizontalně
            {
                for (int i = startRow; i < startRow + width; i++) 
                {
                    for (int j = startCol; j < startCol + length; j++)
                    {
                        board[i, j] = symbol;
                    }
                }
            }
        }
    }
}
