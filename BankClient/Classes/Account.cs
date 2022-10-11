using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClient.Classes
{
    internal class Account
    {
        public string Curreny { get; set; }
        public uint Balance { get; set; }
        public string IBAN { get; set; }
        public Account(string currency, uint balance, string iban)
        {
            Curreny = currency;
            Balance = balance;
            IBAN = iban;
        }
    }
}
