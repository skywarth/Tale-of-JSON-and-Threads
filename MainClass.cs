using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task1Mirror
{
    public class MainClass
    {

        public class _SystemStartUp
        {
            public Settings._result DynamicSettingsGet = new Settings._result();


            /**/
            public Communication._result commStatus = new Communication._result();


        }

        public class _SystemStatus
        {
            public _SystemStartUp SystemStartUp = new _SystemStartUp();
            
            
            

        }
        public static _SystemStatus SystemStatus = new _SystemStatus();


        #region Objects

        //public static Connection Con_ = new Connection();//original

        //public static Communication Con_ = new Communication();

        #endregion








        public static void PrepareClass()
        {
            // Dynamic ayarlari cekiyorum.
            SystemStatus.SystemStartUp.DynamicSettingsGet = Settings.GetDynamicSettings();
                       

            // MainControl'u calistiriyorum.
            Th_MainControl = new Thread(MainControl);
            Th_MainControl.Start();
            /**/
            Th_MainControl2 = new Thread(MainControl2);
            Th_MainControl2.Start();
        }

        //*******************************************************************************************************
        //*******************************************************************************************************
        //*******************************************************************************************************

        #region Main Control

        static Thread Th_MainControl;
        static int MainControlInterval = 250;
        /**/
        static Thread Th_MainControl2;
        static int MainControl2Interval = 1000;
        /// <summary>
        /// MainClass'ta nesne kontrollerini saglar. Th_MainControl Thread'i icinde calisir.
        /// </summary>
        static void MainControl()
        {
            while(true)
            {
                try
                {
                    if(Settings.DynamicStt.MsStt.AutoConnect)
                    { 
                        //if(!SystemStatus.)
                        //{
                        //    Con_.ConnectToMS();
                        //}
                    }






                }
                catch (Exception)
                {                    
                }

                Thread.Sleep(MainControlInterval);
            }


        }
        static void MainControl2()
        {
            while (true)
            {
                try
                {
                    if(!Communication.connectionStatus)
                    {
                        Communication.ConnectTCP();
                        
                    }
                    if (!Communication.listenStatus)
                    {
                        Communication.ListenTCP();
                        

                    }
                    //Communication.ReceiveMessage();
                    //apply async for receive 
                    Communication.ClearBufferHead();
                    

                    Communication.PopulateBuffer();
                    Communication.FinalizeBuffer();
                    Communication.SendBuffer();
                    






                }
                catch (Exception)
                {
                }

                Thread.Sleep(MainControl2Interval);
            }


        }


        #endregion

        //*******************************************************************************************************
        //*******************************************************************************************************
        //*******************************************************************************************************






    }
}
