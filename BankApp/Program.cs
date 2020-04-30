using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("**** Welcome to my bank! ****");
            while(true)
            { 
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Create an account");
            Console.WriteLine("2. Deposit money");
            Console.WriteLine("3. Withdraw money");
            Console.WriteLine("4. Print all accounts");
            Console.WriteLine("5. Print all transactions");

            var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the bank!");
                        return;
                    case "1":
                        Console.Write("Account name: ");
                        var accountName = Console.ReadLine();
                        Console.Write("Email address: ");
                        var emailAddress = Console.ReadLine();

                        var accountTypes = Enum.GetNames(typeof(TypeofAccounts));
                        for (var i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        var accountType = Enum.Parse<TypeofAccounts>(Console.ReadLine());

                        Console.WriteLine("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var account = Bank.CreateAccount(accountName, emailAddress, accountType, amount);
                        Console.WriteLine($"Account Number: {account.AccountNumber}, Account Name: {account.AccountName}, Email Address: {account.EmailAddress}, Balance: {account.Balance}, Created Date: {account.CreatedDate}, Account Type: {account.AccountType}");

                        break;

                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to deposit: ");
                        amount = Convert.ToInt32(Console.ReadLine());

                        Bank.Deposit(accountNumber, amount);
                        Console.Write("Deposit successfully completed.");
                        break;

                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to withdraw: ");
                        amount = Convert.ToInt32(Console.ReadLine());

                        Bank.Withdraw(accountNumber, amount);
                        Console.Write("Withdrawal successfully completed.");
                        break;
                    case "4":
                        PrintAllAccounts();
                        break;
                    case "5":
                        PrintAllAccounts();
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());

                        var transactions = Bank.GetTransactionsByAccountNumber(accountNumber);
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"Transaction Date: {transaction.TransactionDate}, Transaction Amount: {transaction.Amount}, Transaction Type: {transaction.TransactionType}, Account Number: {transaction.AccountNumber}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email Address: ");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAccounts(emailAddress);
            foreach (var a in accounts)
            {
                Console.WriteLine($"Account Number: {a.AccountNumber}, Account Name: {a.AccountName}, Email Address: {a.EmailAddress}, Balance: {a.Balance}, Created Date: {a.CreatedDate}, Account Type: {a.AccountType}");
            }
        }
    }
}
