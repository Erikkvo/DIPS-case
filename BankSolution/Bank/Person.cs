using System.Collections.Generic;
using Money = System.Double;

namespace Bank
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _serialNr = 1; 
        private int _personId = 1; // Uniquely identify person, in case people have same first and last name
        private Money _savings; // Total savings for this given person

        private List<Account> _accounts = new List<Account>(); // Keep track of accounts belonging to given person
        private List<Bank> _bankList = new List<Bank>(); // Keep track of banks given person has accounts in

            
//        Constructor for Person, that takes in firstName and lastName
        public Person(string firstName, string lastName, Money savings)
        {
            _firstName = firstName;
            _lastName = lastName;
            _savings = savings;

        }

//        Getters and setters
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GetName => _firstName + " " + _lastName;
        
        public int SerialNr { get; set; }
        
        public Money Savings
        {
            get { return _savings; }
            set { _savings = value; }
        }

        public Account[] GetAccounts()
        {
            return _accounts.ToArray();
        }
        
        public Bank[] GetBanks()
        {
            return _bankList.ToArray();
        }

        public void AddNewAccount(Account account)
        {
            _accounts.Add(account);
        }
        
        public void AddNewBank(Bank bank)
        {
            _bankList.Add(bank);
        }
        
    }
}