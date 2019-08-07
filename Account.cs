using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public enum TypeOfAccount
    {
        Savings,
        Checking,
        CD,
        Loan
    }
   public class Account
    {
      

        
       // static int lastAccountNumber = 1;
       
        public Account()
        {
          //  AccountNumber = lastAccountNumber++;

            CreatedDate = DateTime.Now;
            
                
        }

        /// <summary>
        /// Defines features of account
        /// </summary>
        public int AccountNumber { get; set; }
        public TypeOfAccount AccountType { get; set; }
        public decimal Balance { get; set; }
        public string EmailAddress { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public decimal Deposit(decimal amount)
        {
            Balance = Balance + amount;
            return Balance;
        }

        public decimal Withdrawl(decimal amount)
        {
            Balance = Balance - amount;
            return Balance;
        }

    }
}
