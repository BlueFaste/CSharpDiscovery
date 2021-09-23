using System;
using System.Threading.Tasks;

using Bank.Exceptions;

namespace Bank.Account
{
    public class CurrentAccountWithdrawRules : IWithdrawRules
    {
        public bool VerifyAmount(Account account, decimal amount)
        {
            return account.OverdraftLimit <= account.Balance - amount && amount > 0;
        }
    }
}