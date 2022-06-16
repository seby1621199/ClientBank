using System;
using MongoDB.Bson.Serialization.Attributes;

[Serializable]
internal class User
{
    [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string _id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int Balance { get; set; }
    public string Country { get; set; }
    public string First_Name { get; set; }
    public string Last_Name { get; set; }
    public User()
    {
    }

}

