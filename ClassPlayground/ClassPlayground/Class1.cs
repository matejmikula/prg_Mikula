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

        public double deposite()
        {
            Random Balance = new Random();
            double UserBalance = Convert.ToDouble(Balance);
            double UserDeposite = Convert.ToDouble(Console.ReadLine());
            double FinalBalance = UserBalance + UserDeposite;
            return FinalBalance;
        }
    }
}
