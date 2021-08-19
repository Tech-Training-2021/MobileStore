using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MobileStore
{
    class Program
    {
        public static void Main(string[] args)
        {
            Firstpg();

        }
        public static void Firstpg()
        {
            Console.WriteLine("Click 1: Sign up\nClick 2: Login\nClick 3: Exit");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Home.Signup();
                    break;

                case 2:
                    Console.WriteLine("\n<----- Login Page ----->\n");
                    Console.Write("Enter User Name: ");
                    string userName = Console.ReadLine();
                    Console.Write("Enter Password Name: ");
                    //string password = Console.ReadLine();
                    string password = null;

                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)    // this loop breaks when user presses enter
                            break;
                        password += key.KeyChar;   //KeyChar is a property that stores the character pressed from the Keyboard
                        Console.CursorVisible = false;  //hides the cursor while typing
                    }
                    Console.CursorVisible = true;
                    Home.Login(userName,password);
                    break;

                default:
                    Console.WriteLine("Please click either 1 or 2");
                    break;
            }
        }
    }
}
