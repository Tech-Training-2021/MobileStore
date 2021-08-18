using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MobileStore
{
    class Program
    {
        static void Main(string[] args)
        {
            SignUp();
        }


        public static void SignUp()
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
    }
}
