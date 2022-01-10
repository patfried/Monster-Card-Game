using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class WaterDragon : AbstractCard
    {
        public WaterDragon()
        {
            CardClass = "Dragon";
            CardName = "Water_Dragon";
            CardDamage = 100;
            CardElement = 2;
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
