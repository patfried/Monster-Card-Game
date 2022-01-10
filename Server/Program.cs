using System;

namespace Monster_Card_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple HTTP-Server!");
            Console.CancelKeyPress += (sender, e) => Environment.Exit(0);

            new HttpServer(8080).Run();
        }
    }
}
