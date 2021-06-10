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
        
        private static void Exercise2_4(YearMonth[] ym) {
            throw new NotImplementedException();
        }

        private static void Exercise2_5(YearMonth[] ym) {
            throw new NotImplementedException();
        }

        
    }
}
