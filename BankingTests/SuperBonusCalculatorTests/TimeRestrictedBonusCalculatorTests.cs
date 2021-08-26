using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BankingDomain;
using Moq;

namespace BankingTests.SuperBonusCalculatorTests
{
    public class TimeRestrictedBonusCalculatorTests
    {
        [Fact]
        public void DepositsBeforeCutoffGetBonus()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(
                    new DateTime(1969,4,20,16,59,59)
                );
            ICanCalculateBonuses bonusCalculator = new TimeRestrictedBonusCalculator(stubbedClock.Object);

            var bonus = bonusCalculator.GetDepositBonusFor(99, 100);

            Assert.Equal(10, bonus);
            
        }

        [Fact]
        public void DepositsAfterCutoffDoNotGetBonus()
        {
            var stubbedClock = new Mock<ISystemTime>();
            stubbedClock.Setup(c => c.GetCurrent()).Returns(
                    new DateTime(1969, 4, 20, 17, 00, 01)
                );
            ICanCalculateBonuses bonusCalculator = new TimeRestrictedBonusCalculator(stubbedClock.Object);

            var bonus = bonusCalculator.GetDepositBonusFor(99, 100);

            Assert.Equal(0, bonus);
        }
           


    }
}
