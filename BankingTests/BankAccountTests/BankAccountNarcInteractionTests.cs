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
    public class BankAccountNarcInteractionTests
    {
        [Fact]
        public void WithdrawalsNotifyTheFeds()
        {
            // Given
            var mockedNarc = new Mock<INarcOnWithdrawals>();
            var account = new BankAccount(
                new Mock<ICanCalculateBonuses>().Object,
                mockedNarc.Object
                );


            // When
            account.Withdraw(42.37M);


            // Then
            mockedNarc.Verify(x => x.TellTheMan(account, 42.37M));
            
        }
    }
}
