using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class WaterElve : AbstractCard
    {
        public WaterElve()
        {
            CardClass = "Elve";
            CardName = "Water_Elve";
            CardDamage = 60;
            CardElement = 2;
            CardType = "Monster";
            CardResetdmg = 60;
        }
    }
}
