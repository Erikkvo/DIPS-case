using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Money = System.Double;

namespace Bank
{
    public class Bank
    {

        private string _bankName;     // Assume a bank is uniquely identified by its name
        private List<Account> _accounts = new List<Account>();     // Keep track of all accounts in given bank
        private List<Person> _customers = new List<Person>();     // Keep track of all customers in given bank

        public Bank(string bankName)
        {
            _bankName = bankName;
        }

        
        public Account CreateAccount(Person customer, Money initialDeposit)
        {
            if (customer.Savings < initialDeposit)
            {
                throw new ArgumentException("Customer must have sufficient funds.");
            }
            else if (initialDeposit < 0)
            {
                throw new ArgumentException("Cannot deposit a negative amount.");
            }
            Account acc = new Account(customer, initialDeposit, this);
            
//            Adds account to bank's list of accounts, if account does not already exist
            if (! GetBankAccounts().Contains(acc))
            {
                _accounts.Add(acc);
            }
            customer.AddNewAccount(acc);
//            Adds customer to bank, if person is not already customer
            if (! GetBankCustomers().Contains(customer)) 
            {
                _customers.Add(customer);
                customer.AddNewBank(this);     // Adds this bank to person's list of banks
            }
            customer.SerialNr += 1;
            Console.WriteLine("Account with name '{0}' successfully created. Available balance: ${1}", acc.AccountName, acc.Balance);
            return acc;
        }

        
//        Deposit amount into account
        public void Deposit(Account to, Money amount)
        {
//            Make sure deposit amount is positive
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be greater than $0");
            }
            if (to.Owner.Savings < amount)
            {
                throw new ArgumentException("Cannot deposit a larger amount than available savings.");
            }
            else
            {
                to.Balance += amount;     // Add amount to account's balance
                to.Owner.Savings -= amount;     // Subtract amount from account-owner's savings
                Console.WriteLine("Successfully deposited ${0} into account '{1}'. \r\nAvailable balance is: ${2}", amount, to.ToString(), to.Balance);
            }
        }
        
//        Withdraw amount from account
        public void Withdraw(Account from, Money amount)
        {
//            Check whether balance in account is sufficient
            if (from.Balance < amount)
            {
                throw new ArgumentException("Cannot withdraw a larger amount than available balance.");
            }
            from.Balance -= amount;     // Subtract amount from account's balance
            from.Owner.Savings += amount;     // Add amount to account-owner's savings
            Console.WriteLine("Withdrawal of ${0} successful. \r\nCurrent available balance is: ${1}", amount, from.Balance);
        }
        
//        Transfer amount from account "from" to account "to"
        public void Transfer(Account from, Account to, Money amount)
        {
            if (amount < 0 || from.Balance < amount)     // Checks whether sending account has sufficient funds
            {
                throw new ArgumentException("Cannot transfer a larget amount than available balance.");
            }
            from.Balance -= amount;     // Subtract amount from sending account's balance. 
            to.Balance += amount;     // Add amount to receiving account's balance.
            Console.WriteLine("Transfer of ${0} from '{1}' to '{2}' successful. \r\nCurrent available balance is: ${3}", amount, from.AccountName, to.AccountName, from.Balance);    // Displays balance in "from" account, as it is the one transferring
        }
        
        
//        Getters and setters
        
//        Gets a list of all accounts belonging to a specific customer
        public Account[] GetAccountsForCustomer(Person customer)
        {
            // DO NOT NEED CODE BELOW (?) AS GETACCOUNTS() RETURNS EMPTY LIST IF EMPTY
//            if (! customer.GetAccounts().Any())
//            {
//                Console.WriteLine("Customer does not have any accounts in this bank.");
//            }
//            foreach (Account account in customer.GetAccounts())
//            {
//                Console.WriteLine(account); // Calls the ToString() ??
//            }
            return customer.GetAccounts();
        }
        
//        Helper function to print a customer's accounts neatly
        public string PrintAccountsForCustomer(Person customer)
        {
            string accs = "";
            foreach (Account account in customer.GetAccounts())
            {
                accs += "'" + account.AccountName + "' has a balance of $" + account.Balance + "\r\n";
            }
            return accs;
        }
        
        
        public List<Account> GetBankAccounts()
        {
            return _accounts;
        }
        
        public List<Person> GetBankCustomers()
        {
            return _customers;
        }

//        Assuming a bank can alter its name post construction
        public string BankName
        {
            get { return _bankName; }
            set { _bankName = value; }
        }

//        ToString method
        public override string ToString()
        {
            return BankName;
        }
        
    }
}