using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monster_Card_Game.Cards;
using Npgsql;

namespace Monster_Card_Game
{
    public class User
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public int UserCoins { get; set; }
        public int Elo { get; set; }
        public int MatchesWon;
        public int MatchesLost;
        public double WinLossRatio;
        
        public List<ICard> CardCollection { get; set; }
        public List<ICard> BattleDeck { get; set; }

        public User(string Username, string Password) // Standard when creating User
        {
            UserName = Username;
            UserPassword = Database.HashPassword(Password,100);
            UserCoins = 20;
            CardCollection = new List<ICard>();
            BattleDeck = new List<ICard>();
            Elo = 100;
            MatchesWon = 0;
            MatchesLost = 0;
            WinLossRatio = 0;
            InsertUserintoDB();
        }

        public User(string Username, string Password, int Coins, int Elodb, int matcheswon,int matcheslost, double wlratio) // Used when Login User in 
        {
            
            UserName = Username;
            UserPassword = Password;
            UserCoins = Coins;
            Elo = Elodb;
            MatchesWon = matcheswon;
            MatchesLost = matcheslost;
            WinLossRatio = wlratio;
            CardCollection = new List<ICard>();
            BattleDeck = new List<ICard>();

        }

        public void BuyPacks()
        {
            UserCoins -= 20;

            var Rand = new Random();
            int RandNumber;

            for (int i = 0; i < 20; i++)
            {
                RandNumber = Rand.Next(0, 27);
                switch (RandNumber)
                {
                    case 0:
                        NormalGoblin Normal_Goblin = new NormalGoblin();
                        CardCollection.Add(Normal_Goblin);
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
                        NormalDragon Normal_Dragon = new NormalDragon();
                        CardCollection.Add(Normal_Dragon);
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
                        NormalWizzard Normal_Wizzard = new NormalWizzard();
                        CardCollection.Add(Normal_Wizzard);
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
                        NormalOrk Normal_Ork = new NormalOrk();
                        CardCollection.Add(Normal_Ork);
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
                        NormalKnight Normal_Knight = new NormalKnight();
                        CardCollection.Add(Normal_Knight);
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
                        NormalKraken Normal_Kraken = new NormalKraken();
                        CardCollection.Add(Normal_Kraken);
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
                        NormalElve Normal_Elve = new NormalElve();
                        CardCollection.Add(Normal_Elve);
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
                        NormalTroll Normal_Troll = new NormalTroll();
                        CardCollection.Add(Normal_Troll);
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
                        NormalSpell Normal_Spell = new NormalSpell();
                        CardCollection.Add(Normal_Spell);
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
        public void printstack()
        {
            foreach (ICard Collection in CardCollection)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"Klasse:{Collection.CardClass}");
                Console.WriteLine($"Name:{Collection.CardName}");
                Console.WriteLine($"Typ:{Collection.CardType}");
                Console.WriteLine($"Schaden:{Collection.CardClass}");
                Console.WriteLine("-----------------------------------------------");

            }
            
        }
        public void createBattledeck(int number)
        {
            
                if (CardCollection.Count == 0)
                {
                    Console.WriteLine("There are no Cards in the Users stack!");
                    
                }
                else
                {
                    BattleDeck.Add(CardCollection[number]);
                    InsertBattledeckIntoDB(number);
                }
            

            
        }

        public void WLRatio()
        {
            this.WinLossRatio = MatchesWon / MatchesLost;
        }

        public ICard PickRandomCard()
        {
            var Rand = new Random();
            int RandNumber;
            int Battledecklenght = BattleDeck.Count();

            RandNumber = Rand.Next(0, Battledecklenght);

            ICard RandomCard = BattleDeck.ElementAt(RandNumber);

            

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

                sql = "INSERT INTO people (name, password, coins, elo, matcheswon, matcheslost, winlossratio) VALUES (@1, @2, @3, @4, @5, @6, @7)"; // prepare
                using var newquery = new NpgsqlCommand(sql, newConnection.Connection);

                newquery.Parameters.AddWithValue("@1", this.UserName);                          // fill in 
                newquery.Parameters.AddWithValue("@2", this.UserPassword);
                newquery.Parameters.AddWithValue("@3", this.UserCoins);
                newquery.Parameters.AddWithValue("@4", this.Elo);
                newquery.Parameters.AddWithValue("@5", this.MatchesWon);
                newquery.Parameters.AddWithValue("@6", this.MatchesLost);
                newquery.Parameters.AddWithValue("@7", this.WinLossRatio);
                
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

            var sql = $" UPDATE people SET name=@1, password=@2, coins=@3, elo=@4, matcheswon=@5, matcheslost=@6  WHERE name='{this.UserName}'"; //prepare / TODO UserNamen ersetzen da er sonst nach dem neuen namen Eintrag sucht der nicht vorhanden ist
            using var query = new NpgsqlCommand(sql, Connection.Connection);

            query.Parameters.AddWithValue("@1", this.UserName);                          // fill in 
            query.Parameters.AddWithValue("@2", this.UserPassword);
            query.Parameters.AddWithValue("@3", this.UserCoins);
            query.Parameters.AddWithValue("@4", this.Elo);
            query.Parameters.AddWithValue("@5", this.MatchesWon);
            query.Parameters.AddWithValue("@6", this.MatchesLost);
            
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
                sql = $" DELETE FROM people WHERE name = '{this.UserName}'"; 
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
        
        public void InsertStackIntoDB()
        {
            
            foreach (ICard Collection in CardCollection)
            {
                Database Connection = new Database();
                
                var sql = "INSERT INTO stack (cardclass, cardname, carddamage, cardelement, cardtype, username) VALUES (@1, @2, @3, @4, @5, @6)"; // prepare
                using var query = new NpgsqlCommand(sql, Connection.Connection);

                query.Parameters.AddWithValue("@1", Collection.CardClass);                          // fill in 
                query.Parameters.AddWithValue("@2", Collection.CardName);
                query.Parameters.AddWithValue("@3", Collection.CardDamage);
                query.Parameters.AddWithValue("@4", Collection.CardElement);
                query.Parameters.AddWithValue("@5", Collection.CardType);
                query.Parameters.AddWithValue("@6", this.UserName);
                query.Prepare();

                query.ExecuteNonQuery();                                                     //execute
                Console.WriteLine("Cards sucsessfully entered into your stack!");
                Connection.Connection.Close();

            }
            
        }
        public void InsertBattledeckIntoDB(int index)
        {

                Database Connection = new Database();

                var sql = "INSERT INTO battledeck (cardclass, cardname, carddamage, cardelement, cardtype, username) VALUES (@1, @2, @3, @4, @5, @6)"; // prepare
                using var query = new NpgsqlCommand(sql, Connection.Connection);

                query.Parameters.AddWithValue("@1", CardCollection[index].CardClass );                          // fill in 
                query.Parameters.AddWithValue("@2", CardCollection[index].CardName);
                query.Parameters.AddWithValue("@3", CardCollection[index].CardDamage);
                query.Parameters.AddWithValue("@4", CardCollection[index].CardElement);
                query.Parameters.AddWithValue("@5", CardCollection[index].CardType);
                query.Parameters.AddWithValue("@6", this.UserName);
                query.Prepare();

                query.ExecuteNonQuery();                                                     //execute
                Console.WriteLine("Card Sucsessfully added to Battledeck!");
                Connection.Connection.Close();

            

        }
        public void CreateStackFromDB()
        {
            
            Database Connection = new Database();
            var sql = $"SELECT cardname FROM stack WHERE username='{this.UserName}'";
            using var query = new NpgsqlCommand(sql, Connection.Connection);
            using NpgsqlDataReader Reader = query.ExecuteReader();
            List<string> tmpCards = new List<string>();
            string tmpname;
            
            while (Reader.Read())
            {
                tmpname = Reader.GetString(0);
                tmpname = string.Join("", tmpname.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                tmpCards.Add(tmpname);
            }

            foreach (string Cards in tmpCards)
            {
                
                switch (Cards)
                {
                    case "Normal_Goblin":
                        NormalGoblin Goblin = new NormalGoblin();
                        CardCollection.Add(Goblin);
                        break;
                    case "Water_Goblin":
                        WaterGoblin Water_Goblin = new WaterGoblin();
                        CardCollection.Add(Water_Goblin);
                        break;
                    case "Fire_Goblin":
                        FireGoblin Fire_Goblin = new FireGoblin();
                        CardCollection.Add(Fire_Goblin);
                        break;
                    case "Normal_Dragon":
                        NormalDragon Dragon = new NormalDragon();
                        CardCollection.Add(Dragon);
                        break;
                    case "Water_Dragon":
                        WaterDragon Water_Dragon = new WaterDragon();
                        CardCollection.Add(Water_Dragon);
                        break;
                    case "Fire_Dragon":
                        FireDragon Fire_Dragon = new FireDragon();
                        CardCollection.Add(Fire_Dragon);
                        break;
                    case "Normal Wizzard":
                        NormalWizzard Wizzard = new NormalWizzard();
                        CardCollection.Add(Wizzard);
                        break;
                    case "Water_Wizzard":
                        WaterWizzard Water_Wizzard = new WaterWizzard();
                        CardCollection.Add(Water_Wizzard);
                        break;
                    case "Fire_Wizzard":
                        FireWizzard Fire_Wizzard = new FireWizzard();
                        CardCollection.Add(Fire_Wizzard);
                        break;
                    case "Normal_Ork":
                        NormalOrk Ork = new NormalOrk();
                        CardCollection.Add(Ork);
                        break;
                    case "Water_Ork":
                        WaterOrk Water_Ork = new WaterOrk();
                        CardCollection.Add(Water_Ork);
                        break;
                    case "Fire_Ork":
                        FireOrk Fire_Ork = new FireOrk();
                        CardCollection.Add(Fire_Ork);
                        break;
                    case "Normal_Knight":
                        NormalKnight Knight = new NormalKnight();
                        CardCollection.Add(Knight);
                        break;
                    case "Water_Knight":
                        WaterKnight Water_Knight = new WaterKnight();
                        CardCollection.Add(Water_Knight);
                        break;
                    case "Fire_Knight":
                        FireKnight Fire_Knight = new FireKnight();
                        CardCollection.Add(Fire_Knight);
                        break;
                    case "Normal_Kraken":
                        NormalKraken Kraken = new NormalKraken();
                        CardCollection.Add(Kraken);
                        break;
                    case "Fire_Kraken":
                        FireKraken Fire_Kraken = new FireKraken();
                        CardCollection.Add(Fire_Kraken);
                        break;
                    case "Water_Kraken":
                        WaterKraken Water_Kraken = new WaterKraken();
                        CardCollection.Add(Water_Kraken);
                        break;
                    case "Normal_Elve":
                        NormalElve Elve = new NormalElve();
                        CardCollection.Add(Elve);
                        break;
                    case "Water_Elve":
                        WaterElve Water_Elve = new WaterElve();
                        CardCollection.Add(Water_Elve);
                        break;
                    case "Fire_Elve":
                        FireElve Fire_Elve = new FireElve();
                        CardCollection.Add(Fire_Elve);
                        break;
                    case "Troll":
                        NormalTroll Troll = new NormalTroll();
                        CardCollection.Add(Troll);
                        break;
                    case "Water_Troll":
                        WaterTroll Water_Troll = new WaterTroll();
                        CardCollection.Add(Water_Troll);
                        break;
                    case "Fire_Troll":
                        FireTroll Fire_Troll = new FireTroll();
                        CardCollection.Add(Fire_Troll);
                        break;
                    case "Normal_Spell":
                        NormalSpell Spell = new NormalSpell();
                        CardCollection.Add(Spell);
                        break;
                    case "Water_Spell":
                        WaterSpell Water_Spell = new WaterSpell();
                        CardCollection.Add(Water_Spell);
                        break;
                    case "Fire_Spell":
                        FireSpell Fire_Spell = new FireSpell();
                        CardCollection.Add(Fire_Spell);
                        break;
                }
                
            }
            Console.WriteLine("Databsecards");
            Connection.Connection.Close();
        }

        public void CreateBattledeckFromDB()
        {

            Database Connection = new Database();
            var sql = $"SELECT cardname FROM battledeck WHERE username='{this.UserName}'";
            using var query = new NpgsqlCommand(sql, Connection.Connection);
            using NpgsqlDataReader Reader = query.ExecuteReader();
            List<string> tmpCards = new List<string>();
            string tmpname;

            while (Reader.Read())
            {
                tmpname = Reader.GetString(0);
                tmpname = string.Join("", tmpname.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
                tmpCards.Add(tmpname);
            }

            foreach (string Cards in tmpCards)
            {

                switch (Cards)
                {
                    case "Normal_Goblin":
                        NormalGoblin Goblin = new NormalGoblin();
                        BattleDeck.Add(Goblin);
                        break;
                    case "Water_Goblin":
                        WaterGoblin Water_Goblin = new WaterGoblin();
                        BattleDeck.Add(Water_Goblin);
                        break;
                    case "Fire_Goblin":
                        FireGoblin Fire_Goblin = new FireGoblin();
                        BattleDeck.Add(Fire_Goblin);
                        break;
                    case "Normal_Dragon":
                        NormalDragon Dragon = new NormalDragon();
                        BattleDeck.Add(Dragon);
                        break;
                    case "Water_Dragon":
                        WaterDragon Water_Dragon = new WaterDragon();
                        BattleDeck.Add(Water_Dragon);
                        break;
                    case "Fire_Dragon":
                        FireDragon Fire_Dragon = new FireDragon();
                        BattleDeck.Add(Fire_Dragon);
                        break;
                    case "Normal Wizzard":
                        NormalWizzard Wizzard = new NormalWizzard();
                        BattleDeck.Add(Wizzard);
                        break;
                    case "Water_Wizzard":
                        WaterWizzard Water_Wizzard = new WaterWizzard();
                        BattleDeck.Add(Water_Wizzard);
                        break;
                    case "Fire_Wizzard":
                        FireWizzard Fire_Wizzard = new FireWizzard();
                        BattleDeck.Add(Fire_Wizzard);
                        break;
                    case "Normal_Ork":
                        NormalOrk Ork = new NormalOrk();
                        BattleDeck.Add(Ork);
                        break;
                    case "Water_Ork":
                        WaterOrk Water_Ork = new WaterOrk();
                        BattleDeck.Add(Water_Ork);
                        break;
                    case "Fire_Ork":
                        FireOrk Fire_Ork = new FireOrk();
                        BattleDeck.Add(Fire_Ork);
                        break;
                    case "Normal_Knight":
                        NormalKnight Knight = new NormalKnight();
                        BattleDeck.Add(Knight);
                        break;
                    case "Water_Knight":
                        WaterKnight Water_Knight = new WaterKnight();
                        BattleDeck.Add(Water_Knight);
                        break;
                    case "Fire_Knight":
                        FireKnight Fire_Knight = new FireKnight();
                        BattleDeck.Add(Fire_Knight);
                        break;
                    case "Normal_Kraken":
                        NormalKraken Kraken = new NormalKraken();
                        BattleDeck.Add(Kraken);
                        break;
                    case "Fire_Kraken":
                        FireKraken Fire_Kraken = new FireKraken();
                        BattleDeck.Add(Fire_Kraken);
                        break;
                    case "Water_Kraken":
                        WaterKraken Water_Kraken = new WaterKraken();
                        BattleDeck.Add(Water_Kraken);
                        break;
                    case "Normal_Elve":
                        NormalElve Elve = new NormalElve();
                        BattleDeck.Add(Elve);
                        break;
                    case "Water_Elve":
                        WaterElve Water_Elve = new WaterElve();
                        BattleDeck.Add(Water_Elve);
                        break;
                    case "Fire_Elve":
                        FireElve Fire_Elve = new FireElve();
                        BattleDeck.Add(Fire_Elve);
                        break;
                    case "Troll":
                        NormalTroll Troll = new NormalTroll();
                        BattleDeck.Add(Troll);
                        break;
                    case "Water_Troll":
                        WaterTroll Water_Troll = new WaterTroll();
                        BattleDeck.Add(Water_Troll);
                        break;
                    case "Fire_Troll":
                        FireTroll Fire_Troll = new FireTroll();
                        BattleDeck.Add(Fire_Troll);
                        break;
                    case "Normal_Spell":
                        NormalSpell Spell = new NormalSpell();
                        BattleDeck.Add(Spell);
                        break;
                    case "Water_Spell":
                        WaterSpell Water_Spell = new WaterSpell();
                        BattleDeck.Add(Water_Spell);
                        break;
                    case "Fire_Spell":
                        FireSpell Fire_Spell = new FireSpell();
                        BattleDeck.Add(Fire_Spell);
                        break;
                }

            }
            Console.WriteLine("Databsecards");
            Connection.Connection.Close();
        }
    }


}
