using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class NormalKnight : AbstractCard
    {
        public NormalKnight()
        {
            CardName = "Knight";
            CardDamage = 75;
            CardElement = Element.NORMAL;
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
