using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApplicaiton
{
    internal class BinaryZeros
    {
        /// <summary>
        /// To find maximum consecutive zeros present in between 1 in the string got as parameter
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static int maxConsecutiveZeros(string str)
        {
            int ind = 0;
            int maxCount = 0;
            int count = 0;
            while (str[ind] != '1') ind++;
            for (; ind < str.Length; ind++)
            {
                if (str[ind] == '1') {
                    if(count>maxCount)maxCount = count;
                    count = 0;
                }
                else
                {
                    count++;
                }
            }
            return maxCount;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Number to find the max zero count inbetween 1s in binary digits");
            Console.WriteLine("Enter the Number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            string BinaryString = Convert.ToString(num, 2);
            Console.WriteLine(BinaryString);
            int Maxcount = maxConsecutiveZeros(BinaryString);
            Console.WriteLine(Maxcount);

        }
    }
}
