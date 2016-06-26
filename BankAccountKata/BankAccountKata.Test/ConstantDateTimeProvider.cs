using BankAccountKata.Utils;
using System;

namespace BankAccountKata.Test
{
    public class ConstantDateTimeProvider : DateTimeProvider
    {
        private DateTime _constantNow;

        public ConstantDateTimeProvider(DateTime now)
        {
            _constantNow = now;
        }
        public override DateTime Today
        {
            get
            {
                return _constantNow.Date;
            }
        }
    }
}
