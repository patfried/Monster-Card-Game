using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster_Card_Game.Cards;
using Npgsql;

namespace Monster_Card_Game
{
    class User
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserCoins { get; set; }
        public int Elo { get; set; }
        
        public List<ICard> CardCollection { get; set; }
        public List<ICard> BattleDeck { get; set; }

        public User()
        {
            UserCoins = 20;
            CardCollection = new List<ICard>();
            Elo = 100;
        }

        public void BuyPack()
        {
            UserCoins = -5;

            var Rand = new Random();
            int RandNumber;

            for (int i = 0; i < 5; i++)
            {
                RandNumber = Rand.Next(0, 27);
                switch (RandNumber)
                {
                    case 0:
                        NormalGoblin Goblin = new NormalGoblin();
                        CardCollection.Add(Goblin);
                        break;
                    case 1:
                        WaterGoblin Water_Goblin = new WaterGoblin();
                        CardCollection.Add(Water_Goblin);
                        break;
                    case 2:
                        FireGoblin Fire_Goblin = new FireGoblin();
                        CardCollection.Add(Fire_Goblin);
                        break;
                    case 3:
                        NormalDragon Dragon = new NormalDragon();
                        CardCollection.Add(Dragon);
                        break;
                    case 4:
                        WaterDragon Water_Dragon = new WaterDragon();
                        CardCollection.Add(Water_Dragon);
                        break;
                    case 5:
                        FireDragon Fire_Dragon = new FireDragon();
                        CardCollection.Add(Fire_Dragon);
                        break;
                    case 6:
                        NormalWizzard Wizzard = new NormalWizzard();
                        CardCollection.Add(Wizzard);
                        break;
                    case 7:
                        WaterWizzard Water_Wizzard = new WaterWizzard();
                        CardCollection.Add(Water_Wizzard);
                        break;
                    case 8:
                        FireWizzard Fire_Wizzard = new FireWizzard();
                        CardCollection.Add(Fire_Wizzard);
                        break;
                    case 9:
                        NormalOrk Ork = new NormalOrk();
                        CardCollection.Add(Ork);
                        break;
                    case 10:
                        WaterOrk Water_Ork = new WaterOrk();
                        CardCollection.Add(Water_Ork);
                        break;
                    case 11:
                       FireOrk Fire_Ork = new FireOrk();
                        CardCollection.Add(Fire_Ork);
                        break;
                    case 12:
                        NormalKnight Knight = new NormalKnight();
                        CardCollection.Add(Knight);
                        break;
                    case 13:
                        WaterKnight Water_Knight = new WaterKnight();
                        CardCollection.Add(Water_Knight);
                        break;
                    case 14:
                       FireKnight Fire_Knight = new FireKnight();
                        CardCollection.Add(Fire_Knight);
                        break;
                    case 15:
                        NormalKraken Kraken = new NormalKraken();
                        CardCollection.Add(Kraken);
                        break;
                    case 16:
                        FireKraken Fire_Kraken = new FireKraken();
                        CardCollection.Add(Fire_Kraken);
                        break;
                    case 17:
                        WaterKraken Water_Kraken = new WaterKraken();
                        CardCollection.Add(Water_Kraken);
                        break;
                    case 18:
                        NormalElve Elve = new NormalElve();
                        CardCollection.Add(Elve);
                        break;
                    case 19:
                        WaterElve Water_Elve = new WaterElve();
                        CardCollection.Add(Water_Elve);
                        break;
                    case 20:
                        FireElve Fire_Elve = new FireElve();
                        CardCollection.Add(Fire_Elve);
                        break;
                    case 21:
                        NormalTroll Troll = new NormalTroll();
                        CardCollection.Add(Troll);
                        break;
                    case 22:
                        WaterTroll Water_Troll = new WaterTroll();
                        CardCollection.Add(Water_Troll);
                        break;
                    case 23:
                        FireTroll Fire_Troll = new FireTroll();
                        CardCollection.Add(Fire_Troll);
                        break;
                    case 24:
                        NormalSpell Spell = new NormalSpell();
                        CardCollection.Add(Spell);
                        break;
                    case 25:
                        WaterSpell Water_Spell = new WaterSpell();
                        CardCollection.Add(Water_Spell);
                        break;
                    case 26:
                        FireSpell Fire_Spell = new FireSpell();
                        CardCollection.Add(Fire_Spell);
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

        public ICard PickRandomCard()
        {
            var Rand = new Random();
            int RandNumber;
            int Battledecklenght = CardCollection.Count;

            RandNumber = Rand.Next(0, Battledecklenght);

            ICard RandomCard = CardCollection.ElementAt(RandNumber);

            Console.WriteLine(RandomCard.CardName);

            return RandomCard;
        }
        public void InsertUserintoDB()
        {
            Database Connection = new Database();

            var sql = $"SELECT * FROM people WHERE name = '{this.UserName}'";
            using var query = new NpgsqlCommand(sql, Connection.Connection);

            bool alreadyexist = query.ExecuteReader().HasRows;

            if(alreadyexist != true) // If there is no such User insert it into DB / new Connection needed because of new query statement
            {
                Database newConnection = new Database();

                sql = "INSERT INTO people (name, password, coins, elo) VALUES (@1, @2, @3, @4)"; // prepare
                using var newquery = new NpgsqlCommand(sql, newConnection.Connection);

                newquery.Parameters.AddWithValue("@1", this.UserName);                          // fill in 
                newquery.Parameters.AddWithValue("@2", this.UserPassword);
                newquery.Parameters.AddWithValue("@3", this.UserCoins);
                newquery.Parameters.AddWithValue("@4", this.Elo);
                newquery.Prepare();

                newquery.ExecuteNonQuery();                                                     //execute
                
                newConnection.Connection.Close();
            }
            else
            {
                Console.WriteLine("User already exists!");
            }
        }
        
        public void UpdateUser()
        {
            Database Connection = new Database();

            var sql = $" UPDATE people SET name=@1, password=@2, coins=@3, elo=@4  WHERE name='{this.UserName}'"; //prepare / TODO UserNamen ersetzen da er sonst nach dem neuen namen Eintrag sucht der nicht vorhanden ist
            using var query = new NpgsqlCommand(sql, Connection.Connection);

            query.Parameters.AddWithValue("@1", this.UserName);                          // fill in 
            query.Parameters.AddWithValue("@2", this.UserPassword);
            query.Parameters.AddWithValue("@3", this.UserCoins);
            query.Parameters.AddWithValue("@4", this.Elo);
            query.Prepare();

            query.ExecuteNonQuery();                                                     //execute

            Connection.Connection.Close();
        }
        
        public void DeleteUser()
        {
            Database Connection = new Database();

            var sql = $"SELECT * FROM people WHERE name = '{this.UserName}'";
            using var query = new NpgsqlCommand(sql, Connection.Connection);

            bool doesexist = query.ExecuteReader().HasRows;

            if(doesexist)
            {
                Database newConnection = new Database();
                sql = $" DELETE FROM people WHERE name = '{this.UserName}'"; //prepare
                using var newquery = new NpgsqlCommand(sql, newConnection.Connection);
                newquery.ExecuteNonQuery();
                newConnection.Connection.Close();
            }
            else
            {
                Console.WriteLine($"User {UserName} does not exist!");
            }
            Connection.Connection.Close();
        }
    }

}
