using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class WaterOrk : AbstractCard
    {
        public WaterOrk()
        {
            CardName = "Water_Ork";
            CardDamage = 80;
            CardElement = Element.WATER;
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
