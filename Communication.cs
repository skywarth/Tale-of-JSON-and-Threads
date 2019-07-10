
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AwesomeSockets;
using AwesomeSockets.Buffers;
using AwesomeSockets.Domain;
using AwesomeSockets.Domain.Sockets;
using AwesomeSockets.Sockets;
using Buffer = AwesomeSockets.Buffers.Buffer;

namespace task1Mirror
{
    public class Communication
    {

        static Buffer inBuf = Buffer.New();
        static Buffer outBuf = Buffer.New();
        static ISocket server;
        static ISocket listenSocket = AweSock.TcpListen(139);
        public static bool connectionStatus = false;
        public static bool listenStatus = false;
        


        public static int debugCounter=0;
        public static _result ConnectTCP()
        {
            //server = AweSock.TcpConnect(Settings.DynamicStt.MsStt.Tcp_Ip, Settings.DynamicStt.MsStt.Port);
            _result rslt = new _result();
            try
            {
                
                server = AweSock.TcpConnect("192.168.1.181", 23);
                rslt.Succes = true;
                connectionStatus = true;
            }
            
            
            catch (Exception ex)
            {
                rslt.Succes = false;
                rslt.Message = ex.ToString();
                connectionStatus = false;
            }
            return rslt;

        }
        public static _result ListenTCP()
        {
            _result rslt = new _result();
            try
            {
                AweSock.TcpAccept(listenSocket, SocketCommunicationTypes.NonBlocking, (listenSocket, error) => { return null; });
                rslt.Succes = true;
                listenStatus = true;
            }
            catch(Exception ex)
            {
                rslt.Succes = false;
                rslt.Message = ex.ToString();
                listenStatus = false;
            }
            return rslt;
        }
        public static void PopulateBuffer()
        {
           
            Buffer.Add(outBuf, "testttsend");
        }
        public static void FinalizeBuffer()
        {

            Buffer.FinalizeBuffer(outBuf);
        }

        public static void ClearBufferHead()
        {
            Buffer.ClearBuffer(outBuf);
            
            
        }

        public static int SendBuffer()
        {
            
            
            int bytesSent = AweSock.SendMessage(server, outBuf);
            
            return bytesSent;
        }

        public static _result ReceiveMessage()
        {
            _result rslt = new _result();
            System.Tuple<int, System.Net.EndPoint> received = AweSock.ReceiveMessage(server, inBuf);
            if (received != null)
            {
                rslt.Succes = true;
                rslt.Message = received.Item1.ToString() + received.Item2.ToString();
            }
            else
            {
                rslt.Succes = false;
            }
            return rslt;
        }
        public static void closeConnection()
        {
            AweSock.CloseSock(server);
            connectionStatus = false;
        }

        public class _result
        {
            public bool Succes = false;
            public string Message = "";
            public object Nesne = new object();

            public _result Copy()
            {
                _result other = (_result)this.MemberwiseClone();
                return other;
            }
        }
    }


}
