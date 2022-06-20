using System;
using System.Windows;
using System.Windows.Input;
using MongoDB.Driver;

namespace BankClient
{
    /// <summary>
    /// Interaction logic for UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        public UserMenu()
        {
            InitializeComponent();
            user_menu_welcome_txt.Content = "Welcome " + Globals.global_user.First_Name + " " + Globals.global_user.Last_Name + "";
            balance_user_menu_txt.Content = "Balance: "+Globals.global_user.Balance + " $";
            iban_user_menu_txt.Content = "IBAN: "+Globals.global_user.IBAN;
        }

        private void Window_Mouse(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var filter = Builders<User>.Filter.Eq("Username", "stefan");
            User search = Globals.m_Collection.Find(filter).FirstOrDefault();
            User user2 = search;
            Globals.global_user.Transfer(user2, 50);


        }
    }
}
