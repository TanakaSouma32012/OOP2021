using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise3 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            inputStrText.Text = "Jackdaws love my big sphinx of quartz";
            inputStrText5_4.Text = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
        }

        private void Button5_3_1_Click(object sender, EventArgs e) {
            TextBoxSpaceCount.Text = inputStrText.Text.Count(c => c == ' ').ToString();
        }

        private void button5_3_2_Click(object sender, EventArgs e) {
            Big_Smoll.Text = inputStrText.Text.Replace("big","small");
        }

        private void button5_3_3_Click(object sender, EventArgs e) {          
            CountTextBox.Text = inputStrText.Text.Split(' ').Length.ToString();

        }

        private void button5_3_4_Click(object sender, EventArgs e) {
            var words = inputStrText.Text.Split(' ').Where(n => n.Length <= 4);
            
            foreach (var word in words) {
                Tango_4Mozi_Ika.Text += word + " ";
            }
        }

        private void button5_3_5_Click(object sender, EventArgs e) {
            var words = inputStrText.Text.Split(' ').ToArray();
            if (words.Length > 0) {
                var sb = new StringBuilder(words[0]);
                foreach (var word in words.Skip(1)) {
                    sb.Append(' ');
                    sb.Append(word);
                }
                kuuhakukugiri_kakunou_renketu.Text = sb.ToString();
            }
            
        }

        private void button5_4_Click(object sender, EventArgs e) {
            foreach (var pair in inputStrText5_4.Text.Split(';')) {
                var array = pair.Split('=');
                TB_CA.Text += ToJapanese(array[0]) + "： " + array[1] + "\r\n";
            }            
        }

        private string ToJapanese(string key) {
            switch (key) {
                case "Novelist":
                    return "作家　 ";

                case "BestWork":
                    return "代表作";

                case "Born":
                    return "誕生年";
            }
            throw new ArgumentException("引数が正しくありません");
        }
    }
}
