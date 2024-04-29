using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblemApplication
{
    public class LeetCodeProblem2
    {
        public async Task<string> ConvertToExcel(int ColumnNumber)
        {
            String result = "";
            lock (this)
            {
                while (ColumnNumber > 0)
                {
                    int remainder = (ColumnNumber - 1) % 26;
                    char c = (char)('A' + remainder);
                    result = c + result;
                    ColumnNumber = (ColumnNumber - 1) / 26;
                }
            }
            return result;
        }

        public async void GetExcelValues()
        {
            Console.WriteLine("Enter your Number : ");
            int ColumnNumber = Convert.ToInt32(Console.ReadLine());
            string result = await ConvertToExcel(ColumnNumber);
            Console.WriteLine("The Result is :" + result);
        }
        public static void Main(string[] args)
        {
            LeetCodeProblem2 program = new LeetCodeProblem2();
            program.GetExcelValues();
        }
    }
}
