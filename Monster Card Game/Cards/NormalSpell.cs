using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class NormalSpell : AbstractCard
    {
        public NormalSpell()
        {
            CardName = "Normal_Spell";
            CardDamage = 20;
            CardElement = Element.NORMAL;
            CardType = "Spell";
        }
      
    }
}
