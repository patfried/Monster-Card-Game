using NUnit.Framework;
using Monster_Card_Game;
using Monster_Card_Game.Cards;
using Npgsql;
using System.Linq;

namespace Monster_Card_Game_Tests
{
    public class Tests
    {

        [Test]
        public void DragonVSElve()
        {
            ICard Dragon =  new NormalDragon();
            ICard Elve = new FireElve();

            Dragon.CheckSpecial(Elve,false);

            Assert.That(Dragon.CardDamage, Is.EqualTo(0));
            Assert.That(Elve.CardDamage, Is.EqualTo(60));
            
        }
        
        [Test]
        public void KnightVSWaterSpell()
        {
            ICard Knight = new NormalKnight();
            ICard Water_Spell = new WaterSpell();

            Knight.CheckSpecial(Water_Spell, false);

            Assert.That(Knight.CardDamage, Is.EqualTo(0));
            Assert.That(Water_Spell.CardDamage, Is.EqualTo(40));

        }

        [Test]
        public void OrkVSWizzard()
        {
            ICard Ork = new NormalOrk();
            ICard Wizzard = new NormalWizzard();

            Ork.CheckSpecial(Wizzard, false);

            Assert.That(Ork.CardDamage, Is.EqualTo(0));
            Assert.That(Wizzard.CardDamage, Is.EqualTo(30));

        }

        [Test]
        public void GoblinVSDragon()
        {
            ICard Goblin = new NormalGoblin();
            ICard Dragon = new NormalDragon();

            Goblin.CheckSpecial(Dragon, false);

            Assert.That(Goblin.CardDamage, Is.EqualTo(0));
            Assert.That(Dragon.CardDamage, Is.EqualTo(100));

        }

        [Test]
        public void WaterTrollVSWaterOrk()
        {
            ICard Ork = new WaterOrk();
            ICard Troll = new WaterTroll();

            Ork.CheckSpecial(Troll, false);

            Assert.That(Ork.CardDamage, Is.EqualTo(0));
            Assert.That(Troll.CardDamage, Is.EqualTo(0));

        }

        [Test]
        public void GoblinVSKraken()
        {
            ICard Goblin = new NormalGoblin();
            ICard Kraken = new NormalKraken();

            Goblin.CheckSpecial(Kraken, false);

            Assert.That(Goblin.CardDamage, Is.EqualTo(100));
            Assert.That(Kraken.CardDamage, Is.EqualTo(125));

        }

        [Test]
        public void KnightsVSDragons()
        {
            ICard Knight = new NormalKnight();
            ICard Dragon = new NormalDragon();

            Knight.CheckSpecial(Dragon, false);

            Assert.That(Knight.CardDamage, Is.EqualTo(75));
            Assert.That(Dragon.CardDamage, Is.EqualTo(50));

        }


        [Test]
        public void WaterElveVSWaterElement()
        {
            ICard Elve = new WaterElve();
            ICard Troll = new WaterTroll();

            Elve.CheckSpecial(Troll, false);

            Assert.That(Elve.CardDamage, Is.EqualTo(60));
            Assert.That(Troll.CardDamage, Is.EqualTo(0));

        }

        [Test]
        public void TrollsVSWizzards()
        {
            ICard Troll = new WaterTroll();
            ICard Wizzard = new NormalWizzard();

            Troll.CheckSpecial(Wizzard, false);

            Assert.That(Wizzard.CardDamage, Is.EqualTo(0));
            Assert.That(Troll.CardDamage, Is.EqualTo(70));

        }

        [Test]
        public void TestElementsbyCreation()
        {
            ICard Goblin = new NormalGoblin();
            ICard Fire_Goblin = new FireGoblin();
            ICard WaterGoblin = new WaterGoblin();

            Assert.That(Goblin.CardElement, Is.EqualTo(0));
            Assert.That(Fire_Goblin.CardElement, Is.EqualTo(1));
            Assert.That(WaterGoblin.CardElement, Is.EqualTo(2));

        }

