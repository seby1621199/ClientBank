using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Classes
{ 
    /* Clasa e inclusa in clasa user*/
    internal class Card
    {
        [BsonElement("Number")]
        public string Number { get; set; }
        [BsonElement("CVV")]
        public string CVV { get; set; }
        [BsonElement("Expiration")]
        public string Expiration { get; set; }






    }
}
