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
    public class BankAccountDepositAndWithdrawalGuardsTests
    {


        [Fact]
        public void AmountForWithdrawIsPositive()
        {
            var account = new BankAccount(
               new Mock<ICanCalculateBonuses>().Object,
               new Mock<INarcOnWithdrawals>().Object);

            var openingBalance = account.GetBalance();
            var amountToWithdraw = -100;

            try
            {
                account.Withdraw(amountToWithdraw);
            }
            catch (TransactionOutOfRangeException)
            {
                // gulp!
            }

            Assert.Equal(
                5000,
                account.GetBalance());
        }

        [Fact]
        public void ExceptionIsThrownOnBadInput()
        {
            var account = new BankAccount(
              new Mock<ICanCalculateBonuses>().Object,
              new Mock<INarcOnWithdrawals>().Object);

           
            var amountToWithdraw = -100;


            Assert.Throws<TransactionOutOfRangeException>(() => account.Withdraw(amountToWithdraw));

        }
    }
}
