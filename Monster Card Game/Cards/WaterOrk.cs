using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class WaterOrk : AbstractCard
    {
        public WaterOrk()
        {
            CardClass = "Ork";
            CardName = "Water_Ork";
            CardDamage = 80;
            CardElement = 2;
            CardType = "Monster";
            CardResetdmg = 80;
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
