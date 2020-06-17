using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAdvanced
{
    public class Bank : BankInterface
    {
        public List<BankValuteInterface> valutes { get; set; }

        public double convert(int sum, string inputValuteKey, string outputValuteKey)
        {            
            if(inputValuteKey != "RUB" && valutes.FirstOrDefault(valute => valute.key == inputValuteKey) == null)
            {
                throw new ArgumentOutOfRangeException("inputValuteKey");
            }

            if(outputValuteKey != "RUB" && valutes.FirstOrDefault(valute => valute.key == outputValuteKey) == null)
            {
                throw new ArgumentOutOfRangeException("outputValuteKey");
            }

            if(inputValuteKey == outputValuteKey)
            {
                return sum;
            }

            BankValuteInterface inputValute = valutes.FirstOrDefault(valute => valute.key == inputValuteKey);
            BankValuteInterface outputValute = valutes.FirstOrDefault(valute => valute.key == outputValuteKey);

            double result = 0;
            if(inputValuteKey == "RUB")
            {
                result = sum / (outputValute.course * outputValute.getPercent());
            }
            else if(outputValuteKey == "RUB")
            {
                result = sum * inputValute.course * inputValute.getPercent();
            }
            else
            {
                result = sum * inputValute.course * inputValute.getPercent() / outputValute.course;
            }

            return Math.Floor(result * 100) / 100;
        }
    }
}
