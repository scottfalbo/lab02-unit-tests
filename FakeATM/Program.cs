using System;

namespace FakeATM
{
    public class Program
    {
        // declaring global variables
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
            
            // Keep rewriting the menu as long as exit == false
            while (!exit)
            {
                string userInput = Console.ReadLine();
                // do something based on the users input
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

        // ---- Ask the user if they would like to make another transaction
        // ---- if not set the global exit == true to break while loop
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

        // ---- Exit the App via the menu or AnotherTransaction prompt
        public static void PowerDown()
        {
            exit = true;
            Console.WriteLine("ATM Bot powering down, beep boop.");
            Console.WriteLine("Did you just say, \"beep boop\",  with your mouth?");
        }

        // ---- Get, and validate the amount the user wants to deposit or withdraw.
        public static decimal GetAmount()
        {
            string userInput = Console.ReadLine();
            bool validator = ValidInputAmount(userInput);

            while (!validator)
            {
                Console.WriteLine($"Please enter a valid, positive, amount.");
                userInput = Console.ReadLine();
                validator = ValidInputAmount(userInput);
            }

            decimal input = Convert.ToDecimal(userInput);
            return input;
        }

        // ---- Validate that the user inputted amount is a convertable to a decimal and not negative.
        public static bool ValidInputAmount(string userinput)
        {
            bool checkDecimal = decimal.TryParse(userinput, out decimal amount);
            return (checkDecimal && amount > 0) ? true : false;
        }

        // ---- Return current balance, very exciting
        public static decimal ViewBalance()
        {
            return balance;
        }

        // ---- Withdraw, make sure the users requested amount is not greater than balance
        // ---- Return un altered balanace and re-prompt main menu if over draw is attempted
        public static decimal Withdraw(decimal amount)
        {
            decimal newBalance = decimal.Subtract(balance, amount);
            if (newBalance < 0)
            {
                Console.WriteLine("Insufficient funds, please select again from the menu.");
                return balance;
            }
            else
            {
                balance = newBalance;
                return balance;
            }
        }

        // ---- Deposit, add the inputted amount to the balance, return the new balance
        public static decimal Deposit(decimal amount)
        {
            balance = decimal.Add(balance, amount);
            return balance;
        }
    }
}
