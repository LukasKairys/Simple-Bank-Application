using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Bank
{
    public class BankController
    {
        private Bank bank;
        private DBController dbController;

        public Bank Bank
        {
            get { return bank; }
            set { bank = value; }
        }


        public BankController()
        {
            dbController = DBController.Instance;
            bank = dbController.getBank();

        }


        public bool makePayment(User sender, int receiverId, int amountOfMoney)
        {
            List<User> Users = dbController.getUsers();
            int affectedUsers = 0;

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Equals(sender))
                {
                    Users[i].Balance -= amountOfMoney;
                    affectedUsers++;
                }

                if (Users[i].UserId == receiverId)
                {
                    Users[i].Balance += amountOfMoney;
                    affectedUsers++;
                }

            }

            if (affectedUsers != 2)
            {
                return false;
            }

            dbController.saveUsers(Users);

            bank.TransactionsDone++;

            dbController.saveBank(bank);

            dbController.saveTransaction(new Transaction(sender.UserId, receiverId, amountOfMoney, DateTime.Now));

            return true;
        }

        public bool makeMoneyTransaction(User user, int amountOfMoney)
        {
            List<User> Users = dbController.getUsers();

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Equals(user))
                {
                    Users[i].Balance += amountOfMoney;
                }
            }

            dbController.saveUsers(Users);

            bank.TransactionsDone++;

            dbController.saveBank(bank);

            dbController.saveTransaction(new Transaction(user.UserId, null, -amountOfMoney, DateTime.Now));

            return true;
        }
    }
}
