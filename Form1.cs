using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;
//
using System.Threading;




namespace task1
{
    delegate void Proc();
    public delegate void ThreadStart();
    public partial class Form1 : Form
    {
        //Thread connectionThread;
        public Form1()
        {
            InitializeComponent();
            //ThreadController.ConnectionThread = new Thread(MakeConnection);
            InitializeThreads();
            

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            /**/
        }

        private void MakeConnection(Settings s)
        {
              try
                {
                    saveSettings();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
            
                string info=null;
                try{
                    AsynchronousClient.StartClient(s);
                    info = "success";
                }
                catch(Exception ex){
                    info = ex.ToString();
                }
                finally{
                    MessageBox.Show(info);
                }
            



        }

        private void saveSettings()
        {
           bool serializeStatus = JsonCom.SerializeJSON(Settings.GetSettingFields(textBox1, textBox2, checkBox1));
            if (serializeStatus)
            {
            }
            else
            {
                throw new Exception("Error occured");
            }
        }

        

        

        private void Button1_Click(object sender, EventArgs e)
        {
            if (ThreadController.ConnectionThread.IsAlive)
            {
                
            }
            else
            {
                InitializeThreads();
            }
            ThreadController.ConnectionThread.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadController.UIThread.Start();
        }
        private void InitializeThreads()
        {



            /*Thread UIThread = new Thread(InterfaceUpdate);
            UIThread.IsBackground = true;
            UIThread.Start();*/
            ThreadController.UIThreadCreate(()=>InterfaceUpdate());
            Settings s= (Settings)JsonCom.DeserializeJSON();
            ThreadController.ConnectionThreadCreate(()=>MakeConnection(s));

        }

        private Settings InterfaceUpdate() {
            Settings currSet = (Settings)JsonCom.DeserializeJSON();
            if (currSet.AutoConnect)
            {
                Settings.SetSettingFields(currSet, textBox1, textBox2, checkBox1);
            }
            return currSet;
        }

        
    }
}
