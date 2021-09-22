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
		public IAccount GetAccount(AccountType type, int accountNumber)
		{
			return new Bank.Account.Account();
		}

		public ITransactionAudit GetAudit()
		{
			throw new NotImplementedException();
		}

		public ILockDownManager GetLockDownManager()
		{
			throw new NotImplementedException();
		}
		public IDateService GetDateService()
		{
			throw new NotImplementedException();
		}
	}
}