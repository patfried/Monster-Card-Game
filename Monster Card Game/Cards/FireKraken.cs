using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class FireKraken : AbstractCard
    {
        public FireKraken()
        {
            CardClass = "Kraken";
            CardName = "Fire_Kraken";
            CardDamage = 125;
            CardElement = 1;
            CardType = "Monster";
            CardResetdmg = 125;
        }

       
    }
}
