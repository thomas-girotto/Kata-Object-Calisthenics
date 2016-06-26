using BankAccountKata.Utils;
using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankAccountKata.Test
{
    public class BankAccountTest
    {
        private BankAccount _bankAccount;
        private FakePrinter _printer;

        [SetUp]
        public void Setup()
        {
            _bankAccount = new BankAccount();
            _printer = new FakePrinter();
            DateTimeProvider.SetACustomDateTimeProvider(
                new ConstantDateTimeProvider(new DateTime(2016, 1, 1)));
        }

        [Test]
        public void Add_one_credit_should_print_one_bankStatement()
        {
            _bankAccount.AddCredit(1000);
            _bankAccount.Print(_printer);
            Check.That(_printer.Statements.Count).Equals(1);
            Check.That(_printer.Statements[0].ToString())
                .Equals("01/01/2016 || 1000.00  ||          || 1000.00  ");
        }

        [Test]
        public void Add_two_credit_should_print_the_right_balance_history()
        {
            _bankAccount.AddCredit(1000);
            // let's say we're tomorrow, then add 1000 once again
            DateTimeProvider.SetACustomDateTimeProvider(
                new ConstantDateTimeProvider(new DateTime(2016, 1, 2)));
            _bankAccount.AddCredit(1000);
            _bankAccount.Print(_printer);
            Check.That(_printer.Statements.Count).Equals(2);
            Check.That(_printer.Statements[0].ToString())
                .Equals("02/01/2016 || 1000.00  ||          || 2000.00  ");
            Check.That(_printer.Statements[1].ToString())
                .Equals("01/01/2016 || 1000.00  ||          || 1000.00  ");
        }

        [Test]
        public void Add_1000_credit_and_400_debit_should_give_600_for_last_balance()
        {
            _bankAccount.AddCredit(1000);
            _bankAccount.AddDebit(400);
            _bankAccount.Print(_printer);
            Check.That(_printer.Statements.Count).Equals(2);
            Check.That(_printer.Statements[0].ToString())
                .Equals("01/01/2016 ||          || 400.00   || 600.00   ");
            Check.That(_printer.Statements[1].ToString())
                .Equals("01/01/2016 || 1000.00  ||          || 1000.00  ");
        }

        [TearDown]
        public void Teardown()
        {
            DateTimeProvider.BackToDefault();
        }
    }

    public class FakePrinter : IPrinter
    {
        public FakePrinter()
        {
            Statements = new List<BankStatement>();
        }

        // Let's say that's ok to have getter setter in tests
        public List<BankStatement> Statements { get; set; }

        public void PrintLine(BankStatement statement)
        {
            Statements.Add(statement);
        }
    }
}
