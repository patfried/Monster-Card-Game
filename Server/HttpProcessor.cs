using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
                case "/createuser": // Create an User

                    Database Connection = new Database(); 
                    User user = Connection.getUserDatabase(list["username"].ToString(), list["password"].ToString());
                    content = $"User: {list["username"]} was created sucsessfully!";
                    Connection.Connection.Close();
                    break;


                case "/collection": // create and print the Stack
                    
                    Database Connection1 = new Database();
                    User user1 = Connection1.getUserDatabase(list["username"].ToString(), list["password"].ToString());
                    user1.BuyPacks();
                    user1.InsertStackIntoDB();
                    user1.printstack();
                    content = "5 Boosterpacks sucsessfully bought!";
                    Connection1.Connection.Close();
                    break;

                case "/battledeck": // fertig machen

                    Database Connection2 = new Database();
                    User user2 = Connection2.getUserDatabase(list["username"].ToString(), list["password"].ToString());

                    user2.BuyPacks();
                    user2.CreateStackFromDB();
                    user2.createBattledeck(2);
                    user2.createBattledeck(6);
                    user2.createBattledeck(15);
                    user2.createBattledeck(18);
                    user2.createBattledeck(9);

                    content = "Battledeck wurder erfolgreich erstellt!";
                    Connection2.Connection.Close();
                    break;

                case "/buypacks":

                    Database Connection3 = new Database();
                    User user3 = Connection3.getUserDatabase(list["username"].ToString(), list["password"].ToString());

                    user3.BuyPacks();
                    user3.InsertStackIntoDB();
                    user3.printstack();

                    break;

                case "/fight":

                    Database Connection4 = new Database();
                    Battle Battle = new Battle();
                    User user4 = Connection4.getUserDatabase(list["username"].ToString(), list["password"].ToString());
                    User user5 = Connection4.getUserDatabase(list["username1"].ToString(), list["password1"].ToString());
                    user4.BuyPacks();
                    user4.InsertStackIntoDB();
                    user5.BuyPacks();
                    user5.InsertStackIntoDB();
                    user4.createBattledeck(2);
                    user4.createBattledeck(6);
                    user4.createBattledeck(15);
                    user4.createBattledeck(18);
                    user4.createBattledeck(9);

                    user5.createBattledeck(2);
                    user5.createBattledeck(6);
                    user5.createBattledeck(15);
                    user5.createBattledeck(18);
                    user5.createBattledeck(9);

                    Battle.StartBattle(user4, user5);
                    break;

                case "/score":

                    Database Connection5 = new Database();

                    Connection5.UpdateScoreboard();

                    Connection5.Connection.Close();
                    break;

            }


            

            Console.WriteLine();
            WriteLine(writer, "HTTP/1.1 200 OK");
            WriteLine(writer, "Server: My simple HttpServer");
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
