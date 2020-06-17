using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Abstractions;

namespace UnitTestsAdvanced
{
    class MoneyPrinter : MoneyPrinterInterface
    {
        readonly IFileSystem fileSystem;
        readonly string path;

        public MoneyPrinter(IFileSystem fileSystem, string path)
        {
            this.fileSystem = fileSystem;
            this.path = path;
        }

        public MoneyPrinter(string path)
        {
            fileSystem = new FileSystem();
            this.path = path;
        }
        public void print(string operation, string currency, int amount)
        {
            fileSystem.File.AppendAllLines(path, new string[] { "Operation: " + operation + "; Currency: " + currency + "; Amount: " + amount });
        }
    }
}
