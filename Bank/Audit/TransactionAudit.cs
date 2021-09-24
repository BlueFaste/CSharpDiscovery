using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Bank.Audit
{
    public class TransactionAudit : ITransactionAudit
    {
        private readonly Dictionary<int, List<Transaction>> _transactions = new Dictionary<int, List<Transaction>>();

        /// <summary>
		/// Gets a list of transactions for the specified account
		/// </summary>
		public async Task<IEnumerable<Transaction>> GetAccountTransactionsAsync(int accountNumber)
        {
            if(!_transactions.ContainsKey(accountNumber)) return Enumerable.Empty<Transaction>();

            return _transactions[accountNumber];
        }

		/// <summary>
		/// Writes a transaction
		/// </summary>
		public async Task WriteTransactionAsync(Transaction transaction)
        {
            if (!_transactions.ContainsKey(transaction.AccountNumber))
            {
                _transactions.Add(transaction.AccountNumber, new List<Transaction>());
            }

            _transactions[transaction.AccountNumber].Add(transaction);
        }
    }
}