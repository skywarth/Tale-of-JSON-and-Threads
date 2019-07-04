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
        
       /* private string SerializeObject(Object o)
        {
            string jsonText="";
            if (o.GetType() == typeof(Settings)){
                MessageBox.Show("test");
                jsonText = JsonConvert.SerializeObject(o, Formatting.None);
            }
            else
            {
                jsonText = null;
            }
            return jsonText;
        }
        */
        
        public static bool SerializeJSON(Object o)
        {
            bool status = false;
            try
            {
                using (StreamWriter file = File.CreateText(Settings.FilePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, o);
                    status = true;
                }
            }catch(Exception ex)
            {
                status= false;
                MessageBox.Show(ex.ToString());

            }
            return status;

            
        }


            public static object DeserializeJSON()
        {
            using (StreamReader file = File.OpenText(Settings.FilePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                Settings s= (Settings)serializer.Deserialize(file, typeof(Settings)); 
                return s;
            }
            
        }

    }
}
