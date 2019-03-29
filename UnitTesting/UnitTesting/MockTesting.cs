using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    public interface ILogForMock
    {
        bool write(string msg);
    }
    
    public class BankAccountForMock
    {
        public int Balance { get; set; }
        private ILogForMock log;

        public BankAccountForMock(ILogForMock log)
        {
            this.log = log;
        }

        public void Deposit(int amount)
        {
            log.write($"User has deposited {amount}");
            Balance += amount;
        }
    }
}
