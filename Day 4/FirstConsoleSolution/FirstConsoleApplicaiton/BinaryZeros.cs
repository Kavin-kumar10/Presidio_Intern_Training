using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApplicaiton
{
    internal class BinaryZeros
    {
        //Ongoing
        //static int maxConsecutiveZeros(string str)
        //{

        //    for(int ind = 0;ind < str.Length;ind++)
        //    {
        //        if (str[ind] == '1') { }
        //    }
        //}
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            string BinaryString = Convert.ToString(num, 2);
            Console.WriteLine(BinaryString);
            //maxConsecutiveZeros(BinaryString);
            
        }
    }
}
