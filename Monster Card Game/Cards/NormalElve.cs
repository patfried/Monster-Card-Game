using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class NormalElve : AbstractCard
    {
        public NormalElve()
        {
            CardClass = "Elve";
            CardName = "Normal_Elve";
            CardDamage = 60;
            CardElement = 0;
            CardType = "Monster";
            CardResetdmg = 60;
        }
    }
}
