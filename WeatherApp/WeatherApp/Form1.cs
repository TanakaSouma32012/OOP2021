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

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static private void button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (num)
            {
                case 1:
                    var results1 = GetWeatherReportFromYahoo(4210);
                    foreach (var s in results1)
                    {
                        //textBox1.Text = s;
                        //Console.WriteLine(s);
                    }
                    Console.ReadLine();
                    break;
                case 2:
                    var results2 = GetWeatherReportFromYahoo(4220);
                    foreach (var s in results2)
                    {
                        Console.WriteLine(s);
                    }
                    Console.ReadLine();
                    break;
                case 3:
                    var results3 = GetWeatherReportFromYahoo(4110);
                    foreach (var s in results3)
                    {
                        Console.WriteLine(s);
                    }
                    Console.ReadLine();
                    break;
                case 4:
                    var results4 = GetWeatherReportFromYahoo(4010);
                    foreach (var s in results4)
                    {
                        Console.WriteLine(s);
                    }
                    Console.ReadLine();
                    break;
                case 9:
                    Console.WriteLine("コードを入力して下さい");
                    int n9 = int.Parse(Console.ReadLine());
                    var results9 = GetWeatherReportFromYahoo(n9);
                    foreach (var s in results9)
                    {
                        Console.WriteLine(s);
                    }
                    Console.ReadLine();
                    break;
            }
        }
        private static IEnumerable<string> GetWeatherReportFromYahoo(int cityCode)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-type", "charset=UTF-8");
                var uriString = string.Format(
                    @"http://rss.weather.yahoo.co.jp/rss/days/{0}.xml", cityCode);
                var url = new Uri(uriString);
                var stream = wc.OpenRead(url);

                XDocument xdoc = XDocument.Load(stream);
                var nodes = xdoc.Root.Descendants("title");
                foreach (var node in nodes)
                {
                    string s = Regex.Replace(node.Value, "【|】|- Yahoo!天気・災害", "");
                    yield return s;
                }
            }
        }
    }
}
