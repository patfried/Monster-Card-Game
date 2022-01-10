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
        }
        
        public void CheckElement(AbstractCard Enemy)
        {
            if(Enemy.CardElement == 2)
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
