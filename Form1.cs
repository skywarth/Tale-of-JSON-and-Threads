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
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }

        private void MakeConnection()
        {
            JsonCom j1 = new JsonCom();
            j1.SerializeJSON(GetSettingFields());

            
        }

        private Settings GetSettingFields()
        {
            Settings s = new Settings(textBox1.Text, textBox2.Text, checkBox1.Checked);
            
            MessageBox.Show(s.Ip+" "+s.Port+" "+s.AutoConnect);
            return s;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Proc demoProc = new Proc(MakeConnection);
            demoProc();
        }
    }
}
