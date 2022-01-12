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
       

        public string StartBattle(User Player1, User Player2)
        {
            User Player1tmp = Player1;
            User Player2tmp = Player2;
            string winner = "";

            while (PlayedRounds < MaxRounds)
            {
                ICard Player1Card = Player1tmp.PickRandomCard();
                ICard Player2Card = Player2tmp.PickRandomCard();

                

                if(Player1Card.CardType == "Monster" && Player2Card.CardType== "Monster") // Monster vs Monster
                {
                    Player1Card.CheckSpecial(Player2Card, false);

                    if (Player1Card.CardDamage > Player2Card.CardDamage)
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player1Card, false);

                        Player2Card.CardDamage = Player2Card.CardResetdmg;
                        Player1Card.CardDamage = Player1Card.CardResetdmg;

                        Player1tmp.BattleDeck.Add(Player2Card);
                        Player2tmp.BattleDeck.Remove(Player2Card);

                    }
                    else if(Player2Card.CardDamage > Player1Card.CardDamage)
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, false);

                        Player2Card.CardDamage = Player2Card.CardResetdmg;
                        Player1Card.CardDamage = Player1Card.CardResetdmg;

                        Player2tmp.BattleDeck.Add(Player1Card);
                        Player1tmp.BattleDeck.Remove(Player1Card);

                    }
                    
                    if (Player1Card.CardDamage == Player2Card.CardDamage)
                    {
                        Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, true);
                        winner = "Its a Draw!";
                        
                    }

                    

                    if (Player1tmp.BattleDeck.Count == 0)
                    {
                        Console.WriteLine("Spiel vorbei Spieler 2 hat gewonnen");
                        
                        Player2.Elo += 3;
                        Player2.MatchesWon++;
                        Player1.Elo -= 5;
                        Player1.MatchesLost++;
                        
                        Player1.UpdateUser();
                        Player2.UpdateUser();
                        winner = "Player2 won!";
                        break;
                    }
                    else if (Player2tmp.BattleDeck.Count == 0)
                    {
                        Console.WriteLine("Spiel vorbei Spieler 1 hat gewonnen");
                        
                        Player1.Elo += 3;
                        Player1.MatchesWon++;
                        Player2.Elo -= 5;
                        Player2.MatchesLost++;
                        
                        Player1.UpdateUser();
                        Player2.UpdateUser();
                        winner = "Player1 won!";
                        break;
                    }
                    
                  
                    
                    PlayedRounds++;
                }
                else if(Player1Card.CardType == "Monster" && Player2Card.CardType == "Spell" || Player1Card.CardType == "Spell" && Player2Card.CardType == "Monster" || Player1Card.CardType == "Spell" && Player2Card.CardType == "Spell")    // Spell vs Spell or Monster vs Spell
                {
                    Player1Card.CheckSpecial(Player2Card, true);

                        if (Player1Card.CardDamage > Player2Card.CardDamage) // Palyer 1 Wins
                        {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player1Card, false);
                        
                            Player2Card.CardDamage = Player2Card.CardResetdmg;
                            Player1Card.CardDamage = Player1Card.CardResetdmg;

                            Player1tmp.BattleDeck.Add(Player2Card);
                            Player2tmp.BattleDeck.Remove(Player2Card);
                        }
                        else if (Player2Card.CardDamage > Player1Card.CardDamage)                                               // Player 2 Wins 
                    {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, false);

                            Player2Card.CardDamage = Player2Card.CardResetdmg;
                            Player1Card.CardDamage = Player1Card.CardResetdmg;

                            Player2tmp.BattleDeck.Add(Player1Card);
                            Player1tmp.BattleDeck.Remove(Player1Card);
                        }
                        if (Player1Card.CardDamage == Player2Card.CardDamage) // Draw
                        {
                            Battlelog(Player1tmp, Player2tmp, Player1Card, Player2Card, Player2Card, true);
                            winner = "Draw Elemental";
                            

                        }

                       

                        if (Player1tmp.BattleDeck.Count == 0)
                        {
                            Console.WriteLine("Spiel vorbei Spieler 2 hat gewonnen");
                            
                            Player2.Elo += 3;
                            Player2.MatchesWon++;
                            Player1.Elo -= 5;
                            Player1.MatchesLost++;
                            Player1.UpdateUser();
                            Player2.UpdateUser();
                            winner = "Player2 won! Elemental";

                        break;
                        }
                        else if (Player2tmp.BattleDeck.Count == 0)
                        {
                            Console.WriteLine("Spiel vorbei Spieler 1 hat gewonnen");
                            
                            Player1.Elo += 3;
                            Player1.MatchesWon++;
                            Player2.Elo -= 5;
                            Player2.MatchesLost++;
                            Player1.UpdateUser();
                            Player2.UpdateUser();
                            winner = "Player1 won! Elemental";
                        break;
                        }
                        PlayedRounds++;                   
                }
                

            }

            Console.WriteLine($"Rounds palyed:{PlayedRounds}");
            if(PlayedRounds == 100)
            {
                Console.WriteLine(winner);
            }
            return winner;

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

