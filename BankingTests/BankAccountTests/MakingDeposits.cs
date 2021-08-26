using BankingDomain;
using BankingTests.TestDoubles;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests.BankAccountTests
{
    public class MakingDeposits
    {
        [Fact]
        public void DepositsIncreaseBalance()
        {
            var account = new BankAccount(
                new DummyBonusCalculator(),
                 new Mock<INarcOnWithdrawals>().Object
                );
            var openingBalance = account.GetBalance();
            var amountToDeposit = 10M;

            account.Deposit(amountToDeposit);

            Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
        }
    }
}
