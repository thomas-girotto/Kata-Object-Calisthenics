using System;
using System.Globalization;

namespace BankAccountKata.Amounts
{
    public class Credit : Amount
    {
        public Credit(decimal value) : base(value) { }

        public override Balance CalculLastBalance(Balance balance)
        {
            return balance.Substract(_value);
        }
        
        public override void Contribute(BankStatement statement)
        {
            var partOfStatement = string.Format("|| {0}||          ||", Formattedvalue());
            statement.Add(partOfStatement);
        }
    }
}
