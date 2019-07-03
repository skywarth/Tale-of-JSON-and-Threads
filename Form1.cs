using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace task1
{
    delegate void Proc();
    public partial class Form1 : Form
    {
        JsonCom j = new JsonCom();
        public Form1()
        {
            InitializeComponent();
            
            Settings currSet=(Settings)j.DeserializeJSON();
            if (currSet.AutoConnect)
            {

            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void MakeConnection()
        {
            
            bool serializeStatus=j.SerializeJSON(GetSettingFields());
            if (serializeStatus)
            {
                MessageBox.Show("success");
            }
            else
            {
                MessageBox.Show("Error");
            }
            
        }

        private Settings GetSettingFields()
        {
            Settings s = new Settings(textBox1.Text, textBox2.Text, checkBox1.Checked);
            
            //MessageBox.Show(s.Ip+" "+s.Port+" "+s.AutoConnect);
            return s;
        }
        private void SetSettingFields(Settings s)
        {
            textBox1.Text = s.Ip;
            textBox2.Text = s.Port;
            checkBox1.Checked = s.AutoConnect;

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            
            j.DeserializeJSON();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Proc demoProc = new Proc(MakeConnection);
            demoProc();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
