using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAdvanced
{
    public class BankMock : BankInterface
    {
        public List<BankValuteInterface> valutes { get; set; }

        public double convert(int sum, string inputValuteKey, string outputValuteKey)
        {
            return sum;
        }
    }
}
