using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using System.Threading;




namespace task1
{
    delegate void Proc();
    public delegate void ThreadStart();
    public partial class Form1 : Form
    {
        Thread connectionThread;
        public Form1()
        {
            InitializeComponent();
            connectionThread = new Thread(MakeConnection);

        }

        private void Label1_Click(object sender, EventArgs e)
        {
            /**/
        }

        private void MakeConnection()
        {
            if (checkBox1.Checked)
            {


                autoConnect();
            }
                string info=null;
                try{
                    AsynchronousClient.StartClient();
                    info = "success";
                }
                catch(Exception ex){
                    info = ex.ToString();
                }
                finally{
                    MessageBox.Show(info);
                }
                
            
            
            
        }

        private void autoConnect()
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
             
            connectionThread.Start();
            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeThreads();

        }
        private void InitializeThreads()
        {
            


            Thread UIThread = new Thread(InterfaceUpdate);
            UIThread.IsBackground = true;
            UIThread.Start();



        }

        private void InterfaceUpdate() {
            Settings currSet = (Settings)JsonCom.DeserializeJSON();
            if (currSet.AutoConnect)
            {
                Settings.SetSettingFields(currSet, textBox1, textBox2, checkBox1);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            AsynchronousClient.StartClient();
            /*Connection con = new Connection();
            con.ExecuteClientSocket(Settings.GetSettingFields(textBox1,textBox2,checkBox1));*/
        }
    }
}
