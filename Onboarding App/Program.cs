using System;
using System.Collections.Generic;
using System.Threading;

namespace Onboarding_App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello New User! Welcome!"); Thread.Sleep(1000);
            Console.WriteLine("Let's setup a new Account for you!"); Thread.Sleep(1000);
            //this is super gross but i can't find a better was to enter down.
            Console.WriteLine("\n\n\n\n");
            User.FirstName = AskQuestion("What is your first name? ");
            User.LastName = AskQuestion("What is your Last name? ");

            Console.Clear();
            
          
            Console.WriteLine("Hello " + User.FirstName + " " + User.LastName + "!"); Thread.Sleep(1000);
            Console.WriteLine("\n\n");
            User.IsOwner = IsOwner("Are you the Owner of this New Account? (y/n) ");

            Console.Clear();

            Console.WriteLine(IsOwnerResponse(User.IsOwner)); Thread.Sleep(2000);

            Console.Clear();

            User.PinNumber = SetPinNumber("Please enter a 4 digit pin number.");

            Console.Clear();


            //Console.WriteLine("Your Pin is now set!"); Thread.Sleep(1500);
            
            //Console.Clear();

            Console.WriteLine(AccountType("Which Account type would you like? ")); Thread.Sleep(3000);

            Console.Clear();

            Console.WriteLine(User.FirstName + " " + User.LastName + ", Thank you for setting up your Account!"); Thread.Sleep(2000);
            Console.WriteLine("\n\n\n\n");
            
            Console.WriteLine("Goodbye!"); Thread.Sleep(1000);

        }
        
        public static string AskQuestion(string question)
        {
            Console.Write(question);
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine();
                Console.WriteLine("Please enter your name.");
                return AskQuestion(question);
            }
            else
            {
                char[] a = input.ToCharArray();
                a[0] = char.ToUpper(a[0]);
                return new string(a);
                
            }

        }
        /// <summary>
        /// This filters through the only valid responses for the question.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static bool IsOwner(string question)
        {
            Console.Write(question);
            var input = Console.ReadLine();


            switch (input)
            {
                case "y":
                case "Y":
                case "yes":
                case "Yes":
                case "YES":
                    return true;
                case "n":
                case "N":
                case "no":
                case "No":
                case "NO":
                    return false;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Please answer yes or no");
                    return IsOwner(question);
            }


        }
        /// <summary>
        /// This compares users response to be either true or false.
        /// </summary>
        /// <param name="reponse">This will input the answer returned from IsOwner method.</param>
        /// <returns></returns>
        public static string IsOwnerResponse(bool reponse)
        {
            if (reponse == true)
            {
                return User.FirstName + " " + User.LastName + ", You are now the Account owner!";
            }
            else
            {
                return User.FirstName + " " + User.LastName + ", You are not the Account owner.";
            }
        }

        public static int SetPinNumber(string x)
        {
            Console.Write(x);
            var result = Console.ReadLine();
            if (result.Length == 4)
            {
                int pin;
                if (int.TryParse(result, out pin))
                {
                    Console.Clear();
                    Console.WriteLine(User.FirstName + " " + User.LastName + ", Your Pin number has been set to " + result + "."); Thread.Sleep(3000);
                    return pin;
                }
                Console.WriteLine();
                Console.WriteLine("Please choose a valid pin.");
                return SetPinNumber(x);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please choose a valid pin.");
                return SetPinNumber(x);
            }


        }

        public static string AccountType(string question)
        {
            Console.Write(question);
            var list = new List<string> {"1: Checking", "2: Savings", "3: Business"};
            
            
            foreach (var option in list)
            {
                Console.WriteLine();
                Console.WriteLine(option);
            }

            Console.Write("\nAnswer: ");

            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.Clear();
                return User.FirstName + " " + User.LastName + ", You selected Checking.";
            }
            else if(input == "2")
            {
                Console.Clear();
                return User.FirstName + " " + User.LastName + ", You selected Savings.";
            }
            else if (input == "3")
            {
                Console.Clear();
                return User.FirstName + " " + User.LastName + ", You selected Business.";
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Please choose a valid Account type.");
                return AccountType(question);
            }
        }
    }
}
