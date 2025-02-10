using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_intro
{
    internal class Player
    {
        private int damage;
        public string name;
        int health;
        public void SetDamage(int value)
        {
            damage = value;
            if (damage <= 0)
            {
                damage = 1;
            }
        }
        public int GetDamage()
        {
            return damage;
        }
    }
    
}
