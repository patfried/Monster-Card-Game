using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class WaterKnight : AbstractCard
    {
        public WaterKnight()
        {
            CardName = "Water_Knight";
            CardDamage = 75;
            CardElement = Element.WATER;
            CardType = "Monster";
        }
    }
}
