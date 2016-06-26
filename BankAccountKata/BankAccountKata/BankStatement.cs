using System;
using BankAccountKata.Amounts;

namespace BankAccountKata
{
    public class BankStatement
    {
        private string _value;

        public void Add(string value)
        {
            _value += value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}