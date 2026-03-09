using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string ip = "192.168.101.103";
            const int port = 50000;
            //var endPointTCP = new IPEndPoint(IPAddress.Parse(ip), port);
            //var socketTCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


            //var data = Encoding.UTF8.GetBytes(answer);
            //socketTCP.Send(data);

            var buffer = new byte[256];
            var size = 0;
            var answerFromServer = new StringBuilder();
            while (true)
            {
                var endPointTCP = new IPEndPoint(IPAddress.Parse(ip), port);
                var socketTCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Console.WriteLine(@"Введіть варіант(1: повернути дату, 2: повернути час, 0: закрити з'єднання): ");
                string answer = Console.ReadLine();
                socketTCP.Connect(endPointTCP);
                var data = Encoding.UTF8.GetBytes(answer);
                socketTCP.Send(data);

                do
                {
                    size = socketTCP.Receive(buffer);
                    answerFromServer.Append(Encoding.UTF8.GetString(buffer, 0, size));

                } while (socketTCP.Available > 0);

                Console.WriteLine(answerFromServer);
                if (answer == "0")
                {
                    break;
                }
                answerFromServer = new StringBuilder();
                socketTCP.Shutdown(SocketShutdown.Both);
                socketTCP.Close();
            }

        }
    }
}
