using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    interface IBankOperations
    {
        
        User makePayment(User user1, User user2);

        User withdrawMoney(User user);

    }
}
