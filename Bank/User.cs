using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public struct User
    {
        private int userId;
        private string name;
        private int balance;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

    }
}
