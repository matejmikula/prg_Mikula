using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num1, num2; // zadefinovani cisel a operace
            string operace;
            double vysledek = 0;

            while (true) //začátek cyklu
            {
                Console.WriteLine("1. napiš jednu z těchto operací +; -; *; /; mocnina; odmocnina; faktorial. ");
                operace = Console.ReadLine();

                Console.WriteLine("2. napiš první číslo.");
                string a;
                a = Console.ReadLine();

                Console.WriteLine("3. napiš druhé číslo (nebo mocninu)");
                Console.WriteLine("    (pokud počítáš pouze s jedním čísle [v této calc.:odmocnina nebo faktorial] tak zde napiš libovolné číslo)"); //nenašel jsem na internetu jiné oddělení pro odstavce než takéto hloupé bohužel
                string b;
                b = Console.ReadLine();

                if (double.TryParse(a, out num1) && double.TryParse(b, out num2)) //přehozené rovnou do double místo int nebo float
                {
                    if (operace == "+") 
                    {
                        vysledek = num1 + num2;
                    }
                    else if (operace == "-")
                    {
                        vysledek = num1 - num2;
                    }
                    else if (operace == "*")
                    {
                        vysledek = num1 * num2;
                    }
                    else if (operace == "/")
                    {
                        if (num2 == 0) //tento if zamezí dělit nulou, se kterou tato kalkulačka neumí počítat
                        {
                            Console.WriteLine("nulou nelze dělit.");
                            continue;
                        }
                        else
                        {
                            vysledek = num1 / num2;
                        }
                    }
                    else if (operace == "mocnina")
                    {
                        vysledek = Math.Pow(num1, num2);
                    }
                    else if (operace == "odmocnina")
                    {
                        vysledek = Math.Sqrt(num1);
                    }
                    else if (operace == "faktorial") 
                    {
                        vysledek = Factorial((int)num1);
                    }
                    else
                    {
                        Console.WriteLine("Neplatná operace, zkus to znovu."); // upozornění na chybu v zápisu operace, potom začíná celý výpočet znova
                        vysledek = 00000;
                        continue;
                    }
                    Console.WriteLine("4. Vše si zadal dobře tady máš výsledek ;p");
                    Console.WriteLine(vysledek);
                }
                else
                {
                    Console.WriteLine("Neplatný vstup, zkontroluj si, že si vše správně napsal."); // to samý jako předchozí else akorát pro to aby vstup byl vždy číslo 
                    continue;
                }

                Console.WriteLine("Chceš provést další výpočet? (Y/N)"); // možnost opakování cyklu (začátek nového příkladu)
                string novyPocet = Console.ReadLine().ToLower();
                if (novyPocet != "y")
                {
                    break; //konec cyklu
                }
            }
            Console.ReadKey();
        }
        static double Factorial(int n) // rekurzivní funkce pro výpočet faktoriálu z dnešní hodiny upravená (s výpomocí chatGPT), aby fungovala v mojí kalkulačce
        {
            if (n < 0)
            {
                Console.WriteLine("Faktoriál nelze spočítat pro záporné číslo.");
                return 0;
            }
            double vysledek = 1;
            for (int i = 1; i <= n; i++)
            {
                vysledek *= i;
            }
            return vysledek;
        }
    } // formatovani/prehlednost kodu mam taky upravene/ou v nekterych castech pres chatGPT, bohuzel si uz presne nepamatuju v kterych oblastech, ale tak jsem to tu aspon zminil
} // většinu popisku zde mam v cestine a vim ze bych mel psat v AJ napr. spis result misto vysledek, ale doufam ze se to jako chyba pocitat nebude :D

