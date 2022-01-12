using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;


namespace Monster_Card_Game
{
    public class Database
    {
        private string Host = "localhost";
        private string Username = "postgres";
        private string Password = "patfried";
        private string DatabaseName = "mctg";

        public NpgsqlConnection Connection;
        
        public Database()
        {
            this.Connection = new NpgsqlConnection($"Host={Host};Username={Username};Password={Password};Database={DatabaseName}");
            if (Connection != null && Connection.State == ConnectionState.Closed)
            {
                this.Connection.Open();
            }
            
        }

        public User Login() // Logging in the User 
        {
            string UserName;
            string UserPassword;
            User Player;
            
                Console.WriteLine("Enter Username and Password!");

            
                Console.WriteLine("Username: ");
                UserName = Console.ReadLine();

                Console.WriteLine("Password: ");
                UserPassword = Console.ReadLine();

                return Player = getUserDatabase(UserName, UserPassword);
            

        }

        public static string HashPassword(string password, int iterations)
        {
            // Create salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt;
                rng.GetBytes(salt = new byte[16]);
                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    var hash = pbkdf2.GetBytes(20);
                    // Combine salt and hash
                    var hashBytes = new byte[16 + 20];
                    Array.Copy(salt, 0, hashBytes, 0, 16);
                    Array.Copy(hash, 0, hashBytes, 16, 20);
                    // Convert to base64
                    var HashedPassword = Convert.ToBase64String(hashBytes);

                   
                    return HashedPassword;
                }
            }

        }



        public User getUserDatabase(string Username, string Password) // Create new User or Login User
        {

            var sql = $"SELECT * FROM people WHERE name = @1";
            using var query = new NpgsqlCommand(sql, Connection);
            query.Parameters.Add(new NpgsqlParameter("@1", Username));
            query.Parameters[0].NpgsqlDbType = NpgsqlDbType.Text;
            query.Prepare();
            
            using NpgsqlDataReader Reader = query.ExecuteReader();
            
            User oldUser = null;
            bool alreadyexist = Reader.HasRows; // check if column is empty


            if (alreadyexist == true)
            {
                Console.WriteLine($"User {Username} exists and will be loged in!");

                string name, password;
                int coins, elo, matcheswon, matcheslost;
                

                while(Reader.Read()) // As long as the Reader is reading entrys
                {
                    name = Reader.GetString(1);
                    password = Reader.GetString(2);
                    coins = Reader.GetInt32(3);
                    elo = Reader.GetInt32(4);
                    matcheswon = Reader.GetInt32(5);
                    matcheslost = Reader.GetInt32(6);
                   

                    name = string.Join("", name.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

                    oldUser = new User(name, password, coins, elo, matcheswon, matcheslost);
                }

                return oldUser;
            }
            else
            {
                Console.WriteLine($"User {Username} does not exists an therefore will be created!");
                oldUser = new User(Username, Password);
                return oldUser;
            }
        }
        public void UpdateScoreboard()
        {
            var sql = $"SELECT name, elo, matcheswon, matcheslost, winlossratio FROM people ORDER By elo DESC, matcheswon DESC";
            using var query = new NpgsqlCommand(sql, Connection);
            using NpgsqlDataReader Reader = query.ExecuteReader();
            List<string> tmpCards = new List<string>();

            Console.WriteLine("SCOREBOARD:");
            Console.WriteLine(" Username  Elo  MatchesWon  MatchesLost  ");
            while(Reader.Read())
            {
                tmpCards.Add(Reader.GetString(0));
                Console.WriteLine($"{Reader.GetString(0)}  {Reader.GetInt16(1)}  {Reader.GetInt16(2)}  {Reader.GetInt16(3)}    ");
            }
            
            

        }
    }
}
