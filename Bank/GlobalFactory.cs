using System;
using Bank.Account;
using Bank.Audit;
using Bank.DateService;
using Bank.LockDown;

namespace Bank
{
	public enum AccountType
	{
		Current = 0,
		Saving = 1
	}

	/// <summary>
	/// This class creates instance of other class. The instance is guaranteed to stay the same for the duration of the test
	/// </summary>
	/// <remarks>
	/// You MUST modify this class as you see fit
	/// </remarks>
	public class GlobalFactory : IGlobalFactory
	{
		private LockDownManager _lockDownManager;
		private TransactionAudit _transactionAudit;

		public IAccount GetAccount(AccountType type, int accountNumber)
		{
			AccountBase account = null;
			if(type == AccountType.Current)
				account = new CurrentAccount(accountNumber, GetAudit());
			else
				account = new SavingAccount(accountNumber, GetAudit());

			var ldm = GetLockDownManager();

			ldm.LockDownStarted += account.OnLockDownStarted;
			ldm.LockDownEnded += account.OnLockDownEnded;

			return account;
		}

		public ITransactionAudit GetAudit()
		{
			if(_transactionAudit == null) _transactionAudit = new TransactionAudit();
			return _transactionAudit;
		}

		public ILockDownManager GetLockDownManager()
		{
			if(_lockDownManager == null)
			{
				_lockDownManager = new LockDownManager();
			}

			return _lockDownManager;
		}
		public IDateService GetDateService()
		{
			throw new NotImplementedException();
		}
	}
}