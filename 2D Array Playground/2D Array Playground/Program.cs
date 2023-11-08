using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Made by Jan Borecky for PRG seminar at Gymnazium Voderadska, year 2023-2024.
 * Extended by students.
 */

namespace _2D_Array_Playground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TODO 1: Vytvoř integerové 2D pole velikosti 5 x 5, naplň ho čísly od 1 do 25 a vypiš ho do konzole (5 řádků po 5 číslech).
            int[,] My2dArray = new int[5, 5];
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
            //TODO 2: Vypiš do konzole n-tý řádek pole, kde n určuje proměnná nRow.
            int nRow = 0;
            for (int j = 0; j < My2dArray.GetLength(1); j++)
            {
                Console.Write(My2dArray[nRow, j] + " ");
            }
           Console.WriteLine();

            //TODO 3: Vypiš do konzole n-tý sloupec pole, kde n určuje proměnná nColumn.
            int nColumn = 0;
            for (int i = 0; i < My2dArray.GetLength(0); i++)
            {
                Console.Write(My2dArray[i, nColumn] + " ");
            }
            Console.Write("\n");
            Console.WriteLine();

            //BONUS TODO: HLAVNÍ DIAGONÁLA
            for (int i = 0; i < My2dArray.GetLength(0); i++)
            {
                Console.Write(My2dArray[i, i] + " ");
                
            }Console.WriteLine();
            //BONUS TODO 2: VEDLEJŠÍ DIAGONÁLA
            int J = 0;
            for (int i = My2dArray.GetLength(0) - 1; i >= 0; i--)
            {
                 Console.Write(My2dArray[i, J] + " ");
                 J++;
            }
            Console.Write("\n");
            Console.WriteLine();

            //TODO 4: Prohoď prvek na souřadnicích [xFirst, yFirst] s prvkem na souřadnicích [xSecond, ySecond] a vypiš celé pole do konzole po prohození.
            //Nápověda: Budeš potřebovat proměnnou navíc, do které si uložíš první z prvků před tím, než ho přepíšeš druhým, abys hodnotou prvního prvku potom mohl přepsat druhý
            int xFirst, yFirst, xSecond, ySecond;
            xFirst = 0;
            yFirst = 4;
            xSecond = 4;
            ySecond = 0;
            int temp1 = My2dArray[xFirst, yFirst];
            My2dArray[xFirst,yFirst] = My2dArray[xSecond, ySecond];
            My2dArray[xSecond, ySecond] = temp1;
            
            for (int i = 0; i < My2dArray.GetLength(0); i++)
            {
                for (int j = 0; j < My2dArray.GetLength(1); j++)
                {
                    Console.Write($" {My2dArray[i, j]}");
                }
                Console.Write("\n");
            }Console.Write("\n");


            //TODO 5: Prohoď n-tý řádek v poli s m-tým řádkem (n je dáno proměnnou nRowSwap, m mRowSwap) a vypiš celé pole do konzole po prohození.
            int nRowSwap = 0;
            int mRowSwap = 1;

            //TODO 6: Prohoď n-tý sloupec v poli s m-tým sloupcem (n je dáno proměnnou nColSwap, m mColSwap) a vypiš celé pole do konzole po prohození.
            int nColSwap = 0;
            int mColSwap = 1;

            //TODO 7: Otoč pořadí prvků na hlavní diagonále (z levého horního rohu do pravého dolního rohu) a vypiš celé pole do konzole po otočení.

            //TODO 8: Otoč pořadí prvků na vedlejší diagonále (z pravého horního rohu do levého dolního rohu) a vypiš celé pole do konzole po otočení.


            Console.ReadKey();
        }
    }
}
