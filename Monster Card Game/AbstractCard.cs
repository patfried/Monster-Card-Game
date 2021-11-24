using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    abstract class AbstractCard
    {
        public string CardName;
        public static int CardDamage;
        public enum Element
        {
            NORMAL,FIRE,WATER
        }
        public Element CardElement;
        public string CardType;
    }
}
