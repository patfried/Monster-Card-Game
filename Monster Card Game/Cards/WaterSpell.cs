using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class WaterSpell : AbstractCard
    {
        public WaterSpell()
        {
            CardName = "Water_Spell";
            CardDamage = 40;
            CardElement = Element.WATER;
            CardType = "Spell";
        }
       

        public void CheckElement(AbstractCard Enemy)
        {
            if (Enemy.CardElement == Element.FIRE)
            {
                Console.WriteLine("Water is effective against fire!");
                CardDamage *= 2;
            }
        }
    }
}
