using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class FireElve : AbstractCard
    {
        public FireElve()
        {
            CardClass = "Elve";
            CardName = "Fire_Elve";
            CardDamage = 60;
            CardElement = 1;
            CardType = "Monster";
            CardResetdmg = 60;
        }
    }
}
