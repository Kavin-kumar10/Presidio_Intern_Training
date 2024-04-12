using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsoleApplicaiton
{
    internal class Authentication
    {
        /// <summary>
        /// Get User Data and Password 
        /// </summary>
        /// <returns></returns>
        static string getUsername()
        {
            Console.WriteLine("Enter User Name : ");
            string username = Console.ReadLine();
            return username;
        }
        static string getPassword()
        {
            Console.WriteLine("Enter Password : ");
            string Password = Console.ReadLine();
            return Password;
        }

        /// <summary>
        /// Authenticate the username and password with 'ABC' and '123'
        /// </summary>
        /// <returns></returns>
        static bool Authenticate(){
            string username = getUsername();
            string password = getPassword();
            int count = 0;

            while((username != "ABC" ||  password != "123")&& count <=3)
            {
                count++;
                username = getUsername();
                password = getPassword();
            }
            if(count == 3)
                return false; 
            else 
                return true;
            
        }


        static void Main(string[] args)
        {
            if (Authenticate()) { Console.WriteLine("Authenticated ... ! you are logged in ... !"); }
            else { Console.WriteLine("Too many Wrong Attempts"); }
        }
    }
}
