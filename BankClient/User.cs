using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

[Serializable]
    internal class User
    {
        [BsonId,BsonElement("_id"),BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }
    public string username { get; set; }
        public string password { get; set; }
        public int balance { get; set; }
    public User()
    {
        //Random rnd = new Random();
        //_id= rnd.Next(1, 100000000);

    }

}

