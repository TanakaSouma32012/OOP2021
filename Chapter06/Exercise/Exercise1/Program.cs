using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1 {
    class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35};            

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
            Console.WriteLine("-----");

        }

        private static void Exercise1_1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise1_2(int[] numbers) {
            var skip = numbers.Length - 2;
            foreach (var w in numbers.Skip(skip)) {
                Console.WriteLine(w);
            }
        }

        private static void Exercise1_3(int[] numbers) {
            var nb = numbers.Select(n => n.ToString());
            foreach (var w in nb) {
                Console.Write(w + " ");
            }
            Console.WriteLine();
        }

        private static void Exercise1_4(int[] numbers) {            
            foreach (var w in numbers.OrderBy(n => n).Take(3)) {
                Console.Write(w + " ");
            }
            Console.WriteLine();
        }

        private static void Exercise1_5(int[] numbers) {
            Console.WriteLine(numbers.Distinct().Count(n => n > 10));
        }
    }
}
