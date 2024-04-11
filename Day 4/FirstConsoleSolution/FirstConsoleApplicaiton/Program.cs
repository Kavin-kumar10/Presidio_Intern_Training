namespace FirstConsoleApplicaiton
{
    internal class Program
    {
        static double num1, num2;
        //Get Values
        static double getValue()
        {
            double num1;
            Console.WriteLine("Enter the number : ");
            while (double.TryParse(Console.ReadLine(), out num1) == false)
                Console.WriteLine("Invalid input, Enter the number ... !");
            return num1;
        }

        //Add numbers
        static double AddNumbers()
        {
       
            double res = 0;
            checked
            {
                res = num1 + num2;  
            }
            return res;
        }

        //Subract Numbers
        static double SubNumbers()
        {
     
            double res = 0;
            checked
            {
                res = num1 - num2;
            }
            return res;
        }

        //multiply numbers
        static double MulNumbers()
        {
         
            double res = 0;
            checked
            {
                res = num1 * num2;
            }
            return res;
        }

        //Divide
        static double DivNumbers()
        {
            
            double res = 0;
            checked
            {
                res = num1 / num2;
            }
            return res;
        }

        //Reminder value
        static double RemNumbers()
        {

            double res = 0;
            checked
            {
                res = num1 % num2;
            }
            return res;
        }

        static void Calculate()
        {
            double sum = AddNumbers();
            double sub = SubNumbers();
            double product = MulNumbers();
            double divide = DivNumbers();
            double remind = RemNumbers();
            Console.WriteLine($"The sum of two values is : {sum}");
            Console.WriteLine($"The Difference of two values is : {sub}");
            Console.WriteLine($"The product of two values is : {product}");
            Console.WriteLine($"The quotient of two values is : {divide}");
            Console.WriteLine($"The reminder of two values is : {remind}");

        }

        static bool perfect(string str, out double val)
        {
            val = 0;
            if(str == null) return false;
            val = 1;
            return true;
        }


        static void Main(string[] args)
        {
            //double ans;
            //bool res = perfect("kavin", out ans);
            //Console.WriteLine(ans);
            num1 = getValue();
            num2 = getValue();
            Calculate();

        }
    }
}
