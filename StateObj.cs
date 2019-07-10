using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace task1Mirror
{
    // State object for receiving data from remote device.  
    public class StateObject
    {
        // Client socket.  
        private Socket workSocket;
        // Size of receive buffer.  
        private const int BufferSize = 256;
        // Receive buffer.  
        private byte[] buffer = new byte[BufferSize1];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();

        public Socket WorkSocket { get => workSocket; set => workSocket = value; }
        public byte[] Buffer { get => buffer; set => buffer = value; }

        public static int BufferSize1 => BufferSize2;

        public static int BufferSize2 => BufferSize;
    }
}
