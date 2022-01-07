using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class FireKnight : AbstractCard
    {
        public FireKnight()
        {
            CardName = "Fire_Knight";
            CardDamage = 75;
            CardElement = Element.FIRE;
            CardType = "Monster";
        }
    }
}
