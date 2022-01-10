using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public class FireSpell : AbstractCard
    {
        public FireSpell()
        {
            CardClass = "Spell";
            CardName = "Fire_Spell";
            CardDamage = 40;
            CardElement = 1;
            CardType = "Spell";
            CardResetdmg = 40;
        }
        
        
    }
}
