using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    class Settings
    {
        private string ip;
        private string port;
        private bool autoConnect;

        private static string filePath = @"..\settings.json";

        public string Ip { get => ip; set => ip = value; }
        public string Port { get => port; set => port = value; }
        public bool AutoConnect { get => autoConnect; set => autoConnect = value; }
        public static string FilePath { get => filePath; set => filePath = value; }

        public Settings(string ip, string port, bool autoConnect)
        {
            Ip = ip;
            Port = port;
            AutoConnect = autoConnect;
        }

        public static Settings GetSettingFields(TextBox t1, TextBox t2, CheckBox cb1)
        {
            Settings s = new Settings(t1.Text, t2.Text, cb1.Checked);

            //MessageBox.Show(s.Ip+" "+s.Port+" "+s.AutoConnect);
            return s;
        }
        public static void SetSettingFields(Settings s, TextBox t1, TextBox t2, CheckBox cb1)
        {
            t1.Text = s.Ip;
            t2.Text = s.Port;
            cb1.Checked = s.AutoConnect;

        }
    }
    


}
