using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Bson;
using MongoDB.Driver;




namespace BankClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        //MongoDB.Driver.MongoClient m_Client;
        //MongoDB.Driver.IMongoDatabase m_Database;
        //MongoDB.Driver.IMongoCollection<User> m_Collection;
        public void  DB()
        {
            Globals.m_Client = new MongoClient("mongodb+srv://bank:Drept1234!@cluster0.zwmtb.mongodb.net/Cluster0?retryWrites=true&w=majority");
            Globals.m_Database = Globals.m_Client.GetDatabase("bank");
            Globals.m_Collection = Globals.m_Database.GetCollection<User>("bank");
            //Globals.test = "ss";

        }



        private void button_Click(object sender, RoutedEventArgs e)
        {
            DB();
            User user = new User();
            user.username = user_input.Text;
            user.balance = 0;
            user.password= Encryption.Encrypt(password_input.Text); ;
            //user_input.Text = Globals.test;
            Globals.m_Collection.InsertOne(user);
            var password=Encryption.Encrypt(password_input.Text);

            // var t = Globals.m_Collection.Find(filter).FirstOrDefault();
            // var doc = bank.Find(filter).FirstOrDefault();
            var filter = Builders<User>.Filter.Eq("username", "saluuut");
            User user1 = Globals.m_Collection.Find(filter).FirstOrDefault();






        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }
    }
}
