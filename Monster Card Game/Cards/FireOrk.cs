using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class FireOrk : AbstractCard
    {
        public FireOrk()
        {
            CardClass = "Ork";
            CardName = "Fire_Ork";
            CardDamage = 80;
            CardElement = 1;
            CardType = "Monster";
        }
        public void CheckWizzard(AbstractCard Enemy)
        {
            if (Enemy.CardName == "Wizzard" || Enemy.CardName == "Fire_Wizzard" || Enemy.CardName == "Water_Wizzard")
            {
                CardDamage = 0;
            }

        }
    }
}
