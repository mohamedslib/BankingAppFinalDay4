namespace BankingDomain
{
    public interface INarcOnWithdrawals
    {
        void TellTheMan(BankAccount bankAccount, decimal amountToWithdraw);
    }
}