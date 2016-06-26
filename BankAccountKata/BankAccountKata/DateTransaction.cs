using System;

namespace BankAccountKata
{
    public struct DateTransaction
    {
        public DateTransaction(DateTime value)
        {
            _value = value;
        }
        private DateTime _value;

        public void Contribute(BankStatement statement)
        {
            statement.Add(_value.ToString("dd/MM/yyyy") + " ");
        }
    }
}
