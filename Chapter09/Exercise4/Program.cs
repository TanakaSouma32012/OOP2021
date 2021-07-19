using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4 {
    class Program {
        static void Main(string[] args) {
            var di1 = new DirectoryInfo(@"C:\Users\infosys\Desktop\data");
            DirectoryInfo di2 = Directory.CreateDirectory(@"C:\Users\infosys\Desktop\Example0719");
            FileInfo[] files = di1.GetFiles();
            FileInfo[] files2 = di2.GetFiles();
            foreach (var d in files) {
                foreach (var d2 in files2) {
                    File.Copy(d.Name,d2.Name,overwrite:true);
                }
                
            }

        }
    }
}
