using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDomain
{
    public class SuperBonusCalculator : ICanCalculateBonuses
    {
        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            return balance >= 5000M ? amountToDeposit * .10M : 0;
        }
    }
}
