using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    class JsonCom
    {
        /*public void LoadJson()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                List<Settings> items = JsonConvert.DeserializeObject<List<Settings>>(json);
            }
        }*/
        private string SerializeObject(Settings o)
        {
            string jsonText="";
            if (o.GetType() == typeof(Settings)){
                MessageBox.Show("test");
                jsonText = JsonConvert.SerializeObject(o, Formatting.Indented);
            }
            else
            {
                jsonText = null;
            }
            return jsonText;
        }

        public bool SerializeJSON(Settings o)
        {
            bool status=false;
            JsonSerializer serializer = new JsonSerializer();
            string jsonText=SerializeObject(o);
            if (String.IsNullOrEmpty(jsonText))
            {
                status = false;
                
            }
            else
            {
                try
                {
                    using (StreamWriter file = File.CreateText(o.FilePath))
                    {

                        serializer.Serialize(file, jsonText);
                        status = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    status = false;
                    MessageBox.Show(ex.ToString());
                }
            }
            return status;
        }

        public Settings DeserializeJSON()
        {

        }

    }
}
