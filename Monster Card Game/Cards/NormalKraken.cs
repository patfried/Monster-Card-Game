using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class NormalKraken : AbstractCard
    {
        public NormalKraken()
        {
            CardName = "Kraken";
            CardDamage = 125;
            CardElement = Element.NORMAL;
            CardType = "Monster";
        }
    }
}
