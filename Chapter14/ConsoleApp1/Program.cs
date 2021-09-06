using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section
{
    class Program
    {
        
        Dictionary<string,int> AreaDic = new Dictionary<string,int>()
        {
            { "前橋",4210},
            { "みなかみ",4220},
            { "宇都宮", 4110},
            { "水戸", 4010},
        };
        static void Main(string[] args)
        {
            new Program();
        }

        List<int> cityCode = new List<int>();

        //コンストラクタ
        public Program()
        {
            Console.WriteLine("Yahoo！週間天気予報");
            Console.WriteLine();
            Console.WriteLine("地域コードを入力");

            //Console.WriteLine("1:前橋");
            //Console.WriteLine("2:みなかみ");
            //Console.WriteLine("3:宇都宮");
            //Console.WriteLine("4:水戸");

            int num1 = 1;
            foreach (KeyValuePair<string,int> pair in AreaDic)
            {
                Console.WriteLine("{0}:{1}", num1++ , pair.Key);
                cityCode.Add(pair.Value);
            }
 
            Console.WriteLine("9:その他");
            Console.WriteLine();
            Console.Write(">");
            var num = Console.ReadLine();
            Console.WriteLine();

            var pos = int.Parse(num);

            IEnumerable<string> results;
            int code;
            if (pos != 9)
            {
               //results = GetWeatherReportFromYahoo(cityCode[pos - 1]);
                code = cityCode[pos - 1];
            }
            else
            {
                Console.Write("コードを入力して下さい");
                var num2 = Console.ReadLine();
                code = int.Parse(num2);

                 //results = GetWeatherReportFromYahoo(int.Parse(num2));
            }
            results = GetWeatherReportFromYahoo(code);
            foreach (var s in results)
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();










            //switch (num)
            //{
            //    case 1:
            //        var results1 = GetWeatherReportFromYahoo(4210);
            //        foreach (var s in results1)
            //        {
            //            Console.WriteLine(s);
            //        }
            //        Console.ReadLine();
            //        break;
            //    case 2:
            //        var results2 = GetWeatherReportFromYahoo(4220);
            //        foreach (var s in results2)
            //        {
            //            Console.WriteLine(s);
            //        }
            //        Console.ReadLine();
            //        break;
            //    case 3:
            //        var results3 = GetWeatherReportFromYahoo(4110);
            //        foreach (var s in results3)
            //        {
            //            Console.WriteLine(s);
            //        }
            //        Console.ReadLine();
            //        break;
            //    case 4:
            //        var results4 = GetWeatherReportFromYahoo(4010);
            //        foreach (var s in results4)
            //        {
            //            Console.WriteLine(s);
            //        }
            //        Console.ReadLine();
            //        break;
            //    case 9:
            //        Console.WriteLine("コードを入力して下さい");
            //        int n9 = int.Parse(Console.ReadLine());
            //        var results9 = GetWeatherReportFromYahoo(n9);
            //        foreach (var s in results9)
            //        {
            //            Console.WriteLine(s);
            //        }
            //        Console.ReadLine();
            //        break;
            //}
        }

        //リスト14.15
        public void DownloadString()
        {
            var wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var html = wc.DownloadString("https://yahoo.co.jp/");
            Console.WriteLine(html);
        
        }
        private void DownloadFileAsync()
        {
            var wc = new WebClient();
            var url = new Uri(@"C:\Users\st32012\Desktop\OneDrive_2021-06-07.zip");
            var filename = @"C:\temp\example.zip";
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            wc.DownloadFileAsync(url, filename);
            Console.ReadLine();//アプリケーションが終了しないように
        }

        static void wc_DownloadProgressChanged(object sender,
                            DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("{0}% {1}/{2}", e.ProgressPercentage,
                              e.BytesReceived, e.TotalBytesToReceive);
        }

        static void wc_DownloadFileCompleted(object sender,
                            System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("ダウンロード完了");
        }
         //14.18(ストリームとしてダウンロード)
        public void OpenReadSample()
        {
            var wc = new WebClient();
            using (var stream = wc.OpenRead(@"http://yahoo.co.jp/"))
            using(var sr = new StreamReader(stream,Encoding.UTF8))
            {
                string html = sr.ReadToEnd();
                Console.WriteLine(html);
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
