
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public class NormalGoblin : AbstractCard
    {

        public NormalGoblin()
        {
            CardClass = "Goblin";
            CardName = "Normal_Goblin";
            CardDamage = 80;
            CardElement = 0;
            CardType = "Monster";
            CardResetdmg = 80;

        }

        public void CheckDragon(AbstractCard Enemy)
        {
            if(Enemy.CardClass == "Dragon")
            {
                CardDamage = 0;
            }
        }
    }
}
