using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

class ThreadController
    {
        private static Thread _connectionThread;
        private static Thread _UIThread;
        
         public static Thread ConnectionThread { get => _connectionThread;}
         //private static Thread UIThread { get => _UIThread; set => _UIThread = value; }
        public static Thread UIThread { get => _UIThread;}
        
        public static Thread UIThreadCreate(ThreadStart t)
        {
                _UIThread = new Thread(t);
                _UIThread.IsBackground = true;
                Debug.WriteLine("UIThread has been created");
                return _UIThread;
        }
        public static Thread ConnectionThreadCreate(ThreadStart t)
        {
            _connectionThread = new Thread(t);
            _connectionThread.IsBackground = true;
        Debug.WriteLine("Connection thread has been created");
        return _connectionThread;
        }
        
        
        
}

