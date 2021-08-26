using System;

namespace BankingDomain
{
    public class TimeRestrictedBonusCalculator : ICanCalculateBonuses
    {
        private readonly ISystemTime _systemTime;

        public TimeRestrictedBonusCalculator(ISystemTime systemTime)
        {
            _systemTime = systemTime;
        }

        public decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit)
        {
            return _systemTime.GetCurrent().Hour >= 17 ? 0 : amountToDeposit * .10M;
        }
    }
}