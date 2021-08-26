using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests.SuperBonusCalculatorTests
{
    public class BonusCalculatorTests
    {
        [Fact]
        public void DepositsBelowCutoffGetNoBonus()
        {
            var calculator = new SuperBonusCalculator();

            var bonus = calculator.GetDepositBonusFor(4999.99M, 100);

            Assert.Equal(0, bonus);
        }

        [Fact]
        public void DepositsAtCutoffGetBonus()
        {
            var calculator = new SuperBonusCalculator();

            var bonus = calculator.GetDepositBonusFor(5000M, 100);

            Assert.Equal(10, bonus);
        }

        [Fact]
        public void DepositsOverCutoffGetBonus()
        {
            var calculator = new SuperBonusCalculator();

            var bonus = calculator.GetDepositBonusFor(5001M, 100);

            Assert.Equal(10, bonus);
        }
    }
}
