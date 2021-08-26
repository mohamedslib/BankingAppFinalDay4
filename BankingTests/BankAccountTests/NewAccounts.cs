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
    public class NewAccounts
    {
        [Fact]
        public void NewAccountsHaveProperBalance()
        {
            var account = new BankAccount(
                new Mock<ICanCalculateBonuses>().Object,
                new Mock<INarcOnWithdrawals>().Object
              );

            decimal openingBalance = account.GetBalance();

            Assert.Equal(5000M, openingBalance);
        }
    }
}
