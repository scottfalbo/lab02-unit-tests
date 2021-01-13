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
                        Console.WriteLine($"Your new balance is: {Deposit(GetAmount())}");
                        AnotherTransacton();
                        break;
                    case "3":
                        Console.WriteLine("How much would you like to withdraw?:");
                        Console.WriteLine($"Your new balance is: {Withdraw(GetAmount())}");
                        AnotherTransacton();
                        break;
                    case "4":
                        PowerDown();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid menu option.");
                        break;
                }
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
                PowerDown();
            }
            else
            {
                Console.WriteLine("Please enter a valid menu option.");
                AnotherTransacton();
            }
        }

        public static void PowerDown()
        {
            exit = true;
            Console.WriteLine("ATM Bot powering down, beep boop.");
            Console.WriteLine("Did you just say, \"beep boop\",  with your mouth?");
        }

        public static decimal GetAmount()
        {
            
            string userInput = Console.ReadLine();
            bool validator = ValidInputAmount(userInput);

            while (!validator)
            {
                Console.WriteLine($"Please enter a valid, positive amount,\nthat does not exceed your balance of {balance}");
                userInput = Console.ReadLine();
                validator = ValidInputAmount(userInput);
            }

            decimal input = Convert.ToDecimal(userInput);
            return input;
        }

        public static bool ValidInputAmount(string userinput)
        {
            bool checkDecimal = decimal.TryParse(userinput, out decimal amount);
            return checkDecimal;
        }

        // return current balance
        public static decimal ViewBalance()
        {
            return balance;
        }

        // withdraw from the balance
        public static decimal Withdraw(decimal amount)
        {
            balance = decimal.Subtract(balance, amount);
            return balance;
        }

        // deposit
        public static decimal Deposit(decimal amount)

        {
            balance = decimal.Add(balance, amount);
            return balance;
        }
    }
}
