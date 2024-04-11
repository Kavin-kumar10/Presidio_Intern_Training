using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApplicaiton
{
    internal class lengthOfUserName
    {
        static string getUserName()
        {
            Console.WriteLine("Enter your Name: ");
            string name = Console.ReadLine();
            return name;
        }
        static int findingLength()
        {
            string name = getUserName();
            int length = name.Length;
            return length;

        }
        static void Main(string[] args)
        {
            int len = findingLength();
            Console.WriteLine("the length of the user name is " + len);
        }
    }
}
