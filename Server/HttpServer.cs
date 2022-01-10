using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Monster_Card_Game
{
    class HttpServer
    {
        protected int port;
        TcpListener listener;

        public HttpServer(int port)
        {
            this.port = port;
        }

        public void Run()
        {
            listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();
            while (true)
            {
                TcpClient s = listener.AcceptTcpClient();
                HttpProcessor processor = new HttpProcessor(s, this);
                new Thread(processor.Process).Start();
                
            }
        }
    }
}
