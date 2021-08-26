namespace BankingDomain
{
    public interface ICanCalculateBonuses
    {
        decimal GetDepositBonusFor(decimal balance, decimal amountToDeposit);
    }
}