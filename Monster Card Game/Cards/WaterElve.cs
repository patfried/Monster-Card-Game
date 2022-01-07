using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class WaterElve : AbstractCard
    {
        public WaterElve()
        {
            CardName = "_Water_Elve";
            CardDamage = 60;
            CardElement = Element.WATER;
            CardType = "Monster";
        }
    }
}
