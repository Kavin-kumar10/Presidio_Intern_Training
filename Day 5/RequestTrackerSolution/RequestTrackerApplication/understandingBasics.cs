using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApplication
{

    internal class understandingBasics
    {
        void UnderstandingSequentialFunction()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("hi its kavin");
            int num1 = 10;
            int num2 = 20;
            int sum = num1 + num2;
            Console.WriteLine($"The sum of values {num1} and {num2} is {sum}");
        }
        void UnderstandingSelectionWithIf()
        {
            string strName = "kavin";
            if (strName == "pravin")
            {
                Console.WriteLine("You are authorized");
            }
            else if (strName == "kavin")
            {
                Console.WriteLine("you are authorized as kavin");
            }
            else
            {
                Console.WriteLine("Unauthorized");
            }
        }
        void UnderstandingSwitchCase()
        {
            int num = 3;
            switch (num)
            {
                case 1:
                    Console.WriteLine("the number is 1");
                    break;
                case 2:
                case 3:
                    Console.WriteLine("The number is 2 or 3");
                    break;
                default:
                    Console.WriteLine("its number");
                    break;
            }
        }

        void UnderstandingIterationWithFor()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }

        void UnderstandingIterationWithWhile()
        {
            int Count = 10;
            while (Count > 0)
            {
                if (Count == 5)
                {
                    Count--;
                    continue;
                }
                if (Count == 2) break;
                Console.WriteLine(Count);
                Count--;
            }
        }
        void UnderstandingIterationWithDoWhile()
        {
            int count = 10;
            do
            {
                Console.WriteLine(count);
                count--;
            } while (count > 0);
        }

        static void Main(string[] args)
        {
            understandingBasics program = new understandingBasics();
            //program.UnderstandingSequentialFunction();
            //program.UnderstandingSelectionWithIf();
            //program.UnderstandingSwitchCase();
            //program.UnderstandingIterationWithFor();
            //program.UnderstandingIterationWithWhile();
            //program.UnderstandingIterationWithDoWhile();
            Console.WriteLine("Hello, World!");
        }
    }
}
