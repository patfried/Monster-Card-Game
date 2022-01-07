﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class WaterDragon : AbstractCard
    {
        public WaterDragon()
        {
            CardName = "Water_Dragon";
            CardDamage = 100;
            CardElement = Element.WATER;
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