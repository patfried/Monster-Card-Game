using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class NormalKnight : AbstractCard
    {
        public NormalKnight()
        {
            CardClass = "Knight";
            CardName = "Normal_Knight";
            CardDamage = 75;
            CardElement = 0;
            CardType = "Monster";
        }

        public void CheckWaterSpell(AbstractCard Enemy)
        {
            if (Enemy.CardName == "Water_Spell")
            {
                CardDamage = 0;
            }

        }
    }
}
