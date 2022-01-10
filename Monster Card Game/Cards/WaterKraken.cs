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
            CardClass = "Kraken";
            CardName = "Water_Kraken";
            CardDamage = 125;
            CardElement = 2;
            CardType = "Monster";
            CardResetdmg = 125;
        }
    }
}
