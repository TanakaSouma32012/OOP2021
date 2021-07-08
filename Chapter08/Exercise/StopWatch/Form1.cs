using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch {
    public partial class Form1 : Form {

        Stopwatch sw = new Stopwatch();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            lbTimeDisp.Text = sw.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void btTimeSt_Click(object sender, EventArgs e) {            
            sw.Start();
            tmdisp.Start();
        }

        private void btTimeSp_Click(object sender, EventArgs e) {            
            sw.Stop();
            tmdisp.Stop();
        }
        private void btReset_Click(object sender, EventArgs e) {
            sw.Reset();
            lbTimeDisp.Text = sw.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }
        private void tmdisp_Tick(object sender, EventArgs e) {
            
            lbTimeDisp.Text = sw.Elapsed.ToString(@"hh\:mm\:ss\.ff");
            
        }

        private void tmdisp_Tick_1(object sender, EventArgs e) {
            lbTimeDisp.Text = sw.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        

       
            
        private void btLap_Click(object sender, EventArgs e) {
            lbLapDisp.Items.Insert(0, lbTimeDisp.Text);
            //lbLapDisp.Items.Insert(0, sw.Elapsed.ToString(@"hh\:mm\:ss\.ff"));
        }
    }
}

