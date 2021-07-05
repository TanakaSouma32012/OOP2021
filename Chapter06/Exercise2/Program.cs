using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        class Book {
            public string Title { get; set; }
            public int Price { get; set; }
            public int Pages { get; set; }
        }
        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Exercise2_1(books);
            Console.WriteLine("-----");

            Exercise2_2(books);

            Console.WriteLine("-----");

            Exercise2_3(books);
            Console.WriteLine("-----");

            Exercise2_4(books);
            Console.WriteLine("-----");

            Exercise2_5(books);
            Console.WriteLine("-----");

            Exercise2_6(books);

            Console.WriteLine("-----");

            Exercise2_7(books);
        }

        private static void Exercise2_1(List<Book> books) {
            var bo = books.FirstOrDefault(b =>b.Title == "ワンダフル・C#ライフ");
            if (bo != null) {
                Console.WriteLine("タイトル；{0}  {1}円 {2}ページ ", bo.Title , bo.Price, bo.Pages);

            }
        }

        private static void Exercise2_2(List<Book> books) {
            var bo = books.Where(n=> n.Title.Contains("C#")).Count();
            Console.WriteLine(bo);
        }

        private static void Exercise2_3(List<Book> books) {
            var bo = books.Where(n => n.Title.Contains("C#")).Average(a => a.Pages);
            Console.WriteLine(bo);
        }

        private static void Exercise2_4(List<Book> books) {
            var bo = books.FirstOrDefault(n=> n.Price >= 4000);
            Console.WriteLine(bo.Title);
        }

        private static void Exercise2_5(List<Book> books) {
            var bo = books.Where(n=> n.Price < 4000).Max(n=> n.Pages);
            Console.WriteLine(bo);
        }

        private static void Exercise2_6(List<Book> books) {
            var bo = books.Where(n => n.Pages >= 400).OrderByDescending(n => n.Price);
            foreach (var m in bo) {
                Console.WriteLine("{0} , {1}" , m.Title , m.Price );
            }
        }

        private static void Exercise2_7(List<Book> books) {
            var bo = books.Where(n => n.Title.Contains("C#") && n.Pages <= 500);
            foreach (var b in bo) {
                Console.WriteLine(b.Title);
            }
        }
    }
}
