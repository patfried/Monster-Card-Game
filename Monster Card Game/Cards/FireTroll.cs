using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class FireTroll : AbstractCard
    {
        public FireTroll()
        {
            CardClass = "Troll";
            CardName = "Fire_Troll";
            CardDamage = 70;
            CardElement = 1;
            CardType = "Monster";
            CardResetdmg = 70;
        }
    }
}
