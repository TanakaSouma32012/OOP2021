using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1 {
    public partial class Form1 : Form {
        static DateTime today = DateTime.Now;
        public Form1() {
            InitializeComponent();
        }

        private void btToday_Click(object sender, EventArgs e) {
            today = DateTime.Now;
            
            tbDateDisp.Text = string.Format("{0:yyyy/M/d HH:mm}", today) + "\r\n";
            tbDateDisp.Text += today.ToString("yyyy年MM月dd日　HH時mm分ss秒") + "\r\n";

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            var dayOfWeek = culture.DateTimeFormat.GetDayName(today.DayOfWeek);
            
            tbDateDisp.Text += today.ToString("ggyy年 M月 d日("+ dayOfWeek +")", culture);
            //tbDateDisp.Text = today.ToString("d");
        }

        private void Form1_Load(object sender, EventArgs e) {                       
            tm.Interval = 1000;
            tm.Enabled = true;
            tm.Tick += Tm_Tick;
            tm.Start();

            tSSTimeLabel.Text = DateTime.Now.ToString();
            
        }
        //タイマーが切れたときに呼ばれるイベントハンドラ
        private void Tm_Tick(object sender, EventArgs e) {
            tSSTimeLabel.Text = DateTime.Now.ToString();

        }
    }
}
