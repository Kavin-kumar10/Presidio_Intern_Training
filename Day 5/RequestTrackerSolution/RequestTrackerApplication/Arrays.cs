using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApplication
{
    internal class Arrays
    {
        void UnderstandingArrays()
        {
            int[] IntegerArray = { 111, 223, 222, 444, 312 };
            int repeatingNumbersCount = 0;  
            for(int i = 0; i < IntegerArray.Length; i++)
            {
                int once = IntegerArray[i] % 10;
                IntegerArray[i] /= 10;
                int tens = IntegerArray[i] % 10;
                IntegerArray[i] /= 10;
                int hundreds = IntegerArray[i] % 10;

                if (once == tens && tens == hundreds) repeatingNumbersCount++;
            }
            Console.WriteLine("Total Repeating digits numbers count is " + repeatingNumbersCount);
        }
        static void Main(string[] args)
        {
            Arrays program = new Arrays();
            program.UnderstandingArrays();
            Console.WriteLine();
        }
    }
}
