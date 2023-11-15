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
        a = Console.ReadLine();
        b = Console.ReadLine();
        int [,] = new int [a,b]
            for (int i = 0; i < My2dArray.GetLength(0); i++) 
             { 
                 for (int j = 0; j < My2dArray.GetLength(1); j++) 
                 { 
                     My2dArray[i,j] = i * 5 + j + 1; 
                     Console.Write(My2dArray[i, j] + " "); 
                 } 
                 Console.Write("\n"); 
             } 
             Console.WriteLine();
        
        }
    }
}
