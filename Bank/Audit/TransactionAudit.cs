using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Bank.Audit
{
    public class TransactionAudit : ITransactionAudit
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        /// <summary>
		/// Gets a list of transactions for the specified account
		/// </summary>
		public async Task<IEnumerable<Transaction>> GetAccountTransactionsAsync(int accountNumber)
        {
            return _transactions.Where(t => t.AccountNumber == accountNumber);
        }

		/// <summary>
		/// Writes a transaction
		/// </summary>
		public async Task WriteTransactionAsync(Transaction transaction)
        {
            _transactions.Add(transaction);
        }
    }
}