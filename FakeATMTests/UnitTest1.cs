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

        [Theory]
        [InlineData(true, "300.65")]
        [InlineData(true, "100")]
        [InlineData(false, "money me")]
        [InlineData(false, "-750.00")]
        public void ValidateInputTest(bool expected, string testInput)
        {
            bool result = Program.ValidInputAmount(testInput);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void OverDrawTest()
        {
            decimal expected = Program.balance;
            decimal testInput = decimal.Add(expected, expected + 1);
            decimal result = Program.Withdraw(testInput);
            Assert.Equal(expected, result);
        }
    }
}
