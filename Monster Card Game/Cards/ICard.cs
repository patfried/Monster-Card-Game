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
        public int CardResetdmg { get; set; }

        public void CheckSpecial(ICard Enemy, bool Modus)
        {
            // Goblins are afraid of Dragons
            if(this.CardClass == "Dragon" && Enemy.CardClass == "Goblin")
            {
                Enemy.CardDamage = 0;
            }else if(this.CardClass == "Goblin" && Enemy.CardClass == "Dragon")
            {
                this.CardDamage = 0;
            }

            //Wizzard can control Orks so they are not able to damage them
            if (this.CardClass == "Wizzard" && Enemy.CardClass == "Ork")
            {
                Enemy.CardDamage = 0;
            }
            else if (this.CardClass == "Ork" && Enemy.CardClass == "Wizzard")
            {
                this.CardDamage = 0;
            }

            //The armor of Knights is so heavy that WaterSpells make them drown them instantly.
            if (this.CardClass == "Water_Spell" && Enemy.CardName == "Knight")
            {
                Enemy.CardDamage = 0;
            }
            else if (this.CardClass == "Knight" && Enemy.CardName == "Water_Spell")
            {
                this.CardDamage = 0;
            }

            //The Kraken is immune against spells. 
            if (this.CardClass == "Kraken" && Enemy.CardClass == "Spell")
            {
                Enemy.CardDamage = 0;
            }
            else if (this.CardClass == "Spell" && Enemy.CardClass == "Kraken")
            {
                this.CardDamage = 0;
            }

            //The FireElves know Dragons since they were little and can evade their attacks. 
            if (this.CardName == "Fire_Elve" && Enemy.CardClass== "Dragon")
            {
                Enemy.CardDamage = 0;
            }
            else if (this.CardClass == "Dragon" && Enemy.CardName == "Fire_Elve")
            {
                this.CardDamage = 0;
            }

            //############################### EXTRA ###############################//

            //WaterOrk and WaterTrolls are friends so they dont fight against each other
            if (this.CardName == "Water_Ork" && Enemy.CardName == "Water_Troll")
            {
                Enemy.CardDamage = 0;
                this.CardDamage = 0;
            }
            else if (this.CardName == "Water_Troll" && Enemy.CardName == "Water_Ork")
            {
                this.CardDamage = 0;
                Enemy.CardDamage = 0;
            }

            //Goblins are smart and swift so they make double damage against the kraken 
            if (this.CardClass == "Goblin" && Enemy.CardClass == "Kraken")
            {
                
                this.CardDamage *= 2 ;
            }
            else if (this.CardClass == "Kraken" && Enemy.CardClass == "Goblin")
            {
                
                Enemy.CardDamage *= 2;
            }

            //Knights are well armored so the dragons make half damage
            if (this.CardClass == "Knight" && Enemy.CardClass == "Dragon")
            {
                Enemy.CardDamage /= 2;
            }
            else if (this.CardClass == "Dragon" && Enemy.CardClass == "Knight")
            {
                this.CardDamage /= 2;
            }

            //Water_Elves are immune to WaterCards

            if (this.CardElement == 2 && Enemy.CardName == "Water_Elve")
            {
                this.CardDamage = 0;
            }
            else if (this.CardName == "Water_Elve" && Enemy.CardElement == 2)
            {
                Enemy.CardDamage = 0;
            }
            //Trolls are immune to the Attacks of the Wizzard
            if (this.CardClass == "Troll" && Enemy.CardClass == "Wizzard")
            {
                Enemy.CardDamage = 0;
            }
            else if (this.CardClass == "Wizzard" && Enemy.CardClass == "Troll")
            {
                this.CardDamage = 0;
            }

            if (Modus)
            {
                // Water VS Fire  -> Water *2 Fire /2
                if(this.CardElement == 1 && Enemy.CardElement == 2)
                {
                    this.CardDamage /= 2;
                    Enemy.CardDamage *= 2;
                }
                else if(this.CardElement == 2 && Enemy.CardElement == 1)
                {
                    this.CardDamage *= 2;
                    Enemy.CardDamage /= 2;
                }

                // Fire VS Normal -> Fire*2  Normal/2
                if (this.CardElement == 0 && Enemy.CardElement == 1)
                {
                    this.CardDamage /= 2;
                    Enemy.CardDamage *= 2;
                }
                else if (this.CardElement == 1 && Enemy.CardElement == 0)
                {
                    this.CardDamage *= 2;
                    Enemy.CardDamage /= 2;
                }

                // Normal VS Water -> Normal*2  Water/2
                if (this.CardElement == 2 && Enemy.CardElement == 0)
                {
                    this.CardDamage /= 2;
                    Enemy.CardDamage *= 2;
                }
                else if (this.CardElement == 0 && Enemy.CardElement == 2)
                {
                    this.CardDamage *= 2;
                    Enemy.CardDamage /= 2;
                }
            }

            //############################### EXTRA ###############################//

            //
        }
    }
}
