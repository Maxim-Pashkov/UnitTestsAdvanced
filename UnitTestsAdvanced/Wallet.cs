using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsAdvanced
{
    class Wallet
    {
        BankInterface bank;
        MoneyPrinterInterface moneyPrinter;

        List<WalletSlot> slots;

        public Wallet(BankInterface bank, MoneyPrinterInterface moneyPrinter)
        {
            this.bank = bank;
            this.moneyPrinter = moneyPrinter;

            slots = new List<WalletSlot>();
        }

        public void addMoney(string valute, int amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            } else if(amount == 0)
            {
                return;
            } 

            WalletSlot valuteSlot = slots.FirstOrDefault(slot => slot.valute.Equals(valute));
            if(valuteSlot == null)
            {
                valuteSlot = new WalletSlot { valute = valute, amount = 0 };
                slots.Add(valuteSlot);
            }

            valuteSlot.amount += amount;

            moneyPrinter.print("addMoney", valute, amount);
        }

        public void removeMoney(string valute, int amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            } else if(amount == 0)
            {
                return;
            }

            WalletSlot valuteSlot = slots.FirstOrDefault(slot => slot.valute.Equals(valute));
            if(valuteSlot == null || amount > valuteSlot.amount)
            {
                throw new ArgumentOutOfRangeException();
            }           
           
            valuteSlot.amount -= amount;

            if (valuteSlot.amount == 0)
            {
                slots.Remove(valuteSlot);
            }

            moneyPrinter.print("removeMoney", valute, amount);
        }

        public int getMoney(string valute)
        {
            WalletSlot valuteSlot = slots.FirstOrDefault(slot => slot.valute.Equals(valute));
            
            return valuteSlot == null ? 0 : valuteSlot.amount;
        }

        public int getTotalMoney(string valute)
        {
            double amount = 0;

            foreach(WalletSlot slot in slots)
            {
                amount += bank.convert(slot.amount, slot.valute, valute);
            }

            return (int) Math.Floor(amount);
        }

        public int getValuteLength()
        {
            return slots.Count;
        }

        public override string ToString()
        {
            return "{" + string.Join(",", slots.Select(slot => " " + slot.amount + " " + slot.valute)) + (slots.Count != 0 ? " " : "") + "}";
        }       
    }
}
