using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTesting
{
    class BankAccount
    {

        public int Balance { get; private set; }
        public BankAccount(int startingBalance)
        {
            Balance = startingBalance;
        }

        public void Deposit(int amount)
        {

        }

        public void withdraw(int amount)
        {

        }
    }

}

[TestFixture]

public class BankAccountTests
{
    [Test]
    public void BankAccountShouldIncreaseOnPositiveDeposit()
    {

    }
}
