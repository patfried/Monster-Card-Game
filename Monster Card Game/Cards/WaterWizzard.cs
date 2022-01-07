using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class WaterWizzard : AbstractCard
    {
        public WaterWizzard()
        {
            CardName = "Water_Wizzard";
            CardDamage = 30;
            CardElement = Element.WATER;
            CardType = "Monster";
        }
    }
}
