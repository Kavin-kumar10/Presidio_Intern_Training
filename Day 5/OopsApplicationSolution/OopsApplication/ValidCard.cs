using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopsApplication
{
    internal class ValidCard
    {

        /// <summary>
        /// Reversing the given card number and converting it to an reversed integer array for further arithmatic operation
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static int[] reverseNumberToIntegerArray(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            int[] numbers = new int[charArray.Length];
            for(int i = 0; i < charArray.Length; i++)
            {
                numbers[i] = charArray[i]-'0';
            }
            return numbers;
        }
        
        /// <summary>
        /// Arithmetic operations to be handled to complete the 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static bool verificationOperations(string str)
        {
            if(str.Length < 15) { return false; };
            int[] numbers = reverseNumberToIntegerArray(str);
            int total = 0;
            for(int ind = 0; ind < numbers.Length; ind++)
            {
                if((ind+1)%2 == 0)
                {
                    numbers[ind] *= 2;
                }
                if (numbers[ind] > 9)
                {
                    int once = numbers[ind] % 10;
                    int tens = numbers[ind] / 10;
                    numbers[ind] = once + tens;
                }
                total += numbers[ind];
            }

            Console.WriteLine("The Final Value is " + total);

            if (total % 10 == 0) return true;
            else return false;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your Code");
            string cardNumber = Console.ReadLine();
            if (verificationOperations(cardNumber)) Console.WriteLine("Valid Card Number ... !");
            else Console.WriteLine("Invalid Card Number ... !");
        }
    }
}
