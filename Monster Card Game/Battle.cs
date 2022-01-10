using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Card_Game
{
    public class Battle
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

                if(Player1Card.CardType == "´Monster" && Player2Card.CardType== "Monster") // Monster vs Monster
                {

                    if (Player1Card.CardDamage > Player2Card.CardDamage)
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player1Card, false);
                        Player1tmp.BattleDeck.Add(Player2Card);
                        Player2tmp.BattleDeck.Remove(Player2Card);

                    }
                    else
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, false);
                        Player2tmp.BattleDeck.Add(Player1Card);
                        Player1tmp.BattleDeck.Remove(Player1Card);

                    }
                    if (Player1Card.CardDamage == Player2Card.CardDamage)
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, true);
                    }

                    if (Player1tmp.BattleDeck.Count == 0)
                    {
                        Console.WriteLine("Spiel vorbei Spieler 2 hat gewonnen");
                        GameOver = true;
                        Player2.Elo += 3;
                        Player2.MatchesWon++;
                        Player1.Elo -= 5;
                        Player1.MatchesLost++;
                        break;
                    }
                    else if (Player2tmp.BattleDeck.Count == 0)
                    {
                        Console.WriteLine("Spiel vorbei Spieler 1 hat gewonnen");
                        GameOver = true;
                        Player1.Elo += 3;
                        Player1.MatchesWon++;
                        Player2.Elo -= 5;
                        Player2.MatchesLost++;
                        break;
                    }
                    Player1.WLRatio();
                    Player2.WLRatio();
                    PlayedRounds++;
                }
                else    // Spell vs Spell or Monster vs Spell
                {
                    
                        if (Player1Card.CardDamage > Player2Card.CardDamage) // Palyer 1 Wins
                        {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player1Card, false);
                            Player1tmp.BattleDeck.Add(Player2Card);
                            Player2tmp.BattleDeck.Remove(Player2Card);
                        }
                        else                                                 // Player 2 Wins 
                        {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, false);
                            Player2tmp.BattleDeck.Add(Player1Card);
                            Player1tmp.BattleDeck.Remove(Player1Card);
                        }
                        if (Player1Card.CardDamage == Player2Card.CardDamage) // Draw
                        {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, true);
                        }

                        if (Player1tmp.BattleDeck.Count == 0)
                        {
                            Console.WriteLine("Spiel vorbei Spieler 2 hat gewonnen");
                            GameOver = true;
                            Player2.Elo += 10;
                            Player1.Elo -= 10;

                            break;
                        }
                        else if (Player2tmp.BattleDeck.Count == 0)
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