        [Test]
        public void SpellDamageVariation()
        {
            ICard Spell = new NormalSpell();
            ICard Fire_Spell = new FireSpell();
            ICard Water_Spell = new WaterSpell();

            Fire_Spell.CheckSpecial(Spell,true); // Fire vs Normal  = 80
            Water_Spell.CheckSpecial(Spell, true);// Water vs Normal = 20

            Assert.That(Spell.CardDamage, Is.EqualTo(40));
            Assert.That(Fire_Spell.CardDamage, Is.EqualTo(80));
            Assert.That(Water_Spell.CardDamage, Is.EqualTo(20));

            Fire_Spell.CardDamage = Fire_Spell.CardResetdmg;
            Water_Spell.CardDamage = Water_Spell.CardResetdmg;

            Fire_Spell.CheckSpecial(Water_Spell, true); // Fire vs Water so *2 = 80
     
            Assert.That(Fire_Spell.CardDamage, Is.EqualTo(20));
            Assert.That(Water_Spell.CardDamage, Is.EqualTo(80));
        }

        /// <summary>
        ///User Tests
        /// </summary>
        /// 

        [Test]
        public void CreateUser()
        {
            
           Database Connection = new Database();
           User user = new User("TestFranz", "123Brücke");
           
           User newuser = Connection.getUserDatabase(user.UserName , user.UserPassword);

           Assert.That(user.UserName, Is.EqualTo(newuser.UserName));

           Connection.Connection.Close(); 
        }

        [Test]
        public void DeleteUser()
        {

            Database Connection = new Database();
            User user = new User("TestFranz", "123Brücke");
            int Check = 0;
            user.DeleteUser();

            Database Connection2 = new Database();
            NpgsqlCommand query = new NpgsqlCommand($"SELECT name FROM people WHERE name ='{user.UserName}'", Connection2.Connection);

            NpgsqlDataReader isempty = query.ExecuteReader();

            if(isempty.HasRows == false)
            {
                Check = 1;
            }
            Assert.That(Check, Is.EqualTo(1));

            Connection.Connection.Close();
        }

        [Test]
        public void UpdateUser()
        {

            Database Connection = new Database();
            User user = new User("UpdatefranzFranz", "123Brücke");

            user.Elo += 20;
            user.MatchesWon = 10;
            user.MatchesLost = 5;
            user.WLRatio();
            user.UpdateUser();

            Database Connection2 = new Database();

            var sql = $"SELECT * FROM people WHERE name ='{user.UserName}'";
            using var query = new NpgsqlCommand(sql, Connection2.Connection);
            using NpgsqlDataReader Reader = query.ExecuteReader();
            
            int coins, elo, matcheswon, matcheslost;
            double wlratio;

            while (Reader.Read()) // As long as the Reader is reading entrys
            {
                
                coins = Reader.GetInt32(3);
                elo = Reader.GetInt32(4);
                matcheswon = Reader.GetInt32(5);
                matcheslost = Reader.GetInt32(6);
                wlratio = Reader.GetDouble(7);

                

                user = new User(user.UserName, user.UserPassword, coins, elo, matcheswon, matcheslost, wlratio);
            }
            
            Assert.That(user.Elo, Is.EqualTo(user.Elo));
            Assert.That(user.MatchesWon, Is.EqualTo(user.MatchesWon));
            Assert.That(user.MatchesLost, Is.EqualTo(user.MatchesLost));
            Assert.That(user.WinLossRatio, Is.EqualTo(user.WinLossRatio));
            user.DeleteUser();

            Connection.Connection.Close();
        }

        [Test]
        public void CheckcoinsafterOpening()
        {
            User user = new User("CoinFranz", "123Brücke");
            
            user.BuyPacks();
            
            Assert.That(user.UserCoins, Is.EqualTo(0));
 
        }

        [Test]
        public void CheckStackandBattledeckSize()
        {
            User user = new User("CoinFranz", "123Brücke");

            user.BuyPacks();

            user.createBattledeck(2);
            user.createBattledeck(6);
            user.createBattledeck(15);
            user.createBattledeck(1);
            user.createBattledeck(9);

            Assert.That(user.CardCollection.Count(), Is.EqualTo(20));
            Assert.That(user.BattleDeck.Count(), Is.EqualTo(5));

            user.DeleteUser();

        }

