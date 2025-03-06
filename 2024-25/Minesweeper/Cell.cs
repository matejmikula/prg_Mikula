using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Cell
    {
        public bool IsMine { get; set; } //vlastnost pro zjištění zda je v poli mina
        public bool IsRevealed { get; set; } //vlastnost pro zjištění zda je pole odhaleno
        public bool IsFlagged { get; set; } //vlastnost pro zjištění zda je pole flagnuté
        public int AdjacentMines { get; set; } //ukládá počet sousedních min okolo pole
        public Cell(bool isMine = false) //kontrola zda je v poli mina či ne
        {
            IsMine = isMine;
            IsRevealed = false; //buňka je nejříve schovaná neflagnutá a nejsou ze začátku žádně sousedníminy (až po odhalení buňky)
            IsFlagged = false;
            AdjacentMines = 0;
        }

        public char Display() //charakterová reprezentace buňky v poli
        {
            if (IsFlagged)
            {
                return 'F';
            }
            if (!IsRevealed)
            {
                return '.';
            }
            if (IsMine)
            {
                return '*';
            }
            if (AdjacentMines > 0) //zobrazení počtu sousedních min v odhalené buňce
            {
                return char.Parse(AdjacentMines.ToString());
            }
            return ' ';
        }
    }
}
