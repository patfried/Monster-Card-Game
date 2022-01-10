using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public interface ICard
    {
        public string CardClass { get; set; }
        public string CardName { get; set; }
        public int CardDamage { get; set; }
        public enum Element
        {
            NORMAL, FIRE, WATER
        }
        public int CardElement { get; set; }
        public string CardType{ get; set; }

        public void CheckSpecial(AbstractCard Enemy)
        {
            if(this.CardClass == "Dragon" && Enemy.CardClass == "Goblin")
            {
                Enemy.CardDamage = 0;
            }else if(this.CardClass == "Goblin" && Enemy.CardClass == "Dragon")
            {
                this.CardDamage = 0;
            }
            else
            {
                this.CardDamage = 0;
            }
        }
    }
}
