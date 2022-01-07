using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class FireElve : AbstractCard
    {
        public FireElve()
        {
            CardName = "Fire_Elve";
            CardDamage = 60;
            CardElement = Element.FIRE;
            CardType = "Monster";
        }
    }
}
