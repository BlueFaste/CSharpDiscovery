using System;
using System.Threading.Tasks;

namespace Bank.Account
{
    public interface IWithdrawRules
    {
        bool VerifyAmount(Account account, decimal amount);
    }
}