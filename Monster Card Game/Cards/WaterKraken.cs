using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class WaterKraken : AbstractCard
    {
        public WaterKraken()
        {
            CardName = "Water_Kraken";
            CardDamage = 125;
            CardElement = Element.WATER;
            CardType = "Monster";
        }
    }
}
