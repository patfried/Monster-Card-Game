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
            CardClass = "Knight";
            CardName = "Water_Knight";
            CardDamage = 75;
            CardElement = 2;
            CardType = "Monster";
            CardResetdmg = 75;
        }
    }
}
