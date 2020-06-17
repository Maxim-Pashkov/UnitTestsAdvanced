using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO.Abstractions.TestingHelpers;

namespace UnitTestsAdvanced
{
    [TestFixture]
    class MoneyPrinterTest
    {
        private MoneyPrinter moneyPrinter;
        private MockFileSystem fileSystem;
        private string filename;

        public MoneyPrinterTest()
        {
            filename = "test.txt";
        }

        [SetUp] 
        public void initMoneyPrinter()
        {
            fileSystem = new MockFileSystem();
            moneyPrinter = new MoneyPrinter(fileSystem, filename);
        }

        [Test]
        public void writeToFile()
        {
            moneyPrinter.print("1", "2", 3);

            string[] lines = fileSystem.File.ReadAllLines(filename);

            Assert.AreEqual(lines.Length, 1);

            Assert.AreEqual(lines[0], "Operation: 1; Currency: 2; Amount: 3");
        }

        [Test]
        public void writeMultilineToFile()
        {
            moneyPrinter.print("1", "2", 3);

            moneyPrinter.print("3", "4", 5);

            string[] lines = fileSystem.File.ReadAllLines(filename);

            Assert.AreEqual(lines.Length, 2);

            Assert.AreEqual(lines[0], "Operation: 1; Currency: 2; Amount: 3");

            Assert.AreEqual(lines[1], "Operation: 3; Currency: 4; Amount: 5");
        }
    }
}
