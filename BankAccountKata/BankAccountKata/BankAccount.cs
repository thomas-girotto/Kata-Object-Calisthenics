using BankAccountKata.Amounts;

namespace BankAccountKata
{
    public class BankAccount 
    {
        private TransactionsHistory _history = new TransactionsHistory();
        private Balance _balance;

        public BankAccount()
        {
            _balance = Balance.Create(0);
        }

        public void AddCredit(decimal amount)
        {
            _balance = _balance.Add(amount);
            var credit = new Credit(amount);
            _history.Add(Transaction.Create(credit));
        }

        public void AddDebit(decimal amount)
        {
            _balance = _balance.Substract(amount);
            var debit = new Debit(amount);
            _history.Add(Transaction.Create(debit));
        }

        public void Print(IPrinter printer)
        {
            var balanceInHistory = _balance;
            foreach (var transaction in _history)
            {
                var statement = transaction.BankStatement(balanceInHistory);
                balanceInHistory = transaction.CalculLastBalance(balanceInHistory);
                printer.PrintLine(statement);
            }
        }
    }
}
