
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class NormalGoblin : AbstractCard
    {

        public NormalGoblin()
        {
            CardName = "Goblin";
            CardDamage = 100;
            CardElement = Element.NORMAL;
            CardType = "Monster";
            
        }
    }
}
