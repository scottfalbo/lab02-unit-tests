using System;
using Xunit;
using FakeATM;

namespace FakeATMTests
{
    public class UnitTest1
    {
        [Fact]
        public void CheckBalanceTest()
        {
            decimal balance = Program.balance;
            Assert.Equal(Program.balance, balance);
        }

        [Fact]
        public void WithdrawTest()
        {
            decimal expected = Program.balance - 500;
            decimal result = Program.Withdraw(500);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DepositTest()
        {
            decimal expected = Program.balance + 500;
            decimal result = Program.Deposit(500);
            Assert.Equal(expected, result);
        }
    }
}
