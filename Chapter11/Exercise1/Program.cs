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
            Exercise1_1(file);
            Console.WriteLine("-------------------");

            Exercise1_2(file);
            Console.WriteLine("-------------------");

            Exercise1_3(file);
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
    }
}
