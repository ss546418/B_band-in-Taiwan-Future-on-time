using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using JDWLSHKQuoteOBJLib;

namespace simulate_tradingAPI_BBand
{
    public partial class Form1 : Form
    {
        JDWLSHKQuoteOBJLib.ApplicationJDWLSHKQuote gapp = null;
        JDWLSHKQuoteOBJLib.ApplicationJDWLSHKQuote gapp1 = null;

        bool bOn;

        string[] comp1 = new string[] { "4", "9" };
        string[] comp2 = new string[] { "5", "0" };

        public Form1()
        {
            InitializeComponent();
        }

        private void button_rec_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gapp = new JDWLSHKQuoteOBJLib.ApplicationJDWLSHKQuote();
            gapp.Init();
            gapp1 = new JDWLSHKQuoteOBJLib.ApplicationJDWLSHKQuote();
            gapp1.Init();

            gapp.AddSymbols("FITX06.TF");
            gapp.OnSymbolTick += new JDWLSHKQuoteOBJLib.IJDWLSHKQuoteNotify_OnSymbolTickEventHandler(handle_price);
            gapp.OnSystemStatus += new JDWLSHKQuoteOBJLib.IJDWLSHKQuoteNotify_OnSystemStatusEventHandler(handle_statue);
            bOn = gapp.GetSystemStatus();
            BeginInvoke((MethodInvoker)delegate
            {
                DisplayLog(listBox1, "連線狀態為" + bOn + DateTime.Now);
            });
        }
        void handle_price(string symbolID, object val)
        {

        }
        void handle_position(string symbolID, object val)
        {
        }
        void handle_statue(bool On)
        {
            BeginInvoke((MethodInvoker)delegate
            {
                DisplayLog(listBox1, "連線狀態改變為" + bOn+ DateTime.Now);
            });
        }
        void DisplayLog(ListBox listbox, string strMsg)
        {
            listbox.Items.Add(strMsg);
            listbox.SelectedIndex = listbox.Items.Count - 1;
        }




    }
}
