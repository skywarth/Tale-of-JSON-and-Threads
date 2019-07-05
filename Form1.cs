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
using System.Diagnostics;

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
            /*if (ThreadController.ConnectionThread.IsAlive)
            {
                Debug.WriteLine("thread alive");
            }
            else
            {
                InitializeThreads();
                Debug.WriteLine("Re initiate thread");
            }*/


            InitializeThreads();
            ThreadController.ConnectionThread.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadController.UIThread.Start();
        }
        private void InitializeThreads()
        {


            StackTrace stackTrace = new StackTrace();
            Debug.WriteLine("Form1 initializeThreads called by " + stackTrace.GetFrame(1).GetMethod().Name);
            /*Thread UIThread = new Thread(InterfaceUpdate);
            UIThread.IsBackground = true;
            UIThread.Start();*/

            //PROBLEM
            /*
             * ORIGINAL
            ThreadController.UIThreadCreate(()=>InterfaceUpdate());
            Settings s= (Settings)JsonCom.DeserializeJSON();
            */
            ThreadController.UIThreadCreate(() => InterfaceUpdate());
            ThreadController.JSONDeserThreadCreate(()=>ThreadController.JSONDeserLocker());
            Settings s = ThreadController.JSONDeserLocker();

            if (s != null && s.AutoConnect)
            {
                ThreadController.ConnectionThreadCreate(() => MakeConnection(s));
                ThreadController.ConnectionThread.Start();
            }
            else
            {
                ThreadController.ConnectionThreadCreate(() => MakeConnection(Settings.GetSettingFields(textBox1, textBox2, checkBox1)));
            }

            
            



        }

        private Settings InterfaceUpdate() {

            Settings currSet = ThreadController.JSONDeserLocker();
            if (currSet !=null && currSet.AutoConnect)
            {
                Settings.SetSettingFields(currSet, textBox1, textBox2, checkBox1);
            }
            return currSet;
        }

        
    }
}
