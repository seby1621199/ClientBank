using MongoDB.Driver;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BankClient
{
    class Globals
    {
        public static MongoDB.Driver.MongoClient m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
        public static MongoDB.Driver.IMongoDatabase m_Database = Globals.m_Client.GetDatabase("bank");
        public static MongoDB.Driver.IMongoCollection<User> m_Collection = Globals.m_Database.GetCollection<User>("users");
        public static User global_user;
        public static string text = "nu s-a schimbat";
        public int x = 0;
        public static async Task<double> Convert(string from, string to, double amount)
        {
            double result = 100;
            //int amount = 5;
            //string from = "EUR";
            //string to = "RON";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-converter18.p.rapidapi.com/api/v1/convert?from=" + from + "&to=" + to + "&amount=" + amount),
                Headers =
    {
        { "X-RapidAPI-Key", "4de4a2bedfmsh108fc0b822bf003p1205c3jsn0bc305269f2b" },
        { "X-RapidAPI-Host", "currency-converter18.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                dynamic tmp = Newtonsoft.Json.JsonConvert.DeserializeObject(body);
                result = (double)tmp.result.convertedAmount;
                //Console.WriteLine(body);
                //Console.WriteLine(result);
            }
            // int result_int= int.Parse(result);
            return result;
        }
    }
}
