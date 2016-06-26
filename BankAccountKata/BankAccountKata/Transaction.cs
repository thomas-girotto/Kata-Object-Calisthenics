using System;
using BankAccountKata.Amounts;
using BankAccountKata.Utils;

namespace BankAccountKata
{
    public class Transaction
    {
        private readonly Amount _amount;
        private readonly DateTransaction _date;

        private Transaction(Amount amount)
        {
            _amount = amount;
            _date = new DateTransaction(DateTimeProvider.Current.Today);
        }

        public static Transaction Create(Amount amount)
        {
            var transaction = new Transaction(amount);
            return transaction;
        }

        public BankStatement BankStatement(Balance balance)
        {
            var statement = new BankStatement();
            _date.Contribute(statement);
            _amount.Contribute(statement);
            balance.Contribute(statement);
            return statement;
        }

        public Balance CalculLastBalance(Balance balance)
        {
            return _amount.CalculLastBalance(balance);
        }
    }
}
