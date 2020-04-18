using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating an instance of an account == object!
            var myFirstAccount = Bank.CreateAccount("My checking", "test@test.com", TypeofAccounts.Checking);
            myFirstAccount.Deposit(123455);
            Console.WriteLine($"AN: {myFirstAccount.AccountNumber}, Name:{myFirstAccount.AccountName}, Email: {myFirstAccount.EmailAddress}, B: {myFirstAccount.Balance:C}, CD: {myFirstAccount.CreatedDate}, AT: {myFirstAccount.AccountType}");

            var mySecondAccount = Bank.CreateAccount("My saving", "test@test.com", TypeofAccounts.Saving);
            Console.WriteLine($"AN: {mySecondAccount.AccountNumber}, Name: {mySecondAccount.AccountName}, Email: {mySecondAccount.EmailAddress}, B: {mySecondAccount.Balance:C}, CD: {mySecondAccount.CreatedDate}, AT: {mySecondAccount.AccountType}");

            var myThirdAccount = Bank.CreateAccount("My CD", "test@test.com", TypeofAccounts.CD);
            Console.WriteLine($"AN: {myThirdAccount.AccountNumber}, Name: {myThirdAccount.AccountName}, Email: {myThirdAccount.EmailAddress}, B: {myThirdAccount.Balance:C}, CD: {myThirdAccount.CreatedDate}, AT: {myThirdAccount.AccountType}");

            var myFourthAccount = Bank.CreateAccount("My Loan", "test@test.com", TypeofAccounts.Loan);
            Console.WriteLine($"AN: {myFourthAccount.AccountNumber}, Name: {myFourthAccount.AccountName}, Email: {myFourthAccount.EmailAddress}, B: {myFourthAccount.Balance:C}, CD: {myFourthAccount.CreatedDate}, AT: {myFourthAccount.AccountType}");

            var myFifthAccount = Bank.CreateAccount("My Loan", "test@test.com", TypeofAccounts.Loan);
            Console.WriteLine($"AN: {myFifthAccount.AccountNumber}, Name: {myFifthAccount.AccountName}, Email: {myFifthAccount.EmailAddress}, B: {myFifthAccount.Balance:C}, CD: {myFifthAccount.CreatedDate}, AT: {myFifthAccount.AccountType}");
        }
    }
}
