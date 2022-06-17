using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using MongoDB.Driver;

namespace BankClient
{
    /// <summary>
    /// Interaction logic for RegisterFinal.xaml
    /// </summary>
    public partial class RegisterFinal : Window
    {
        private void DB()
        {
            Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
            Globals.m_Database = Globals.m_Client.GetDatabase("bank");
            Globals.m_Collection = Globals.m_Database.GetCollection<User>("bank");

        }

        public RegisterFinal()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void button_finish_register_Click(object sender, RoutedEventArgs e)
        {
            DB();
            Random rnd = new Random();
            Globals.global_user.First_Name = first_name_input.Text.ToUpper();
            Globals.global_user.Last_Name = last_name_input.Text.ToUpper();
            Globals.global_user.Country = country_input.Text.ToUpper();
            Globals.global_user.IBAN = Globals.global_user.Country[0].ToString() + Globals.global_user.Country[1].ToString() + rnd.Next(10, 99) + "BNK" + Globals.global_user.First_Name[0].ToString() + Globals.global_user.Last_Name[0].ToString() + rnd.Next(10000000, 99999999);

            var filter = Builders<User>.Filter.Eq("Username", Globals.global_user.Username);
            var update = Builders<User>.Update.Set("Country", Globals.global_user.Country).Set("First_Name", Globals.global_user.First_Name).Set("Last_Name", Globals.global_user.Last_Name).Set("IBAN", Globals.global_user.IBAN);
            Globals.m_Collection.UpdateOne(filter, update);

            // User search = Globals.m_Collection.Find(filter).FirstOrDefault();
            register_final_txt.Visibility = Visibility.Visible;
            Thread.Sleep(3000);
            this.Close();



        }
    }

}
