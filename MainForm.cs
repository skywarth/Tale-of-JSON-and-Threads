﻿using System;
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

namespace task1Mirror
{
    delegate void Proc();
    public delegate void ThreadStart();
    public partial class MainForm : Form
    {
        //Thread connectionThread;
        public MainForm()
        {
            InitializeComponent();
            //ThreadController.ConnectionThread = new Thread(MakeConnection);
            InitializeThreads();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainClass.PrepareClass();


            //ThreadController.UIThread.Start();
        }



        

        //**************************************************************************************************************



       /* private void MakeConnection(Settings s)
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
                
                    Connection.StartClient(s);
                    info = "success";
                }
                catch(Exception ex){
                    info = ex.ToString();
                }
                finally{
                    MessageBox.Show(info);
                }
            
        }*/

        /*private void saveSettings()
        {
           bool serializeStatus = JsonCom.SerializeJSON(Settings.GetSettingFields(textBox1, textBox2, checkBox1));
            if (serializeStatus)
            {
            }
            else
            {
                throw new Exception("Error occured");
            }
        }*/

        

        

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


            //InitializeThreads();
            //ThreadController.ConnectionThread.Start();


            /*Communication.MakeConnection();
            Communication.PopulateBuffer("testaa");
            Communication.FinalizeBuffer();
            Communication.sendBuffer();
            Communication.ClearBufferHead();*/

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
             * Original
            ThreadController.UIThreadCreate(()=>InterfaceUpdate());
            Settings s= (Settings)JsonCom.DeserializeJSON();
            */



            /*
            ThreadController.UIThreadCreate(() => InterfaceUpdate());
            Settings s = (Settings)JsonCom.DeserializeJSON();

            if (s != null && s.AutoConnect)
            {
                ThreadController.ConnectionThreadCreate(() => MakeConnection(s));
                ThreadController.ConnectionThread.Start();
            }
            else
            {
                ThreadController.ConnectionThreadCreate(() => MakeConnection(Settings.GetSettingFields(textBox1, textBox2, checkBox1)));
            }

            */
            



        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Communication.closeConnection();
        }

        /*  private Settings InterfaceUpdate() {

              Settings currSet = (Settings)JsonCom.DeserializeJSON();
              if (currSet !=null && currSet.AutoConnect)
              {
                  Settings.SetSettingFields(currSet, textBox1, textBox2, checkBox1);
              }
              return currSet;
    }*/
        /* private Settings InterfaceUpdate(Settings s)
         {


             if (s != null && s.AutoConnect)
             {
                 Settings.SetSettingFields(s, textBox1, textBox2, checkBox1);
             }
             return s;
    }*/


    }
}
