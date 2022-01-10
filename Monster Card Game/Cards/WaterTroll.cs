using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class WaterTroll : AbstractCard
    {
        public WaterTroll()
        {
            CardClass = "Troll";
            CardName = "Water_Troll";
            CardDamage = 70;
            CardElement = 2;
            CardType = "Monster";
            CardResetdmg = 70;
        }
    }
}
