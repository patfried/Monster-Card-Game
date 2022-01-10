using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class NormalOrk : AbstractCard
    {
        public NormalOrk()
        {
            CardClass = "Ork";
            CardName = "Normal_Ork";
            CardDamage = 80;
            CardElement = 0;
            CardType = "Monster";
            CardResetdmg = 80;
        }

        public void CheckWizzard(AbstractCard Enemy)
        {
            if (Enemy.CardName == "Normal_Wizzard" || Enemy.CardName == "Fire_Wizzard" || Enemy.CardName == "Water_Wizzard")
                {
                    CardDamage = 0;
                }
            
        }
    }
}
