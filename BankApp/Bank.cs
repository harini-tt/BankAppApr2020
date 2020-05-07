using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankApp
{
    static class Bank
    {
        private static BankContext db = new BankContext();
        /// <summary>
        /// Create an account with the bank
        /// </summary>
        /// <param name="accountName">Name of the account</param>
        /// <param name="emailAddress">Account holder's email address</param>
        /// <param name="accountType">Type of account</param>
        /// <returns></returns>
        public static Account CreateAccount(string accountName,
            string emailAddress, TypeofAccounts accountType = TypeofAccounts.Checking, decimal initialAmount = 0)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            if (initialAmount > 0)
            {
                Deposit(account.AccountNumber, initialAmount);
            }

            return account;
        }

        public static IEnumerable<Account> GetAccounts(string emailAddress)
        {
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction> GetTransactionsByAccountNumber(int accountNumber)
        {
            return db.Transactions
                    .Where(t => t.AccountNumber == accountNumber)
                    .OrderByDescending(t => t.TransactionDate);
        }

        public static void Deposit(int accountNumber, decimal amount)
        {
            //Locate the account
            //LINQ
            var account = db.Accounts.SingleOrDefault(account => account.AccountNumber == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Account number is invalid!");
                return;
            }
            //Deposit on the account

            account.Deposit(amount);
            //add a transaction
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Branch deposit",
                Amount = amount,
                TransactionType = TypeofTransaction.Credit,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }


        public static void Withdraw(int accountNumber, decimal amount)
        {
            //Locate the account
            //LINQ
            var account = db.Accounts.SingleOrDefault(account => account.AccountNumber == accountNumber);

            if (account == null)
            {
                Console.WriteLine("Account number is invalid!");
                return;
            }
            //Deposit on the account

            account.Withdraw(amount);
            //add a transaction
            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                Description = "Branch Withdrawal",
                Amount = amount,
                TransactionType = TypeofTransaction.Debit,
                AccountNumber = accountNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }

    }
}
