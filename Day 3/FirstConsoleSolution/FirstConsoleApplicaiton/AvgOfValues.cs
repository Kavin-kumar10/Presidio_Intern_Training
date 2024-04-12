using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApplicaiton
{
    internal class AvgOfValues
    {
        //Get Values
        static List<double> getValues()
        {
            List<double> numberList = new List<double>();
            int num1 = 0;
            while (num1 >= 0)
            {
                Console.WriteLine("Enter New Number : ");
                while (int.TryParse(Console.ReadLine(), out num1) == false)
                {
                    Console.WriteLine("Invalid value, please enter the number: ");
                }
                numberList.Add(num1);
            }
            return numberList;
        }

        static double getAverageOf7DivisorValues() {
              List<double> list = getValues();
            double sum = 0;
            double count = 0;
            foreach (double value in list)
            {
                if(value%7 == 0)
                {
                    sum += value;
                    count++;
                }
            }
            return sum/count;
        }

        static void Main(string[] args)
        {
            double res = getAverageOf7DivisorValues();
            Console.WriteLine("The average of values with 7 as divisor : "+res);
        }
    }
}
