﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace ArrayPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int[] nums = { 10, 20, 30, 40, 50 };

            //TODO 2: Vypiš do konzole všechny prvky pole, zkus klasický for, kde i využiješ jako index v poli, a foreach (vysvětlíme si).
            Console.WriteLine("vypiš for cyklus");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

            foreach (int num in nums) 
            { 
                Console.WriteLine(num); 
            }
            //TODO 3: Spočti sumu všech prvků v poli a vypiš ji uživateli.
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num; // +=, *=, ==, /=  
            }
            //TODO 4: Spočti průměr prvků v poli a vypiš ho do konzole.
            int average = sum / nums.Length;
            Console.WriteLine("Průměr: " + average);
            //TODO 5: Najdi maximum v poli a vypiš ho do konzole.
            int max = nums[0];
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > max)
                {
                    max = nums[i]; 
                }
            }
            Console.WriteLine("Maximum: " + max);
            //TODO 6: Najdi minimum v poli a vypiš ho do konzole.
            int min = nums.Min();
            Console.WriteLine("Minimum: " + min);
            //TODO 7: Vyhledej v poli číslo, které zadá uživatel, a vypiš index nalezeného prvku do konzole.
            int number = int.Parse(Console.ReadLine());
            int index = Array.IndexOf(nums, number);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == number)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("Prvek v tomto poli neexistuje.");
            }
            else
            {
                Console.WriteLine($"prvek {number} je na indexu {index}");
            }
            //TODO 8: Změň tvorbu integerového pole tak, že bude obsahovat 100 náhodně vygenerovaných čísel od 0 do 9. Vytvoř si na to proměnnou typu Random.
            Random random = new Random();
            nums = new int[100];
            for (int i = 0; i < 100; i++)
            {
                nums[i] = random.Next(0, 10);
                Console.WriteLine($"{i}-tý prvek pole je {nums[i]}");
            }
            //TODO 9: Spočítej kolikrát se každé číslo v poli vyskytuje a spočítané četnosti vypiš do konzole.
            int[] counts = new int[10];
            foreach (int num in nums)
            {
                counts[num]++;
            }
            {

            }
            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine($"četnost {i} je {counts[i]}");
            }

            //TODO 10: Vytvoř druhé pole, do kterého zkopíruješ prvky z prvního pole v opačném pořadí.
            int[] reverseArray = new int[100];
            for (int i = reverseArray.Length - 1; i >= 0; i--)
            {
                reverseArray[i] = nums[nums.Length - 1 - i];
            }
            for (int i = 0; i < reverseArray.Length; i++)
            {
                Console.Write($"{reverseArray[i]}");
            }

            Console.ReadKey();
        }
    }
}
