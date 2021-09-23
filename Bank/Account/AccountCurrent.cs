using System.Threading.Tasks;
using System;
using Bank.Exceptions;

namespace Bank.Account
{
    public class AccountCurrent : IAccount
    {
        public int AccountNumber { get; } = 2;

		public decimal OverdraftLimit { get; set; }
		public decimal Balance { get; set; } = 0;
		public async Task DepositAsync(decimal amount)
        {
            if(amount < 0) throw new UnauthorizedAccountOperationException();
            Balance = Balance + amount;
        }
		public async Task WithdrawAsync(decimal amount)
        {
           if(amount < 0) throw new UnauthorizedAccountOperationException();
           if (Balance - amount < OverdraftLimit) throw new UnauthorizedAccountOperationException(); 
           Balance = Balance - amount;
        }
    }
}