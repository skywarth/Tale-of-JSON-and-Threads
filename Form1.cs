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
        JsonCom j = new JsonCom();
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            /**/
        }

        private void MakeConnection()
        {
            
            bool serializeStatus=JsonCom.SerializeJSON(Settings.GetSettingFields(textBox1,textBox2,checkBox1));
            if (serializeStatus)
            {
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("Error");
            }
            
        }

        

        private void Button2_Click(object sender, EventArgs e)
        {
            /**/
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Proc demoProc = new Proc(MakeConnection);
            demoProc();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //loadCheck();
            InitializeThreads();

        }
        private void InitializeThreads()
        {

            Thread k=ThreadController.UIThreadCreate(InterfaceUpdate);

        }
        private void loadCheck()
        {
            /*Settings currSet = (Settings)j.DeserializeJSON();
            if (currSet.AutoConnect)
            {
                Settings.SetSettingFields(currSet,textBox1,textBox2,checkBox1);
            }*/
            
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
