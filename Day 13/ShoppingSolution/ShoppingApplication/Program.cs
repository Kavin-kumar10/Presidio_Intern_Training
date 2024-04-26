using ShoppingModalLibrary.cs;
using ShoppingBLLibrary;
using ShoppingDALLibrary;

namespace ShoppingApplication
{
    public static class StringMethods
    {
        public static string Reverse(this string msg)
        {
            char[] chars = msg.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }

    }
    public static class NumberExtension
    {
        public static int[] EvenCatch(this int[] nums)
        {
            List<int> result = new List<int>();
            foreach (int num in nums)
                if (num % 2 == 0)
                    result.Add(num);
            return result.ToArray();
        }
    }
    internal class Program
    {

        //public delegate int calcDel(int n1, int n2);//creating a type that refferes to a method
        //public delegate float calcDelFloat(float n1, float n2);//creating a type that refferes to a method
        //public delegate T calcDel<T>(T n1, T n2);//creating a generic  type that refferes to a method
        //void Calculate(calcDel<int> cal)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        //}
        //void Calculate(Func<int, int, int> cal)
        //{
        //    int n1 = 10, n2 = 20;
        //    int result = cal(n1, n2);
        //    Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        //}
        //public int Add(int num1, int num2)
        //{
        //    return (num1 + num2);
        //}

        public static Customer CreateNewCustomer(ICustomerServices customerServices) {
            
            Customer customer = new Customer() { Name = "kavin", Age = 12, Phone = "9876543210" };
            customerServices.AddCustomer(customer);
            Cart cart = new Cart() { Customer = customer,CustomerId = customer.Id };
            return customer;
        }
        public void PrintAllDetailsAboutCustomer()
        {

        }

        static void Main(string[] args)
        {
            ICustomerServices customerServices = new CustomerBL(new CustomerRepository());
            //ICartServices cartServices = new CartBL(new CartRepository());
            ICartItemsServices cartItemsServices = new CartItemBL(new CartItemRepository());
            IProductServices productServices = new ProductBL(new ProductRepository());


            Product product = new Product() { Name ="Jean",Price = 10,QuantityInHand = 10};
            productServices.AddProduct(product);
            //CartItem cartitem = new CartItem() { Product = product,ProductId = product.Id,CartId = cart.Id,Discount = 20,Price = product.Price,PriceExpiryDate = DateTime.Now,Quantity = 1 };
            //cartItemsServices.AddCartItem(cartitem);



    
           // int[] arr = { 12, 2, 3, 4, 5, 6, 7, 8, };
           // var result = arr.OrderBy(x=>x);
           // Console.WriteLine(result.ToArray()[0]);
           // int[] evenNumebrs = arr.EvenCatch();
           // foreach (int n in evenNumebrs)
           //     Console.WriteLine(n);

           // IRepository<int,Customer> _customerrepo = new CustomerRepository();
           //_customerrepo.Add(new Customer() { Id = 1, Name = "kavin", Phone = "876543290", Age = 25 });
           // _customerrepo.Add(new Customer() { Id = 2, Name = "pravin", Phone = "10876543290", Age = 28});
           // _customerrepo.Add(new Customer() { Id = 3, Name = "Navin", Phone = "2136543290", Age = 45}); 
            
           // var customers = _customerrepo.GetAll().ToList();
           // customers = customers.OrderBy(n=>n.Name).ThenBy(n=>n.Age).ToList();
           // foreach(var items in customers)
           //     Console.WriteLine(items);
           // Console.WriteLine("hi");


            //Console.WriteLine("Hello, World!");
            //Program program = new Program();
            //calcDel c1 = new calcDel(program.Add);
            //calcDel<int> c1 = new calcDel<int>(program.Add);//Generic type instantiation
            //calcDel<int> c1 = delegate (int num1, int num2)//You can do if you are alwayts going to use teh ref to use the method
            //{
            //    return (num1 + num2);
            //};
            //calcDel<int> c1 = (int num1, int num2)=>(num1 + num2);
            //Func<int, int, int> c1 = (num1, num2) => (num1 + num2);
            //program.Calculate(c1);

        }
    }
}
