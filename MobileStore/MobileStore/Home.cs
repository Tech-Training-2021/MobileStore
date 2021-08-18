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
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter prefered store Location: ");
            string location = Console.ReadLine();
            Console.Write("Please enter birth date (yyyy/mm/dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            int id = LCustomer.Count() + 1;

            Customer.kCustomer dcustomer = new Customer.kCustomer()
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Location = location,
                Dob = dob
            };
            int flag = 0;
            string sdob = "";
            foreach (var o in LCustomer)
            {
                if (o.FirstName.ToString() == firstName && o.LastName.ToString() == lastName)
                {
                    flag = 1;
                    sdob = o.Dob.ToShortDateString();
                }
            }
            if (flag == 0)
            {
                LCustomer.Add(dcustomer);
                var jsonString = JsonConvert.SerializeObject(LCustomer, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(@"customer.json", jsonString);
                Console.WriteLine("Successfully created account...Please do the login");
            }
            else
            {
                Console.WriteLine("Already exist\nDisplay Information:");
                Console.WriteLine($"First Name : {firstName}\nLast Name : {lastName}\nLocation : {location}\nDob : {sdob}");
            }
            Program.Firstpg();
        }

        public static void Login()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            int flag = 0;
            foreach (var o in LCustomer)
            {
                if (o.FirstName.ToString() == firstName && o.LastName.ToString() == lastName)
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Incorrect first name or last name");
                Program.Firstpg();
            }
            else if(firstName == "Admin" && lastName == "Admin")
            {
                Console.WriteLine("Click 1: Search Customer by first and last name\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                int choice = int.Parse(Console.ReadLine());
                while (choice != 5)
                {
                    switch (choice)
                    {
                        case 1:
                            //search customer
                            AllFun.Search_Customer();
                            Console.WriteLine("Click 1: Search Customer by first and last name\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 2:
                            //view all customers
                            foreach (var o in LCustomer)
                            {
                                if (o.FirstName.ToString() != "Admin" && o.LastName.ToString() != "Admin")
                                {
                                    Console.WriteLine($"Id : {o.Id}\tFirst Name : {o.FirstName.ToString()}\tLast Name : {o.LastName.ToString()}\tLocation : {o.Location.ToString()}\tDob : {o.Dob.ToShortDateString()}\n");
                                }
                            }
                            Console.WriteLine("Click 1: Search Customer by first and last name\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 3:
                            //add product into json
                            AllFun.Add_Products();
                            Console.WriteLine("Click 1: Search Customer by first and last name\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            //iterate list to display all products
                            foreach (var o in LProduct)
                            {
                                    Console.WriteLine($"Product Id : {o.P_Id}\tCompany Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColors : {o.Color}\tStore Location : {o.Store}\n");
                            }
                            Console.WriteLine("Click 1: Search Customer by first and last name\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Please click either 1 2 3 4");
                            break;

                    }
                }
            }
            else
            {
                Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                int choice = int.Parse(Console.ReadLine());
                while (choice != 5)
                {
                    switch (choice)
                    {
                        case 1:
                            //view own details
                            foreach (var o in LCustomer)
                            {
                                if (o.FirstName.ToString() == firstName && o.LastName.ToString() == lastName)
                                {
                                    Console.WriteLine($"First Name : {firstName}\nLast Name : {lastName}\n Location : {o.Location.ToString()}\n Dob : {o.Dob.ToShortDateString()}");
                                }
                            }
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 2:
                            //iterate list to display all products
                            foreach (var o in LProduct)
                            {
                                Console.WriteLine($"Product Id : {o.P_Id}\tCompany Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tColors : {o.Color}\tStore Location : {o.Store}\n");
                            }
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 3:
                            //Search Product
                            Book_Order.Search_Product();
                            Console.WriteLine("Click 1: View own details\nClick 2 : View All Products\nClick 3 : Search Product By Name\nClick 4 : Book an Order\nClick 5 : Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 4:
                            //Book product
                            Book_Order.Product_Book(firstName);
                            break;
                        case 5:
                            Console.WriteLine("Please click 1 2 3 4");
                            break;
                    }
                }
            }
        }
    }
}
