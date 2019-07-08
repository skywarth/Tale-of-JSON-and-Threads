using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    public class Settings
    {
        

        public class _MsStt
        {
            private string Tcp_Ip { get; set; } = "0.0.0.0";
            private string _IP;
            private string _Port;
            private bool _autoConnect;

            private static string filePath = @"..\settings.json";
        }


        public class _DynamicStt
        {
            public _MsStt MsStt = new _MsStt();
        }
        public static _DynamicStt DynamicStt = new _DynamicStt();

        

        /// <summary>
        /// 
        /// </summary>
        public static _result SaveDynamicSettings()
        {
            _result rslt = new _result();

            try
            {
                string json = JsonConvert.SerializeObject(DynamicStt);
                File.WriteAllText("Settings.settings", json);
                rslt.Succes = true;
            }
            catch (Exception ex)
            {
                rslt.Message = ex.Message;
            }

            return rslt;
        }


        public static _result GetDynamicSettings()
        {
            _result rslt = new _result();

            try
            {
                if(File.Exists("Settings.settings"))
                {
                    string json = File.ReadAllText("Settings.setting");
                    DynamicStt = JsonConvert.DeserializeObject<_DynamicStt>(json);
                    rslt.Succes = true;
                }
                else
                {
                    rslt.Message = "Dosya yok.";
                }

            }
            catch (Exception ex)
            {
                rslt.Message = ex.Message;               
            }

            return rslt;
        }






        /*public string Ip { get => _IP; set => _IP = value; }
        public string Port { get => _Port; set => _Port = value; }
        public bool AutoConnect { get => autoConnect; set => autoConnect = value; }
        public static string FilePath { get => filePath; set => filePath = value; }*/

        /*public Settings(string ip, string port, bool autoConnect)
        {
            Ip = ip;
            Port = port;
            AutoConnect = autoConnect;
        }
        */
        /*
                //Might migrate the methods to UIController after this
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
                */

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


        //////////////////////////////////////////

        



    }
    


}
