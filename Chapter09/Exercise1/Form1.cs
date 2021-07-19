using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btOpen_Click(object sender, EventArgs e) {
            if (ofdOpenFile.ShowDialog() == DialogResult.OK) {
                using (var reader = new StreamReader(ofdOpenFile.FileName, Encoding.GetEncoding("shift_jis"))) {
                    while (!reader.EndOfStream) {
                        var line = reader.ReadLine();  // １行読み込み
                        tbOutput.Text += line + "\r\n";
                    }
                }
                var count = File.ReadLines(ofdOpenFile.FileName, Encoding.GetEncoding("shift_jis"))
                    .Count(s => s.Contains(tbKeyword.Text));
                tbOutput.Text += count.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            if (ofdOpenFile.ShowDialog() == DialogResult.OK) {
                int count = 0;
                using (var reader = new StreamReader(ofdOpenFile.FileName, Encoding.GetEncoding("shift_jis"))) {
                    while (!reader.EndOfStream) {
                        var line = reader.ReadLine();  // １行読み込み
                        tbOutput.Text += line + "\r\n";
                        if (line.Contains(tbKeyword.Text)) {
                            count++;
                        }
                    }
                    tbOutput.Text = "キーワード「" + tbKeyword.Text + " 」は" + count + "," + "\r\n";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e) {
            if (ofdOpenFile.ShowDialog() == DialogResult.OK) {
                int count = 0;
                var lines = File.ReadLines(ofdOpenFile.FileName, Encoding.GetEncoding("shift_jis"));
                foreach (var line in lines) {
                    if (line.Contains(tbKeyword.Text)) {
                        count++;
                    }
                }
                tbOutput.Text += "キーワード「" + tbKeyword.Text + " 」は" + count + "," + "\r\n";
            }
        }
    }
}
