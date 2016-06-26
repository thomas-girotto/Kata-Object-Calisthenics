using System.Globalization;

namespace BankAccountKata.Amounts
{
    public class Debit : Amount
    {
        public Debit(decimal value) : base(value) { }

        public override Balance CalculLastBalance(Balance balance)
        {
            return balance.Add(_value);
        }

        public override void Contribute(BankStatement statement)
        {
            var partOfStatement = string.Format("||          || {0}||", Formattedvalue());
            statement.Add(partOfStatement);
        }
    }
}
