using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassPlayground
{
    internal class Rectangle
    {
        public int width;
        public int height;
        public int CalcArea()
        {
            int CalcArea = width * height;
            return CalcArea;
        }
        public double CalcAspectRatio() 
        {
            if (height == 0)
            {
                Console.WriteLine("Height cannot be zero.");
                return 0.0;
            }
             
            double CalcAspectRatio = (double)width / height;
            
            return CalcAspectRatio;
        }
        public double ContainsPoint()
        {
            int UserChoiceX = Convert.ToInt32(Console.ReadLine());
            int UserChoiceY = Convert.ToInt32(Console.ReadLine());
            double ContainsPointX = (double)UserChoiceX - (double)width;
            double ContainsPointY = (double)UserChoiceY - (double)height;
            double ContainsPoint = ContainsPointX + ContainsPointY;
            return ContainsPoint;
        }
    }
    internal class BankAccount
    {
        public int accountNumber;
        public string holderName;
        public string currency;
        public double balance;

        // Constructor to initialize bank account
        public BankAccount(string holderName, string currency)
        {
            Random random = new Random();
            accountNumber = random.Next(100000000, 1000000000); // Generate a random account number
            this.holderName = holderName;
            this.currency = currency;
            this.balance = 0.0;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited {amount} {currency}. New balance: {balance} {currency}.");
            }
            else
            {
                Console.WriteLine("Deposit amount must be positive.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrew {amount} {currency}. New balance: {balance} {currency}.");
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid amount.");
            }
        }

        public void Transfer(double amount, BankAccount targetAccount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                targetAccount.balance += amount;
                Console.WriteLine($"Transferred {amount} {currency} to account {targetAccount.accountNumber}. New balance: {balance} {currency}.");
            }
            else
            {
                Console.WriteLine("Insufficient funds or invalid amount.");
            }
        }
    }
}
