using System;
using System.Globalization;

namespace BankAccountKata.Amounts
{
    public class Balance
    {
        private readonly decimal _value;

        private Balance(decimal value)
        {
            _value = value;
        }

        public static Balance Create(decimal value)
        {
            return new Balance(value);
        }

        public Balance Add(decimal value)
        {
            return new Balance(_value + value);
        }

        public Balance Substract(decimal value)
        {
            return new Balance(_value - value);
        }

        public void Contribute(BankStatement statement)
        {
            var formattedBalance = _value.ToString("#.00", CultureInfo.InvariantCulture);
            var partialStatement = string.Format(" {0}", formattedBalance.PadRight(9));
            statement.Add(partialStatement);
        }
    }
}
