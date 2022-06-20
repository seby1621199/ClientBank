using System;
using BankClient;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

[Serializable]
internal class User
{
    [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
#pragma warning disable IDE1006 // Naming Styles
    public string _id { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    public string Username { get; set; }
    public string Password { get; set; }
    public uint Balance { get; set; }
    public string Country { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public string IBAN { get; set; }
    public User()
    {
    }

    public User(string name)
    {
        var filter = Builders<User>.Filter.Eq("Username", name);
        User user = Globals.m_Collection.Find(filter).FirstOrDefault();
        this.Username = user.Username;
        this.Password = user.Password;
        this.Balance = user.Balance;
        this.Country = user.Country;
        this.IBAN = user.IBAN;
        this.First_Name = user.First_Name;
        this.Last_Name = user.Last_Name;




    }
    public void Transfer(User user2, uint money_transfer)
    {
        /* user1 transfer money to user2 */
        this.Balance -= money_transfer;
        user2.Balance += money_transfer;
        Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
        Globals.m_Database = Globals.m_Client.GetDatabase("bank");
        Globals.m_Collection = Globals.m_Database.GetCollection<User>("bank");
        // User search = Globals.m_Collection.Find(filter).FirstOrDefault();


        /* IF BALANCE < MONEY TRANSFER RESOLVE ERRROR */
        if (this.Balance >= money_transfer)
        {
            this.Update();
            user2.Update();
        }

    }

    public void Load_DB()
    {
        Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
        Globals.m_Database = Globals.m_Client.GetDatabase("bank");
        Globals.m_Collection = Globals.m_Database.GetCollection<User>("bank");
    }

    public void Update()
    {

        var filter = Builders<User>.Filter.Eq("Username", this.Username);
        //var update = Builders<User>.Update.Set("Balance", this.Balance);
        var update = Builders<User>.Update.Set("Balance", Globals.global_user.Balance).Set("First_Name", Globals.global_user.First_Name).Set("Last_Name", Globals.global_user.Last_Name).Set("IBAN", Globals.global_user.IBAN).Set("Password", Globals.global_user.Password).Set("Country", Globals.global_user.Country);
        Globals.m_Collection.UpdateOne(filter, update);
    }


}

