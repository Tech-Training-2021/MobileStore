using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore
{
    class Book_Order
    {
        static List<Product.oMumbai> LOrder   = JsonConvert.DeserializeObject<List<Product.oMumbai>>(File.ReadAllText(@"Order.json"));
        static List<Product.kMumbai> LProduct = JsonConvert.DeserializeObject<List<Product.kMumbai>>(File.ReadAllText(@"Product.json"));
        static List<Product.oMumbai> LHistory = JsonConvert.DeserializeObject<List<Product.oMumbai>>(File.ReadAllText(@"History.json"));
        public static void Search_Product()
        {
            int sflag = 0;
            Console.Write("Enter Customer's Company Name: ");
            try
            {
                string c_name = Console.ReadLine();
                Console.WriteLine(LProduct);
                foreach (var o in LProduct)
                {
                    if (o.C_Name.ToString() == c_name)
                    {
                        Console.WriteLine($"Product Id : {o.P_Id}\t Company Name : {c_name}\t Mobile Name : {o.M_Name}\tRAM : {o.Ram}\tROM : {o.Storage}\tStore : {o.Store}\n");
                        sflag = 1;
                    }
                }
                if (sflag == 0)
                {
                    Console.WriteLine("No such product exist");
                }
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
        }
        public static void BuyStatus(string name)
        {
            string json = File.ReadAllText("Order.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            List<int> ids = new List<int>();
            List<string> mnames = new List<string>();
            for (int o = 0; o < LOrder.Count; o++)
            {
                Console.WriteLine(LOrder.Count);
                if (LOrder[o].Cust.ToString() == name && !(LOrder[o].Buy))
                {
                    Console.WriteLine(LOrder[o].Cust.ToString() + " " + LOrder[o].Buy);
                    
                    mnames.Add(LOrder[o].M_Name);
                    jsonObj[o]["Buy"]= true;
                    Console.WriteLine(LOrder[o].Cust.ToString() + " " + LOrder[o].Buy);


                }
            }

            


            Console.WriteLine(ids);

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("Order.json", output);


            var list1 = File.ReadAllText(@"Order.json");
            dynamic jsonObj12 = Newtonsoft.Json.JsonConvert.DeserializeObject(list1);

            for (var i= jsonObj12.Count-1;i >= 0;i--)
            {
                
                    Console.WriteLine(jsonObj12[i].P_Id+ "  "+ jsonObj12[i].Cust+" "+name);
                    if (jsonObj12[i].Cust == name)
                    {
                        Console.WriteLine("111111111111111111111");
                        Product.oMumbai dproducts = new Product.oMumbai()
                        {
                            P_Id = jsonObj12[i].P_Id,
                            C_Name = jsonObj12[i].C_Name,
                            M_Name = jsonObj12[i].M_Name,
                            Ram = jsonObj12[i].Ram,
                            Storage = jsonObj12[i].Storage,
                            Color = jsonObj12[i].Color,
                            Store = jsonObj12[i].Store,
                            Cust = name,
                            Buy = true
                        };

                        Console.WriteLine(jsonObj12[i]);
                        LHistory.Add(dproducts);

                        var jsonString = JsonConvert.SerializeObject(LHistory, Newtonsoft.Json.Formatting.Indented);
                        File.WriteAllText(@"History.json", jsonString);
                        jsonObj12[i].Remove();



                        var jsonfile3 = jsonObj12.ToString();
                        File.WriteAllText(@"Order.json", jsonfile3);


                    }
                
            }
            var list2 = File.ReadAllText(@"Product.json");
            dynamic jsonObj123 = Newtonsoft.Json.JsonConvert.DeserializeObject(list2);
            //            var jsonfile3 = jsonObj12.ToString();
            //          File.WriteAllText(@"Product.json", jsonfile3);

            for (var i = 0; i < LProduct.Count; i++)
            {
                for (var j = 0; j < LOrder.Count; j++)
                {
                    if (LProduct[i].P_Id == LOrder[i].P_Id)
                        ids.Add(LProduct[i].P_Id);
                }
            }

            for (var i = jsonObj123.Count - 1; i >= 0; i--)
            {
                for (var j = ids.Count - 1; j >= 0; j--) 
                {
                    if (jsonObj123[i].P_Id == ids[j])
                    {
                        jsonObj123[i].Remove();


                        var jsonfile4 = jsonObj123.ToString();
                        File.WriteAllText(@"Product.json", jsonfile4);
                    }
                } 
            }


        }
        public static void DeleteCart(string name)
        {
            //List<int> ids = new List<int>();
            Console.WriteLine("OK");
            var list = File.ReadAllText(@"Order.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(list);
            Console.WriteLine(jsonObj.Count);
            for (int i= jsonObj.Count-1; i>=0;i--)
            {
                Console.WriteLine("jsonObj.Count"+jsonObj.Count);
                if (jsonObj[i].Cust == name)
                {
                    Console.WriteLine(jsonObj[i]);
                    jsonObj[i].Remove();
                    
                }
            }

            var jsonfile2 = jsonObj.ToString();
            File.WriteAllText(@"Order.json", jsonfile2);
            


        }
        public static void checkout(string name)
        {
            double Total_Price = 0;
            foreach(var o in LOrder)
            {
                if (o.Cust.ToString() == name && !(o.Buy) )
                {
                    Total_Price += o.Price;
                    

                }
            }
            Console.WriteLine("Your Total Price is : " + Total_Price);
            Console.WriteLine("Press 1 if You Want To Buy All Products in Your Cart Else Press 2 to Delete Products From Your Cart  : ");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:


                    Console.WriteLine("Enter Payment Method Type : ");
                    Console.WriteLine("<1> Cash On Delivery \t <2>Credit or Debit \t <3>Net Banking \t <4>UPI : ");
                    int pay = int.Parse(Console.ReadLine());
                    switch (pay)
                    {
                        case 1:
                            Book_Order.BuyStatus(name);
                            Console.WriteLine("You Have Succesfully Bought Items :");
                            break;
                        case 2:
                            Book_Order.BuyStatus(name);
                            break;
                        case 3:
                            Book_Order.BuyStatus(name);
                            break;
                        case 4:
                            Book_Order.BuyStatus(name);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                     
                    Book_Order.DeleteCart(name);
                    break;
                default:
                    break;
            }
            
        }
        public static void Product_Book(string firstname)
        {
            string name = firstname;
            int sflag = 0;
            int id;
            
            
            Book_Order.Search_Product();
     
            Console.WriteLine("Enter the Product Id Which You Want to Buy From Above List : ");
            id = int.Parse(Console.ReadLine());
            foreach (var o in LProduct)
            {
                if (o.P_Id == id)

                {
                    Console.WriteLine(o.P_Id+" "+ id);
                    Product.oMumbai dproducts = new Product.oMumbai()
                    {
                        P_Id = id,
                        C_Name = o.C_Name,
                        M_Name = o.M_Name,
                        Ram = o.Ram,
                        Storage = o.Storage,
                        Color = o.Color,
                        Store = o.Store,
                        Cust = firstname,
                        Buy = false
                    };
                    LOrder.Add(dproducts);
                    var jsonString = JsonConvert.SerializeObject(LOrder, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(@"Order.json", jsonString);
                    Console.WriteLine("Successfully Added");
                    //Book_Order.ProdDelete();
                    Console.WriteLine("Press <1> To Buy Another Product Else Press <2> to Checkout");
                    int ch = int.Parse(Console.ReadLine());
                    while (ch != 3)
                    {
                        switch (ch)
                        {
                            case 1:
                                Book_Order.Product_Book(name);
                                break;
                            case 2:
                                Book_Order.checkout(name);
                                break;
                            default:
                                Console.WriteLine("Enter Either 1 or 2 : ");
                                ch = int.Parse(Console.ReadLine());
                                break;
                        }
                    }
                    sflag = 1;
                    break;
                }
            }
            
            if (sflag == 0)
            {
                Console.WriteLine("No such product exist");

            }
        }
    }
}
