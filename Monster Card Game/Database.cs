using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Monster_Card_Game
{
    class Database
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

        public void Login() // Logging in the User and Errorhandling
        {

        }

        public string HashPassword(string Password)
        {
            return "Anus";
        }


    }
}
