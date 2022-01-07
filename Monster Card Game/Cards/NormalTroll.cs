using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class NormalTroll : AbstractCard
    {
        public NormalTroll()
        {
            CardName = "Troll";
            CardDamage = 70;
            CardElement = Element.NORMAL;
            CardType = "Monster";
        }
    }
}
