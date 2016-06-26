using BankAccountKata.Amounts;
using BankAccountKata.Utils;
using NFluent;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountKata.Test
{
    public class TransactionTest
    {
        [SetUp]
        public void Setup()
        {
            DateTimeProvider.SetACustomDateTimeProvider(
                new ConstantDateTimeProvider(new DateTime(2016, 1, 1)));
        }

        [Test]
        public void Bank_statement_should_begin_with_today()
        {
            var transaction = Transaction.Create(new Credit(1000));
            var bankStatement = transaction.BankStatement(Balance.Create(500));
            Compare(bankStatement, "01/01/2016 ");
        }

        [Test]
        public void Bank_statement_should_have_separator_at_12th_caracter()
        {
            var transaction = Transaction.Create(new Credit(1000));
            var bankStatement = transaction.BankStatement(Balance.Create(500));
            Compare(bankStatement, "01/01/2016 ||");
        }

        [Test]
        public void Credit_Bank_statement_should_be_displayed_after_date()
        {
            var transaction = Transaction.Create(new Credit(1000));
            var bankStatement = transaction.BankStatement(Balance.Create(500));
            Compare(bankStatement, "01/01/2016 || 1000.00");
        }

        [Test]
        public void Bank_statement_should_have_separator_after_credit()
        {
            var transaction = Transaction.Create(new Credit(1000));
            var bankStatement = transaction.BankStatement(Balance.Create(500));
            Compare(bankStatement, "01/01/2016 || 1000.00  ||");
        }

        [Test]
        public void Credit_Bank_statement_should_not_have_any_debit_information()
        {
            var transaction = Transaction.Create(new Credit(1000));
            var bankStatement = transaction.BankStatement(Balance.Create(500));
            Compare(bankStatement, "01/01/2016 || 1000.00  ||          ||");
        }

        [Test]
        public void Debit_Bank_statement_should_not_have_any_credit_information()
        {
            var transaction = Transaction.Create(new Debit(1000));
            var bankStatement = transaction.BankStatement(Balance.Create(500));
            Compare(bankStatement, "01/01/2016 ||          || 1000.00  ||");
        }

        [Test]
        public void Bank_statement_should_have_balance_at_the_end()
        {
            var transaction = Transaction.Create(new Debit(1000));
            var bankStatement = transaction.BankStatement(Balance.Create(2500));
            Compare(bankStatement, "01/01/2016 ||          || 1000.00  || 2500.00");
        }

        [TearDown]
        public void Teardown()
        {
            DateTimeProvider.BackToDefault();
        }


        private void Compare(BankStatement statement, string toCheck)
        {
            if (statement.ToString().Length < toCheck.Length)
            {
                throw new AssertionException(string.Format(
                    "the bank statement is shorter than what we expect.\n bank statement: {0} \n expected string: {1} ", 
                    statement, toCheck));
            }

            char characterFromStatement;
            char characterToCheck;

            for (int i = 0; i < toCheck.Length; i++)
            {
                characterToCheck = toCheck[i];
                characterFromStatement = statement.ToString()[i];
                if (characterToCheck != characterFromStatement)
                {
                    throw new AssertionException(string.Format(
                        "The character at {0} is different than expected.\n Bank statement: {1}\n expected string: {2}", 
                        i, statement, toCheck));
                }
            }
        }
    }
}
