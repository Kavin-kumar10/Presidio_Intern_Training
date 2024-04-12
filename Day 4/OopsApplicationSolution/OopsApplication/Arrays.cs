using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsApplication
{
    internal class Arrays
    {
        /// <summary>
        /// Completely for training purpose doesn't include with Doctor application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your num : ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num);
            int[] numbers = new int[3];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3; 
            for(int ind = 0; ind < numbers.Length; ind++)
            {
                Console.WriteLine(numbers[ind]);
            }
            int count = numbers.Length - 1;
            while (count >= 0)
            {
                Console.WriteLine(numbers[count]);
                count--;
            }
        }
    }
}
