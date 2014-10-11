using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public struct Transaction
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int? receiverId;

        public int? ReceiverId
        {
            get { return receiverId; }
            set { receiverId = value; }
        }
        private int amountOfMoney;

        public int AmountOfMoney
        {
            get { return amountOfMoney; }
            set { amountOfMoney = value; }
        }
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public Transaction(int userId, int? receiverId, int amountOfMoney, DateTime transactionDate)
        {
            this.userId = userId;
            this.receiverId = receiverId;
            this.amountOfMoney = amountOfMoney;
            this.date = transactionDate;
        }

    }
}
