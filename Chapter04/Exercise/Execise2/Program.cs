using Exercise1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Execise2 {
    class Program {
        static void Main(string[] args) {
            var ymCollection = new Exercise1.YearMonth[] {
                new Exercise1.YearMonth(1980,1),
                new Exercise1.YearMonth(1990,4),
                new Exercise1.YearMonth(2000,7),
                new Exercise1.YearMonth(2010,9),
                new Exercise1.YearMonth(2020,12),
            };
            Exercise2_2(ymCollection);
            Console.WriteLine("------------");

            Exercise2_4(ymCollection);
            Console.WriteLine("------------");

            Exercise2_5(ymCollection);
            Console.WriteLine("------------");
        }

        private static void Exercise2_2(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                Console.WriteLine(ym);
            }
        }
        static YearMonth FindFirst21C(YearMonth[] ymCollection) {
            foreach (var ym in ymCollection) {
                if (ym.Is21Century)                     
                    return ym;                
            }
            return null;
        }
        
        private static void Exercise2_4(YearMonth[] ymCollection) {            
            var yeamonth = FindFirst21C(ymCollection);
            var s = yeamonth != null ? yeamonth.ToString() : "21世紀のデータはありません";
            Console.WriteLine(s);
        }

        private static void Exercise2_5(YearMonth[] ymCollection) {
            var s =  ymCollection.Select(n => n.AddOneMonth()).ToArray();

            foreach (var ym in s) {
                Console.WriteLine(ym);
            }
        }        
    }
}
