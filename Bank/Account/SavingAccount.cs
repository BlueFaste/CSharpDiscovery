using System;
using System.Threading.Tasks;

using Bank.Audit;
using Bank.Exceptions;

namespace Bank.Account
{
    public class SavingAccount : AccountBase
    {
        public SavingAccount(int accountNumber, ITransactionAudit transactionAudit) : base(accountNumber, transactionAudit)
        { }

        public override decimal OverdraftLimit 
        { 
            get => 0;
            set => throw new UnauthorizedAccountOperationException();
        }

        protected override bool VerifyWithdrawAmount(decimal amount)
        {
            return Balance * 0.1M >= amount  && amount > 0;
        }
    }
}