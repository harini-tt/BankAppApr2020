using System;
namespace BankApp
{
    enum TypeofTransaction
    {
        Credit,
        Debit
    }
    class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TypeofTransaction TransactionType { get; set; }
        public int AccountNumber { get; set; }
    }
        
}
