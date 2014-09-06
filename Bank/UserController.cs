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

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public UserController(User user)
        {
            this.user = user;
        }

        public void makePayment(int receiverID, int amountOfMoney, BankController bankController)
        {

            if (isEnoughMoney(amountOfMoney))
            {
                bankController.makePayment(user.UserId, receiverID, amountOfMoney);
            }
            else
            {
                // Payment cannot be done

            }

        }

        private bool isEnoughMoney(int amountOfMoney)
        {

            return (user.Balance - amountOfMoney) > 0 ? true : false;

        }

    }
}