        /// <summary>
        ///Battle Tests
        /// </summary>
        /// 

        [Test]
        public void FightforDraw()
        {
            User user = new User("KampfFranz", "123Brücke");
            User user2 = new User("WildeOtto", "123Baum");

            NormalDragon Dragon = new NormalDragon();
            FireDragon Dragon2 = new FireDragon();
            string Result;

            user.BattleDeck.Add(Dragon);
            user2.BattleDeck.Add(Dragon2);

            Battle Battle = new Battle();

            Result = Battle.StartBattle(user, user2);


            Assert.That(Result, Is.EqualTo("Its a Draw!"));
            

            user.DeleteUser();
            user2.DeleteUser();
        }

        [Test]
        public void FightPlayer1Win()
        {
            User user = new User("KampfFranz", "123Brücke");
            User user2 = new User("WildeOtto", "123Baum");

            NormalDragon Dragon = new NormalDragon();
            NormalOrk Ork = new NormalOrk();
            string Result;

            user.BattleDeck.Add(Dragon);
            user2.BattleDeck.Add(Ork);

            Battle Battle = new Battle();

            Result = Battle.StartBattle(user, user2);


            Assert.That(Result, Is.EqualTo("Player1 won!"));


            user.DeleteUser();
            user2.DeleteUser();
        }

        [Test]
        public void FightPlayer2Win()
        {
            User user = new User("KampfFranz", "123Brücke");
            User user2 = new User("WildeOtto", "123Baum");

            NormalDragon Dragon = new NormalDragon();
            NormalOrk Ork = new NormalOrk();
            string Result;

            user.BattleDeck.Add(Ork);
            user2.BattleDeck.Add(Dragon);

            Battle Battle = new Battle();

            Result = Battle.StartBattle(user, user2);


            Assert.That(Result, Is.EqualTo("Player2 won!"));


            user.DeleteUser();
            user2.DeleteUser();
        }

        [Test]
        public void FightPlayer1ElementalWin()
        {
            User user = new User("KampfFranz", "123Brücke");
            User user2 = new User("WildeOtto", "123Baum");

            NormalDragon Dragon = new NormalDragon();
            WaterSpell Spell = new WaterSpell();
            string Result;

            user.BattleDeck.Add(Dragon);
            user2.BattleDeck.Add(Spell);

            Battle Battle = new Battle();

            Result = Battle.StartBattle(user, user2);


            Assert.That(Result, Is.EqualTo("Player1 won! Elemental"));


            user.DeleteUser();
            user2.DeleteUser();
        }

        [Test]
        public void FightPlayer2ElementalWin()
        {
            User user = new User("KampfFranz", "123Brücke");
            User user2 = new User("WildeOtto", "123Baum");

            NormalDragon Dragon = new NormalDragon();
            WaterSpell Spell = new WaterSpell();
            string Result;

            user.BattleDeck.Add(Spell);
            user2.BattleDeck.Add(Dragon);

            Battle Battle = new Battle();

            Result = Battle.StartBattle(user, user2);


            Assert.That(Result, Is.EqualTo("Player2 won! Elemental"));


            user.DeleteUser();
            user2.DeleteUser();
        }

        [Test]
        public void FightDrawElementalwithSpells()
        {
            User user = new User("KampfFranz", "123Brücke");
            User user2 = new User("WildeOtto", "123Baum");

            WaterSpell Spell1 = new WaterSpell();
            WaterSpell Spell = new WaterSpell();
            string Result;

            user.BattleDeck.Add(Spell1);
            user2.BattleDeck.Add(Spell);

            Battle Battle = new Battle();

            Result = Battle.StartBattle(user, user2);


            Assert.That(Result, Is.EqualTo("Draw Elemental"));


            user.DeleteUser();
            user2.DeleteUser();
        }

    }
}