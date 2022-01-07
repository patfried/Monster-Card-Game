
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
            CardDamage = 50;
            CardElement = Element.NORMAL;
            CardType = "Monster";
            
        }

        public void CheckDragon(AbstractCard Enemy)
        {
            if(Enemy.CardName == "Dragon" || Enemy.CardName == "Fire_Dragon" || Enemy.CardName == "Water_Dragon")
            {
                CardDamage = 0;
            }
        }
    }
}
