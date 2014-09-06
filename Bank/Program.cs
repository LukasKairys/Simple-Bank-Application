using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {

            User lukas = new User();
            lukas.Balance = 100;
            lukas.Name = "lukas";
            lukas.UserId = 1;

            User tomas = new User();
            tomas.Balance = 100;
            tomas.Name = "tomas";
            tomas.UserId = 2;

            Bank swedbank = new Bank();
            swedbank.BankId = 2;
            swedbank.Name = "SwedBank";
            swedbank.TransactionsDone = 0;

            UserController userController = new UserController(lukas);

            List<User> Users = new List<User>();
            Users.Add(lukas);
            Users.Add(tomas);

            DBController dbController = DBController.Instance;
            dbController.saveUsers(Users);


            BankController bankController = new BankController("SwedBank");
            userController.makePayment(2, 50, bankController);



        }
    }
}
