using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class MainMenuInterface
    {
        private UserController userController;
        private BankController bankController;

        public MainMenuInterface(UserController userController, BankController bankController)
        {
            this.bankController = bankController;
            this.userController = userController;
            DisplayMainMenu();
        }

        public void DisplayMainMenu()
        {
            int choice = 0;
            while (choice != 9)
            {
                Console.Clear();
                Console.WriteLine("------" + bankController.Bank.Name + " bank ------");
                Console.WriteLine("--Welcome, " + userController.User.Name + "--");
                Console.WriteLine("--Your balance is: " + userController.User.Balance + "--");
                Console.WriteLine("--Please select action: ");
                Console.WriteLine("1.Make a payment");
                Console.WriteLine("2.Withdraw money");
                Console.WriteLine("3.Deposit money");
                Console.WriteLine("4.Get transactions history");
                Console.WriteLine("5.Compare you balance with other user");
                Console.WriteLine("9.Close program");

                string line = Console.ReadLine();
                int.TryParse(line, out choice);

                switch (choice)
                {
                    case 1:
                        MakePaymentInterface();
                        break;
                    case 2:
                        WithdrawMoneyInterface();
                        break;
                    case 3:
                        DepositMoneyInterface();
                        break;
                    case 4:
                        GetTransactionsInterface();
                        break;
                    case 5:
                        GetCompareUsersInterface();
                        break;
                    case 9:
                        Console.WriteLine("Closing program");
                        break;
                    default:
                        Console.WriteLine("Enter valid number");
                        break;
                }
            }
        }

        public void MakePaymentInterface()
        {
            Console.Clear();

            Console.WriteLine("--Enter receiver Id:");
            string receiverLine = Console.ReadLine();
            int receiverId;

            Console.WriteLine("--Enter amount of money:");
            string moneyLine = Console.ReadLine();
            int amountOfMoney;

            if (int.TryParse(receiverLine, out receiverId) && int.TryParse(moneyLine, out amountOfMoney))
            {
                if (userController.makePayment(receiverId, amountOfMoney, bankController))
                {
                    userController.User.Balance -= amountOfMoney;
                    Console.WriteLine("--Payment done, enter 0 to go back--");
                }
                else
                {
                    Console.WriteLine("--Wrong receiverId or not enough money--");
                }

            }
            else
            {
                Console.WriteLine("--Value must be int--");
            }

            Console.Read();


        }

        public void WithdrawMoneyInterface()
        {
            Console.Clear();

            Console.WriteLine("--Enter amount of money:");
            string moneyLine = Console.ReadLine();
            int amountOfMoney;

            if (int.TryParse(moneyLine, out amountOfMoney))
            {
                if (userController.withdrawMoney(amountOfMoney, bankController))
                {
                    userController.User.Balance -= amountOfMoney;
                    Console.WriteLine("--Withdrawal done, enter 0 to go back--");
                }
                else
                {
                    Console.WriteLine("--Not enough money--");
                }

            }
            else
            {
                Console.WriteLine("--Value must be int--");
            }

            Console.Read();
        }

        public void DepositMoneyInterface()
        {
            Console.Clear();

            Console.WriteLine("--Enter amount of money:");
            string moneyLine = Console.ReadLine();
            int amountOfMoney;

            if (int.TryParse(moneyLine, out amountOfMoney))
            {
                if (userController.depositMoney(amountOfMoney, bankController))
                {
                    userController.User.Balance += amountOfMoney;
                    Console.WriteLine("--Deposit done, enter 0 to go back--");
                }
                else
                {
                    Console.WriteLine("--Cash is fake--");
                }

            }
            else
            {
                Console.WriteLine("--Value must be int--");
            }

            Console.Read();
        }

        public void GetTransactionsInterface()
        {
            Console.Clear();

            Console.WriteLine("--All userId" + userController.User.UserId + " transactions ordered by date--");

            List<Transaction> userTransactions = userController.getUserTransactions();

            foreach (var transaction in userTransactions)
            {
                Console.Write(transaction.Date.ToString() + ":");
                Console.Write(" user Id: " + transaction.UserId + ",");
                Console.Write(" receiver Id: " + transaction.ReceiverId + ",");
                Console.WriteLine(" amout of money: " + transaction.AmountOfMoney);
            }

            Console.WriteLine("--Transactions end, enter 0 to go back--");
            Console.Read();
        }


        public void GetCompareUsersInterface()
        {
            Console.Clear();

            Console.WriteLine("--Enter user Id:");
            string userLine = Console.ReadLine();
            int userId;

            if (int.TryParse(userLine, out userId))
            {
                int? result = userController.compareTwoUsers(userId);

                switch (result)
                {
                    case 1:
                        Console.WriteLine("You have less money, sad");
                        break;
                    case 0:
                        Console.WriteLine("You have the same amount of money, sad");
                        break;
                    case -1:
                        Console.WriteLine("You have more money, congratulations");
                        break;
                    default:
                        Console.WriteLine("User does not exists");
                        break;

                }
            }
            else
            {
                Console.WriteLine("--Value must be int--");
            }

            Console.Read();
        }

    }
}
