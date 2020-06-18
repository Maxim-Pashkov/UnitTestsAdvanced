using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAdvanced
{
    class MoneyPrinterStub : MoneyPrinterInterface
    {
        public string operation;
        public string currency;
        public int amount;

        public void print(string operation, string currency, int amount)
        {
            this.operation = operation;
            this.currency = currency;
            this.amount = amount;
        }
    }
}
