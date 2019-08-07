using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
   static class Bank
    {
        private static List<Account> AllAccounts = new List<Account>();
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
            AllAccounts.Add(account);
            return account;

        }

       public static IEnumerable<Account> GetAllAccounts()
        {
            return AllAccounts;
        }

        public static void Deposit(int accountnumber,decimal amount)
        {
           var account= AllAccounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
            if (account == null)
            {
                return;
            }
            account.Deposit(amount);
        }

        public static void Withdrawl(int accountnumber, decimal amount)
        {
            var account = AllAccounts.SingleOrDefault(a => a.AccountNumber == accountnumber);
            if (account == null)
            {
                return;
            }
            account.Withdrawl(amount);
        }
    }
}
