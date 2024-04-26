namespace AsynAwaitTaskLearnApplication
{
    internal class Program
    {
        async Task<int> GetResultFromDatabaseServer()
        {
            return new Random().Next();
        }

        void PrintNumbers()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("By " + Thread.CurrentThread.Name + " " + i);
                Thread.Sleep(1000);
            }
        }

        public static void Main(string[] args)
        {

            Program program = new Program();
            Program program1 = new Program();

            program.PrintNumbers();
            program1.PrintNumbers();
            Thread t1 = new Thread(program.PrintNumbers);
            t1.Name = "You";
            Thread t2 = new Thread(program.PrintNumbers);
            t2.Name = "Me";
            t1.Start();
            t2.Start();
            Console.WriteLine("After the thread call");

            //Console.WriteLine("Hello, World!");
            //Program program = new Program();
            //int number = await program.GetResultFromDatabaseServer();
            //Console.WriteLine("This is the random number from server " + number);
            //Console.WriteLine("This is the random number from main" + new Random().Next());

        }
    }
}
