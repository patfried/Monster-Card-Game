using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class WaterGoblin : AbstractCard
    {
        public WaterGoblin()
        {
            CardClass = "Goblin";
            CardName = "Water_Goblin";
            CardDamage = 50;
            CardElement = 2;
            CardType = "Monster";
            CardResetdmg = 50;

        }
        public void CheckDragon(AbstractCard Enemy)
        {
            if (Enemy.CardClass == "Dragon")
            {
                CardDamage = 0;
            }
        }
    }
}
