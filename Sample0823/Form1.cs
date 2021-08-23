using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample0823
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Exec_Click(object sender, EventArgs e)
        {
            var num = 1;

            for (int i = 0; i < int.Parse(Jyou.Text); i++)
            {
                num *= int.Parse(Value.Text);

            }
            Result.Text = num.ToString();
        }
    }
}
