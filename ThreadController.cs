using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Threading;


    class ThreadController
    {
        
        public static Thread UIThreadCreate(ParameterizedThreadStart t)
        {
        Thread UIThread = new Thread(() => t);
            UIThread.IsBackground = true;
            return UIThread;
        }


   }

