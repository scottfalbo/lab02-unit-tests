using System;

namespace FakeATM
{
    public class Program
    {
        public static decimal balance = 5000;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Fake ATM\n");
            UserInterface();
        }
        public static void UserInterface()
        {
            Console.WriteLine("Make a selection from the menu:\n1. Check Balance \n2. Deposit \n3. Withdraw \n4. Exit");
            bool exit = false;
            while (!exit)
            {
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine($"balance: {ViewBalance()}");
                        break;
                    case "2":
                        Console.WriteLine("deposit");
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
                        Console.WriteLine("catch all");
                        break;
                }
                UserInterface();
            }
        }

        public static decimal GetAmount()
        {
            return 0;
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
