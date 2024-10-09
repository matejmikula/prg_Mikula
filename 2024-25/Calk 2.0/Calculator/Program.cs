using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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
            Double N1, N2;
            double Ans = 0;
            while (true)
            {
                Console.WriteLine("Write your first number");
                string A = Console.ReadLine();
                Console.Write("\n");

                Console.WriteLine("Write the mathematic operation you want to do (options: +, -, *, /, ^, √, !,");
                ConsoleKeyInfo keyInfoC = Console.ReadKey();
                // Extract the character from the key
                char keyCharC = keyInfoC.KeyChar;
                string op = keyCharC.ToString();
                Console.Write("\n");
                if (op == "+" || op == "-" || op == "*" || op == "/" || op == "^")
                {
                    Console.WriteLine("Write your second nunmber");
                    string B = Console.ReadLine();
                    Console.Write("\n");

                    if (double.TryParse(A, out N1) && double.TryParse(B, out N2))
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
                            if (N2 == 0)
                            {
                                Console.WriteLine("Math Error (can´t divide by zero");
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
                        else
                        {
                            Console.WriteLine("Wrong Math operation, try again"); // upozornění na chybu v zápisu operace, potom začíná celý výpočet znova
                            Ans = 000000;
                            continue;
                        }
                        Console.WriteLine(Ans);
                    }
                    else
                    {
                        Console.WriteLine("Wrong Input, check if you´ve got everything right"); // to samý jako předchozí else akorát pro to aby vstup byl vždy číslo 
                        continue;
                    }
                }
                else if (double.TryParse(A, out N1))
                {
                    if (op == "√")
                    {
                        if (N1 < 0)
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
                    Console.Write("\n");
                    Console.WriteLine($"The result is: {Ans}");
                    Console.Write("\n");
                    // Ask if the user wants to perform another operation
                    Console.WriteLine("Do you want to do another operation? Press (Y/N):");
                    ConsoleKeyInfo keyInfoD = Console.ReadKey();
                    // Extract the character from the key
                    char keyCharD = keyInfoD.KeyChar;
                    string newOp = keyCharD.ToString();
                    Console.Write("\n");
                    if (newOp != "y")
                    {
                        break; // End the program
                    }


                    /*
                     * ZADANI
                     * Vytvor program ktery bude fungovat jako kalkulacka. Kroky programu budou nasledujici:
                     * 1) Nacte vstup pro prvni cislo od uzivatele (vyuzijte metodu Console.ReadLine() - https://learn.microsoft.com/en-us/dotnet/api/system.console.readline?view=netframework-4.8.*/

                    /* 2) Zkonvertuje vstup od uzivatele ze stringu do integeru - https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number.
                    * 3) Nacte vstup pro druhe cislo od uzivatele a zkonvertuje ho do integeru. (zopakovani kroku 1 a 2 pro druhe cislo)
                    * 4) Nacte vstup pro ciselnou operaci. Rozmysli si, jak operace nazves. Muze to byt "soucet", "rozdil" atd. nebo napr "+", "-", nebo jakkoliv jinak.
                    * 5) Nadefinuj integerovou promennou result a prirad ji prozatimne hodnotu 0.
                    * 6) Vytvor podminky (if statement), podle kterych urcis, co se bude s cisly dit podle zadane operace
                    *    a proved danou operaci - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements.
                    * 7) Vypis promennou result do konzole
                    * 
                    * Rozsireni programu pro rychliky / na doma (na poradi nezalezi):
                    * 1) Vypis do konzole pred nactenim kazdeho uzivatelova vstupu co po nem chces (aby vedel, co ma zadat)
                    * 2) a) Kontroluj, ze uzivatel do vstupu zadal, co mel (cisla, popr. ciselnou operaci). Pokud zadal neco jineho, napis mu, co ma priste zadat a program ukoncete.
                    * 2) b) To same, co a) ale misto ukonceni programu opakovane cti vstup, dokud uzivatel nezada to, co ma
                    *       - https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-while-statement
                    * 3) Umozni uzivateli zadavat i desetinna cisla, tedy prekopej kalkulacku tak, aby umela pracovat s floaty
                    */

                    Console.ReadKey(); //Toto nech jako posledni radek, aby se program neukoncil ihned, ale cekal na stisk klavesy od uzivatele.
                }
            }
            double Factorial(int n) // rekurzivní funkce pro výpočet faktoriálu z dnešní hodiny upravená (s výpomocí chatGPT), aby fungovala v mojí kalkulačce
            {
                if (n < 0)
                {
                    Console.WriteLine("Faktoriál nelze spočítat pro záporné číslo.");
                    return 0;
                }
                double AnsF = 1;
                for (int i = 1; i <= n; i++)
                {
                    AnsF *= i;
                }
                return AnsF;
            }
        }
    }
}
