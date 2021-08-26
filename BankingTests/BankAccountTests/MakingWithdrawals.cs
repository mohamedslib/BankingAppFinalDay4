using BankingDomain;
using BankingTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests
{
    public class MakingWithdrawals
    {
        private readonly BankAccount _account;
        private readonly decimal _openingBalance;
        public MakingWithdrawals()
        {
            _account = new BankAccount(new DummyBonusCalculator(), new Mock<INarcOnWithdrawals>().Object);
            _openingBalance = _account.GetBalance();
        }

        [Fact]
        public void WithdrawalsDecreaseBalance()
        {
            // Given
           
            var amountToWithdraw = 10M;
            // When
            _account.Withdraw(amountToWithdraw);
            // Then
            Assert.Equal(_openingBalance - amountToWithdraw, _account.GetBalance());
        }

        // Replicate the bad behavior (this should pass when you start, demonstrating where the problem is)


        [Fact]
        public void OverdraftNotAllowed()
        {
          
            var amountToWithrdaw = _openingBalance + 1;

            try
            {
                _account.Withdraw(amountToWithrdaw);
            }
            catch (OverdraftException)
            {

                // cool. No problem. Was Expecting that.
            }

            Assert.Equal(_openingBalance, _account.GetBalance());
        }

        [Fact]
        public void OverdraftThrowsException()
        {
           

            Assert.Throws<OverdraftException>(() =>
                _account.Withdraw(_account.GetBalance() + 0.1M)
            );
        }

        [Fact]
        public void CanTakeAllTheMoney()
        {
            // Given - Arrange - Establish Context
           

            // When - Act 
            _account.Withdraw(_openingBalance);

            // Then - Assert 
            Assert.Equal(0, _account.GetBalance());
        }
    }
}
