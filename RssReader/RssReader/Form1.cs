using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader
{
    public partial class Form1 : Form
    {
        private object cityCode;
        public string weburl = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            setRssTitle(tbUrl.Text);

        }

        public List<string> link = new List<string>();
        List<string> link4 = new List<string>();
        List<string> link5 = new List<string>();
        
        public void setRssTitle(string uri)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-type", "charset=UTF-8");

                var uriString = string.Format(
                   @"{0}", uri, cityCode);
                var url = new Uri(uriString);
                var stream = wc.OpenRead(url);

                XDocument xdoc = XDocument.Load(stream);

                var nodes = xdoc.Root.Descendants("title");
                var nodes2 = xdoc.Root.Descendants("link");
                var nodes3 = xdoc.Root.Descendants("comments");
                var nodes4 = xdoc.Root.Descendants("description");
                var nodes5 = xdoc.Root.Descendants("pubDate");
                
                foreach (var node in nodes)
                {
                    var u = Regex.Replace(node.Value, "", "");
                    lbTitles.Items.Add(u);

                    
                }
                foreach (var node2 in nodes2)
                {
                    link.Add(node2.Value);
                    

                }
                foreach (var node4 in nodes4)
                {
                    link4.Add(node4.Value);
                }
                foreach (var node5 in nodes5)
                {
                    link5.Add(node5.Value);
                }

            }
        }

        
        private void lbTitles_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            weburl = link[lbTitles.SelectedIndex];
            label2.Text = link4[lbTitles.SelectedIndex];
            label3.Text = link5[lbTitles.SelectedIndex];
        }

        private void btWeb_Click(object sender, EventArgs e)
        {
            var form2 = new Form2(weburl);
            form2.Show();

        }
    }
}
