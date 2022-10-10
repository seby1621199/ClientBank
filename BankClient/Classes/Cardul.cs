using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Buffers.Text;

namespace BankClient.Classes
{
    [BsonKnownTypes(typeof(Silver), typeof(Classic), typeof(Gold), typeof(Platinum))]
    public abstract class Cardul
    {
        public string Number { get; set; }
        public string CVV { get; set; }
        public string Expiration { get; set; }
        public double Tax { get; set; }
    }

    class Silver : Cardul
    {
        public Silver()
        {
            Random rnd = new Random();
            Number = rnd.Next(100000000, 999999999).ToString();
            CVV = rnd.Next(100, 999).ToString();
            Expiration = DateTime.Now.AddYears(5).ToString("MM/yy");
            Tax = 0.7;
        }
    }

    class Classic : Cardul
    {
        public Classic()
        {
            Random rnd = new Random();
            Number = rnd.Next(100000000, 999999999).ToString();
            CVV = rnd.Next(100, 999).ToString();
            Expiration = DateTime.Now.AddYears(5).ToString("MM/yy");
            Tax = 0.5;
        }
    }

    class Gold : Cardul
    {
        public Gold()
        {
            Random rnd = new Random();
            Number = rnd.Next(100000000, 999999999).ToString();
            CVV = rnd.Next(100, 999).ToString();
            Expiration = DateTime.Now.AddYears(5).ToString("MM/yy");
            Tax = 0.5;
        }
    }
    class Platinum : Cardul
    {
        public Platinum()
        {
            Random rnd = new Random();
            Number = rnd.Next(100000000, 999999999).ToString();
            CVV = rnd.Next(100, 999).ToString();
            Expiration = DateTime.Now.AddYears(5).ToString("MM/yy");
            Tax = 0.3;
        }
    }

}
