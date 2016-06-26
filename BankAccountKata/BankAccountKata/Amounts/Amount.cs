using System;
using System.Globalization;

namespace BankAccountKata.Amounts
{
    public abstract class Amount
    {
        protected readonly decimal _value;
        private const int ColLength = 9;

        protected Amount(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("value must be greater than 0");
            }
            _value = value;
        }

        public abstract Balance CalculLastBalance(Balance balance);

        public abstract void Contribute(BankStatement statement);
        
        protected string Formattedvalue()
        {
            var debit = _value.ToString("#.00", CultureInfo.InvariantCulture);
            return debit.PadRight(ColLength, ' ');
        }
    }
}
