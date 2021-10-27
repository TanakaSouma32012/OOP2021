using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework
{

    class Program
    {
        static void Main(string[] args)
        {
            #region
            //using (var db = new BooksDbContext())
            //{
            //    db.Database.Log = sql => { Debug.Write(sql); };
            //    var count = db.Books.Count();
            //    Console.WriteLine(count);



            //}

            //データの追加
            //InsertBooks();
            //DisplayAllBooks();
            //AddAuthors();
            //AddBooks();
            //UpdateBook();
            //DeleteBook();


            #endregion

            Console.WriteLine("1_1");
            Exercise13_1_1();
            
            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("1_2");
            Exercise13_1_2();

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("1_3");
            Exercise13_1_3();

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("1_4");
            Exercise13_1_4();

            Console.WriteLine("-----------------------------------------");

            Console.WriteLine("1_5");
            Exercise13_1_5();

            Console.WriteLine("-----------------------------------------");

            //Console.WriteLine("1_6");
            //Exercise13_1_6();

            //Console.WriteLine("-----------------------------------------");

            //Console.WriteLine("1_7");
            //Exercise13_1_7();

            //Console.WriteLine("-----------------------------------------");

        }

        private static void Exercise13_1_7()
        {
            using (var db = new BooksDbContext())
            {
                Console.WriteLine("名前");
                string namedata = Console.ReadLine();

                Console.WriteLine("タイトル");
                string titledata = Console.ReadLine();

                Console.WriteLine("発行年");
                int PublishedYeardata = int.Parse(Console.ReadLine());

                var author1 = db.Authors.Single(a => a.Name == namedata);
                var book1 = new Book
                {
                    Title = titledata,
                    PublishedYear = PublishedYeardata,
                    Author = author1,
                };
                db.Books.Add(book1);

                Console.WriteLine("----------------------------------------------");

                Console.ReadLine();
            }
        }

        private static void Exercise13_1_6()
        {
            Console.WriteLine("誕生日");
            Console.WriteLine("年");
            int birthdaydata1 = int.Parse(Console.ReadLine());
            Console.WriteLine("月");
            int birthdaydata2 = int.Parse(Console.ReadLine());
            Console.WriteLine("日");
            int birthdaydata3 = int.Parse(Console.ReadLine());

            Console.WriteLine("性別");
            string genderdata = Console.ReadLine();

            Console.WriteLine("名前");
            string namedata = Console.ReadLine();

            try
            {
                using (var db = new BooksDbContext())
                {
                    var author1 = new Author
                    {
                        Birthday = new DateTime(birthdaydata1, birthdaydata2, birthdaydata3),
                        Gender = genderdata,
                        Name = namedata
                    };
                    db.Authors.Add(author1);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }

        private static void Exercise13_1_5()
        {
            using (var db = new BooksDbContext())
            {

                var authors = db.Authors
                                .OrderByDescending(o=>o.Birthday);
                foreach (var author in authors)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"{author.Name}");
                    foreach (var book in author.Books)
                    {
                        Console.WriteLine($"{book.Title}:{book.PublishedYear}");
                    }
                }
            }
        }

        private static void Exercise13_1_4()
        {
            using (var db = new BooksDbContext())
            {
                var books = db.Books.OrderBy(o=>o.PublishedYear).Take(3);
                foreach (var book in books)
                {
                    Console.WriteLine($"{book.Title}:{book.Author.Name}:{book.PublishedYear}");
                }
            }
        }

        private static void Exercise13_1_3()
        {
            using (var db = new BooksDbContext())
            {
                var authors = db.Books.Where(a=> a.Title.Length == db.Books.Max(x=>x.Title.Length));
                foreach (var author in authors)
                {
                    Console.WriteLine($"{author.Title}:{author.PublishedYear}:{author.Author.Name}:{author.Author.Birthday:yyyy/MM/dd}");
                }
                
            }
        }

        private static void Exercise13_1_2()
        {
            using (var db = new BooksDbContext())
            {
                foreach (var author in db.Authors)
                {
                    Console.WriteLine($"{author.Name}:{author.Gender}:{author.Birthday:yyyy/MM/dd}:{author.Id}");
                }
                foreach (var book in db.Books)
                {
                    Console.WriteLine($"{book.Title}:{book.PublishedYear}:{book.Id}");
                }

            }
        }

        private static void Exercise13_1_1()
        {
            /*問題13.1********************************/
            /*1
            using (var db = new BooksDbContext())
            {
                var author1 = new Author
                {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "男性",
                    Name = "菊池寛"
                };
                db.Authors.Add(author1);

                var author2 = new Author
                {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "男性",
                    Name = "川端康成"
                };
                db.Authors.Add(author2);

                db.SaveChanges();
            }
            using (var db = new BooksDbContext())
            {


                var author1 = db.Authors.Single(a => a.Name == "夏目漱石");
                var book1 = new Book
                {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = author1,
                };
                db.Books.Add(book1);

                var author2 = db.Authors.Single(a => a.Name == "川端康成");
                var book2 = new Book
                {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = author2,
                };
                db.Books.Add(book2);

                var author3 = db.Authors.Single(a => a.Name == "菊池寛");
                var book3 = new Book
                {
                    Title = "真珠婦人",
                    PublishedYear = 2002,
                    Author = author3,
                };
                db.Books.Add(book3);

                var author4 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book4 = new Book
                {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = author4,
                };
                db.Books.Add(book4);

                db.SaveChanges();
            }
            */
        }

        #region//P321～P343

        // List 13-12
        private static void DeleteBook()
        {
            using (var db = new BooksDbContext())
            {
                var book = db.Books.SingleOrDefault(x => x.Id == 10);
                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                }
            }
        }


        // List 13-5
        static void InsertBooks()
        {
            using (var db = new BooksDbContext())
            {
                var book1 = new Book
                {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author
                    {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };
                db.Books.Add(book1);

                var book2 = new Book
                {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author
                    {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);

                db.SaveChanges();//データベースの更新
            }
        }

        // List 13-7
        static IEnumerable<Book> GetBooks()
        {
            using (var db = new BooksDbContext())
            {
                return db.Books.Where(book=>book.Author.Name.StartsWith("夏目")).ToList();
            }
        }

        // List 13-8
        static void DisplayAllBooks()
        {
            var books = GetBooks();
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title}{book.PublishedYear}");
            }
            Console.ReadLine();
        }

        // List 13-9
        private static void AddAuthors()
        {
            using (var db = new BooksDbContext())
            {
                var author1 = new Author
                {
                    Birthday = new DateTime(1878, 12, 7),
                    Gender = "F",
                    Name = "与謝野晶子"
                };
                db.Authors.Add(author1);

                var author2 = new Author
                {
                    Birthday = new DateTime(1896, 8, 27),
                    Gender = "M",
                    Name = "宮沢賢治"
                };
                db.Authors.Add(author2);

                db.SaveChanges();

            }
        }

        // List 13-10
        private static void AddBooks()
        {
            using (var db = new BooksDbContext())
            {
                var author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                var book1 = new Book
                {
                    Title = "みだれ髪",
                    PublishedYear = 2000,
                    Author = author1,
                };
                db.Books.Add(book1);

                var author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book2 = new Book
                {
                    Title = "銀河鉄道の夜",
                    PublishedYear = 1989,
                    Author = author2,
                };
                db.Books.Add(book2);

                db.SaveChanges();

            }
        }

        //List 13-11
        private static void UpdateBook()
        {
            using (var db = new BooksDbContext())
            {
                var book = db.Books.Single(x => x.Title == "銀河鉄道の夜");
                book.PublishedYear = 2016;
                db.SaveChanges();
            }
        }
        #endregion
    }
}
#region
//using (var db = new BooksDbContext())
//{
//    var authors = db.Authors
//                    .Where(a => a.Books.Count() >= 2);
//    foreach (var author in authors)
//    {
//        Console.WriteLine($"{author.Name}{author.Gender}{author.Birthday}");
//    }
//}
//using (var db = new BooksDbContext())
//{

//    var books = db.Books
//                  .OrderBy(b => b.PublishedYear)
//                  .ThenBy(b => b.Author.Name);
//    foreach (var book in books)
//    {
//        Console.WriteLine($"{book.Title}{book.PublishedYear}{book.Author.Name}");
//    }
//}
//using (var db = new BooksDbContext())
//{
//    var groups = db.Books
//                   .GroupBy(b => b.PublishedYear)
//                   .Select(g => new
//                   {
//                       Year = g.Key,
//                       Count = g.Count()
//                   });

//    foreach (var g in groups)
//    {
//        Console.WriteLine($"{g.Year}{g.Count}");
//    }
//}
//using (var db = new BooksDbContext())
//{
//    var author = db.Authors
//                   .Where(a => a.Books.Count() ==
//                                    db.Authors.Max(x => x.Books.Count()))
//                   .First();
//    Console.WriteLine($"{author.Name}{author.Gender}{author.Birthday}");

//}
#endregion