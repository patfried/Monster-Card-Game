using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public class WaterSpell : AbstractCard
    {
        public WaterSpell()
        {
            CardClass = "Spell";
            CardName = "Water_Spell";
            CardDamage = 40;
            CardElement = 2;
            CardType = "Spell";
            CardResetdmg = 40;
        }

        public void CheckElement(AbstractCard Enemy)
        {
            if (Enemy.CardElement == 1)
            {
                CardDamage *= 2;
            }

            if (Enemy.CardClass == "Kraken")
            {
                CardDamage = 0;
            }
        }
    }
}
