using System;
using System.Threading.Tasks;

using Bank.Exceptions;

namespace Bank.Account
{
    public class Account : IAccount
    {
        public int AccountNumber { get; } = 0;
		
		public decimal OverdraftLimit { get; set; }
		
        public decimal Balance { get; } = 0;
		
        public async Task DepositAsync(decimal amount)
        {
			if (amount < 0) throw new UnauthorizedAccountOperationException();
        }

		public async Task WithdrawAsync(decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}