using System;
using System.Collections.Generic;
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
    public List<Account> Accounts { get; set; } = new List<Account>();
    public User()
    {
    }

    public User(string name)
    {
        User user = Globals.m_Collection.Find(x => x.Username == name).FirstOrDefault();
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
        Globals.m_Collection.ReplaceOne(x => x.Username ==Username , this);
    }
    
    
    public int Deposit(uint money_deposit,string iban)
    {
        int nr = -1;
        for (int i = 0; i < Accounts.Count; i++)
        {
            if (Accounts[i].IBAN == iban)
            {
                Accounts[i].Balance += money_deposit;
                this.Update();
                nr = i;
            }
        }
        return nr;

        //this.Balance += money_deposit;
        // this.Update();
    }
    public int WithDraw(uint money_withdraw, string iban)
    {
        int nr = -1;
        for (int i = 0; i < Accounts.Count; i++)
        {
            if (Accounts[i].IBAN == iban)
            {
                Accounts[i].Balance -= money_withdraw;
                this.Update();
                nr = i;
            }
        }
        return nr;

       // this.Balance -= money_withdraw;
        //this.Update();
    }
    public Account Transfer(int account_number,string user2_iban, uint money_transfer)
    {
        //find account 2
        var filter = Builders<User>.Filter.ElemMatch(x => x.Accounts, x => x.IBAN == user2_iban);
        User user2 = Globals.m_Collection.Find(filter).FirstOrDefault();
        
        this.Accounts[account_number].Balance -= money_transfer;
        int nr = user2.GetAccountNumber(user2_iban);
        user2.Accounts[nr].Balance += money_transfer;
        //account2.Balance += money_transfer;
        this.Update();
        user2.Update();
        Globals.convert("EUR", "RON", 5);
        return user2.Accounts[nr];


    }

    public void Delete()
    {
        var filter = Builders<User>.Filter.Eq("Username", this.Username);
        Globals.m_Collection.DeleteOne(filter);
    }

    public void AddAccount(Account account)
    {
        this.Accounts.Add(account);
        this.Update();
    }

    //get account number by iban
    public int GetAccountNumber(string iban)
    {
        int nr = -1;
        for (int i = 0; i < Accounts.Count; i++)
        {
            if (Accounts[i].IBAN == iban)
            {
                nr = i;
            }
        }
        return nr;
    }

}

