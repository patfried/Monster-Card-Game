using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class User
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserCoins { get; set; }
        
        public List<ICard> CardCollection { get; set; }

        public User()
        {
            UserCoins = 20;
            CardCollection = new List<ICard>();
        }

        public void BuyPacks()
        {
            UserCoins = -20;

            var Rand = new Random();
            int RandNumber;

            for (int i = 0; i < 20; i++)
            {
                RandNumber = Rand.Next(0, 3);
                switch (RandNumber)
                {
                    case 0:
                        NormalGoblin Goblin = new NormalGoblin();
                        CardCollection.Add(Goblin);
                        break;
                    case 1:
                        NormalDragon Dragon = new NormalDragon();
                        CardCollection.Add(Dragon);
                        break;
                    case 2:
                        NormalSpell Spell = new NormalSpell();
                        CardCollection.Add(Spell);
                        break;
                }

            }

        }
        public void CreateBattledeck()
        {
            foreach (ICard Collection in CardCollection)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine(Collection.CardName);
                Console.WriteLine(Collection.CardType);
                Console.WriteLine(Collection.CardDamage);
                Console.WriteLine("-----------------------------------------------");

            }
            
        }
    }

}
