using Housing.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Program
    {
        public class Tester
        {
            public static void Main(string[] args)
            {
                AccessHelper helper = new AccessHelper();
                Console.WriteLine(helper.GetAssociates());
            }
        }
    }
}
