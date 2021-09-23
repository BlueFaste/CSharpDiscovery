using System;
using System.Threading.Tasks;

using Bank.Exceptions;

namespace Bank.Account
{
    public class SavingAccountWithdrawRules : IWithdrawRules
    {
        public bool VerifyAmount(Account account, decimal amount)
        {
            return account.Balance * 0.1M >= amount  && amount > 0;
        }
    }
}