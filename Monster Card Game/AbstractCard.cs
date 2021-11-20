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
        public int CardDamage;
        public enum Element
        {
            NORMAL,FIRE,ICE
        }
    }
}
