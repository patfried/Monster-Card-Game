using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class FireKnight : AbstractCard
    {
        public FireKnight()
        {
            CardClass = "Knight";
            CardName = "Fire_Knight";
            CardDamage = 75;
            CardElement = 1; 
            CardType = "Monster";
            CardResetdmg = 75;
        }
    }
}
