using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class User : IEquatable<User>, IComparable<User>
    {
        private int userId;
        private string name;
        private int balance;

        public int UserId { get; set; }

        public string Name { get; set; }

        public int Balance { get; set; }

        public bool Equals(User userToCompare)
        {
            if (userId == userToCompare.userId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public int CompareTo(User other)
        {
            if (Balance < other.Balance)
            {
                return 1;
            }
            else if(Balance == other.Balance)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
