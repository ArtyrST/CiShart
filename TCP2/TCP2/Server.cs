using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP2
{
    internal class Program
    {
        static void ReturnDate(Socket listener)
        {
            Console.WriteLine("Returning date...");
            listener.Send(Encoding.UTF8.GetBytes(DateTime.Now.ToString("dd.MM.yyyy")));
        }
        static void ReturnTime(Socket listener)
        {
            Console.WriteLine("Returning time...");
            listener.Send(Encoding.UTF8.GetBytes(DateTime.Now.ToString("HH:mm:ss")));
        }
        static void ReturnError(Socket listener)
        {
            Console.WriteLine("Invalid number from client...");
            listener.Send(Encoding.UTF8.GetBytes("Invalid number..."));
        }
        static void Main(string[] args)
        {
            //const string ip = "192.168.1.2";
            const int port = 50000;

            var endPointTCP = new IPEndPoint(IPAddress.Parse("192.168.101.103"), port);
            var socketTCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketTCP.Bind(endPointTCP);
            socketTCP.Listen(2);
            while (true)
            {
                var listener = socketTCP.Accept();
                var buffer = new byte[1024];
                int size = 0;
                var data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));

                } while (listener.Available > 0);

                if (data.Equals("1"))
                {
                    ReturnDate(listener);
                }
                else if (data.Equals("2"))
                {
                    ReturnTime(listener);
                }
                else if (data.Equals("0"))
                {
                    {
                        listener.Send(Encoding.UTF8.GetBytes("Done!"));
                        listener.Shutdown(SocketShutdown.Both);
                        listener.Close();
                        
                    }
                }
                else
                {
                    ReturnError(listener);
                    
                }
            }
        }
    }
}
