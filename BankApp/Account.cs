﻿using System;
namespace BankApp
{
    enum TypeofAccounts
    {
        Checking = 101,
        Saving,
        CD = 140,
        Loan
    }

    /// <summary>
    /// This class represents a bank account,
    /// where you can deposit, withdraw...
    /// </summary>
    class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        public int AccountNumber { get; private set; }
        public string EmailAddress { get; set; }
        public string AccountName { get; set; }
        public TypeofAccounts AccountType { get; set; }
        public decimal Balance { get; private set; }
        public DateTime CreatedDate { get; private set; }
        #endregion

        #region Constructor
        public Account()
        {
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to deposit</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public decimal Withdraw(decimal amount)
        {
            Balance -= amount;
            return Balance;
        }
        #endregion
    }
}