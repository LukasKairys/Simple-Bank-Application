using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class UserController
    {

        private User user;
        private DBController dbController;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public UserController(User user)
        {
            this.user = user;
            dbController = DBController.Instance;
        }

        public bool makePayment(int receiverId, int amountOfMoney, BankController bankController)
        {

            if (amountOfMoney > 0 && isEnoughMoney(amountOfMoney) && user.UserId != receiverId)
            {
                if (bankController.makePayment(user, receiverId, amountOfMoney))
                {
                    user.Balance -= amountOfMoney;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool withdrawMoney(int amountOfMoney, BankController bankController)
        {
            if (isEnoughMoney(amountOfMoney))
            {

                if (amountOfMoney > 0 && bankController.makeMoneyTransaction(user, -amountOfMoney))
                {
                    user.Balance -= amountOfMoney;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool depositMoney(int amountOfMoney, BankController bankController)
        {
            if (amountOfMoney > 0 && bankController.makeMoneyTransaction(user, amountOfMoney))
            {
                user.Balance += amountOfMoney;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Transaction> getUserTransactions()
        {
            List<Transaction> allTransactions = dbController.getTransactions();

            List<Transaction> userTransactions = allTransactions.Where(
                                                            transaction => 
                                                                (transaction.UserId == User.UserId)
                                                                || (transaction.ReceiverId == User.UserId))
                                                                .OrderBy(transaction => transaction.Date).ToList();
            return userTransactions;
        }

        public int? compareTwoUsers(int otherUserId)
        {
            List<User> Users = dbController.getUsers();

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].UserId == otherUserId)
                {
                    return User.CompareTo(Users[i]);
                }

            }

            return null;

        }

        private bool isEnoughMoney(int amountOfMoney)
        {
            return (user.Balance - amountOfMoney) > 0 ? true : false;
        }

    }
}
