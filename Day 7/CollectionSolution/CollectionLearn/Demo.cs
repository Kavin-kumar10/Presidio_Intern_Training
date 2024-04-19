using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionLearn
{
    public class Contacts{
        private string[] str = new string[10];
        public string this[int ind] {
            get
            {
                return str[ind];
            }
            set
            {
                str[ind] = value;
            }
        }

        public int this[string name]
        {
            get
            {
                int idx = -1;
                for(int i = 0; i < str.Length; i++)
                {
                    if (str[i] == name) return i;
                }
                return idx;
            }

        }
        public override string ToString()
        {
            string contacts = "";
            for (int i = 0; i < str.Length; i++) {
                contacts += str[i]+" ";
            }
            return contacts;

        }
    }
    public struct Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Server{ 
        public int Id { get; set; }
        public string Name { get; set; }
    }



    public class Animal {
        public virtual void color()
        {
            Console.WriteLine("Animal Color");
        }
    }

    public class Dog:Animal {
        public override void color()
        {
            Console.WriteLine("Dogs color");   
        }
    }


    public class Demo
    {
        public static void OOPsDemo()
        {

            //Overriding
            Dog dog = new Dog();
            dog.color();

            //struct
            Customer c1 = new Customer();
            c1.Id = 1;
            c1.Name = "kavin";
            Customer c2 = c1;
            c2.Name = "Ramu";
            Console.WriteLine("c1 name is {0} and c2 name is {1}", c1.Name, c2.Name);

            //Class
            Server s1 = new Server();
            s1.Id = 2;
            s1.Name = "Raja";
            Server s2 = s1;
            s2.Name = "Pravin";
            Console.WriteLine("s1.name is {0} and s2 name is {1}", s1.Name, s2.Name);


            //Indexers
            Contacts contacts = new Contacts();
            contacts[0] = "kavin";
            contacts[1] = "Pravin";
            contacts[2] = "azagar";
            Console.WriteLine(contacts.ToString());
        }

        public static int divide()
        {
            try
            {
                int num1 = Convert.ToInt32(Console.ReadLine());
                int num2 = Convert.ToInt32(Console.ReadLine());
                int res = num1 / num2;
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally Called");
            }
            return 0;
        }

        public static void Main(string[] args)
        {
            divide();
        }
    }
}
