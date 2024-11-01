using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_and_Dictionaries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string op;
            List<string> FavFood = new List<string>();

            while (true)
            {
                Console.WriteLine("Add food, remove food, status food");
                op = Console.ReadLine();
                op = op.ToLower();
                if (op == "add food")
                {
                    Console.WriteLine("write the name of your new favorite food");
                    FavFood.Add(Console.ReadLine());
                }
                else if (op == "remove food")
                {
                    if (FavFood.Count <= 0)
                    {
                        Console.WriteLine("there aren´t any foods here (yet)");
                        continue;
                    }
                    else if (FavFood.Count > 0)
                    {
                        Console.WriteLine("which do you want to remove?");
                        foreach (string food in FavFood)
                        {
                            Console.WriteLine($"your choices are: {food}");
                        }
                        FavFood.Remove(Console.ReadLine());

                    }
                }
                else if (op == "status food")
                {
                    if (FavFood.Count > 0)
                    {
                        foreach (string food in FavFood)
                        {
                            Console.WriteLine($"your favorite foods are: {food}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("there aren´t any foods here (yet)");
                        continue;
                    }
                    
                }
                else
                {
                    Console.WriteLine("wrong input try again");
                    continue;
                }
                
                string newOP;
                Console.WriteLine("do you want to add/remove anything else or check status? Y/N");
                newOP = Console.ReadLine();
                newOP = newOP.ToLower();
                if (newOP != "y")
                {
                    break;
                }
            }
        }
    }
}
