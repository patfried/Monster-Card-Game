using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class FireWizzard :  AbstractCard
    {
        public FireWizzard()
        {
            CardClass = "Wizzard";
            CardName = "Fire_Wizzard";
            CardDamage = 30;
            CardElement = 1;
            CardType = "Monster";
            CardResetdmg = 30;
        }
    }
}
