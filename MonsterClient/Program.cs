using System;
using System.IO;
using System.Net.Sockets;

namespace MonsterClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("localhost", 8000);

            var writer = new StreamWriter(clientSocket.GetStream());
            var reader = new StreamReader(clientSocket.GetStream());
            Console.WriteLine(reader.ReadLine());
            Console.WriteLine(reader.ReadLine());

            string input = null;
            while ((input = Console.ReadLine()) != "quit")
            {
                writer.WriteLine(input);
                writer.Flush();
            }
            writer.WriteLine("quit");
        }
    }
}
