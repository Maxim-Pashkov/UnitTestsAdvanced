using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAdvanced
{
    public interface BankValuteInterface
    {
        string key { get; set; }
        int course { get; set; }

        double getPercent();
    }
}
