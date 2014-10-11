using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class LoginInterface
    {

        private UserController userController;
        private BankController bankController;

        static void Main(string[] args)
        {

            int userId;
            LoginInterface consoleInterface = new LoginInterface();

            Console.WriteLine("--Hello, please sign in by entering your Id--");
            Console.WriteLine("--Available userId's from 1 to 5--");
            string line = Console.ReadLine();

            if (int.TryParse(line, out userId))
            {
                bool isUserLoggedIn = consoleInterface.Login(userId);

                if (isUserLoggedIn)
                {
                    MainMenuInterface mainMenuInterface = new MainMenuInterface(consoleInterface.userController, consoleInterface.bankController);
                }
                else
                {
                    Console.WriteLine("Id doesn't exist");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("!ERROR, Int value is required!");
                Console.ReadLine();
            }


        }

        private bool Login(int Id)
        {
            DBController dbController = DBController.Instance;
            List<User> users = dbController.getUsers();

            
            User user = users.First(userFromList => userFromList.UserId == Id);
            if (user != null)
            {
                userController = new UserController(user);

                bankController = new BankController();

                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
