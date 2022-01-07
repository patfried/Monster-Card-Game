﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class FireTroll : AbstractCard
    {
        public FireTroll()
        {
            CardName = "Fire_Troll";
            CardDamage = 70;
            CardElement = Element.FIRE;
            CardType = "Monster";
        }
    }
}