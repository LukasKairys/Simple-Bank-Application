using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public BankController(string BankName)
        {
            this.dbController = DBController.Instance;
            List<Bank> Banks = dbController.getBanks();
            bank = Banks.FirstOrDefault(bankObj => bankObj.Name == BankName);

        }


        public void makePayment(int senderId, int receiverId, int amountOfMoney)
        {
            List<User> Users = dbController.getUsers();
            User sender = Users.FirstOrDefault(user => user.UserId == senderId);
            User receiver = Users.FirstOrDefault(user => user.UserId == receiverId);

            sender.Balance -= amountOfMoney;
            receiver.Balance += amountOfMoney;

            bank.TransactionsDone++;



        }

        public void withdrawMoney(int userId, int amountOfMoney)
        {
           // user.Balance -= amountOfMoney;
            this.bank.TransactionsDone++;
            //return user;
        }

        public void depositMoney(int userId, int amountOfMoney)
        {
            this.bank.TransactionsDone++;
        }
    }
}
