using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<char> rows = new List<char>() {'a','b','c','d','e','f','g','h','i','j'};
            bool validInput = false;
            while (!validInput)
            {
                string input = Console.ReadLine();
                if (input.Length != 1)
                {
                    validInput = false;
                }
                else
                {
                    char row = input[0];
                    int index = rows.IndexOf(row);
                    if (index == -1)
                    {
                        validInput = false;
                    }
                    else
                    {
                        validInput = true;
                    }
                }
            }
        }
    }
}
