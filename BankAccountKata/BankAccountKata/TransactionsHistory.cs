using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountKata
{
    public class TransactionsHistory : IEnumerable<Transaction>
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public void Add(Transaction transaction)
        {
            _transactions.Insert(0, transaction);
        }

        public IEnumerator<Transaction> GetEnumerator()
        {
            return _transactions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _transactions.GetEnumerator();
        }
    }
}
