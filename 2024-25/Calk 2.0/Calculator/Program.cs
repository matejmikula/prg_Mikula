using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2024-2025.
 * Extended by students.
 */

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // zavedení datových typu
            Double N1, N2;
            double Ans = 0;
            string binaryAns;
            while (true) //iterace kalkulačky
            {

                Console.WriteLine("Write your first number"); //přečtení prvního čísla
                string A = Console.ReadLine();
                Console.Write("\n");

                Console.WriteLine("Write the mathematic operation you want to do (options: +, -, *, /, ^, sqr root, !, binary)");
                string op = Console.ReadLine().ToLower(); // přečtení operace
                Console.Write("\n");
                if (op == "+" || op == "-" || op == "*" || op == "/" || op == "^") // pokud jsou tyto operace nechá se přečíst i druhé číslo
                {
                    Console.WriteLine("Write your second nunmber");
                    string B = Console.ReadLine();
                    Console.Write("\n");

                    if (double.TryParse(A, out N1) && double.TryParse(B, out N2)) // parse čísel a vatvoření operací pro 2 čísla
                    {
                        if (op == "+")
                        {
                            Ans = N1 + N2;
                        }
                        else if (op == "-")
                        {
                            Ans = N1 - N2;
                        }
                        else if (op == "*")
                        {
                            Ans = N1 * N2;
                        }
                        else if (op == "/")
                        {
                            if (N2 == 0) // zajištění že se nebude dělit nulou
                            {
                                Console.WriteLine("Math Error (can´t divide by zero)");
                                continue;
                            }
                            else
                            {
                                Ans = N1 / N2;
                            }
                        }
                        else if (op == "^")
                        {
                            Ans = Math.Pow(N1, N2);
                        }
                        if (op != "binary") // odpověď pokud nebočítal binární převod, protože ten mám ve stringu, zbytek mam jako double
                        {

                            Console.WriteLine(Ans);

                        }

                    }
                    else //kontrola, že uživatel vloží číslo a ne něco jiného
                    {
                        Console.WriteLine("Wrong Input, check if you´ve got everything right"); // to samý jako předchozí else akorát pro to aby vstup byl vždy číslo 
                        continue;
                    }
                    Console.WriteLine("Do you want to do another operation? Press (Y/N):");
                    ConsoleKeyInfo keyInfo2 = Console.ReadKey(); // "reset" programu, aby mohl uživatel vložit nový příklad
                    // automatické přečtení charakteru (vygenerováno od chatgpt :D) 
                    char keyChar2 = keyInfo2.KeyChar;
                    string newOpN2 = keyChar2.ToString().ToLower();
                    Console.Write("\n");
                    if (newOpN2 != "y")
                    {
                        break; // End the program
                    }
                    Console.Write("\n");
                }
                else if (double.TryParse(A, out N1)) // opět parse čísla, ale pouze pro operace, které vyžadují pouze jendo číslo
                {
                    if (op == "sqr root")
                    {

                        if (N1 < 0) // kontrola, že není číslo menší než nula a můžeme ho odmocnit
                        {
                            Console.WriteLine("You can´t square root number smaller than 0");
                        }
                        else
                        {
                            Ans = Math.Sqrt(N1);
                        }
                    }
                    else if (op == "!")
                    {
                        Ans = Factorial((int)N1);
                    }
                    else if (op == "binary")
                    {
                        binaryAns = ToBinary(N1);
                        Console.WriteLine(binaryAns); // binary ans je ve stringu, proto je jediná operace, která má u sebe rovnou Console.WriteLine();
                    }
                    else // opět kontrola že uživatel zadal správnou operaci
                    {
                        Console.WriteLine("Wrong Math operation, try again"); 
                        Ans = 000000;
                        continue;
                    }
                    Console.WriteLine("Do you want to do another operation? Press (Y/N):"); // opět "reset" programu, aby mohl uživatel vložit nový příklad
                    ConsoleKeyInfo keyInfo1 = Console.ReadKey();
                    // opět automatické přečtení charakteru (vygenerováno od chatgpt :D) 
                    char keyChar1 = keyInfo1.KeyChar;
                    string newOpN1 = keyChar1.ToString().ToLower();
                    Console.Write("\n");
                    if (newOpN1 != "y")
                    {
                        break; // ukončí program
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input, check if you´ve got everything right"); // to samý jako předchozí else akorát pro to aby vstup byl vždy číslo 
                    continue;
                }
            }
        }
        static double Factorial(int n) // rekurzivní funkce pro výpočet faktoriálu z minulého roku (z minulé kalkulačky)
        {
            if (n == 0) // zajistí, že faktoriál 0 je 1
            {
                return 1;
            }
            else if (n < 0) // kontrola, že máme nezáporné číslo a můžeme počítat
            {
                Console.WriteLine("Faktoriál nelze spočítat pro záporné číslo.");
                return 0;
            }
            double Ans = 1;
            for (int i = 1; i <= n; i++) //iterace pro výpočet faktoriálu
            {
                Ans *= i;
            }
            return Ans;
        }
        static string ToBinary(double N1) // rekurzivní funkce, která konvertuje z desítkoví do binární soustavy (výpomoc od chatgpt)
        {
            if (N1 == 0) return "0"; // pokud je N1 0 je to automaticky 0 

            StringBuilder binary = new StringBuilder();

            while (N1 > 0) // kontrola že je číslo větší jak 0, abysme ho mohli konvertovat
            {
                int Ans = (int)N1 % 2;  // získá zbytek buď 1 nebo 0
                binary.Insert(0, Ans);  // předřadí zbytek do binárního výsledku
                N1 = Math.Floor(N1 / 2);      // vydělí 2 a zbaví se zbytků
            }

            return binary.ToString(); 
        }
    }
}
