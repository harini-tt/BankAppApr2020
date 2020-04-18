using System;
namespace BankApp
{
    static class Bank
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountName"></param>
        /// <param name="emailAddress"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public static Account CreateAccount(string accountName, string emailAddress, TypeofAccounts accountType)
        {
            var account = new Account
            {
                AccountName = accountName,
                EmailAddress = emailAddress,
                AccountType = accountType
            };
            return account;
        }
    }
}
