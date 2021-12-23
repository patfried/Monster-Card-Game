using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class FireSpell : AbstractCard
    {
        public FireSpell()
        {
            CardName = "Fire_Spell";
            CardDamage = 60;
            CardElement = Element.FIRE;
            CardType = "Spell";
        }
        public void Created()
        {
            Console.WriteLine("Fire_Spell was created sucsessfully!");
        }
    }
}
