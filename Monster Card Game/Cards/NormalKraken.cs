using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class NormalKraken : AbstractCard
    {
        public NormalKraken()
        {
            CardClass = "Kraken";
            CardName = "Normal_Kraken";
            CardDamage = 125;
            CardElement = 0;
            CardType = "Monster";
        }
    }
}
