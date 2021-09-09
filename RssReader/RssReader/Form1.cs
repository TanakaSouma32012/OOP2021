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

        public Form1()
        {
            InitializeComponent();
        }

        private void btRead_Click(object sender, EventArgs e)
        {
            setRssTitle(tbUrl.Text);

        }
        private void setRssTitle(string uri)
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

                foreach (var node in nodes)
                { 
                    foreach (var node2 in nodes2)
                    {
                        var u = Regex.Replace(node.Value, "","");
                        lbTitles.Items.Add(u);
                        lbTitles.Items.Add(node2.Value);
                    }
                }
            }
        }

        private void lbTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item =  lbTitles.SelectedItem.ToString();
            
            wbBrowser.Navigate(item);
        }
    }
}
