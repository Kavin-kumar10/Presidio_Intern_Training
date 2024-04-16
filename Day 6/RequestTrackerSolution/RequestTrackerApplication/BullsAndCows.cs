using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApplication
{
    internal class BullsAndCows
    {
        static string GetStringFromConsole()
        {
            string str = Console.ReadLine();
            while (str.Length != 4) { 
                Console.WriteLine("Invalid String input : ");
                str = Console.ReadLine();
            }
            return str;
        }
        static void Main(string[] args)
        {
            int bull = 0, cow = 0;
            Console.WriteLine("Enter your first word");
            string str1 = GetStringFromConsole();
            Console.WriteLine("Enter your second word");
            string str2 = GetStringFromConsole();
            char[] array1 = str1.ToCharArray();
            char[] array2 = str2.ToCharArray(); 
            for(int ind = 0; ind < array2.Length; ind++)
            {
                for(int j = 0; j < array1.Length; j++)
                {
                    if (array1[ind] == array2[j])
                    {
                        if (ind == j) cow++;
                        else bull++;
                        break;
                    }
                }
            }
            Console.WriteLine($"The bull value is {bull} and the cow is {cow}");
        }
    }
}
