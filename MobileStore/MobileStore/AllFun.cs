using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class AllFun
    {
        static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));
        static List<Customer.kCustomer> LCustomer = JsonConvert.DeserializeObject<List<Customer.kCustomer>>(File.ReadAllText(@"customer.json"));
        public static void Search_Customer()
        {
            int sflag = 0;
            Console.Write("Enter Customer's First Name: ");
            string sfirstName = Console.ReadLine();
            Console.Write("Enter Customer's Last Name: ");
            string slastName = Console.ReadLine();
            string slocation = "", sdob = "";
            foreach (var o in LCustomer)
            {
                if (o.FirstName.ToString() == sfirstName && o.LastName.ToString() == slastName)
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
                Console.WriteLine($"Customer's First Name : {sfirstName}\nLast Name : {slastName}\n Location : {slocation}\n Dob : {sdob}");
            }
        }
        public static void Add_Products()
        {
            Console.Write("Enter Mobile Company: ");
            string c_name = Console.ReadLine();
            Console.Write("Enter Mobile Name: ");
            string m_name = Console.ReadLine();
            Console.Write("Enter RAM: ");
            string ram =Console.ReadLine();
            int i;
            bool success = int.TryParse(ram, out i);
            if (!success)
            {
                Console.WriteLine("Please enter integer value");
                Console.Write("Enter RAM: ");
                ram = Console.ReadLine();
                success = int.TryParse(ram, out i);
            }
            Console.Write("Enter ROM: ");
            string rom = Console.ReadLine();
            int j;
            bool r_success = int.TryParse(rom, out j);
            if (!r_success)
            {
                Console.WriteLine("Please enter integer value");
                Console.Write("Enter ROM: ");
                rom = Console.ReadLine();
                r_success = int.TryParse(rom, out j);
            }

            Console.Write("Enter color: ");
            string color = Console.ReadLine();
            Console.Write("Enter store: ");
            string store = Console.ReadLine();
            Console.Write("Enter Price: ");
            string price = Console.ReadLine();
            int k;
            bool p_success = int.TryParse(price, out k);
            if (!success)
            {
                Console.WriteLine("Please enter integer value");
                Console.Write("Enter Price: ");
                price = Console.ReadLine();
                p_success = int.TryParse(price, out k);
            }
            if (String.IsNullOrEmpty(c_name) || String.IsNullOrEmpty(m_name) || String.IsNullOrEmpty(color) || i == 0 || j == 0 || k == 0 || String.IsNullOrEmpty(store))
            {
                Console.WriteLine("All fields are required");
            }
            else 
            { 

            int id = LProduct.Count() + 1;
            //assigning values to the keys
            Product.kMumbai dproduct = new Product.kMumbai()
            {
                P_Id = id,
                C_Name = c_name,
                M_Name = m_name,
                Ram = i,
                Storage = j,
                Color = color,
                Store = store,
                Price = k,
                Store_Count = (c_name + "_" + m_name + "_" + i + "_" + j + "_" + color + "_" + store).ToUpper()
            };
            LProduct.Add(dproduct);
            var jsonString = JsonConvert.SerializeObject(LProduct, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"Product.json", jsonString);
            Console.WriteLine("Successfully Added");
        }

        }

    }
}
