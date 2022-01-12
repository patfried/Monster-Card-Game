using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Npgsql;
using NpgsqlTypes;

namespace Monster_Card_Game
{
    class HttpProcessor
    {
        private TcpClient socket;
        private HttpServer httpServer;

        public string Method { get; private set; }
        public string Path { get; private set; }
        public string Version { get; private set; }

        public Dictionary<string, string> Headers { get; }
        

        public HttpProcessor(TcpClient s, HttpServer httpServer)
        {
            this.socket = s;
            this.httpServer = httpServer;

            Method = null;
            Headers = new();
        }

        public void Process()
        {
            var writer = new StreamWriter(socket.GetStream()) { AutoFlush = true };
            var reader = new StreamReader(socket.GetStream());
            Console.WriteLine();

            // read (and handle) the full HTTP-request
            JObject list = new JObject();
            string line = null;
            string content = "";
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
                if (line.Length == 0)
                    break;  // empty line means next comes the content (which is currently skipped)

                // handle first line of HTTP
                if (Method == null)
                {
                    var parts = line.Split(' ');
                    Method = parts[0];
                    Path = parts[1];
                    Version = parts[2];
                }
                // handle HTTP headers
                else
                {
                    var parts = line.Split(": ");
                    Headers.Add(parts[0], parts[1]);
                }
            }

            if (this.Headers.ContainsKey("Content-Length") ? true : false)
            {
                // Testausgabe des contents
                int length = int.Parse(this.Headers["Content-Length"]);
                char[] buffer = new char[length];
                reader.Read(buffer, 0, length);
                string lineContent = new string(buffer);

                // Verhindert dass das Programm abbricht weil kein content gesendet wird

                list = JsonConvert.DeserializeObject<JObject>(lineContent);
            }

            switch(this.Path)
            {
                case "/createuser": // create an User

                    {
                        Database Connection = new Database();
                        User user = Connection.getUserDatabase(list["username"].ToString(), list["password"].ToString());
                        content = $"User: {list["username"]} was created sucsessfully!";
                        Connection.Connection.Close();
                        
                    }
                    break;

                case "/delete": // delete an User

                    {
                        Database Connection = new Database();
                        User user = Connection.getUserDatabase(list["username"].ToString(), list["password"].ToString());
                        int Check = 0;
                        string uname = user.UserName;
                        user.DeleteUser();

                        Database Connection2 = new Database();
                        NpgsqlCommand query = new NpgsqlCommand($"SELECT name FROM people WHERE name =@1", Connection2.Connection);
                        query.Parameters.Add(new NpgsqlParameter("@1", uname));
                        query.Parameters[0].NpgsqlDbType = NpgsqlDbType.Text;
                        query.Prepare();

                        NpgsqlDataReader isempty = query.ExecuteReader();

                        if (isempty.HasRows == false)
                        {
                            Check = 1;
                        }
                        if(Check == 1)
                        {
                            content = $"{uname} has been deleted";
                        }

                        Connection.Connection.Close();
                    }
                    break;


                case "/collection": // create and print the Stack

                    {
                        Database Connection = new Database();
                        User user = Connection.getUserDatabase(list["username"].ToString(), list["password"].ToString());
                        user.BuyPacks();
                        user.InsertStackIntoDB();
                        user.printstack();
                        content = "5 Boosterpacks sucsessfully bought!";
                        Connection.Connection.Close();
                    }
                 
                    break;

                case "/battledeck": // Create a Battledeck and write it into the DB

                    {
                        Database Connection = new Database();
                        User user = Connection.getUserDatabase(list["username"].ToString(), list["password"].ToString());

                        user.CreateStackFromDB();

                        user.createBattledeck(2);
                        user.createBattledeck(13);
                        user.createBattledeck(10);
                        user.createBattledeck(8);
                        user.createBattledeck(5);

                        content = "Battledeck was sucsessfully created!";
                        user.UpdateUser();
                        Connection.Connection.Close();
                    }
                    
                    break;


                case "/fight": // fight

                    {
                        Database Connection = new Database();
                        Battle Battle = new Battle();
                        User user = Connection.getUserDatabase(list["username"].ToString(), list["password"].ToString());
                        User user1 = Connection.getUserDatabase(list["username1"].ToString(), list["password1"].ToString());

                        user.CreateBattledeckFromDB();
                        user1.CreateBattledeckFromDB();

                        Battle.StartBattle(user, user1);
                        Connection.UpdateScoreboard();
                    }
                   
                    break;

                case "/score": // Show the scoreboard

                    {
                        Database Connection = new Database();

                        Connection.UpdateScoreboard();

                        Connection.Connection.Close();
                    }
                    
                    break;

            }


            

            Console.WriteLine();
            WriteLine(writer, "HTTP/1.1 200 OK");
            WriteLine(writer, "Server: Monster Trading Game");
            WriteLine(writer, $"Current Time: {DateTime.Now}");
            WriteLine(writer, $"Content-Length: {content.Length}");
            WriteLine(writer, "Content-Type: text/html; charset=utf-8");
            WriteLine(writer, "");
            WriteLine(writer, content);

            writer.WriteLine();
            writer.Flush();
            writer.Close();
        }

        private void WriteLine(StreamWriter writer, string s)
        {
            Console.WriteLine(s);
            writer.WriteLine(s);
        }
    }
}
