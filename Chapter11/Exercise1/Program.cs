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
            var novelists = xdoc.Root.Elements();
            foreach (var novelist in novelists)
            {
                var xname = novelist.Element("name");
                var xteammembers = novelist.Element("teammembers");
                Console.WriteLine("{0} {1}",xname.Value,xteammembers.Value);
            }
        }

        private static void Exercise1_2(string file)
        {
            var xdoc = XDocument.Load(file); //XMLファイルのロード
            var novelists = xdoc.Root.Elements().OrderBy(x => (int)x.Element("firstplayed"));
            foreach (var novelist in novelists)
            {
                var name = novelist.Element("name");
                var kanzi = name.Attribute("kanji");
                var firstplayed = novelist.Element("firstplayed");
                Console.WriteLine("{0} {1}", kanzi.Value,firstplayed.Value);
            }

        }

        private static void Exercise1_3(string file)
        {
            var xdoc = XDocument.Load(file); //XMLファイルのロード
            var novelists = xdoc.Root.Elements().Max(x => x.Element("teammembers"));
            
        }

       

       
    }
}
