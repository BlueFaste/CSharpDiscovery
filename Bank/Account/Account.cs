using System;
using System.Threading.Tasks;

using Bank.Exceptions;

namespace Bank.Account
{
    public class Account : IAccount
    {
        private IWithdrawRules _withdrawRules;

        public int AccountNumber { get; } = 0;

        public Account(int accountNumber, IWithdrawRules withdrawRules)
        {
            if (withdrawRules == null) throw new ArgumentNullException(nameof(withdrawRules));

            AccountNumber = accountNumber;
            _withdrawRules = withdrawRules;
        }
		
		public decimal OverdraftLimit { get; set; }
		
        public decimal Balance { get; private set; }
		
        public async Task DepositAsync(decimal amount)
        {
			if (amount < 0) throw new UnauthorizedAccountOperationException();

            Balance += amount;
        }

		public async Task WithdrawAsync(decimal amount)
        {
            if (!_withdrawRules.VerifyAmount(this, amount)) throw new UnauthorizedAccountOperationException();
            Balance -= amount;
        }
    }
}