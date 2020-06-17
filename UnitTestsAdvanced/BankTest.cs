using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestsAdvanced
{
    [TestFixture]
    class BankTest
    {
        private Bank bank;

        [SetUp]
        public void initBank()
        {
            bank = new Bank
            {
                valutes = new List<BankValuteInterface>
                {
                    new BankValuteStub{ key = "USD", course = 70 },
                    new BankValuteStub{ key = "EUR", course = 80 },
                    new BankValuteStub{ key = "GBP", course = 100 },
                }
            };
        }

        [Test]
        public void convertUSDtoRUB()
        {
            Assert.AreEqual(bank.convert(200, "USD", "RUB"), 14000);
        }

        [Test]
        public void convertEURtoRUB()
        {
            Assert.AreEqual(bank.convert(200, "EUR", "RUB"), 16000);
        }

        [Test]
        public void convertGBPtoRUB()
        {
            Assert.AreEqual(bank.convert(200, "GBP", "RUB"), 20000);
        }

        [Test]
        public void convertRUBtoRUB()
        {
            Assert.AreEqual(bank.convert(200, "RUB", "RUB"), 200);
        }

        [Test]
        public void convertUSDtoEUR()
        {
            Assert.AreEqual(bank.convert(200, "USD", "EUR"), 175);
        }

        [Test]
        public void convertEURtoEUR()
        {
            Assert.AreEqual(bank.convert(200, "EUR", "EUR"), 200);
        }

        [Test]
        public void convertGBPtoEUR()
        {
            Assert.AreEqual(bank.convert(200, "GBP", "EUR"), 250);
        }

        [Test]
        public void convertRUBtoEUR()
        {
            Assert.AreEqual(bank.convert(200, "RUB", "EUR"), 2.5);
        }

        [Test]
        public void convertUSDtoUSD()
        {
            Assert.AreEqual(bank.convert(200, "USD", "USD"), 200);
        }

        [Test]
        public void convertEURtoUSD()
        {
            Assert.AreEqual(bank.convert(200, "EUR", "USD"), 228.57);
        }

        [Test]
        public void convertGBPtoUSD()
        {
            Assert.AreEqual(bank.convert(200, "GBP", "USD"), 285.71);
        }

        [Test]
        public void convertRUBtoUSD()
        {
            Assert.AreEqual(bank.convert(200, "RUB", "USD"), 2.85);
        }

        [Test]
        public void convertUSDtoGBP()
        {
            Assert.AreEqual(bank.convert(200, "USD", "GBP"), 140);
        }

        [Test]
        public void convertEURtoGBP()
        {
            Assert.AreEqual(bank.convert(200, "EUR", "GBP"), 160);
        }

        [Test]
        public void convertGBPtoGBP()
        {
            Assert.AreEqual(bank.convert(200, "GBP", "GBP"), 200);
        }

        [Test]
        public void convertRUBtoGBP()
        {
            Assert.AreEqual(bank.convert(200, "RUB", "GBP"), 2);
        }   

        [Test]
        public void convertErrorInputValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => bank.convert(200, "KZT", "RUB"));
        }

        [Test]
        public void convertErrorOutputValue()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => bank.convert(200, "RUB", "KZT"));
        }
    }
}
