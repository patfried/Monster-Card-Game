using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class FireDragon : AbstractCard
    {
        public  FireDragon()
        {
            CardClass = "Dragon";
            CardName = "Fire_Dragon";
            CardDamage = 100;
            CardElement = 1;
            CardType = "Monster";
            CardResetdmg = 100;
        }
        public void CheckElve(AbstractCard Enemy)
        {
            if (Enemy.CardName == "Fire_Elve")
            {
                CardDamage = 0;
            }
        }
    }
}
