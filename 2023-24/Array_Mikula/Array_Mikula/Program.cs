using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Array_Mikula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, j;

            Console.WriteLine("Write the number of columns:");
            j = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Write the number of rows:");
            i = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n");
            Console.WriteLine("Array length of your choosing");

            int[,] UserArray = new int[i, j];

            Console.WriteLine("Random fill: 1");
            Console.WriteLine("Gradual fill: 2");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice) // možnosti vytvoření Arraye dle typu
            {
                case 1:
                    UserArray = Random(UserArray);
                    break;
                case 2:
                    UserArray = Gradual(UserArray);
                    break;
            }

            Console.WriteLine("Write the operation you want to perform");
            Console.WriteLine("1: Swap places of numbers");
            Console.WriteLine("2: Swap places of rows");
            Console.WriteLine("3: Swap places of columns");
            Console.WriteLine("4: Swap places of numbers on the main diagonal");
            Console.WriteLine("5: Swap places of numbers on the second diagonal");
            Console.WriteLine("6: Swap numbers around the main diagonal");
            Console.WriteLine("7: Multiplication of array by a number");
            Console.WriteLine("8: Array addition");
            Console.WriteLine("9: Array subtraction");

            int operation = Convert.ToInt32(Console.ReadLine());
            int[,] UserArray2;

            switch (operation) // všechny vytvořené možnosti operací s Arrayi  
            {
                case 1:
                    UserArray = SwapNumber(UserArray);
                    break;
                case 2:
                    UserArray = SwapRows(UserArray);
                    break;
                case 3:
                    UserArray = SwapColumns(UserArray);
                    break;
                case 4:
                    UserArray = SwapNumbersMainDiagonal(UserArray);
                    break;
                case 5:
                    UserArray = SwapNumbersSecondDiagonal(UserArray);
                    break;
                case 6:
                    UserArray = Transposition(UserArray);
                    break;
                case 7:
                    UserArray = Multiplication(UserArray);
                    break;
                case 8:
                    Console.WriteLine("Enter the second array:");
                    UserArray2 = ControlArrayInput(UserArray);
                    ArrayAddition(UserArray, UserArray2);
                    break;
                case 9:
                    Console.WriteLine("Enter the second array:");
                    UserArray2 = ControlArrayInput(UserArray);
                    ArraySubtraction(UserArray, UserArray2);
                    break;
            }

            Console.ReadKey();
        }

        static int[,] Random(int[,] UserArray) //vytvoření Array s náhodnými čísly od 1 do 99
        {
            int a = UserArray.GetLength(0);
            int b = UserArray.GetLength(1);
            Random random = new Random();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    UserArray[i, j] = random.Next(1, 99);
                    Console.Write($"{UserArray[i, j]} ");
                }
                Console.Write("\n");
            }

            Console.WriteLine();
            return UserArray;
        }
        static int[,] Gradual(int[,] UserArray) //vytvoření postupného Arraye
        {
            int counter = 0;
            int a = UserArray.GetLength(0);
            int b = UserArray.GetLength(1);
            Random random = new Random();
            for (int i = 0; i < UserArray.GetLength(0); i++)
            {
                for (int j = 0; j < UserArray.GetLength(1); j++)
                {
                    UserArray[i, j] = ++counter;
                    Console.Write($"{UserArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            return UserArray;
        }
        static int[,] SwapNumber(int[,] UserArray) //výměna dvou čísel podle indexu
        {
            int xFirst, yFirst, xSecond, ySecond;
            Console.WriteLine("write index of the first number you want to switch (1st X 2nd Y)");
            xFirst = Convert.ToInt32(Console.ReadLine()); 
            yFirst = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("write index of the second number you want to switch (1st X 2nd Y)");
            xSecond = Convert.ToInt32(Console.ReadLine());
            ySecond = Convert.ToInt32(Console.ReadLine());

            int temporary = UserArray[xFirst, yFirst]; // dočasně uchovaná původni souřadnice v integeru Temporary
            UserArray[xFirst, yFirst] = UserArray[xSecond, ySecond];
            UserArray[xSecond, ySecond] = temporary;

            for (int i = 0; i < UserArray.GetLength(0); i++)
            {
                for (int j = 0; j < UserArray.GetLength(1); j++)
                {
                    Console.Write($"{UserArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            return UserArray;
        }
        static int[,] SwapRows(int[,] UserArray)
        {
            int nRowSwap, mRowSwap;
            Console.WriteLine("write the index of the first row you want to swap");
            nRowSwap = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("write the index of the second row you want to swap");
            mRowSwap = Convert.ToInt32(Console.ReadLine()); 

            for (int j = 0; j < UserArray.GetLength(1); j++) // přes sloupce
            {
                int temp = UserArray[nRowSwap, j];
                UserArray[nRowSwap, j] = UserArray[mRowSwap, j];
                UserArray[mRowSwap, j] = temp;
            }

            for (int i = 0; i < UserArray.GetLength(0); i++) // přes řádky
            {
                for (int j = 0; j < UserArray.GetLength(1); j++) // znovu přes sloupce
                {
                    Console.Write($"{UserArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            return UserArray;

        }
        static int[,] SwapColumns(int[,] UserArray) //(nefunkční) výměna sloupců
        {
            int nColSwap, mColSwap;
            Console.WriteLine("Write the index of the first column you want to swap:");
            nColSwap = Convert.ToInt32(Console.ReadLine()); // index prvního sloupce
            Console.WriteLine("Write the index of the second column you want to swap:");
            mColSwap = Convert.ToInt32(Console.ReadLine()); // index 2 sloupce

            for (int i = 0; i < UserArray.GetLength(1); i++) // přes řádky
            {
                int temp = UserArray[i, nColSwap];
                UserArray[i, nColSwap] = UserArray[i, mColSwap];
                UserArray[i, mColSwap] = temp;
            }

            for (int i = 0; i < UserArray.GetLength(0); i++) // přes řádky
            {
                for (int j = 0; j < UserArray.GetLength(1); j++) // přes sloupce
                {
                    Console.Write($"{UserArray[i, j]} ");
                }
                Console.Write("\n");
            }

            Console.WriteLine();

            return UserArray;
            // dělal jsem to podle vzoru na Yeenya repozitáři, ale z nějakýho důvodu mi to nechce prohazovat celý sloupce. Zkoušel jsem se ptát aj chatgpt, ale ten mi s tím taky nepomohl, ale řekl jsem si, že to jsem dám radši i nefunkční...

        }
        static int[,] SwapNumbersMainDiagonal(int[,] UserArray)
        {
            for (int i = 0; i < UserArray.GetLength(0) / 2; i++) // přes rádky/sloupce
            {
                int temp = UserArray[i, i];
                int coordToSwap = UserArray.GetLength(0) - 1 - i;
                UserArray[i, i] = UserArray[coordToSwap, coordToSwap];
                UserArray[coordToSwap, coordToSwap] = temp;
            }

            for (int i = 0; i < UserArray.GetLength(0); i++) // přes řádky
            {
                for (int j = 0; j < UserArray.GetLength(1); j++) // přes sloupce
                {
                    Console.Write($"{UserArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            return UserArray;
        }
        static int[,] SwapNumbersSecondDiagonal(int[,] UserArray) //výměna pozic čísel na vedlejší diagonále
        {
            for (int i = UserArray.GetLength(0) - 1; i > UserArray.GetLength(0) / 2; i--) // přes řádky a sloupce
            {
                int j = UserArray.GetLength(0) - 1 - i;
                int temp = UserArray[i, j];
                UserArray[i, j] = UserArray[j, i];
                UserArray[j, i] = temp;
            }

            for (int i = 0; i < UserArray.GetLength(0); i++) // přes řádky
            {
                for (int j = 0; j < UserArray.GetLength(1); j++) // přes sloupce
                {
                    Console.Write($"{UserArray[i, j]} ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            return UserArray;

        }
        static int[,] Transposition(int[,] UserArray) //výměna pozic čísel podle hlavní diagonáli
        {
            int[,] TransposedArray = new int[UserArray.GetLength(1), UserArray.GetLength(0)];

            for (int i = 0; i < UserArray.GetLength(0); i++)
            {
                for (int j = 0; j < UserArray.GetLength(1); j++)
                {
                    UserArray[i, j] = TransposedArray[j, i];
                    Console.Write($"{UserArray[j, i]} ");
                }
                Console.Write("\n");
            }

            Console.WriteLine();

            return UserArray;

        }
        static int[,] Multiplication(int[,] UserArray)
        {
            int MultiplicationNumber;
            Console.WriteLine("Enter the the number you want to multiply the array by:");
            MultiplicationNumber = Convert.ToInt32(Console.ReadLine()); ;
            {
                int rows = UserArray.GetLength(0);
                int columns = UserArray.GetLength(1);

                int[,] ResultArray = new int[rows, columns];

                for (int i = 0; i < rows; i++) //for lopp na násobení Arraye vybraným číslem
                {
                    for (int j = 0; j < columns; j++)
                    {
                        ResultArray[i, j] = UserArray[i, j] * MultiplicationNumber; // tady se to znásobí
                        Console.Write($"{ResultArray[i, j]} ");
                    }
                    Console.Write("\n");
                }
            }
            return UserArray;
        }
        static int[,] ArrayAddition(int[,] UserArray, int[,] UserArray2) // sčítání Arrayu
        {
            int[,] Result = Addition(UserArray, UserArray2);

            for (int i = 0; i < Result.GetLength(0); i++)
            {
                for (int j = 0; j < Result.GetLength(1); j++)
                {
                    Console.WriteLine("Here is your result");
                    Console.Write($"{Result[i, j]} ");
                }
                Console.WriteLine();
            }

            return Result;
        }

        static int[,] Addition(int[,] UserArray, int[,] UserArray2)
        {
            int rows = UserArray.GetLength(0);
            int columns = UserArray.GetLength(1);

            int[,] ResultArray = new int[rows, columns];

            for (int i = 0; i < rows; i++) //for loop na výpočet sčítání
            {
                for (int j = 0; j < columns; j++)
                {
                    ResultArray[i, j] = UserArray[i, j] + UserArray2[i, j]; //tady se to sčítá
                }
            }
            return ResultArray;
        }
        static int[,] ArraySubtraction(int[,] UserArray, int[,] UserArray2) //sečtení dvou Arrayu
        {
            int[,] Result = Subtraction(UserArray, UserArray2);

            for (int i = 0; i < Result.GetLength(0); i++)
            {
                for (int j = 0; j < Result.GetLength(1); j++)
                {
                    Console.WriteLine("Here is your result");
                    Console.Write($"{Result[i, j]} ");
                }
                Console.WriteLine();
            }

            return Result;
        }
        static int[,] Subtraction(int[,] UserArray, int[,] UserArray2)
        {
            int rows = UserArray.GetLength(0);
            int columns = UserArray.GetLength(1);

            int[,] ResultArray = new int[rows, columns];

            for (int i = 0; i < rows; i++) //for loop na výpočet odčítání
            {
                for (int j = 0; j < columns; j++)
                {
                    ResultArray[i, j] = UserArray[i, j] - UserArray2[i, j]; //tady se to odčítá
                }
            }
            return ResultArray;
        }
        static int[,] ControlArrayInput(int[,] UserArray)
        {
            while (true)
            {
                Console.WriteLine($"Enter the size of the row for the new array (must be the same as the first array):");
                int rows2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the size of the column for the new array (must be the same as the first array):");
                int columns2 = int.Parse(Console.ReadLine());

                if (rows2 == UserArray.GetLength(0) && columns2 == UserArray.GetLength(1))
                {
                    int[,] newArray = new int[rows2, columns2];

                    Console.WriteLine("For random fill enter 1:");
                    Console.WriteLine("For gradual fill enter 2");

                    int choice2 = int.Parse(Console.ReadLine());

                    switch (choice2)
                    {
                        case 1:
                            newArray = Random(newArray);
                            break;
                        case 2:
                            newArray = Gradual(newArray);
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;// kontrola výběru jedný ze dvou možností
                    }
                    return newArray;
                }
                else
                {
                    Console.WriteLine("The dimensions of the new array must be the same as the first array. Please try again."); //kontrola dimenzí druhého arraye
                }
            }
        
        }
    }
} //s formátováním a opravováním některých chybných operací jsem si pomohl pomocí chatGPT. S vysvětlováním a programováním Arrayi mi hodně pomáhal Vašek (Košler), tak je možný že budu mít některý věci hodně podobný ne-li stejný jako on.
