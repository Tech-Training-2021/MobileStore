using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class SignUp
    {
        static List<Customer.kCustomer> LCustomer = Customer.CustomerList();
        static List<Product.kProduct> LProduct = Product.ProductList();
        public static void Signup()
        {
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter prefered store Location: ");
            string location = Console.ReadLine();
            Console.Write("Please enter birth date (yyyy/mm/dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            int id = LCustomer.Count() + 1;

            Customer.kCustomer dcustomer = new Customer.kCustomer()
            {
                Id = id,
                UserName = userName,
                Password = password,
                Location = location,
                Dob = dob
            };
            int flag = 0;
            string sdob = "";
            foreach (var o in LCustomer)
            {
                if (o.UserName.ToString() == userName && o.Password.ToString() == password)
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
                Console.WriteLine($"First Name : {userName}\nLast Name : {password}\n Location : {location}\n Dob : {sdob}");
            }
            Program.Firstpg();
        }

        public static void Login()
        {
            Console.Write("Enter User Name: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password Name: ");
            string password = Console.ReadLine();

            int flag = 0;
            foreach (var o in LCustomer)
            {
                if (o.UserName.ToString() == userName && o.Password.ToString() == password)
                {
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Incorrect Username or password");
                Program.Firstpg();
            }
            else if(userName == "Admin" && password == "Admin")
            {
                Console.WriteLine("Click 1: Search Customer by first and last name\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                int choice = int.Parse(Console.ReadLine());
                while (choice != 5)
                {
                    switch (choice)
                    {
                        case 1:
                            int sflag = 0;
                            Console.Write("Enter Customer's User Name: ");
                            string sUserName = Console.ReadLine();
                            Console.Write("Enter Customer's Location: ");
                            string slocation = Console.ReadLine();
                            string spassword = "", sdob="";
                            foreach (var o in LCustomer)
                            {
                                if (o.UserName.ToString() == sUserName && o.Location.ToString() == slocation)
                                {
                                    slocation = o.Location.ToString();
                                    sdob = o.Dob.ToShortDateString();
                                    sflag = 1;
                                }
                            }
                            if (sflag == 0)
                            {
                                Console.WriteLine("No such customer exist");
                            }
                            else
                            {
                                Console.WriteLine($"Customer's Username Name : {sUserName}\nPassword : {spassword}\n Location : {slocation}\n Dob : {sdob}");
                            }
                            Console.WriteLine("Click 1: Search Customer by first and location\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 2:
                            foreach (var o in LCustomer)
                            {
                                if (o.UserName.ToString() != "Admin" && o.Password.ToString() != "Admin")
                                {
                                    Console.WriteLine($"Id : {o.Id}\tUser Name : {o.UserName.ToString()}\tPassword : {o.Password.ToString()}\tLocation : {o.Location.ToString()}\tDob : {o.Dob.ToShortDateString()}\n");
                                }
                            }
                            Console.WriteLine("Click 1: Search Customer by first and last name\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 3:
                            Console.Write("Enter Mobile Company: ");
                             string c_name = Console.ReadLine();
                            Console.Write("Enter Mobile Name: ");
                            string m_name = Console.ReadLine();
                            //array list for ram
                            List<int> ram_list = new List<int>();
                            Console.Write("Enter number of RAM's you want to add: ");
                            int ram_n = int.Parse(Console.ReadLine());
                            for (int i = 0; i < ram_n; i++)
                            {
                                Console.Write("Enter RAM: ");
                                ram_list.Add(int.Parse(Console.ReadLine()));
                            }
                            //array list for rom
                            List<int> rom_list = new List<int>();
                            Console.Write("Enter number of ROM's you want to add: ");
                            int rom_n = int.Parse(Console.ReadLine());
                            for (int i = 0; i < rom_n; i++)
                            {
                                Console.Write("Enter ROM: ");
                                rom_list.Add(int.Parse(Console.ReadLine()));
                            }
                            //array list for color
                            List<String> c_list = new List<String>();
                            Console.Write("Enter number of colors you want to add: ");
                            int n = int.Parse(Console.ReadLine());
                            for (int i = 0; i < n; i++)
                            {
                                Console.Write("Enter color: ");
                                c_list.Add(Console.ReadLine());
                            }

                            Console.Write("Enter store: ");
                             string store = Console.ReadLine();

                             int p_id = LProduct.Count() + 1;
                            //assigning values to the keys
                             Product.kProduct dproduct = new Product.kProduct()
                             {
                                 P_Id = p_id,
                                 C_Name = c_name,
                                 M_Name = m_name,
                                 Ram = ram_list,
                                 Storage = rom_list,
                                 Color = c_list,
                                 Store = store
                             };
                             int s_flag = 0;
                            foreach (var o in LProduct)
                            {
                                if (o.C_Name.ToString() == c_name && o.M_Name.ToString() == m_name)
                                {
                                    s_flag = 1;
                                }
                            }
                            if (s_flag == 0)
                            {
                                //add into the list then store into json
                                LProduct.Add(dproduct);
                                var jsonString = JsonConvert.SerializeObject(LProduct, Newtonsoft.Json.Formatting.Indented);
                                File.WriteAllText(@"Product.json", jsonString);
                                Console.WriteLine("Successfully Added");
                            }
                            else
                            {
                                Console.WriteLine("Already exist");
                            }
                            Console.WriteLine("Click 1: Search Customer by first and last name\nClick 2: View all customers\nClick 3: Add a Product\nClick 4: View all Products\nClick 5: Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;
                        case 4:
                            //iterate list to display all products
                            foreach (var o in LProduct)
                            {
                                    Console.WriteLine($"Product Id : {o.P_Id}\tCompany Name : {o.C_Name}\tMobile Name : {o.M_Name}\tRAM : {string.Join(", ",o.Ram.ToArray())}\tROM : {string.Join(", ", o.Storage.ToArray())}\tColors : {string.Join(", ", o.Color.ToArray())}\tStore Location : {o.Store}\n");
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
                Console.WriteLine("Click 1: View own details\nClick 2 : Exit");
                int choice = int.Parse(Console.ReadLine());
                while (choice != 2)
                {
                    switch (choice)
                    {
                        case 1:
                            foreach (var o in LCustomer)
                            {
                                if (o.UserName.ToString() == userName && o.Password.ToString() == password)
                                {
                                    Console.WriteLine($"User Name : {userName}\nPassword : {password}\n Location : {o.Location.ToString()}\n Dob : {o.Dob.ToShortDateString()}");
                                }
                            }
                            Console.WriteLine("Click 1: View own details\nClick 2 : Exit");
                            choice = int.Parse(Console.ReadLine());
                            break;

                        case 2:
                            Console.WriteLine("Please click 1");
                            break;
                    }
                }
            }
        }
    }
}
