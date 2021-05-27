using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCalculator {
    class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter("Sales.csv");

            Dictionary<string,int> amountParStore =  sales.GetPerStoreSales();
            foreach (KeyValuePair<string,int> obj in amountParStore) {
                Console.WriteLine("{0} {1}",obj.Key,obj.Value);
            }
        }
    }
}
