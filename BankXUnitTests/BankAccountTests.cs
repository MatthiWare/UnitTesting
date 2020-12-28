using Bank;
using System;
using Xunit;

namespace BankXUnitTests
{
    public class BankAccountTests
    {
        [Fact]
        public void Adding_Funds_Updates_Balance()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT
            account.Add(100);

            // ASSERT
            Assert.Equal(1100, account.Balance);
        }

        [Fact]
        public void Adding_Negative_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-100));
        }

        [Fact]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT
            account.Withdraw(100);

            // ASSERT
            Assert.Equal(900, account.Balance);
        }

        [Fact]
        public void Withdrawing_Negative_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-100));
        }

        [Fact]
        public void Withdrawing_More_Than_Funds_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Fact]
        public void Transfering_Funds_Updates_Both_Accounts()
        {
            // ARRANGE
            var account = new BankAccount(1000);
            var otherAccount = new BankAccount();

            // ACT
            account.TransferFundsTo(otherAccount, 500);

            // ASSERT
            Assert.Equal(500, account.Balance);
            Assert.Equal(500, otherAccount.Balance);
        }

        [Fact]
        public void TransferFundsTo_Non_Existing_Account_Throws()
        {
            // ARRANGE
            var account = new BankAccount(1000);

            // ACT + ASSERT
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 2000));
        }
    }
}
