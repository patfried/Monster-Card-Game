using NUnit.Framework;
using Monster_Card_Game;
using Monster_Card_Game.Cards;

namespace Monster_Card_Game_Tests
{
    public class Tests
    {

        [Test]
        public void DragonVSElve()
        {
            NormalDragon Dragon =  new NormalDragon();
            FireElve Elve = new FireElve();

            Dragon.CheckElve(Elve);

            Assert.That(Dragon.CardDamage, Is.EqualTo(0));
            Assert.That(Elve.CardDamage, Is.EqualTo(60));
            
        }
        
        [Test]
        public void KnightVSWaterSpell()
        {
            NormalKnight Knight = new NormalKnight();
            WaterSpell Water_Spell = new WaterSpell();

            Knight.CheckWaterSpell(Water_Spell);

            Assert.That(Knight.CardDamage, Is.EqualTo(0));
            Assert.That(Water_Spell.CardDamage, Is.EqualTo(40));

        }

        [Test]
        public void OrkVSWizzard()
        {
            NormalOrk Ork = new NormalOrk();
            NormalWizzard Wizzard = new NormalWizzard();

            Ork.CheckWizzard(Wizzard);

            Assert.That(Ork.CardDamage, Is.EqualTo(0));
            Assert.That(Wizzard.CardDamage, Is.EqualTo(30));

        }

        [Test]
        public void GoblinVSDragon()
        {
            NormalGoblin Goblin = new NormalGoblin();
            NormalDragon Dragon = new NormalDragon();

            Goblin.CheckDragon(Dragon);

            Assert.That(Goblin.CardDamage, Is.EqualTo(0));
            Assert.That(Dragon.CardDamage, Is.EqualTo(100));

        }

        [Test]
        public void SpellVSKraken()
        {
            NormalKraken Kraken = new NormalKraken();
            NormalSpell Spell = new NormalSpell();

            Spell.CheckKraken(Kraken);

            Assert.That(Spell.CardDamage, Is.EqualTo(0));
            Assert.That(Kraken.CardDamage, Is.EqualTo(125));

        }

        [Test]
        public void TestElementsbyCreation()
        {
            NormalGoblin Goblin = new NormalGoblin();
            FireGoblin Fire_Goblin = new FireGoblin();
            WaterGoblin WaterGoblin = new WaterGoblin();

            Assert.That(Goblin.CardElement, Is.EqualTo(0));
            Assert.That(Fire_Goblin.CardElement, Is.EqualTo(1));
            Assert.That(WaterGoblin.CardElement, Is.EqualTo(2));

        }

        [Test]
        public void SpellDamageVariation()
        {
            NormalSpell Spell = new NormalSpell();
            FireSpell Fire_Spell = new FireSpell();
            WaterSpell Water_Spell = new WaterSpell();

            Fire_Spell.CheckElement(Spell); // Fire vs Normal  = 40
            Water_Spell.CheckElement(Spell);// Water vs Normal = 40

            Assert.That(Spell.CardDamage, Is.EqualTo(40));
            Assert.That(Fire_Spell.CardDamage, Is.EqualTo(40));
            Assert.That(Water_Spell.CardDamage, Is.EqualTo(40));

            Fire_Spell.CheckElement(Water_Spell); // Fire vs Water so *2 = 80
            Water_Spell.CheckElement(Fire_Spell); // Water vs Fire so *2 = 80

            Assert.That(Spell.CardDamage, Is.EqualTo(40));
            Assert.That(Fire_Spell.CardDamage, Is.EqualTo(80));
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

    }
}