using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAdvanced
{
    public interface BankInterface
    {
        List<BankValuteInterface> valutes { get; set; }
        double convert(int sum, string inputValuteKey, string outputValuteKey);
    }
}
