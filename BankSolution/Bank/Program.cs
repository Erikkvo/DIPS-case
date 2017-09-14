using System;
using System.Collections.Generic;
using System.Security.Principal;
using Money = System.Double;

namespace Bank
{
    public class Program
    {
//        ------------------------------------------------------------------------------------------------------------------------------------
//        NOTE: An unsuccessful attempt of running unit tests in "Jetbrains Rider" due to lack of time resulted in 'testing' code here.. Sorry
//        ------------------------------------------------------------------------------------------------------------------------------------
        public static void Main(string[] args)
        {
        
            try
            {
                // Try to run this code snippet. Exceptions will be caught
//                Create objects to work with
                Bank dnb = new Bank("DNB");
                Bank sparebank1 = new Bank("Sparebank 1");
                Person runar = new Person("Runar", "HanKarenSomIntervjuaMeg", 500000);
                Person andreas = new Person("Andreas", "HanDudenSomHookaMegOppMedIntervjuet", 750000);
                Person meg = new Person("Erik", "Ormevik", 23456);

//                "Test" methods within classes
                dnb.CreateAccount(runar, 200000);
//                dnb.CreateAccount(andreas, -20);    // Triggers exception, as initial amount is negative
                dnb.CreateAccount(meg, 15000);
                dnb.CreateAccount(meg, 29);    
//                sparebank1.CreateAccount(meg, 50000);    // Triggers exception, as customer does not have sufficient funds
            
                dnb.Deposit(meg.GetAccounts()[0], 333);
//                dnb.Deposit(meg.GetAccounts()[0], 2345678);    // Triggers exception, as customer's savings are less than deposit amount
//                dnb.Deposit(andreas.GetAccounts()[0], 444);    // Triggers exception, as account was not successfully created
                dnb.Withdraw(meg.GetAccounts()[1], 13);
//                dnb.Withdraw(meg.GetAccounts()[1], 6567586895);    // Triggers exception, as withdrawal amount is larger than account balance
//                dnb.Withdraw(runar.GetAccounts()[0], 1300000);    // Triggers exception, as account does not have sufficient funds
                dnb.Transfer(runar.GetAccounts()[0], meg.GetAccounts()[1], 66666);
//                dnb.Transfer(runar.GetAccounts()[0], meg.GetAccounts()[1], 123456789098765432);    // Triggers exception, as transfer amount is greater than available balance

                dnb.GetAccountsForCustomer(meg);     // Returns list of account objects
                Console.WriteLine(dnb.PrintAccountsForCustomer(meg));     // Prints "meg"'s accounts
                Console.WriteLine(dnb.PrintAccountsForCustomer(andreas));     // Prints "andreas"'s accounts (andreas has no accounts)
                
                
                
                Console.WriteLine("{0} now has ${1} in his pockets.", runar.GetName, runar.Savings);
            
            }
            catch (Exception e)     // Catches all exceptions
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}