using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient
{
      class Globals
    {
        public static MongoDB.Driver.MongoClient m_Client;
        public static MongoDB.Driver.IMongoDatabase m_Database;
        public static MongoDB.Driver.IMongoCollection<User> m_Collection;
        public static User global_user;
        public static string  text = "nu s-a schimbat";
    }
}
