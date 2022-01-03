using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class Battle
    {

        public void StartBattle(User Player1, User Player2)
        {
            for (int i = 0; i < 5; i++)
            {
                DetWinner(Player1, Player2, i);
            }
            Console.WriteLine("Battle Ended!");
        }

        public void DetWinner(User Player1, User Player2, int index)
        {
            if (Player1.CardCollection[index].CardDamage > Player2.CardCollection[index].CardDamage)
            {
                Console.WriteLine($"{Player1.CardCollection[index].CardName} won!");
                /* Player1.CardCollection.Add(Player2.CardCollection[index]);
                 Player2.CardCollection.Remove(Player2.CardCollection[index]);
                 Console.WriteLine($"{Player2.CardCollection[index].CardName} was removed!"); */
            }
            else
            {
                Console.WriteLine($"{Player2.CardCollection[index].CardName} won!");
                /* Player2.CardCollection.Add(Player1.CardCollection[index]);
                 Player1.CardCollection.Remove(Player1.CardCollection[index]);
                 Console.WriteLine($"{Player1.CardCollection[index].CardName} was removed!");*/
            }
            if (Player1.CardCollection[index].CardDamage == Player2.CardCollection[index].CardDamage)
            {
                Console.WriteLine("Both Cards have the Same Damage! It´s a DRAW!!!!");
            }
        }

        // gewinner bekommt die Karte vom Verlierer // index out of bound wenn nur einer verwendet wird vlt 2 seperate indexe innerhalb der collection führen
        // Scoreboard updaten
        // draw beachten
        // Gewinner ermitteln mittels Punkte 

    }
}

