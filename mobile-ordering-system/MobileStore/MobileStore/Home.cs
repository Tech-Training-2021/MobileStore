using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class Home
    {
        //Read data from json
        static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));
        static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));
        public static void Signup()
        {
            Console.WriteLine("<----- SignUp Page ----->\n");

            Authentication.AuthenticateID();

            Authentication.AuthenticateUsername();

            Authentication.AuthenticatePassword();

            Console.WriteLine("\nEnter FirstName: ");
            string firstname = Console.ReadLine();

            Console.WriteLine("\nEnter LastName: ");
            string lastname = Console.ReadLine();

            Console.WriteLine("\nEnter Location: ");
            string location = Console.ReadLine();

            Authentication.AuthenticateRest(firstname, lastname, location);

            Authentication.AuthenticateMobile();

            Authentication.AuthenticateDOB();

            Authentication.Register();
        }

        public static void Login()
        {
            Console.WriteLine("<----- Login Page ----->\n");
            AuthenticateLogin.AuthenticateUsernamePassword();
        }
    }
}
