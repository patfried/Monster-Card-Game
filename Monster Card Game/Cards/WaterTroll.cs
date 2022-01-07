using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class WaterTroll : AbstractCard
    {
        public WaterTroll()
        {
            CardName = "Water_Troll";
            CardDamage = 70;
            CardElement = Element.WATER;
            CardType = "Monster";
        }
    }
}
