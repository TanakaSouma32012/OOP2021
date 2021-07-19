using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    class Program {
        static void Main(string[] args) {
            var filePath = @"C:\Users\infosys\Desktop\data\text07_16_1.txt";
            var lines = File.ReadLines(filePath)
                            .Select((s,ix) => String.Format("{0,4}: {1}",ix+1,s))
                            .ToArray();            

            var fp2 = @"C:\Users\infosys\Desktop\data\text07_19_1.txt";
            using (var writer = new StreamWriter(fp2)) {
                foreach (var line in lines) {
                    Console.WriteLine(line);
                    writer.WriteLine(line);
                }
            }
        }
    }
}
