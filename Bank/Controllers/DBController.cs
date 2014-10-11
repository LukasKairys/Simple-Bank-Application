using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Bank
{
    class DBController
    {

        private static DBController instance;

        private DBController() { }

        public static DBController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DBController();
                }
                return instance;
            }
        }

        private string banksFileName = "D:\\GitRepo\\Bank.txt";
        private string usersFileName = "D:\\GitRepo\\Users.txt";
        private string transactionsFileName = "D:\\GitRepo\\Transactions.txt";

        public List<User> getUsers()
        {
            List<User> Users = new List<User>();

            try
            {
                StreamReader sr = new StreamReader(usersFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

                Users = (List<User>) serializer.Deserialize(sr);

                for (int i = 0; i < Users.Count; i++)
                {
                    Users[i].Name = EncryptionHelper.Decrypt(Users[i].Name);
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return Users;

        }

        public List<Transaction> getTransactions()
        {
            List<Transaction> Transactions = new List<Transaction>();

            try
            {
                StreamReader sr = new StreamReader(transactionsFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Transaction>));

                Transactions = (List<Transaction>)serializer.Deserialize(sr);

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return Transactions;

        }

        public Bank getBank()
        {
            Bank bank = new Bank();

            try
            {
                StreamReader sr = new StreamReader(banksFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(Bank));

                bank = (Bank)serializer.Deserialize(sr);

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return bank;

        }

        public void saveUsers(List<User> Users)
        {
            try
            {
                StreamWriter sw = new StreamWriter(usersFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

                for (int i = 0; i < Users.Count; i++)
                {
                    Users[i].Name = EncryptionHelper.Encrypt(Users[i].Name);
                }

                serializer.Serialize(sw, Users);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public void saveTransaction(Transaction transaction)
        {
            List<Transaction> transactions = new List<Transaction>();

            transactions = getTransactions();

            transactions.Add(transaction);

            try
            {
                StreamWriter sw = new StreamWriter(transactionsFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Transaction>));

                serializer.Serialize(sw, transactions);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }

        public void saveBank(Bank bank)
        {
            try
            {
                StreamWriter sw = new StreamWriter(banksFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(Bank));

                serializer.Serialize(sw, bank);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

    }
}
