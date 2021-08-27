using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section01
{
    class Program
    {
        static void Main(string[] args)
        {
            var novelists = ReadNovelists();

            foreach (var novelist in novelists)
            {
                Console.WriteLine("{0} ({1}-{2}) - {3}",
                                   novelist.Name , novelist.Birth.Year , novelist.Death.Year
                                   ,string .Join(",",novelist.Masterpieces));
            }
        }
        //カスタムクラスのオブジェクトとして要素を取り出す
        static public IEnumerable<Novelist> ReadNovelists()
        {
            var xdoc = XDocument.Load("novelists.xml"); //XMLファイルのロード
            var novelists = xdoc.Root.Elements()
                                   .Select(X => new Novelist
                                   {
                                       Name = (string)X.Element("name"),
                                       KanaName　= (string)(X.Element("name").Attribute("kana")),
                                       Birth = (DateTime)X.Element("birth"),
                                       Death = (DateTime)X.Element("death"),
                                       Masterpieces = X.Element("masterpieces")
                                                        .Elements("title")
                                                        .Select(title => title.Value)
                                                        .ToArray()
                                   });
            return novelists.ToArray();
        }
    }
}




//var xdoc = XDocument.Load("novelists.xml");
//var xtitles = xdoc.Root.Elements()
//                       .Select(X => new
//                       {
//                           Name = (string)X.Element("name"),
//                           Birth = (DateTime)X.Element("birth"),
//                           Death = (DateTime)X.Element("death")
//                       });
