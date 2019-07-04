using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    class Connection
    {
        //System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        public void ExecuteClientSocket(Settings s)
        {
            //clientSocket.Connect("127.0.0.1", 8888);


            /*IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 11111);

            Socket sender = new Socket(ipAddr.AddressFamily,
                   SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(localEndPoint);*/




            //IPEndPoint remoteEP = new IPEndPoint(long.Parse(s.Ip), int.Parse(s.Port));
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(s.Ip),int.Parse(s.Port));
            MessageBox.Show(remoteEP.ToString());
            /*Socket client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);*/
        }
    }
}
