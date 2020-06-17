using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAdvanced
{
    public class BankValuteStub : BankValuteInterface
    {
        public string key { get; set; }
        public int course { get; set; }

        public double getPercent()
        {
            return 1;
        }
    }
}
