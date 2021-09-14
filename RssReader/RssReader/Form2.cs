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
            
            wbBrowser.GoBack();
            

        }

        private void btsusumu_Click(object sender, EventArgs e)
        {
            
            wbBrowser.GoForward();
            
            
        }
        //ページの読み込みが終わると呼ばれる
        private void wbBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btBack.Enabled = wbBrowser.CanGoBack;
            btsusumu.Enabled = wbBrowser.CanGoForward;
        }
    }
}
