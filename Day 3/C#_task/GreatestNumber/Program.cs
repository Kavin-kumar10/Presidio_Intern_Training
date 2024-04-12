namespace GreatestNumber
{
    internal class Program
    {
        static List<double> getValues()
        {
            List<double> numberList = new List<double>();
            int num1 = 0;
            while (num1 >= 0)
            {
                Console.WriteLine("Enter New Number : ");
                while(int.TryParse(Console.ReadLine(),out num1) == false)
                {   
                    Console.WriteLine("Invalid value, please enter the number: ");
                }
                numberList.Add(num1);
            }
            return numberList;
        }
        static double GreaterNumber()
        {
            List<double> numberList = getValues();
            double greaterNumber = int.MinValue;
            for(int ind = 0;ind < numberList.Count; ind++)
            {
                if (numberList[ind] > greaterNumber)greaterNumber = numberList[ind];
            }
            return greaterNumber;

        }
        static void Main(string[] args)
        {
            double res = GreaterNumber();
            Console.WriteLine("The greated among the given value is "+ res);
        }
    }
}
