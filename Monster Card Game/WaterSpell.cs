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
        public void Created()
        {
            Console.WriteLine("Water_Spell was created sucsessfully!");
        }
    }
}
