﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game.Cards
{
    class NormalElve : AbstractCard
    {
        public NormalElve()
        {
            CardName = "Elve";
            CardDamage = 60;
            CardElement = Element.NORMAL;
            CardType = "Monster";
        }
    }
}