using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RssReader
{
    public partial class Form2 : Form
    {
        public Form2(string url)
        {
            InitializeComponent();
            wbBrowser.Navigate(url);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            
        }

        private void btBack_Click(object sender, EventArgs e)
        {
            if (wbBrowser.CanGoBack == true)
            {
                wbBrowser.GoBack();
            }
            
        }

        private void btsusumu_Click(object sender, EventArgs e)
        {
            if (wbBrowser.CanGoForward == true)
            {
                wbBrowser.GoForward();
            }
            
        }
    }
}
