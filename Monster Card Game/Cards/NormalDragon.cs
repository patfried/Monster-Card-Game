using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public class NormalDragon : AbstractCard
    {
        public NormalDragon()
        {
            CardClass = "Dragon";
            CardName = "Normal_Dragon";
            CardDamage = 100;
            CardElement = 0;
            CardType = "Monster";
        }

        public void CheckElve(AbstractCard Enemy)
        {
            if (Enemy.CardName == "Fire_Elve")
            {
                CardDamage = 0;
            }
        }
    }
}
