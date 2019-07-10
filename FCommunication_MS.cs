using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task1Mirror
{
    public class FCommunication_MS
    {


        #region Communication

        #region Object

        public class ComTitles
        {
            public const byte Head = 0xFF;
            public const byte End = 0xFE;
            public const byte Isolator = 0xFD;
            public const byte PacketIsolator = 0xFC;



        }

        /**/
          
        

        /**/


        TcpClient client;
        NetworkStream stream;

        Thread Th_Listener;

        #endregion




        #region OutPuts


        #endregion


        #region Public etods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public async Task<Settings._result> ConnectToServer(string ip, int port)
        {
            Settings._result rslt = new Settings._result();
            rslt.Succes = false;


            Task task = Task.Factory.StartNew(() =>
            {
                try
                {
                    bool ok = false;

                    if(client == null)
                    {
                        ok = true;
                    }
                    else
                    {
                        if(client.Connected)
                        {
                            rslt.Message = "Zaten vljkdfnfbv";
                        }
                        else
                        {
                            ok = true;
                        }
                    }

                    if(ok)
                    {
                        client = new TcpClient(ip, port);
                        stream = client.GetStream();

                        Th_Listener = new Thread(Listener);
                        Th_Listener.Start();

                        rslt.Succes = true;
                        rslt.Message = "baglandı";
                    }
                }
                catch (Exception ex)
                {
                    rslt.Message = ex.Message;
                }
            });
            await task;

            return rslt;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisConnectToServer()
        {
            Settings._result rslt = new Settings._result();
            rslt.Succes = false;

            try
            {
                if(client != null)
                {
                    client.Close();
                }

                rslt.Succes = true;
                rslt.Message = "Bağlantı koparıldı";
            }
            catch (Exception ex)
            {
                rslt.Message = ex.Message;
            }
        }

        #endregion


        #region Private Metods

        #region Rev
        void Listener()
        {
            int adet;// Gelen paketinm boyutu
            byte[] bytes = new byte[10000]; // Gelen pakletin yazildigi dizi.

            try
            {
                while ((adet = stream.Read(bytes , 0, bytes.Length)) != 0)
                {
                    try
                    {
                        byte[] data = new byte[adet];
                        Array.Copy(bytes, data, adet);
                        CheckRevSyntax(data);                                           
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception)
            {
            }

            client.Close();
        }
        /**/
        public static byte ComputeAdditionChecksum(byte[] data)
        {
            long longSum = data.Sum(x => (long)x);//long overflow engellemek için (uzun bir streamde)
            return unchecked((byte)longSum);
        }
        /**/
        void CheckRevSyntax(byte[] data)
        {
            /**/
            int adet = stream.Read(data, 0, data.Length);
            
            int iterator = 0;
            int size = data.Length+1;//increment for correct size, since .length gives 3 for a 4 element array.
            int infactCounter = 0;
            Settings._result rslt = new Settings._result();

            Type type = typeof(ComTitles);
            int NumberOfConst = type.GetProperties().Length;

            byte[] InfactData = new byte[size-NumberOfConst];

            try
            {
                /*for (iterator = 0; iterator < adet; iterator++)
                {
                    if(iterator)

                }*/

                /*if (iterator == 0)
                {
                    
                }*/

                if (data[0] == ComTitles.Head)// first head check
                {
                    if (data[1] == (byte)(size - NumberOfConst))//infact data size check
                    {
                        if (data[2] == ComTitles.Head)// second head check
                        {
                            if (data[size - 1] == ComTitles.End)//end check
                            {
                               /* For extracting infact */
                                Array.Copy(data, 3, InfactData, 0, (size - NumberOfConst));
                                byte checkSum = ComputeAdditionChecksum(InfactData);
                                if (data[size - 2] == checkSum)
                                {

                                }

                            }
                        }
                    }
                }


            }
            catch (Exception ex)
            {

                rslt.Succes = false;
                rslt.Message = ex.ToString();
            }

            /**/
        }

        #endregion


        #region Send

        #endregion




        #endregion







        #endregion





        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************












    }
}
