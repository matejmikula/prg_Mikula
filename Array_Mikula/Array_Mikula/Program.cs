using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Mikula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            Console.WriteLine("write number of columns:");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("write number of rows:");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("\n");
            Console.WriteLine("Array length of your choosing");
            int[,] UserArray = new int[a, b];
            Console.WriteLine("Random fill: 1");
            Console.WriteLine("Gradual fill: 2");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    UserArray = Random(UserArray);
                    break;
                case 2:
                    UserArray = Gradual(UserArray);
                    break;
            }
            int operation = Convert.ToInt32(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    UserArray = SwapNumber(UserArray); 
                    break;   
            }


            Console.ReadKey();                  
        }
        static int[,] Random(int[,] UserArray)
        {
            int a = UserArray.GetLength(0);
            int b = UserArray.GetLength(1);
            Random random = new Random();
            for (int i = 0; i < UserArray.GetLength(0); i++)
            {
                for (int j = 0; j < UserArray.GetLength(1); j++)
                {
                    UserArray[i, j] = random.Next(1, 99);
                    Console.Write(UserArray[i, j] + " ");
                }
                Console.Write("\n");
                Console.WriteLine();
            }
            Console.WriteLine();

            return UserArray;
          
        }
        static int[,] Gradual(int[,] UserArray)
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
                    Console.Write(UserArray[i, j] + " ");
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            return UserArray;
        }
        static int[,] SwapNumber(int[,] UserArray)
        {
            int xFirst, yFirst, xSecond, ySecond;
            Console.WriteLine("write index of the first number you want to switch");
            xFirst = Convert.ToInt32(Console.ReadLine());
            yFirst = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("write index of the second number you want to switch");
            xSecond = Convert.ToInt32(Console.ReadLine());
            ySecond = Convert.ToInt32(Console.ReadLine());

            int temporary = UserArray[xFirst, yFirst];
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
        
    }
}
