using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    class Program {
        static void Main(string[] args) {
            var books = Books.GetBooks();

            Console.WriteLine("本の平均価格は" + books.Average(x => x.Price).ToString("#,0") + "円");
            Console.WriteLine("本の総ページ数は" + books.Sum(x => x.Pages) + "ページ");
            Console.WriteLine("最も価格の高い本" + books.Max(x => x.Price).ToString("#,0") + "円");
            Console.WriteLine("最も価格の安い本" + books.Min(x => x.Price).ToString("#,0") + "円");
            Console.WriteLine("本の冊数" + books.Count + "冊");
            Console.WriteLine("５００円以上の本" + books.Count(x=> 500<x.Price) + "冊");

            Console.WriteLine("「物語」が含まれている本の冊数"　+ books.Count(n=> n.Title.ToString().Contains("物語")) + "冊");
            var bk = books.Where(n =>  n.Title.Contains("物語")).Take(5);
            foreach (var b in bk) {
                Console.WriteLine(b.Title);
            }

            Console.WriteLine();

            var boos1 = books.OrderByDescending(n => n.Price).Take(3);
            Console.WriteLine("高額書籍ベスト3" );
            foreach (var b1 in boos1) {
                Console.WriteLine("{0} {1}",b1.Title , b1.Price);
            }

            Console.WriteLine();

            var titles = books.Select(x => x.Title);            
            foreach (var item in titles) {
                Console.WriteLine(item);
            }

            


        }
    }
}
