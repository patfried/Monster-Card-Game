using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class NormalWizzard : AbstractCard
    {
        
        NormalWizzard()
        {
            CardName = "Wizzard";
            CardDamage = 30;
            CardElement = Element.NORMAL;
            CardType = "Monster";
        }

   
    }
}
