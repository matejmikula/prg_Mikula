using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wofkolmao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("glhf");
            Console.WriteLine("vložte svou volbu (kamen, nuzky, papir)");
            
            Random random = new Random(); // chatGPT helpnul
            while (true)
            {
                string[] moznosti = { "kamen", "nuzky", "papir" };
                string hracVolba = Console.ReadLine();
                if (hracVolba != "kamen" && hracVolba != "nuzky" && hracVolba != "papir")
                {
                    Console.WriteLine("zadejte platné možnosti");
                    continue;
                }
                string protivnikVolba = moznosti[random.Next(moznosti.Length)];
                Console.WriteLine($"protivník zvolil {protivnikVolba}"); 
                if (hracVolba == protivnikVolba)
                {
                    Console.WriteLine("je to remíza zkus to znova");
                }
                else if (
                    (hracVolba == "kamen" && protivnikVolba == "nuzky") ||  //chatGPT helpnul
                    (hracVolba == "nuzky" && protivnikVolba == "papir") ||
                    (hracVolba == "papir" && protivnikVolba == "kamen")
                    )
                {
                    Console.WriteLine("gratuluji k výhře");
                }
                else {
                    Console.WriteLine("soupeř vyhrál, snad to vyjde příště...");
                }
                Console.WriteLine("Pokud chceš hrát znova napiš ANO");
                
                string novaHra = Console.ReadLine().ToLower();
                if (novaHra != "ano")
                {
                    break;
                } 
                    else { Console.WriteLine("Napiš svou novou volbu ");
                }
                 

            }

        }
    }
}
