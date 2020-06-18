using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestsAdvanced
{
    [TestFixture]
    class WalletTest
    {
        private Wallet wallet;
        private BankMock bank;
        private MoneyPrinterStub moneyPrinter;

        [SetUp]
        public void initWallet()
        {
            bank = new BankMock();
            moneyPrinter = new MoneyPrinterStub();

            wallet = new Wallet(bank, moneyPrinter);
        }

        [Test]
        public void getMoneyEmpty()
        {
            Assert.AreEqual(wallet.getMoney("RUB"), 0);
        }

        [Test]
        public void getMoneyNotEmpty()
        {
            wallet.addMoney("RUB", 1);

            Assert.AreEqual(wallet.getMoney("RUB"), 1);
        }

        [Test]
        public void getMoneyMultiply()
        {
            wallet.addMoney("RUB", 1);

            wallet.addMoney("EUR", 2);

            Assert.AreEqual(wallet.getMoney("RUB"), 1);
        }

        [Test]
        public void getMoneyAfterRemove()
        {
            wallet.addMoney("RUB", 3);

            wallet.removeMoney("RUB", 2);

            Assert.AreEqual(wallet.getMoney("RUB"), 1);
        }

        [Test]
        public void getMoneyAfterFullRemove()
        {
            wallet.addMoney("RUB", 3);

            wallet.removeMoney("RUB", 2);

            wallet.removeMoney("RUB", 1);

            Assert.AreEqual(wallet.getMoney("RUB"), 0);
        } 

        [Test]
        public void addMoney()
        {
            wallet.addMoney("RUB", 100);

            Assert.AreEqual(wallet.getMoney("RUB"), 100);
        }

        [Test]
        public void addMoneyMultiply()
        {
            wallet.addMoney("RUB", 100);

            wallet.addMoney("RUB", 300);

            Assert.AreEqual(wallet.getMoney("RUB"), 400);
        }

        [Test]
        public void addMoneyZero()
        {
            wallet.addMoney("RUB", 0);

            Assert.AreEqual(wallet.getMoney("RUB"), 0);
        }

        [Test]
        public void addMoneyNegative()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => wallet.addMoney("RUB", -100));
        }

        [Test]
        public void removeMoney()
        {
            wallet.addMoney("RUB", 300);

            wallet.removeMoney("RUB", 200);

            Assert.AreEqual(wallet.getMoney("RUB"), 100);
        } 

        [Test]
        public void removeMoneyMultiply()
        {
            wallet.addMoney("RUB", 300);

            wallet.removeMoney("RUB", 200);

            wallet.removeMoney("RUB", 50);

            Assert.AreEqual(wallet.getMoney("RUB"), 50);
        }

        [Test]
        public void removeMoneyZero()
        {
            wallet.removeMoney("RUB", 0);

            Assert.AreEqual(wallet.getMoney("RUB"), 0);
        }

        [Test]
        public void removeMoneyNegative()
        {
            Assert.Catch<ArgumentOutOfRangeException>(() => wallet.removeMoney("RUB", -100));
        }

        [Test]
        public void removeMoneyOverhead()
        {
            wallet.addMoney("RUB", 100);

            Assert.Catch<ArgumentOutOfRangeException>(() => wallet.removeMoney("RUB", 300));
        }

        [Test]
        public void getValuteLengthEmpty()
        {
            Assert.AreEqual(wallet.getValuteLength(), 0);
        }

        [Test]
        public void getValuteLengthAfterAddMoney()
        {
            wallet.addMoney("RUB", 100);
            wallet.addMoney("RUB", 200);

            wallet.addMoney("USD", 300);

            Assert.AreEqual(wallet.getValuteLength(), 2);
        }

        [Test]
        public void getValuteLengthAfterAddAndRemoveMoney()
        {
            wallet.addMoney("RUB", 100);
            wallet.addMoney("RUB", 200);

            wallet.addMoney("USD", 300);

            wallet.addMoney("EUR", 400);

            wallet.removeMoney("EUR", 400);

            Assert.AreEqual(wallet.getValuteLength(), 2);
        }

        [Test]
        public void toStringEmpty()
        {
            Assert.AreEqual(wallet.ToString(), "{}");
        }

        [Test]
        public void toStringAfterAddMoney()
        {
            wallet.addMoney("RUB", 100);
            wallet.addMoney("RUB", 300);

            wallet.addMoney("EUR", 200);

            Assert.AreEqual(wallet.ToString(), "{ 400 RUB, 200 EUR }");
        }

        [Test]
        public void toStringAfterAddAndRemoveMoney()
        {
            wallet.addMoney("RUB", 100);
            wallet.addMoney("RUB", 200);

            wallet.addMoney("EUR", 200);

            wallet.addMoney("USD", 300);

            wallet.removeMoney("RUB", 150);

            wallet.removeMoney("EUR", 200);

            wallet.removeMoney("USD", 0);

            Assert.AreEqual(wallet.ToString(), "{ 150 RUB, 300 USD }");
        }

        [Test]
        public void getTotalMoneyEmpty()
        {
            Assert.AreEqual(wallet.getTotalMoney("RUB"), 0);
        }

        [Test]
        public void getTotalMoney()
        {
            wallet.addMoney("RUB", 300);

            Assert.AreEqual(wallet.getTotalMoney("RUB"), 300);
        }

        [Test]
        public void getTotalMoneyMultiply()
        {
            wallet.addMoney("RUB", 300);

            wallet.addMoney("EUR", 200);

            Assert.AreEqual(wallet.getTotalMoney("RUB"), 500);
        }

        [Test]
        public void getTotalMoneyAfterRemove()
        {
            wallet.addMoney("RUB", 300);

            wallet.removeMoney("RUB", 200);

            wallet.addMoney("EUR", 300);

            Assert.AreEqual(wallet.getTotalMoney("RUB"), 400);
        }

        [Test]
        public void getTotalMoneyAfterFullRemove()
        {
            wallet.addMoney("RUB", 400);

            wallet.addMoney("RUB", 100);

            wallet.addMoney("EUR", 300);

            wallet.removeMoney("RUB", 500);

            Assert.AreEqual(wallet.getTotalMoney("RUB"), 300);
        }

        [Test]
        public void moneyPrinterAfterAddMoney()
        {
            wallet.addMoney("RUB", 300);

            Assert.AreEqual(moneyPrinter.operation, "addMoney");
            Assert.AreEqual(moneyPrinter.currency, "RUB");
            Assert.AreEqual(moneyPrinter.amount, 300);
        }

        [Test]
        public void moneyPrinterAfterAddAndRemoveMoney()
        {
            wallet.addMoney("RUB", 300);

            wallet.removeMoney("RUB", 200);

            Assert.AreEqual(moneyPrinter.operation, "removeMoney");
            Assert.AreEqual(moneyPrinter.currency, "RUB");
            Assert.AreEqual(moneyPrinter.amount, 200);
        }

        [Test]
        public void moneyPrinterAfterAddMoneyZero()
        {
            wallet.addMoney("RUB", 0);

            Assert.IsNull(moneyPrinter.operation);
            Assert.IsNull(moneyPrinter.currency);
            Assert.AreEqual(moneyPrinter.amount, 0);
        }

        [Test]
        public void moneyPrinterAfterRemoveMoneyZero()
        {
            wallet.removeMoney("RUB", 0);

            Assert.IsNull(moneyPrinter.operation);
            Assert.IsNull(moneyPrinter.currency);
            Assert.AreEqual(moneyPrinter.amount, 0);
        }

    }
}
