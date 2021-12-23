using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;


// Eingabe vom Client empfangen und parsen
// je nach eingabe wird dann eine Funktion aufgerufen z.b Login
//

namespace MonsterServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is running...");
            TcpListener listener = new TcpListener(IPAddress.Loopback, 8000);
            listener.Start(5);

            while (true)
            {
                try
                {

                    new Task(() =>
                    {
                        TcpClient clientSocket = listener.AcceptTcpClient();
                        var writer = new StreamWriter(clientSocket.GetStream());
                        var reader = new StreamReader(clientSocket.GetStream());

                        writer.WriteLine("Welcome to my Server");
                        writer.WriteLine("Please enter your commands....");
                        writer.Flush();
                        string message;
                        do
                        {
                            message = reader.ReadLine();
                            Console.WriteLine("recived: " + message);
                        } while (message != "quit");
                    }).Start();
                }

                catch (Exception e)
                {
                    Console.WriteLine($"error occured: {e.Message}");
                }
            }
        }
    }
}
