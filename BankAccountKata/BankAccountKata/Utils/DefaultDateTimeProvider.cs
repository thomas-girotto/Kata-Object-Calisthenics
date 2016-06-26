using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountKata.Utils
{
    public class DefaultDateTimeProvider : DateTimeProvider
    {
        public override DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }
    }
}
