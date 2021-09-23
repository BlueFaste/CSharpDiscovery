using System;
using System.Threading.Tasks;

using Bank.Exceptions;

namespace Bank.Account
{
    public abstract class AccountBase : IAccount
    {
        public int AccountNumber { get; } = 0;

        public AccountBase(int accountNumber)
        {
            AccountNumber = accountNumber;
        }
		
		public virtual decimal OverdraftLimit { get; set; }
		
        public decimal Balance { get; private set; }
		
        public async Task DepositAsync(decimal amount)
        {
			if (amount < 0) throw new UnauthorizedAccountOperationException();

            Balance += amount;
        }

		public async Task WithdrawAsync(decimal amount)
        {
            //if ( OverdraftLimit > Balance - amount || amount < 0) throw new UnauthorizedAccountOperationException();
            if (!VerifyWithdrawAmount(amount)) throw new UnauthorizedAccountOperationException();
            Balance -= amount;
        }

        protected abstract bool VerifyWithdrawAmount(decimal amount);
    }
}