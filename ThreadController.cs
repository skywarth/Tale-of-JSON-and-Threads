using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using task1;

class ThreadController
    {
        private static Thread _connectionThread;
        private static Thread _UIThread;
        private static Thread _JSONDeserThread;
         public static Thread ConnectionThread { get => _connectionThread;}
         //private static Thread UIThread { get => _UIThread; set => _UIThread = value; }
        public static Thread UIThread { get => _UIThread;}
    public static Thread JSONDeserThread { get => _JSONDeserThread; set => _JSONDeserThread = value; }

    public static Thread UIThreadCreate(System.Threading.ThreadStart t)
        {
                _UIThread = new Thread(t);
                _UIThread.IsBackground = true;
                Debug.WriteLine("UIThread has been created");
                return _UIThread;
        }
        public static Thread ConnectionThreadCreate(System.Threading.ThreadStart t)
        {
            _connectionThread = new Thread(t);
            _connectionThread.IsBackground = true;
        Debug.WriteLine("Connection thread has been created");
        return _connectionThread;
        }


        public static Thread JSONDeserThreadCreate(System.Threading.ThreadStart t)
        {
        _JSONDeserThread = new Thread(t);
        _JSONDeserThread.IsBackground = true;
        Debug.WriteLine("JSONDeserThread thread has been created");
        return JSONDeserThread;
        }


        static ReaderWriterLock locker = new ReaderWriterLock();

        public static Settings JSONDeserLocker()
        {
        Settings s=null;
        try
        {
            locker.AcquireWriterLock(int.MaxValue); //You might wanna change timeout value 
            s = (Settings)JsonCom.DeserializeJSON();
        }
        finally
        {
            locker.ReleaseWriterLock();
           
        }
        return s;
    }



}

