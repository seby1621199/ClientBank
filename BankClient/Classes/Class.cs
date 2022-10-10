using MongoDB.Driver;

namespace BankClient
{
     class Globals
    {
        public static MongoDB.Driver.MongoClient m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
        public static MongoDB.Driver.IMongoDatabase m_Database = Globals.m_Client.GetDatabase("bank");
        public static MongoDB.Driver.IMongoCollection<User> m_Collection = Globals.m_Database.GetCollection<User>("users");
        public static User global_user;
        public static string text = "nu s-a schimbat";
    }
}
