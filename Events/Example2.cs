using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events
{

    public class User
    {
        // Properties to hold user details
        public string Name { get; set; }
        public string SSN { get; set; }

        // Constructor to initialize a User
        public User(string name, string ssn)
        {
            Name = name;
            SSN = ssn;
        }
    }

    public class BankAccount
    {
        private const decimal Threshold = 5000000;

        private User AccountHolder { get; set; }
        private string AccountNumber { get; set; }
        private decimal Balance { get; set; }

        public delegate void UserBalanceExceededHandler(User user);
        public event UserBalanceExceededHandler UserBalanceExceeded;


        public BankAccount(User user, string accountNumber, decimal initialBalance)
        {
            AccountHolder = user;
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void PrintUserInfo()
        {
            Console.WriteLine("Account Holder: " + AccountHolder.Name);
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Current Balance: " + Balance);
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine("Deposited: " + amount);

                if (Balance >= Threshold)
                {
                    Console.WriteLine("WARNING: Your balance exceeds 5,000,000!");
                    UserBalanceExceeded?.Invoke(AccountHolder);
                }
            }
            else
            {
                Console.WriteLine("Invalid deposit amount!");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine("Withdrew: " + amount);
            }
            else
            {
                Console.WriteLine("Invalid withdraw amount!");
            }
        }
    }

    class FederalAgency
    {
        public void InvestigateUserIncomeSources(User user)
        {
            Console.WriteLine("User to be investigated: ");
            Console.WriteLine("Account Holder: " + user.Name);
            Console.WriteLine("Account Number: " + user);
        }
    }
}