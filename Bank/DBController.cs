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

        private string banksFileName = "D:\\GitRepo\\Banks.txt";
        private string usersFileName = "D:\\GitRepo\\Users.txt";

        public List<User> getUsers()
        {
            List<User> Users = new List<User>();

            try
            {
                StreamReader sr = new StreamReader(usersFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

                Users = (List<User>) serializer.Deserialize(sr);

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return Users;

        }

        public List<Bank> getBanks()
        {
            List<Bank> Banks = new List<Bank>();

            try
            {
                StreamReader sr = new StreamReader(banksFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Bank>));

                Banks = (List<Bank>)serializer.Deserialize(sr);

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return Banks;

        }

        public void saveUsers(List<User> Users)
        {
            try
            {
                StreamWriter sw = new StreamWriter(usersFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));

                serializer.Serialize(sw, Users);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Saving done.");
            }

        }

        private void saveBanks(List<Bank> Banks)
        {
            try
            {
                StreamWriter sw = new StreamWriter(banksFileName);

                XmlSerializer serializer = new XmlSerializer(typeof(List<Bank>));

                serializer.Serialize(sw, Banks);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Saving done.");
            }
        }

    }
}
