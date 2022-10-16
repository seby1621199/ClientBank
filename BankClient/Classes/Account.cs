namespace BankClient.Classes
{
    internal class Account
    {
        public string Currency { get; set; }
        public double Balance { get; set; }
        public string IBAN { get; set; }
        public Account(string currency, uint balance, string iban)
        {
            Currency = currency;
            Balance = balance;
            IBAN = iban;
        }
    }
}



