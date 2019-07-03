using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Settings
    {
        private string ip;
        private string port;
        private bool autoConnect;

        public string Ip { get => ip; set => ip = value; }
        public string Port { get => port; set => port = value; }
        public bool AutoConnect { get => autoConnect; set => autoConnect = value; }

        public Settings(string ip, string port, bool autoConnect)
        {
            Ip = ip;
            Port = port;
            AutoConnect = autoConnect;
        }
    }
    
    
}
