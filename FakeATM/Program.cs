using System;

namespace FakeATM
{
    public class Program
    {
        public static decimal balance = 5000;
        public static bool exit = false;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Fake ATM\n");
            UserInterface();
        }
        public static void UserInterface()
        {
            Console.WriteLine("Make a selection from the menu:\n1. Check Balance \n2. Deposit \n3. Withdraw \n4. Exit");
            
            while (!exit)
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine($"Your current balance is: {ViewBalance()}");
                        break;
                    case "2":
                        Console.WriteLine("How much would you like to deposit?:");
                        Deposit(GetAmount());
                        break;
                    case "3":
                        Console.WriteLine("withdraw");
                        Withdraw(GetAmount());
                        break;
                    case "4":
                        Console.WriteLine("exit");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
                UserInterface();
            }
        }

        public static void AnotherTransacton()
        {
            Console.WriteLine("Would you like to make another transaction?\n1. yes\n2. no");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                UserInterface();
            }
            else if (userInput == "2")
            {
                exit = true;
                UserInterface();
            }
            else
            {
                Console.WriteLine("Please enter a valid menu option.");
                AnotherTransacton();
            }
        }

        public static decimal GetAmount()
        {
            string userInput = Console.ReadLine();
            decimal input = Convert.ToDecimal(userInput);
            return input;
        }
        // return current balance
        public static decimal ViewBalance()
        {
            return balance;
        }

        // withdraw from the balance
        public static decimal Withdraw(decimal amount)
        {
            return decimal.Subtract(balance, amount);
        }

        // deposit
        public static decimal Deposit(decimal amount)

        {
            return decimal.Add(balance, amount);
        }
    }
}
