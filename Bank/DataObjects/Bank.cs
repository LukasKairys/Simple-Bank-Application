using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public struct Bank
    {
        private int bankId;
        private int transactionsDone;
        private string name;

        public int BankId
        {
            get { return bankId; }
            set { bankId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int TransactionsDone
        {
            get { return transactionsDone; }
            set { transactionsDone = value; }
        }
    }
}
