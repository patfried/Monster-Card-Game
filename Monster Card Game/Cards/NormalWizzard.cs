using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public class NormalWizzard : AbstractCard
    {
        
        public NormalWizzard()
        {
            CardClass = "Wizzard";
            CardName = "Normal_Wizzard";
            CardDamage = 30;
            CardElement = 0;
            CardType = "Monster";
        }

   
    }
}
