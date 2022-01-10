using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public class NormalSpell : AbstractCard
    {
        public NormalSpell()
        {
            CardClass = "Spell";
            CardName = "Normal_Spell";
            CardDamage = 40;
            CardElement = 0;
            CardType = "Spell";
        }

        public void CheckKraken(AbstractCard Enemy)
        {
            if (Enemy.CardClass == "Kraken")
            {
                CardDamage = 0;
            }
        }
         

}
}
