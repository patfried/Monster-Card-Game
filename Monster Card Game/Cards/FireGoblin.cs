﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    public class FireGoblin : AbstractCard
    {
        public FireGoblin()
        {
            CardClass = "Goblin";
            CardName = "Fire_Goblin";
            CardDamage = 80;
            CardElement = 1;
            CardType = "Monster";
            CardResetdmg = 80;

        }
        public void CheckDragon(AbstractCard Enemy)
        {
            if (Enemy.CardClass == "Dragon")
            {
                CardDamage = 0;
            }
        }
    }
}
