using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task1
{
    class UIController
    {
        private void InitializeThreads(TextBox t1,TextBox t2, TextBox t3)
        {


            StackTrace stackTrace = new StackTrace();
            Debug.WriteLine("Form1 initializeThreads called by " + stackTrace.GetFrame(1).GetMethod().Name);
            /*Thread UIThread = new Thread(InterfaceUpdate);
            UIThread.IsBackground = true;
            UIThread.Start();*/

            //PROBLEM
            /*
             * Original
            ThreadController.UIThreadCreate(()=>InterfaceUpdate());
            Settings s= (Settings)JsonCom.DeserializeJSON();
            */

            ThreadController.UIThreadCreate(() => InterfaceUpdate());
            Settings s = (Settings)JsonCom.DeserializeJSON();

            if (s != null && s.AutoConnect)
            {
                ThreadController.ConnectionThreadCreate(() => MakeConnection(s));
                ThreadController.ConnectionThread.Start();
            }
            else
            {
                ThreadController.ConnectionThreadCreate(() => MakeConnection(Settings.GetSettingFields(t1, t2, t3)));
            }






        }
        private Settings InterfaceUpdate()
        {

            Settings currSet = (Settings)JsonCom.DeserializeJSON();
            if (currSet != null && currSet.AutoConnect)
            {
                Settings.SetSettingFields(currSet, textBox1, textBox2, checkBox1);
            }
            return currSet;
        }
        private Settings InterfaceUpdate(Settings s)
        {


            if (s != null && s.AutoConnect)
            {
                Settings.SetSettingFields(s, textBox1, textBox2, checkBox1);
            }
            return s;
        }
        private void MakeConnection(Settings s)
        {
            try
            {
                saveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            string info = null;
            try
            {

                Connection.StartClient(s);
                info = "success";
            }
            catch (Exception ex)
            {
                info = ex.ToString();
            }
            finally
            {
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
    }
}
