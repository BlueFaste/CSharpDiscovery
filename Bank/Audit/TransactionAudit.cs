using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var transactions = new List<Transaction>();

            foreach (var trans in _transactions)
            {
                if (trans.AccountNumber == accountNumber)
                    transactions.Add(trans);
            }

            return transactions;
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