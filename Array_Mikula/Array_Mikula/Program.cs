using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Mikula
{
    internal class Program
    {
        static void Main(string[] args)
        {
        double a, b;
        Console.WriteLine("Napiš zde kolik má mít list sloupců:")
        b = Console.ReadLine();
        Console.WriteLine("Napiš zde kolik má mít list řádků:")
        a = Console.ReadLine();
        int[,] UserArray = new int[a,b]
            for (int i = 0; i < UserArray.GetLength(0); i++) 
             { 
                 for (int j = 0; j < UserArray.GetLength(1); j++) 
                 { 
                     UserArray[i,j] = i * 5 + j + 1; 
                     Console.Write(UserArray[i, j] + " "); 
                 } 
                 Console.Write("\n"); 
             } 
             Console.WriteLine();
        Console.ReadKey();
        }
    }
}
