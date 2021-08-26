using BankingDomain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests.BankAccountTests
{
    public class BankAccountBonusCalculatorInteractionTests
    {

        [Fact]
        public void BonusCalculatorIsUsedProperly()
        {
            // Given
            var stubbedBonusCalculator = new Mock<ICanCalculateBonuses>();
            var account = new BankAccount(
                stubbedBonusCalculator.Object,
                new Mock<INarcOnWithdrawals>().Object);

            var openingBalance = account.GetBalance();
            var amountToDeposit = 53.25M;

            stubbedBonusCalculator.Setup(x => 
                x.GetDepositBonusFor(openingBalance, amountToDeposit))
                .Returns(42m);

            // When
            account.Deposit(amountToDeposit);
            // Then 
            Assert.Equal(openingBalance + amountToDeposit + 42M, account.GetBalance());

        }
    }

    public class StubbedBonusCalculator : ICanCalculateBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            return balance == 5000M && amountToDeposit == 53.25M ? 42 : 0;
        }
    }
}
