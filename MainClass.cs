using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task1
{
    public class MainClass
    {

        public class _SystemStartUp
        {
            public Settings._result DynamicSettingsGet = new Settings._result();



        }

        public class _SystemStatus
        {
            public _SystemStartUp SystemStartUp = new _SystemStartUp();

           
          

        }
        public static _SystemStatus SystemStatus = new _SystemStatus();


        #region Objects

        public static Connection Con_ = new Connection();


        #endregion








        public static void PrepareClass()
        {
            // Dynamic ayarlari cekiyorum.
            SystemStatus.SystemStartUp.DynamicSettingsGet = Settings.GetDynamicSettings();
                       

            // MainControl'u calistiriyorum.
            Th_MainControl = new Thread(MainControl);
            Th_MainControl.Start();
            
        }

        //*******************************************************************************************************
        //*******************************************************************************************************
        //*******************************************************************************************************

        #region Main Control

        static Thread Th_MainControl;
        static int MainControlInterval = 250;
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



        #endregion

        //*******************************************************************************************************
        //*******************************************************************************************************
        //*******************************************************************************************************






    }
}
