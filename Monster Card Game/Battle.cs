using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    class Battle
    {
        int MaxRounds = 100;
        int PlayedRounds = 0;
        bool GameOver = false;

        public void StartBattle(User Player1, User Player2)
        {
            User Player1tmp = Player1;
            User Player2tmp = Player2;

            while (PlayedRounds < MaxRounds || GameOver == false)
            {
                ICard Player1Card = Player1tmp.PickRandomCard();
                ICard Player2Card = Player2tmp.PickRandomCard();

                if(Player1Card.CardType == Player2Card.CardType) // Monster vs Monster
                {
                    if (Player1Card.CardDamage > Player2Card.CardDamage)
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player1Card, false);
                        Player1tmp.CardCollection.Add(Player2Card);
                        Player2tmp.CardCollection.Remove(Player2Card);

                    }
                    else
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, false);
                        Player2tmp.CardCollection.Add(Player1Card);
                        Player1tmp.CardCollection.Remove(Player1Card);

                    }
                    if (Player1Card.CardDamage == Player2Card.CardDamage)
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, true);
                    }

                    if (Player1tmp.CardCollection.Count == 0)
                    {
                        Console.WriteLine("Spiel vorbei Spieler 2 hat gewonnen");
                        GameOver = true;
                        Player2.Elo += 10;
                        Player1.Elo -= 10;
                        break;
                    }
                    else if (Player2tmp.CardCollection.Count == 0)
                    {
                        Console.WriteLine("Spiel vorbei Spieler 1 hat gewonnen");
                        GameOver = true;
                        Player1.Elo += 10;
                        Player2.Elo -= 10;
                        break;
                    }
                    PlayedRounds++;
                }
                else    // Spell vs Spell or Monster vs Spell
                {
                    
                        if (Player1Card.CardDamage > Player2Card.CardDamage) // Palyer 1 Wins
                        {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player1Card, false);
                            Player1tmp.CardCollection.Add(Player2Card);
                            Player2tmp.CardCollection.Remove(Player2Card);
                        }
                        else                                                 // Player 2 Wins 
                        {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, false);
                            Player2tmp.CardCollection.Add(Player1Card);
                            Player1tmp.CardCollection.Remove(Player1Card);
                        }
                        if (Player1Card.CardDamage == Player2Card.CardDamage) // Draw
                        {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, true);
                        }

                        if (Player1tmp.CardCollection.Count == 0)
                        {
                            Console.WriteLine("Spiel vorbei Spieler 2 hat gewonnen");
                            GameOver = true;
                            Player2.Elo += 10;
                            Player1.Elo -= 10;

                            break;
                        }
                        else if (Player2tmp.CardCollection.Count == 0)
                        {
                            Console.WriteLine("Spiel vorbei Spieler 1 hat gewonnen");
                            GameOver = true;
                            Player1.Elo += 10;
                            Player2.Elo -= 10;
                            break;
                        }
                        PlayedRounds++;                   
                }
               
            }
            
        }
        private void Battlelog(User Player1, User Player2, ICard Player1Card, ICard Player2Card, ICard Winner, bool Draw)
        {
            if(Draw == false)
            {
                Console.WriteLine($"{Player1.UserName}: {Player1Card.CardName}({Player1Card.CardDamage}) vs {Player2.UserName}: {Player2Card.CardName}({Player2Card.CardDamage}) => {Player1Card.CardDamage} vs {Player2Card.CardDamage} => {Winner.CardName} wins");
            }
            else
            {
                Console.WriteLine($"{Player1.UserName}: {Player1Card.CardName}({Player1Card.CardDamage}) vs {Player2.UserName}: {Player2Card.CardName}({Player2Card.CardDamage}) => {Player1Card.CardDamage} vs {Player2Card.CardDamage} => Draw");
            }
        }


        
        
        
       

    }
}

