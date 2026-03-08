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
            const string ip = "127.0.0.1";
            const int port = 8080;

            var endPointTCP = new IPEndPoint(IPAddress.Parse(ip), port);
            var socketTCP = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            Console.WriteLine(@"Введіть варіант(1: повернути дату, 2: повернути час, 0: закрити з'єднання): ");
            string answer = Console.ReadLine();

            var data = Encoding.UTF8.GetBytes(answer);
            socketTCP.Connect(endPointTCP);
            socketTCP.Send(data);

            var buffer = new byte[256];
            var size = 0;
            var answerFromServer = new StringBuilder();

            do
            {
                size = socketTCP.Receive(buffer);
                answerFromServer.Append(Encoding.UTF8.GetString(buffer, 0, size));

            } while (socketTCP.Available > 0);

            Console.WriteLine(answerFromServer);

            socketTCP.Shutdown(SocketShutdown.Both);
            socketTCP.Close();

        }
    }
}
