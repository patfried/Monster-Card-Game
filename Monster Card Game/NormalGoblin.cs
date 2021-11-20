using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class NormalGoblin : AbstractCard
    {
        public NormalGoblin()
        {
            CardName = "Fire_Goblin";
            CardDamage = 100;
            Element CardElement = Element.NORMAL;
            
        }

        public void Created()
        {
            Console.WriteLine("Fire_Goblin was created sucsessfully!");
        }
    }
}
