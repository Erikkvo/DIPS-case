using System.Collections.Generic;
using System.Data.SqlTypes;
using Money = System.Double;

namespace Bank
{
    public class Account
    {

        private Person _owner;
        private Bank _bank;
        private string _accountName;
        private Money _balance = 0;

        
        public Account(Person owner, Money balance, Bank bank)
        {
            _owner = owner;
            _bank = bank;
            _balance = balance;
            _accountName = owner.GetName + " " + owner.SerialNr.ToString();
        }

//        Getters and setters
        public Person Owner => _owner;

        public Bank Bank => _bank;
        
        public string AccountName => _accountName;
        
        public Money Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }


        public override string ToString()
        {
            return AccountName;
        }
        
    }
}