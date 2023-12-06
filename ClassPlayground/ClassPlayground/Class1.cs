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
        public int ContainsPoint()
        {
            int UserChoiceX = Convert.ToInt32(Console.ReadLine());
            int UserChoiceY = Convert.ToInt32(Console.ReadLine());
            int ContainsPoint = ;
        }
    }
}
