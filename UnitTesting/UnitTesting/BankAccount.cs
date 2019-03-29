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
            if(amount <= 0)
            {
                throw new ArgumentException("Non Positive Number", nameof(amount));
            }
            Balance += amount;
        }

        public bool withdraw(int amount)
        {
            if(Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void SampleAsserts()
        {
            //Success
            //Assert.That(2 + 2, Is.EqualTo(4));

            //Failure
            //Assert.That(2 + 2, Is.EqualTo(5));
            //throw new Exception();
            //Assert.Fail("This Test Will Fail");

        }

        [Test]
        public void SampleWarnings()
        {
            //Inconclusive
            //Assert.Inconclusive();

            //Warning
            //Assert.Warn("This is not good");

            //Warn.If(2 + 2 != 5);
            //Warn.If(2 + 2, Is.Not.EqualTo(5));
            //Warn.If(() => 2 + 2, Is.Not.EqualTo(5).After(2000));

            //Warn.Unless(2 + 2 == 5);
            //Warn.Unless(2 + 2, Is.EqualTo(5));
            //Warn.Unless(() => 2 + 2, Is.EqualTo(5).After(2000));
        }

        private BankAccount ba;

        [SetUp]
        public void Setup()
        {
            ba = new BankAccount(100);
        }

        [Test]
        public void BankAccountShouldIncreaseOnPositiveDeposit()
        {
            //AAA

            //Arange
            //Initialized in Setup;

            //Act
            ba.Deposit(100);

            //Assert
            Assert.That(ba.Balance, Is.EqualTo(200));

        }

        [Test]
        public void BankAccountShouldThrowOnNonPositiveDeposit()
        {
            var ex = Assert.Throws<ArgumentException>(
                () => ba.Deposit(-1)
            );

            StringAssert.StartsWith("Non Positive Number", ex.Message);
        }
    }

    [TestFixture]
    public class DataDrivenTest
    {

        private BankAccount ba;

        [SetUp]
        public void Setup()
        {
            ba = new BankAccount(100);
        }

        [Test]
        [TestCase(50,true,50)]
        [TestCase(100,true,0)]
        [TestCase(1000, false, 100)]
        public void TestMultipleWithdrwalScenarios(int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            var result = ba.withdraw(amountToWithdraw);
            //Warn.If(!result, "Failed for some reason");
            Assert.Multiple(() => {
                Assert.That(result, Is.EqualTo(shouldSucceed));
                Assert.That(expectedBalance, Is.EqualTo(ba.Balance));
            });
            
        }

    }
}
