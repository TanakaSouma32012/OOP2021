using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "Sample.xml";
            var file2 = "11_2.xml";
            Exercise1_1(file);
            Console.WriteLine("-------------------");

            Exercise1_2(file);
            Console.WriteLine("-------------------");

            Exercise1_3(file);
            Console.WriteLine("-------------------");

            Exercise1_4(file);
            Console.WriteLine("-------------------");

            Exercise2(file2);
            Console.WriteLine("-------------------");

        }

        

        private static void Exercise1_1(string file)
        {
            var xdoc = XDocument.Load(file); //XMLファイルのロード
            var sports = xdoc.Root.Elements()
                            .Select(x => new { 
                                Name = x.Element("name").Value,
                                Teammembers = x.Element("teammembers").Value
                            });
            foreach (var s in sports)
            {
                Console.WriteLine("{0} {1}",s.Name,s.Teammembers);
            }
        }

        private static void Exercise1_2(string file)
        {
            var xdoc = XDocument.Load(file); //XMLファイルのロード
            var novelists = xdoc.Root.Elements()
                                .Select(x => new {
                                    firstplayed = x.Element("firstplayed").Value,
                                    name = x.Element("name").Attribute("kanji").Value
                                }).OrderBy(x => int.Parse(x.firstplayed));
            foreach (var s in novelists)
            {
                
                Console.WriteLine("{0} {1}",s.name,s.firstplayed);
            }

        }

        private static void Exercise1_3(string file)
        {
            var xdoc = XDocument.Load(file); //XMLファイルのロード
            var novelists = xdoc.Root.Elements()
                                .Select(x => new 
                                {
                                    teammembers = x.Element("teammembers").Value,
                                     name = x.Element("name").Value
                                })
                                .OrderByDescending(x => int.Parse(x.teammembers))
                                .First();
            
                Console.WriteLine("{0}", novelists.name);
            
        }

        private static void Exercise1_4(string file)
        {
            //var newfile = "sports.xml";
            //var element = new XElement("ballsport",
            //                    new XElement("name", "サッカー", new XAttribute("kanji", "蹴球 ")),
            //                    new XElement("teammembers", "11"),
            //                    new XElement("firstplayed", "1848")
            //                    );
            //var xdoc = XDocument.Load(file);
            //xdoc.Root.Add(element);
            //xdoc.Save(newfile);
        }

        private static void Exercise2(string file)
        {
            var xdoc = XDocument.Load(file); //XMLファイルのロード

            var newfile1 = "11_2new.xml";//XMLファイルの作成
            xdoc.Save(newfile1);

            var newfile2 = XDocument.Load("11_2new.xml");//XMLファイルのロード

            var sports = xdoc.Root.Elements()
                            .Select(x => new {
                                Kanji = x.Element("kanji").Value,
                                Yomi = x.Element("yomi").Value
                            });

            var element = new XElement("difficultkanji");
            newfile2.Root.Add(element);

            foreach (var s in sports)
            {
                var element2 =  new XElement(new XElement("kanji", s.Kanji, new XAttribute("yomi", s.Yomi)));
                newfile2.Root.Add(element2);
                newfile2.Save(newfile2.ToString());
            }
            
        }
    }
}
