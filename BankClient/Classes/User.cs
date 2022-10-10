using System;
using BankClient;
using BankClient.Classes;
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
   // public Card Card { get; set; }
    public Cardul Cardul { get; set; }
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
        this.Cardul = user.Cardul;




    }
    //public void Transfer(User user2, uint money_transfer)
    //{


        
       
    //    this.Balance -= money_transfer;
    //    user2.Balance += money_transfer;
    //    Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
    //    Globals.m_Database = Globals.m_Client.GetDatabase("bank");
    //    Globals.m_Collection = Globals.m_Database.GetCollection<User>("bank");
    //    // User search = Globals.m_Collection.Find(filter).FirstOrDefault();


    //    /* IF BALANCE < MONEY TRANSFER RESOLVE ERRROR */
    //    if (this.Balance >= money_transfer)
    //    {
    //        this.Update();
    //        user2.Update();
    //    }
    //}

    public void Load_DB()
    {
        Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
        Globals.m_Database = Globals.m_Client.GetDatabase("bank");
        Globals.m_Collection = Globals.m_Database.GetCollection<User>("users");
    }

    public void Update()
    {

        var filter = Builders<User>.Filter.Eq("Username", this.Username);
        //var update = Builders<User>.Update.Set("Balance", this.Balance)
        var update = Builders<User>.Update.Set("Balance", this.Balance).Set("First_Name", this.First_Name).Set("Last_Name", this.Last_Name).Set("IBAN", this.IBAN).Set("Password", this.Password).Set("Country", this.Country);
        Globals.m_Collection.UpdateOne(filter, update);
    }

    public void Deposit(uint money_deposit)
    {
        this.Balance += money_deposit;
        this.Update();
    }
    public void WithDraw(uint money_withdraw)
    {
        this.Balance -= money_withdraw;
        this.Update();
    }
    public void Transfer(User user2, uint money_transfer)
    {
        this.Balance -= money_transfer;
        user2.Balance += money_transfer;
        this.Update();
        user2.Update();
    }

    public void Delete()
    {
        var filter = Builders<User>.Filter.Eq("Username", this.Username);
        Globals.m_Collection.DeleteOne(filter);
    }


}

