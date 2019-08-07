using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank");
            Console.WriteLine("Please select an option");
            while (true)
            {

            
            Console.WriteLine("1. Exit");
            Console.WriteLine("2. Create a new account");
            Console.WriteLine("3. Deposit money");
            Console.WriteLine("4. Withdrawl");
            Console.WriteLine("5. Print all accounts");
                Console.WriteLine("6. Print all Transactions");

            var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        return;

                    case "2":
                        Console.WriteLine("Please enter your name");
                        var Name = Console.ReadLine();
                        Console.WriteLine("Please enter your email address");
                        var emailaddress = Console.ReadLine();
                        Console.WriteLine("Please select an account type");

                        //  foreach  (var S in Enum.GetNames(typeof(TypeOfAccount)))
                        //  {
                        //   Console.WriteLine(S);

                        // }

                        var s = Enum.GetNames(typeof(TypeOfAccount));
                        for (int i = 0; i < s.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}.{s[i] }");

                        }

                        var option1 = Convert.ToInt32(Console.ReadLine());
                        //var accountType=Enum.GetNames
                        var accountType = Enum.Parse<TypeOfAccount>(s[option1 - 1]);

                        Console.WriteLine("Please enter the intial deposit");

                        var initialAmount = Convert.ToInt32(Console.ReadLine());

                        var account = Bank.CreateAccount(emailaddress, accountType, initialAmount);
                        Console.WriteLine($"{account.AccountNumber}, {account.EmailAddress} , {account.AccountType} , {account.Balance:C} , {account.CreatedDate}");
                        break;

                    case "3":
                        Console.WriteLine("Enter account number");
                        var accountNum = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the amount to deposit");
                        var amount = Convert.ToDecimal(Console.ReadLine());
                        Bank.Deposit(accountNum, amount);
                        
                        break;

                    case "4":
                        Console.WriteLine("Enter account number");
                        var accountNum1= Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the amount to deposit");
                        var amount1 = Convert.ToDecimal(Console.ReadLine());
                        Bank.Withdrawl(accountNum1, amount1);

                        break;

                    case "5":
                        Console.WriteLine("Printing all the accounts");
                        PrintAllAccounts();


                        break;

                    case "6":
                        
                        PrintAllAccounts();
                        Console.WriteLine("Enter Account Number: ");
                        accountNum = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Printing all the Transactions");
                       var t= Bank.GetAllTransactions(accountNum);

                        foreach (var item in t)
                        {

                            Console.WriteLine($"{item.TransactionId}, {item.TypeOfTransaction} , {item.TransactionDate},{item.Amount}");


                        }




                        break;

                    default:
                        break;
                }
            }
        }

        private static void PrintAllAccounts()
        {
            var accounts1 = Bank.GetAllAccounts();
            foreach (var item in accounts1)
            {
                
                Console.WriteLine($"{item.AccountNumber}, {item.EmailAddress} , {item.AccountType} , {item.Balance:C} ," +
                    $" {item.CreatedDate}");

            }
        }
    }
}
