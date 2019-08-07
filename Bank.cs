using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
  public static class Bank
    {
        // private static List<Account> AllAccounts = new List<Account>();
        private static BankModel db = new BankModel();
        public static Account CreateAccount(String emailAddress,TypeOfAccount accountType, decimal amount)
        {
            var account = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType,
            };
            if (amount > 0)
            {
                account.Deposit(amount);
            }
            // AllAccounts.Add(account);
            db.Accounts.Add(account);
            db.SaveChanges();

            return account;

        }

       public static IEnumerable<Account> GetAllAccounts(string emailaddress)
        {
            // return AllAccounts;
          return  db.Accounts.Where(a=>a.EmailAddress==emailaddress);
        }

        public static void Deposit(int accountnumber,decimal amount)
        {
           var account= db.Accounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
            if (account == null)
            {
                return;
            }
            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Credit,
                Description = "Bank Deposit",
                Amount = amount,
                AccountNumber=accountnumber

            };
            db.Transactions.Add(transaction);

            db.SaveChanges();
        }
        public static IEnumerable<Transaction> GetAllTransactions(int accountnumber)
        {
            return db.Transactions.Where(t=>t.AccountNumber==accountnumber).OrderByDescending(t=>t.TransactionDate);
            

        }



            public static void Withdrawl(int accountnumber, decimal amount)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
            if (account == null)
            {
                return;
            }
            account.Withdrawl(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TypeOfTransaction = TransactionType.Debit,
                Description = "Bank Withdrawl",
                Amount = amount,
                AccountNumber=accountnumber
                

            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
