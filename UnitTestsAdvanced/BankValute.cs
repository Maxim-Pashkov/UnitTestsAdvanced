using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAdvanced
{
    public class BankValute: BankValuteInterface
    {
        public string key { get; set; }
        public int course { get; set; }

        private Random rnd;

        public BankValute()
        {
            rnd = new Random();
        }

        public double getPercent()
        {
            return (1 + rnd.Next(-2, 2)) / 10;
        }
    }
}
