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
            CardClass = "Troll";
            CardName = "Normal_Troll";
            CardDamage = 70;
            CardElement = 0;
            CardType = "Monster";
        }
    }
}
